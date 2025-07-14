using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

public class NetworkConfigurator
{
    public static string GetAdapterNameById(string adapterId)
    {
        var adapter = NetworkInterface.GetAllNetworkInterfaces()
            .FirstOrDefault(ni => ni.Id == adapterId);

        return adapter?.Name ?? throw new Exception("Adapter name not found.");
    }

    public static string GetActiveAdapterName()
    {
        string localIP = GetLocalIPAddress();
        if (localIP == "-1") return null;

        var query = new SelectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = TRUE");
        using (var searcher = new ManagementObjectSearcher(query))
        {
            foreach (ManagementObject adapter in searcher.Get())
            {
                string[] ipAddresses = (string[])adapter["IPAddress"];
                if (ipAddresses != null && ipAddresses.Contains(localIP))
                {
                    return adapter["Description"]?.ToString();
                }
            }
        }

        return null;
    }
    public static string GetMainActiveAdapterId()
    {
        var adapter = NetworkInterface.GetAllNetworkInterfaces()
            .Where(ni =>
                ni.OperationalStatus == OperationalStatus.Up &&
                ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                ni.NetworkInterfaceType != NetworkInterfaceType.Tunnel &&    // exclude vps
                ni.GetIPProperties().GatewayAddresses.Any(g => g.Address.AddressFamily == AddressFamily.InterNetwork) && // has gateway
                ni.GetIPProperties().UnicastAddresses.Any(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork)
            )
            // Optional: Exclude adapters by description
            //.Where(ni => !ni.Description.ToLower().Contains("radmin"))
            .OrderByDescending(ni => ni.Speed)  // prefer fastest adapter
            .FirstOrDefault();

        return adapter?.Id ?? throw new Exception("No main active adapter found.");
    }
    public static string GetAdapterIdFromIP(string ipAddress)
    {
        var allAdapters = NetworkInterface.GetAllNetworkInterfaces();

        foreach (var adapter in allAdapters)
        {
            var ipProps = adapter.GetIPProperties();
            var unicastAddresses = ipProps.UnicastAddresses;

            foreach (var unicast in unicastAddresses)
            {
                if (unicast.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // IPv4 only
                {
                    if (unicast.Address.ToString() == ipAddress)
                    {
                        return adapter.Id; // Return the adapter ID
                    }
                }
            }
        }

        throw new Exception($"No network adapter found with IP {ipAddress}");
    }

    // Sets a static IPv4 address on the specified network adapter.
    public static bool SetStaticIP(string adapterId, string ip, string subnet, string gateway)
    {
        var query = new SelectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = TRUE");

        using (var searcher = new ManagementObjectSearcher(query))
        {
            foreach (ManagementObject adapter in searcher.Get())
            {
                // Match by UUID (SettingID == NetworkInterface.Id)
                string settingId = adapter["SettingID"]?.ToString();
                if (settingId != null && settingId.Equals(adapterId, StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        // Set IP and Subnet
                        var setIP = adapter.InvokeMethod("EnableStatic", new object[] { new string[] { ip }, new string[] { subnet } });
                        // Set Gateway
                        var setGateway = adapter.InvokeMethod("SetGateways", new object[] { new string[] { gateway }, new ushort[] { 1 } });

                        // Optional Set DNS
                        // var setDNS = adapter.InvokeMethod("SetDNSServerSearchOrder", new object[] { new string[] { "8.8.8.8", "8.8.4.4" } });

                        return (Convert.ToUInt32(setIP) == 0 || Convert.ToUInt32(setIP) == 1) &&
                               (Convert.ToUInt32(setGateway) == 0 || Convert.ToUInt32(setGateway) == 1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        return false; // Adapter with matching UUID not found
    }
    public static bool SetDynamicIP(string adapterId)
    {
        var query = new SelectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = TRUE");

        using (var searcher = new ManagementObjectSearcher(query))
        {
            foreach (ManagementObject adapter in searcher.Get())
            {
                string settingId = adapter["SettingID"]?.ToString();

                if (settingId != null && settingId.Equals(adapterId, StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        var result = adapter.InvokeMethod("EnableDHCP", null);
                        return Convert.ToUInt32(result) == 0 || Convert.ToUInt32(result) == 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error setting DHCP: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        return false; // Adapter not found
    }

    // Gets the local IP used for internet-bound traffic.
    public static string GetLocalIPAddress()
    {
        try
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                var endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint?.Address.ToString() ?? "-1";
            }
        }
        catch
        { return "-1"; }
    }
    //check if IP is static or dynamic true = dynamic, false = static
    public static bool? IsAdapterUsingDHCP(string adapterId)
    {
        var query = new SelectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = TRUE");

        using (var searcher = new ManagementObjectSearcher(query))
        {
            foreach (ManagementObject adapter in searcher.Get())
            {
                string settingId = adapter["SettingID"]?.ToString();
                if (settingId != null && settingId.Equals(adapterId, StringComparison.OrdinalIgnoreCase))
                {
                    return (bool?)adapter["DHCPEnabled"];
                }
            }
        }

        return null; // Adapter with given UUID not found
    }

    public static string GetSubnetMaskById(string adapterId)
    {
        var adapter = NetworkInterface.GetAllNetworkInterfaces()
            .FirstOrDefault(ni => ni.Id == adapterId);

        if (adapter == null)
            throw new Exception("Adapter not found.");

        var unicast = adapter.GetIPProperties().UnicastAddresses
            .FirstOrDefault(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork);

        if (unicast?.IPv4Mask == null)
            throw new Exception("Subnet mask not found.");

        return unicast.IPv4Mask.ToString();
    }
    public static string GetGatewayById(string adapterId)
    {
        var adapter = NetworkInterface.GetAllNetworkInterfaces()
            .FirstOrDefault(ni => ni.Id == adapterId);

        if (adapter == null)
            throw new Exception("Adapter not found.");

        var gateway = adapter.GetIPProperties().GatewayAddresses
            .FirstOrDefault(g => g.Address.AddressFamily == AddressFamily.InterNetwork);

        if (gateway == null)
            throw new Exception("Gateway not found.");

        return gateway.Address.ToString();
    }
    public static string GetSubnetPrefix(string ipAddress, string subnetMask)
    {
        var ipBytes = IPAddress.Parse(ipAddress).GetAddressBytes();
        var maskBytes = IPAddress.Parse(subnetMask).GetAddressBytes();

        byte[] networkBytes = new byte[4];
        for (int i = 0; i < 4; i++)
        {
            networkBytes[i] = (byte)(ipBytes[i] & maskBytes[i]);
        }

        //returns e.g. "192.168.1."
        return $"{networkBytes[0]}.{networkBytes[1]}.{networkBytes[2]}.";
    }

    //gets IPs of connected devices in the network
    public static List<string> DiscoverAllActiveDevices(string subnet)
    {
        List<string> ips = new List<string>();

        // First, ping everything to populate ARP table
        Parallel.For(1, 255, i =>
        {
            string ip = subnet + i;
            try
            {
                using (Ping ping = new Ping())
                {
                    ping.Send(ip, 250);
                }
            }
            catch { }
        });

        Thread.Sleep(100); // Give time for ARP to fill

        // Then, read ARP table
        var arpResult = GetArpTable(subnet);
        return arpResult;
    }

    public static List<string> GetArpTable(string subnet)
    {
        List<string> arpIPs = new List<string>();

        Process p = new Process();
        p.StartInfo.FileName = "arp";
        p.StartInfo.Arguments = "-a";
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.CreateNoWindow = true;
        p.Start();

        string output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();

        foreach (string line in output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
        {
            // Typical ARP output lines containing IP and MAC look like:
            //  192.168.1.10       00-11-22-33-44-55     dynamic
            if (line.Contains("dynamic") || line.Contains("static"))
            {
                string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2 && parts[0].StartsWith(subnet))
                {
                    arpIPs.Add(parts[0]);  // Add only IPs starting with the subnet prefix
                }
            }
        }

        return arpIPs;
    }



    public static bool IsConnectedToInternet()
    {
        try
        {
            using (var ping = new Ping())
            {
                var reply = ping.Send("8.8.8.8", 1000); // 1 second timeout
                return reply.Status == IPStatus.Success;
            }
        }
        catch
        {
            return false;
        }
    }
}
