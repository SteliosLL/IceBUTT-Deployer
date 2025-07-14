using System;
using System.Management;

namespace IceButt
{
    public class findDriver
    {
        public static bool driverExistsByName(string driverName)
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");
            foreach (var device in searcher.Get())
            {
                Console.WriteLine(device["Name"]?.ToString());
                string name = device["Name"]?.ToString() ?? "";
                if (name.IndexOf(driverName , StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
