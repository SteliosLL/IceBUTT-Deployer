using IWshRuntimeLibrary;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace IceButt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //general
        public string buttFolderPath;
        public string iceButtDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\IceButt";
        //sender 
        public string iceButtStartupShortcut = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\iceButtStart.lnk";
        public string iceButtDesktopShortcut = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\iceButtStart.lnk";
        public string icecastFolderPath;
        public string icecastXmlPath;
        public string VBCablePath;
        public string buttrcPath;
        public string iceButtBatFile;
        //reciever 
        public string playStreamBatPath;
        public string playStreamDesktopShortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Play IceButt stream.lnk";
        public string playStreamStartupShortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\iceButtPlayStream.lnk";
        public string playListPath;
        //system 
        public string installedSoftwarePath;
        public string rootDrive = Path.GetPathRoot(Environment.SystemDirectory); // result is C:\ for example
        public string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public string ProgramFilesx86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }
        public string programFiles = Environment.ExpandEnvironmentVariables("%ProgramW6432%");


        public string MainLocalIP = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            ipLbl.Tag = false;
            Directory.CreateDirectory(softwarePath);
            installedSoftwarePath = rootDrive + "IceButt";
            icecastFolderPath = ProgramFilesx86() + @"\Icecast";
            icecastXmlPath = icecastFolderPath + @"\icecast.xml";
            buttFolderPath = installedSoftwarePath + @"\BUTT\" + Properties.Settings.Default.buttFolderName;
            VBCablePath = programFiles + @"\VB\CABLE";

            buttrcPath = appdata + @"\buttrc";
            iceButtBatFile = iceButtDocsPath + @"\iceButtStart.bat";

            playStreamBatPath = iceButtDocsPath + @"\playStream.bat";
            playListPath = iceButtDocsPath + @"\playlist.xspf";

            refreshBtn.PerformClick();
        }
        public void CreateShortcut(string shortcutPath, string targetPath)
        {
            var shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
            shortcut.TargetPath = targetPath;
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
            //shortcut.WindowStyle = 1; // Normal window
            shortcut.Save();
        }
        public void showMenuStripAtBtn(ContextMenuStrip menuStrip, Button btn)
        {
            menuStrip.Show(btn, new Point(btn.Width - btn.Width, btn.Height));
        }
        bool senderSet = true;
        private void checkSender()
        {
            senderSet = true;
            if (System.IO.File.Exists(ProgramFilesx86() + @"\Icecast\icecast.bat"))
            {
                iceCastBtn.FlatStyle = FlatStyle.Standard;
                iceCastBtn.Text = "Installed";
                remIceCastBtn.Visible = true;
            }
            else
            {
                iceCastBtn.FlatStyle = FlatStyle.System;
                iceCastBtn.Text = "Install";
                remIceCastBtn.Visible = false;
                senderSet = false;
            }
            if (Directory.Exists(buttFolderPath))
            {
                buttBtn.FlatStyle = FlatStyle.Standard;
                buttBtn.Text = "Installed";
                remButtBtn.Visible = true;
            }
            else
            {
                buttBtn.FlatStyle = FlatStyle.System;
                buttBtn.Text = "Install";
                remButtBtn.Visible = false;
                senderSet = false;
            }
            if (findDriver.driverExistsByName("VB-Audio Virtual Cable"))
            {
                vbBtn.FlatStyle = FlatStyle.Standard;
                vbBtn.Text = "Installed";
                remVbBtn.Visible = true;
            }
            else
            {
                vbBtn.FlatStyle = FlatStyle.System;
                vbBtn.Text = "Install";
                remVbBtn.Visible = false;
                //senderSet = false; No need since VB cable is optional
            }
            if (senderSet) senderCfgBtn.Enabled = true;
            else senderCfgBtn.Enabled = false;  //ONLY enable senderCfgBtn if all the previous programs are installed
            if (System.IO.File.Exists(appdata + @"\buttrc") && System.IO.File.Exists(iceButtDocsPath + @"\iceButtStart.bat")) //config check
            {
                senderCfgBtn.FlatStyle = FlatStyle.Standard;
                senderCfgBtn.Width = 75;
                modifySenderConfBtn.Visible = true;
                senderCfgBtn.Text = "Installed";

            }
            else
            {
                senderCfgBtn.FlatStyle = FlatStyle.System;
                senderCfgBtn.Text = "Install";
                senderCfgBtn.Width = 99;
                modifySenderConfBtn.Visible = false;
                senderSet = false;
            }
            if (senderSet && (bool)ipLbl.Tag)
            {
                setStatusSenderLbl.Text = "ALL SET";
                setStatusSenderLbl.BackColor = Color.LimeGreen;
                IPstaticNotifLbl.ForeColor = Color.Green;
                senderGrpBox.Enabled = true;
            }
            else if (senderSet && !(bool)ipLbl.Tag)
            {
                ipMsgColorFlicker();
                setStatusSenderLbl.Text = "ALMOST SET";
                setStatusSenderLbl.BackColor = Color.Orange;
                senderGrpBox.Enabled = true;
            }
            else
            {
                setStatusSenderLbl.Text = "NOT SET";
                setStatusSenderLbl.BackColor = Color.Red;
                IPstaticNotifLbl.ForeColor = SystemColors.ControlText;
                senderGrpBox.Enabled = false;
            }
        }
        bool recieverSet = true;
        public string vlcPath;
        private void checkReceiver()
        {
            recieverSet = true;
            bool dir32 = System.IO.File.Exists(ProgramFilesx86() + @"\VideoLAN\VLC\vlc.exe");
            bool dir64 = System.IO.File.Exists(programFiles + @"\VideoLAN\VLC\vlc.exe");
            if (dir32 || dir64)
            {
                vlcBtn.FlatStyle = FlatStyle.Standard;
                vlcBtn.Text = "Installed";
                remVlcBtn.Visible = true;
                if (dir32)
                {
                    vlcPath = ProgramFilesx86() + @"\VideoLAN\VLC";
                }
                if (dir64) //put 64 last so that if both exist, 64 is preferred
                {
                    vlcPath = programFiles + @"\VideoLAN\VLC";
                }
            }
            else
            {
                vlcBtn.FlatStyle = FlatStyle.System;
                vlcBtn.Text = "Install";
                remVlcBtn.Visible = false;
                senderSet = false;
            }
            if (recieverSet) recieverCfgBtn.Enabled = true;
            else recieverCfgBtn.Enabled = false;
            if (System.IO.File.Exists(iceButtDocsPath + @"\playStream.bat") && System.IO.File.Exists(iceButtDocsPath + @"\playlist.xspf"))//config check
            {
                recieverCfgBtn.FlatStyle = FlatStyle.Standard;
                recieverCfgBtn.Text = "Installed";
                recieverCfgBtn.Width = 75;
                modifyRecieverConfBtn.Visible = true;
            }
            else
            {
                recieverCfgBtn.FlatStyle = FlatStyle.System;
                recieverCfgBtn.Text = "Install";
                recieverCfgBtn.Width = 99;
                modifyRecieverConfBtn.Visible = false;
                recieverSet = false;
            }
            if (recieverSet)
            {
                setStatusRecieverLbl.Text = "ALL SET";
                setStatusRecieverLbl.BackColor = Color.LimeGreen;
                recieverGrpBox.Enabled = true;
            }
            else
            {
                setStatusRecieverLbl.Text = "NOT SET";
                setStatusRecieverLbl.BackColor = Color.Red;
                recieverGrpBox.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartThread(() =>
            {
                setIPLbl();
                BeginInvoke((MethodInvoker)delegate ()
                {
                    checkSender();
                    checkReceiver();
                });
            });


        }
        bool secondTry = false;
        public void setIPLbl()
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                refreshBtn.Enabled = false;
                panel1.Enabled = false;
                refreshingLbl.Visible = true;
            });
            Thread.Sleep(4000);// wait for the IP to settle
            string ip = NetworkConfigurator.GetLocalIPAddress();
            bool isConnected = NetworkConfigurator.IsConnectedToInternet();
            if (ip == "-1" || !isConnected)
            {
                BeginInvoke((MethodInvoker)delegate ()
                {
                    ipLbl.Text = "Not found";
                    MainLocalIP = "";
                });
            }
            else
            {
                BeginInvoke((MethodInvoker)delegate ()
                {
                    ipLbl.Text = ip;
                });
                try
                {
                    string id = NetworkConfigurator.GetAdapterIdFromIP(ip);
                    bool? isDynamic = NetworkConfigurator.IsAdapterUsingDHCP(id);
                    if (isDynamic == true)
                    {
                        BeginInvoke((MethodInvoker)delegate ()
                        {
                            ipLbl.Text = ipLbl.Text + "(Dynamic)";
                            ipLbl.Tag = false;
                        });
                    }
                    else if (isDynamic == false)
                    {
                        BeginInvoke((MethodInvoker)delegate ()
                        {
                            ipLbl.Text = ipLbl.Text + "(Static)";
                            ipLbl.Tag = true;
                        });
                    }
                    MainLocalIP = ip;
                }
                catch
                {
                    if (!secondTry)
                    {
                        setIPLbl();
                    }
                    else
                    {
                        secondTry = false;
                        BeginInvoke((MethodInvoker)delegate ()
                        {
                            ipLbl.Text = "Not found";
                            MainLocalIP = "";
                        });
                    }
                }
            }
            BeginInvoke((MethodInvoker)delegate ()
            {
                refreshingLbl.Visible = false;
                refreshBtn.Enabled = true;
                panel1.Enabled = true;
            });
        }
        bool flickerRunnin = false;
        public void ipMsgColorFlicker()
        {
            if (flickerRunnin == true) return;
            IPstaticNotifLbl.ForeColor = SystemColors.ControlText;
            StartThread(() =>
            {
                while (!(bool)ipLbl.Tag && senderCfgBtn.FlatStyle == FlatStyle.Standard)
                {
                    flickerRunnin = true;
                    BeginInvoke((MethodInvoker)delegate ()
                    {
                        IPstaticNotifLbl.BackColor = Color.Red;
                        // modifySenderConfBtn.FlatStyle = FlatStyle.Flat;
                        //modifySenderConfBtn.BackColor = Color.Red;

                    });
                    Thread.Sleep(600);
                    BeginInvoke((MethodInvoker)delegate ()
                    {
                        IPstaticNotifLbl.BackColor = SystemColors.Control;
                        //  modifySenderConfBtn.FlatStyle = FlatStyle.Standard;
                        //  modifySenderConfBtn.BackColor = SystemColors.ControlLight;
                    });
                    Thread.Sleep(600);
                }
                flickerRunnin = false;
            });
        }
        private void senderCfgBtn_Click(object sender, EventArgs e)
        {
            if (recieverCfgBtn.FlatStyle == FlatStyle.Standard && senderCfgBtn.FlatStyle == FlatStyle.System)//means this PC is already set as a sender
            {
                if (MessageBox.Show("This computer has already been set as a reciever. Setting it as a sender too might not work as expected. Are you sure that you want to set it as a sender?", "Set computer configuration as sender", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
            }
            editPassFrm editpassForm = new editPassFrm(this);
            editpassForm.ShowDialog();
        }
        private void recieverCfgBtn_Click(object sender, EventArgs e)
        {
            if (senderCfgBtn.FlatStyle == FlatStyle.Standard && recieverCfgBtn.FlatStyle == FlatStyle.System)//means this PC is already set as a sender
            {
                if (MessageBox.Show("This computer has already been set as a sender. Setting it as a reciever too might not work as expected. Are you sure that you want to set it as a reciever?", "Set computer configuration as reciever", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
            }
            recieverInstallConfg recieverConfFrm = new recieverInstallConfg(this);
            recieverConfFrm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode port;
            try
            {
                doc.Load(icecastXmlPath);
            }
            catch { MessageBox.Show("Icecast.xml error.", "Sender configuration", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Close(); }
            port = doc.SelectSingleNode("//listen-socket/port");
            Process.Start("http://localhost:" + port.InnerText.Trim());
        }
        string softwarePath = Application.StartupPath + @"\icebutt_software";
        public bool checkifSoftwareExists(string filename)
        {
            if (System.IO.File.Exists(softwarePath + "\\" + filename))
            {
                return true;
            }
            else
            {
                MessageBox.Show(filename + " not found. Please put the required files inside the 'icebutt_software' folder and try again", "Install " + filename, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        public Thread StartThread(Action action)
        {
            Thread thread = new Thread(() => { action(); });
            thread.Start();
            return thread;
        }
        public void InvokeIfRequired(Control control, MethodInvoker action)
        {
            try
            {
                if (control.InvokeRequired)
                { control.Invoke(action); }
                else { action(); }
            }
            catch { }
        }

        public void extractZip(string zipPath, string extractPath)
        {
            try
            {
                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string fullPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

                        if (!fullPath.StartsWith(Path.GetFullPath(extractPath), StringComparison.OrdinalIgnoreCase))
                        { throw new IOException("Invalid entry path: " + entry.FullName); }
                        string dir = Path.GetDirectoryName(fullPath);
                        if (!string.IsNullOrEmpty(dir))
                        { Directory.CreateDirectory(dir); }
                        if (!string.IsNullOrEmpty(entry.Name))
                        { entry.ExtractToFile(fullPath, true); }

                    }
                }
            }
            catch (Exception)
            {
                // Delete the entire extraction folder on failure
                try
                {
                    if (Directory.Exists(extractPath))
                        Directory.Delete(extractPath, true);
                }
                catch
                {
                    // ignore failures deleting the folder
                }
                throw;
            }
        }

        public void installSoftware(string name, string filename, string extractFoldName = "")//must be run on a seperate thread from the UI
        {
            DialogResult msgResult = DialogResult.No;
            this.Invoke((MethodInvoker)delegate
            {
                msgResult = MessageBox.Show("This will install " + name + ". If its already installed please uninstall it first. Continue?", "Install " + name, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            });

            if (msgResult == DialogResult.Yes)
            {
                if (checkifSoftwareExists(filename))
                {
                    if (extractFoldName.Trim() != "") Directory.CreateDirectory(extractFoldName);
                    if (Path.GetExtension(filename) == ".zip")
                    {
                        var isDone = new BoolWrapper { Value = false };
                        pleaseWaitFrm frm = new pleaseWaitFrm(isDone, this, "Installing " + name);
                        BeginInvoke((MethodInvoker)delegate ()//run the Form on the UI thread. so that it freezes other forms when it shows
                        {
                            frm.ShowDialog();
                        });
                        try
                        {
                            extractZip(softwarePath + "\\" + filename, extractFoldName);
                            isDone.Value = true;
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("Installation done!", "Install " + name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            });

                        }
                        catch (Exception ex)
                        {
                            isDone.Value = true;
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("Installation of " + name + " failed." + Environment.NewLine + "DETAILS: " + ex.ToString(), "Installation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            });
                        }
                        InvokeIfRequired(refreshBtn, () => refreshBtn.PerformClick());
                    }
                    else//.exe
                    {
                        Process p = new Process();
                        p.StartInfo.FileName = softwarePath + "\\" + filename;
                        p.StartInfo.WorkingDirectory = Directory.GetParent(softwarePath + "\\" + filename).FullName;
                        p.Start();
                        p.WaitForExit();
                        InvokeIfRequired(refreshBtn, () => refreshBtn.PerformClick());
                    }
                }
                else
                {
                    BeginInvoke((MethodInvoker)delegate ()
                    {
                        MessageBox.Show("The installer for " + name + "was not found. Make sure to rename the " + name + "installer to " + filename + " and put it in the 'icebutt_software' folder", "Installer not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            }

        }
        public void removeSoftware(string name, string uninstPath) //if uninstPath does not point to an executable, then it is assumed that it is a folder and it will be deleted
        {
            DialogResult msgResult = DialogResult.No;
            this.Invoke((MethodInvoker)delegate
            {
                msgResult = MessageBox.Show("This will uninstall " + name + ". Continue?", "Uninstall " + name, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            });
            if (msgResult == DialogResult.Yes)
            {
                if (Path.GetExtension(uninstPath) != ".exe")
                {
                    if (Directory.Exists(uninstPath))
                    {
                        var isDone = new BoolWrapper { Value = false };
                        pleaseWaitFrm frm = new pleaseWaitFrm(isDone, this, "Uninstalling " + name);
                        BeginInvoke((MethodInvoker)delegate ()//run the wait form on the UI thread. so that it freezes when it shows.
                        {
                            frm.ShowDialog();
                        });
                        try
                        {
                            Directory.Delete(uninstPath, true);
                            isDone.Value = true;
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("Uninstall completed", "Uninstall " + name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            });
                            BeginInvoke((MethodInvoker)delegate ()
                            {
                                refreshBtn.PerformClick();
                            });
                        }
                        catch (Exception ex)
                        {
                            isDone.Value = true;
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("Failed to uninstall " + name + Environment.NewLine + "DETAILS: " + ex.ToString(), "Uninstall error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            });
                            BeginInvoke((MethodInvoker)delegate ()
                            {
                                refreshBtn.PerformClick();

                            });
                        }

                    }
                    else
                    {
                        InvokeIfRequired(refreshBtn, () => refreshBtn.PerformClick());
                        //means its been already removed, for some reason
                    }
                }
                else
                {
                    if (System.IO.File.Exists(uninstPath))
                    {
                        Process p = new Process();
                        p.StartInfo.FileName = uninstPath;
                        p.StartInfo.WorkingDirectory = Path.GetDirectoryName(uninstPath);
                        p.Start();
                        p.WaitForExit();
                        //check if it spawned any child uninstallers and wait for those
                        string parentPid = p.Id.ToString();
                        var searcher = new ManagementObjectSearcher(
                            $"SELECT * FROM Win32_Process WHERE ParentProcessId={parentPid}");

                        var children = searcher.Get();
                        if (children.Count > 0)
                        {
                            foreach (var obj in searcher.Get())
                            {
                                string childPid = obj["ProcessId"].ToString();
                                Process child = Process.GetProcessById(int.Parse(childPid));
                                child.WaitForExit();
                            }
                        }
                        InvokeIfRequired(refreshBtn, () => refreshBtn.PerformClick());
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("Cannot uninstall " + name + ". Installation damaged or already removed.", "Uninstaller not found error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                        BeginInvoke((MethodInvoker)delegate ()
                        {
                            refreshBtn.PerformClick();
                        });
                    }
                }
            }
        }
        private void iceCastBtn_Click(object sender, EventArgs e)
        {
            StartThread(() => installSoftware("Icecast", "icecast.exe"));
        }

        private void buttBtn_Click(object sender, EventArgs e)
        {
            StartThread(() => installSoftware("BUTT", "butt.zip", installedSoftwarePath + @"\BUTT"));
        }

        infoFrm infFrm = null;
        private void button2_Click(object sender, EventArgs e)
        {
            if (infFrm == null)
            {
                infFrm = new infoFrm();
            }
            infFrm.ShowDialog();
        }

        private void vlcBtn_Click(object sender, EventArgs e)
        {
            StartThread(() => installSoftware("VLC", "vlc-3.0.21-win32.exe"));
        }
        public DialogResult remConfigMsg(string name)
        {
            return MessageBox.Show("You need to remove the configuration first before uninstalling " + name + " to prevent leaving remnant files that could cause unwanted behavior. By removing the configuration, your PC won't work as a sender or reciever and you will be able to use it like normal. Continue?", "Step before uninstalling " + name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        private void remIceCastBtn_Click(object sender, EventArgs e)
        {
            if (senderCfgBtn.FlatStyle == FlatStyle.Standard)//means configuration is installed. Better remove it so that there are no problems with trying to start missing files and other unexpected behaviors etc
            {
                if (remConfigMsg("Icecast") == DialogResult.Yes)
                {
                    editPassFrm frm = new editPassFrm(this);
                    int result = frm.unsetSender(false);
                    if (result != 1) return;
                }
                else return;
            }
            StartThread(() => removeSoftware("Icecast", icecastFolderPath + @"\uninstall.exe"));
        }

        private void remButtBtn_Click(object sender, EventArgs e)
        {
            if (senderCfgBtn.FlatStyle == FlatStyle.Standard)//means configuration is installed. Better remove it so that there are no problems with trying to start missing files and other unexpected behaviors etc
            {
                if (remConfigMsg("BUTT") == DialogResult.Yes)
                {
                    editPassFrm frm = new editPassFrm(this);
                    int result = frm.unsetSender(false);
                    if (result != 1) return;
                }
                else return;
            }
            StartThread(() => removeSoftware("BUTT", Directory.GetParent(buttFolderPath).FullName));
        }

        private void remVlcBtn_Click(object sender, EventArgs e)
        {
            if (recieverCfgBtn.FlatStyle == FlatStyle.Standard)//means configuration is installed. Better remove it so that there are no problems with trying to start missing files and other unexpected behaviors etc
            {
                if (remConfigMsg("VLC") == DialogResult.Yes)
                {
                    recieverInstallConfg frm = new recieverInstallConfg(this);
                    int result = frm.unsetReciever(false);
                    if (result != 1) return;
                }
                else return;
            }
            bool dir32 = System.IO.File.Exists(ProgramFilesx86() + @"\VideoLAN\VLC\vlc.exe");
            bool dir64 = System.IO.File.Exists(programFiles + @"\VideoLAN\VLC\vlc.exe");
            StartThread(() =>
            {
                if (dir32 || dir64)
                {
                    if (dir32)
                    {
                        removeSoftware("VLC (32bit)", ProgramFilesx86() + @"\VideoLAN\VLC\uninstall.exe");
                    }
                    if (dir64)
                    {
                        removeSoftware("VLC (64bit)", programFiles + @"\VideoLAN\VLC\uninstall.exe");
                    }
                }
            });
        }

        private void remVbBtn_Click(object sender, EventArgs e)
        {
            StartThread(() => removeSoftware("VBCable", VBCablePath + @"\VBCABLE_Setup_x64.exe"));

        }

        private void vbBtn_Click(object sender, EventArgs e)
        {
            string name = "VBCable";
            var isDone = new BoolWrapper { Value = false };
            pleaseWaitFrm frm = new pleaseWaitFrm(isDone, this, "Installing " + name);
            StartThread(() =>
            {
                BeginInvoke((MethodInvoker)delegate ()
                {
                    frm.ShowDialog();
                });
                try
                {
                    Directory.CreateDirectory(softwarePath + @"\vbcable");
                    extractZip(softwarePath + @"\vbcable.zip", softwarePath + @"\vbcable");//extract vbcable.zip before running installer
                    isDone.Value = true;
                    BeginInvoke((MethodInvoker)delegate ()
                    {
                        StartThread(() =>
                        {
                            installSoftware(name, @"\vbcable\VBCABLE_Setup_x64.exe");
                            try//try deleting extracted files since we dont need them anymore
                            {
                                Directory.Delete(softwarePath + @"\vbcable", true);
                            }
                            catch { }
                        });
                    });
                }
                catch (Exception ex)
                {
                    isDone.Value = true;
                    BeginInvoke((MethodInvoker)delegate ()
                    {
                        MessageBox.Show("Installation of " + name + " failed." + Environment.NewLine + "DETAILS: " + ex.ToString(), "Installation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            });
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            StartThread(() => installSoftware("Voicemeeter", "voicemeeter.exe"));
        }

        private void remVoicemeterBtn_Click(object sender, EventArgs e)
        {
            StartThread(() => removeSoftware("Voicemeeter", programFiles + @"\VB\Voicemeeter\voicemeeter.exe"));//FIX THIS CUZ IDK IF IT INSTALLS 32 OR 64 BIT

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void startSendingBtn_Click(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcessesByName("icecast");
            Process[] p2 = Process.GetProcessesByName("butt");
            if (p.Length > 0 || p2.Length > 0)
            {
                MessageBox.Show("Cannot start sending because Icecast or BUTT are already running. Please make sure that both of these programs are closed first.","Start sending error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (System.IO.File.Exists(iceButtBatFile))
            {
                try
                {
                    using (Process process = new Process())
                    {
                        process.StartInfo.FileName = iceButtBatFile;
                        process.StartInfo.WorkingDirectory = iceButtDocsPath;
                        process.Start();
                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong while trying to start Icecast and BUTT", "Start sending error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                refreshBtn.PerformClick();
                MessageBox.Show("Sender configuration for Icecast and BUTT not set. Please set it by clicking the install button", "Missing sender configuration", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void startRecievingBtn_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(playListPath) && System.IO.File.Exists(playStreamBatPath))
            {
                try
                {
                    using (Process process = new Process())
                    {
                        process.StartInfo.FileName = playStreamBatPath;
                        process.StartInfo.WorkingDirectory = iceButtDocsPath;
                        process.Start();
                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong while trying to start VLC", "Start recieving error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                refreshBtn.PerformClick();
                MessageBox.Show("Reciever configuration for VLC not set. Please set it by clicking the install button", "Missing reciever configuration", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void modifySenderConfBtn_Click(object sender, EventArgs e)
        {
            senderCfgBtn.PerformClick();
        }

        private void modifyRecieverConfBtn_Click(object sender, EventArgs e)
        {
            recieverCfgBtn.PerformClick();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }
    }
}
