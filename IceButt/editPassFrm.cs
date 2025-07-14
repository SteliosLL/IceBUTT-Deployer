using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace IceButt
{
    public partial class editPassFrm : Form
    {
        Form1 parentFrm;
        public editPassFrm(Form1 parent)
        {
            InitializeComponent();
            parentFrm = parent;

        }
        XmlDocument doc = new XmlDocument();
        //auth
        XmlNode sourcePasswordNode;
        XmlNode relayPasswordNode;
        XmlNode adminUserNode;
        XmlNode adminPasswordNode;
        //other
        XmlNode port;
        private void editPassFrm_Load(object sender, EventArgs e)
        {
            automaticSetIPStaticChckBox.Checked = Properties.Settings.Default.setsenderStaticIPautomatically;
            if (parentFrm.senderCfgBtn.FlatStyle == FlatStyle.System)
            {
                unsetBtn.Enabled = false;
            }
            try
            {
                var ini = new iniParser(parentFrm.buttrcPath);
                string str = ini.Get("iceButt", "mount");
                if (str != null)
                {
                    if (str.Trim() != "")
                    {
                        streamMountPointtxtBox.Text = ini.Get("iceButt", "mount");
                    }
                }
            }
            catch { }

            runOnStartCheckBox.Checked = File.Exists(parentFrm.iceButtStartupShortcut);
            if (unsetBtn.Enabled)//if unsetBtn is disabled it means the configuration has not been installed. In that case leave the streamDeskShortcutChckBox to the default value,
            {
                streamDeskShortcutChckBox.Checked = File.Exists(parentFrm.iceButtDesktopShortcut);
            }
            startMinimizedChckBOX.Checked = Properties.Settings.Default.startSenderMinimized;

            // Load the XML document
            try
            {
                doc.Load(parentFrm.icecastXmlPath);
            }
            catch { MessageBox.Show("Icecast.xml error.", "Sender configuration", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Close(); }

            //auth
            sourcePasswordNode = doc.SelectSingleNode("//authentication/source-password");
            relayPasswordNode = doc.SelectSingleNode("//authentication/relay-password");
            adminUserNode = doc.SelectSingleNode("//authentication/admin-user");
            adminPasswordNode = doc.SelectSingleNode("//authentication/admin-password");
            //other
            port = doc.SelectSingleNode("//listen-socket/port");
            // hostname = doc.SelectSingleNode("//hostname");

            if (sourcePasswordNode != null)
            {
                sourceTxtBox.Text = sourcePasswordNode.InnerText;
            }
            if (relayPasswordNode != null)
            {
                relayBox2.Text = relayPasswordNode.InnerText;
                if (sourcePasswordNode.InnerText == relayPasswordNode.InnerText) checkBox1.Checked = true;
                else checkBox1.Checked = false;
            }
            if (adminUserNode != null)
            {
                adminNameTxtBox.Text = adminUserNode.InnerText;
            }
            if (adminPasswordNode != null)
            {
                adminpassTxtBox.Text = adminPasswordNode.InnerText;
            }

            if (port != null)
            {
                portTxtBox.Text = port.InnerText;
            }

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!NetworkConfigurator.IsConnectedToInternet() && automaticSetIPStaticChckBox.Checked)
            {
                if (MessageBox.Show("NOTICE: It seems like this computer is not connected to a network. You need to connect your device to a network before saving, in order to properly set automatically your static IP. \n\nDO NOT continue unless you know what you are doing. Continue?", "Save settings", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            }
            //create batch file for starting icecast and BUTT
            try
            {
                string startMinimized = "";
                if (startMinimizedChckBOX.Checked)
                {
                    startMinimized = @"/MIN";
                }
                string buttPath = parentFrm.buttFolderPath;
                string icecastPath = parentFrm.icecastFolderPath;
                string batchFile = "cd  " + buttPath + Environment.NewLine + "start " + startMinimized + @" butt.exe " + Environment.NewLine + "cd " + '"' + icecastPath + '"' + Environment.NewLine + "start " + startMinimized + " icecast.bat";
                Directory.CreateDirectory(parentFrm.iceButtDocsPath);//create iceButt documents folder if it does not already exist
                System.IO.File.WriteAllText(parentFrm.iceButtBatFile, batchFile);
                if (streamDeskShortcutChckBox.Checked)//create desktop shortcut
                {
                    parentFrm.CreateShortcut(parentFrm.iceButtDesktopShortcut, parentFrm.iceButtBatFile);
                }
                else//or delete it (if it exists)
                {
                    if (System.IO.File.Exists(parentFrm.iceButtDesktopShortcut))
                    {
                        try
                        {
                            System.IO.File.Delete(parentFrm.iceButtDesktopShortcut);
                        }
                        catch (Exception a)
                        {
                            MessageBox.Show("Failed to delete desktop shortcut." + Environment.NewLine + "DETAILS: " + a.ToString(), "Create desktop shortcut for starting the stream", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                Properties.Settings.Default.startSenderMinimized = startMinimizedChckBOX.Checked;
                Properties.Settings.Default.Save();
                if (runOnStartCheckBox.Checked)//create startup shortcut
                {
                    parentFrm.CreateShortcut(parentFrm.iceButtStartupShortcut, parentFrm.iceButtBatFile);
                }
                else//or delete it (if it exists)
                {
                    if (System.IO.File.Exists(parentFrm.iceButtStartupShortcut))
                    {
                        try
                        {
                            System.IO.File.Delete(parentFrm.iceButtStartupShortcut);
                        }
                        catch (Exception a)
                        {
                            MessageBox.Show("Failed to delete startup file." + Environment.NewLine + "DETAILS: " + a.ToString(), "Start Icecast + BUTT on startup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create Icecast + BUTT startup file." + Environment.NewLine + "DETAILS: " + ex.ToString(), "Start Icecast + BUTT on startup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                sourcePasswordNode.InnerText = sourceTxtBox.Text.Trim();
                if (checkBox1.Checked)
                {
                    relayPasswordNode.InnerText = sourceTxtBox.Text.Trim();
                }
                else
                {
                    relayPasswordNode.InnerText = relayBox2.Text.Trim();
                }
                adminUserNode.InnerText = adminNameTxtBox.Text.Trim();
                adminPasswordNode.InnerText = adminpassTxtBox.Text.Trim();
                port.InnerText = portTxtBox.Text.Trim();
                doc.Save(parentFrm.icecastXmlPath);
            }
            catch (Exception a) { MessageBox.Show("There is a problem with icecast.xml. Failed to save changes." + Environment.NewLine + "DETAILS: " + a.ToString(), "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (!File.Exists(parentFrm.buttrcPath))//start butt to create the buttrc ini file, if it does not exist, so that we can later modify it
            {
                Process p = new Process();
                p.StartInfo.WorkingDirectory = parentFrm.buttFolderPath;
                p.StartInfo.FileName = parentFrm.buttFolderPath + @"\butt.exe";
                p.Start();
                int i2 = 0;
                while (p.MainWindowHandle == IntPtr.Zero && i2 < 500)//check if BUTT has fully started by waiting for 5 seconds at most
                {
                    Thread.Sleep(10);
                    i2++;
                }
                Thread.Sleep(500);
                if (p != null && !p.HasExited)
                {
                    // Send close message to the main window
                    bool closeSent = p.CloseMainWindow();
                    if (closeSent)
                    {
                        int i = 0;
                        while (!p.HasExited && i < 500) { Thread.Sleep(10); i++; }//wait for 5 seconds at most for BUTT to close
                        if (!p.HasExited)
                        {
                            p.Kill();
                            try
                            {
                                File.Delete(parentFrm.buttrcPath);//delete possibly malformed ini file
                            }
                            catch { }
                            MessageBox.Show("Something went wrong when trying to start BUTT to generate the configuration file." + Environment.NewLine + "DETAILS:  CANNOT CLOSE BUTT", "Save configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch { }

                        try
                        {
                            File.Delete(parentFrm.buttrcPath);//delete possibly malformed ini file
                        }
                        catch { }
                        MessageBox.Show("Something went wrong when trying to start BUTT to generate the configuration file." + Environment.NewLine, "Save configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            var ini = new iniParser(parentFrm.buttrcPath);
            //Modify BUTT ini file
            //main settings
            ini.Set("main", "check_for_update", "0");
            ini.Set("main", "connect_at_startup", "1");
            ini.Set("main", "force_reconnecting", "1");
            ini.Set("main", "server", "iceButt");//set iceButt as main server
            ini.Set("main", "srv_ent", "iceButt");
            string srvNum = ini.Get("main", "num_of_srv");
            int num = int.Parse(srvNum);
            if (!ini.HasSection("iceButt"))//check if iceButt already exists
            {
                num++;
            }
            ini.Set("main", "num_of_srv", num.ToString());
            //create iceButt stream
            ini.Set("iceButt", "address", "127.0.0.1");
            ini.Set("iceButt", "port", portTxtBox.Text.Trim());
            ini.Set("iceButt", "password", sourceTxtBox.Text.Trim());
            ini.Set("iceButt", "type", "1");//Icecast type
            ini.Set("iceButt", "tls", "0");
            ini.Set("iceButt", "custom_listener_url", "");
            ini.Set("iceButt", "custom_listener_mount", "");
            ini.Set("iceButt", "cert_hash", "");
            ini.Set("iceButt", "mount", streamMountPointtxtBox.Text.Trim());
            ini.Set("iceButt", "usr", "source");
            ini.Set("iceButt", "protocol", "0");
            // string bitrate = ini.Get("audio", "bitrate");

            ini.Save();
            Properties.Settings.Default.Save();
            if (parentFrm.senderCfgBtn.FlatStyle == FlatStyle.System && streamDeskShortcutChckBox.Checked)//inform the user about the desktop shortcut for starting the stream
            {
                MessageBox.Show("This will create a shortcut on your Desktop called \"iceButtStart\" which you can use to start streaming(sending) the audio.", "Desktop shortcut for starting the stream", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            //set static IP and then save in a thread
            parentFrm.StartThread(() =>
            {
                if (parentFrm.MainLocalIP == "" && automaticSetIPStaticChckBox.Checked)
                {
                    parentFrm.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("Cannot find IP address of your computer's main adapter. Please set the IP to static manually. You can find countless guides online", "Automatically set IP as static error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
                else//SET STATIC IP
                {
                    var isDone = new BoolWrapper { Value = false };
                    try
                    {
                        string adapterID = NetworkConfigurator.GetAdapterIdFromIP(parentFrm.MainLocalIP);
                        if (automaticSetIPStaticChckBox.Checked && NetworkConfigurator.IsAdapterUsingDHCP(adapterID) == true)
                        {
                            pleaseWaitFrm frm = new pleaseWaitFrm(isDone, parentFrm, "Setting static IP address, please wait");
                            BeginInvoke((MethodInvoker)delegate ()//run the wait Form on the UI thread. so that it freezes other forms when it shows
                            {
                                frm.ShowDialog();
                            });
                            string gateway = NetworkConfigurator.GetGatewayById(adapterID);
                            string subnet = NetworkConfigurator.GetSubnetMaskById(adapterID);
                            List<string> connectedIPs = NetworkConfigurator.DiscoverAllActiveDevices(NetworkConfigurator.GetSubnetPrefix(gateway, subnet));
                            List<int> nums = new List<int>();
                            foreach (string ip in connectedIPs)
                            {
                                int number = int.Parse(ip.Substring(ip.LastIndexOf(".") + 1));
                                nums.Add(number);
                            }
                            int randomNum(List<int> exclude, Tuple<int, int> range)
                            {
                                var _exclude = new HashSet<int>(exclude);
                                var fullRange = Enumerable.Range(range.Item1, range.Item2 - range.Item1 + 1)
                                                           .Where(i => !_exclude.Contains(i))
                                                           .ToList();

                                if (fullRange.Count == 0)
                                    throw new InvalidOperationException("No available numbers in the specified range.");

                                var preferredRange = fullRange.Where(i => i >= 26 && i <= 100).ToList();
                                var rand = new Random();

                                // 70% chance to pick from preferred range, 30% from the rest
                                bool pickPreferred = preferredRange.Count > 0 && rand.NextDouble() < 0.7;

                                var finalPool = pickPreferred ? preferredRange : fullRange;
                                return finalPool[rand.Next(finalPool.Count)];
                            }
                            int randnum;
                            try
                            {
                                randnum = randomNum(nums, Tuple.Create(26, 254));
                            }
                            catch (InvalidOperationException)
                            {
                                parentFrm.Invoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show("Failed to find a free IP address. Please set the static IP manually", "Failed to set static IP address automatically", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                });
                                goto continuee;//go to finsih
                            }
                            string staticIP = NetworkConfigurator.GetSubnetPrefix(gateway, subnet);
                            staticIP = staticIP + randnum;
                            NetworkConfigurator.SetStaticIP(adapterID, staticIP, subnet, gateway);
                        }
                        Properties.Settings.Default.setsenderStaticIPautomatically = automaticSetIPStaticChckBox.Checked;
                        Properties.Settings.Default.Save();
                        isDone.Value = true;
                    }
                    catch
                    {
                        isDone.Value = true;
                        parentFrm.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("Failed to set a static IP address. Restart your computer and try again later, or set the static IP manually. It is CRUCIAL that you complete this step one way or another", "Save settings error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                        return;
                    }
                }
            continuee:
                BeginInvoke((MethodInvoker)delegate ()
                {
                    MessageBox.Show("Done!", "Save changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    parentFrm.refreshBtn.PerformClick();
                });
            });

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            relayBox2.Enabled = !checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", parentFrm.icecastXmlPath);
        }

        private void startMinimizedChckBOX_CheckedChanged(object sender, EventArgs e)
        {

        }
        public int unsetSender(bool showMsg = true)
        {
            int result = 0;
            string errorStr = "";
            if (showMsg)
            {
                if (MessageBox.Show("This will unset this computer from working as the sender and you will be able to use it like normal. For example any shortcuts on your desktop for starting the stream will be removed and if you've set the stream to start on startup, it won't start any more. Continue?", "Unset computer configuration", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return result;
                }
            }
            try
            {
                if (File.Exists(parentFrm.iceButtStartupShortcut))//delete startup file
                {
                    File.Delete(parentFrm.iceButtStartupShortcut);
                }
                if (File.Exists(parentFrm.iceButtDesktopShortcut))//delete desktop shortcut
                {
                    File.Delete(parentFrm.iceButtDesktopShortcut);
                }
                if (File.Exists(parentFrm.iceButtBatFile))
                {
                    File.Delete(parentFrm.iceButtBatFile);
                }
                try//don't care if it fails to delete
                {
                    File.Delete(parentFrm.buttrcPath);
                }
                catch { }
                result = 1;
                if (showMsg)
                {
                    MessageBox.Show("Done!", "Unset computer configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                result = -1;
                errorStr += errorStr + "DETAILS: Failed to delete shortcuts and other files";
            }
            Properties.Settings.Default.setsenderStaticIPautomatically = true; //reset to default setting
            Properties.Settings.Default.Save();
            try
            {
                string adapterID = NetworkConfigurator.GetAdapterIdFromIP(parentFrm.MainLocalIP);
                //set IP back to dynamic
                NetworkConfigurator.SetDynamicIP(adapterID);
            }
            catch
            {
                result = -1;
                errorStr += errorStr + "DETAILS: Failed to set IP back to dynamic. Please do it manually or try again later";
            }
            if (errorStr != "")
            {
                MessageBox.Show("Failed to fully unset the configuration!\n" + errorStr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            parentFrm.refreshBtn.PerformClick();
            this.Close();
            return result;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            unsetSender();
        }

        private void portTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            textboxUtils.checkForNumber(portTxtBox, this, e);
        }

        private void refreshAudBtn_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start(parentFrm.buttFolderPath + @"\butt.exe");
            }
            catch
            {
                MessageBox.Show("Failed to open butt", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            senderHelpFrm frm = new senderHelpFrm();
            frm.ShowDialog();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void automaticSetIPStaticChckBox_Click(object sender, EventArgs e)
        {
            if (!automaticSetIPStaticChckBox.Checked)
            {
                if (MessageBox.Show("DO NOT CONTINUE IF YOU DO NOT KNOW WHAT YOU'RE DOING. \n\nGiving your computer a static local IP address is crucial for the setup to work. Uncheck this box ONLY if you want to set the static IP manually. Continue?", "Do not automatically set static IP address", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    automaticSetIPStaticChckBox.Checked = true;
                }
            }
        }
    }
}
