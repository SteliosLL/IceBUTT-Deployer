using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace IceButt
{
    public partial class recieverInstallConfg : Form
    {
        Form1 parentFrm;
        public recieverInstallConfg(Form1 parentForm)
        {
            InitializeComponent();
            parentFrm = parentForm;
        }

        private void recieverInstallConfg_Load(object sender, EventArgs e)
        {
            if (parentFrm.recieverCfgBtn.FlatStyle == FlatStyle.System)
            {
                unsetBtn.Enabled = false;
            }
            try
            {
                string batFile = File.ReadAllText(parentFrm.iceButtDocsPath + @"\playStream.bat");
                if (batFile.Contains("--qt-start-minimized"))
                {
                    startMinimizedChckBox.Checked = true;
                }
            }
            catch { }

            playStreamOnStartChckBox.Checked = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\iceButtPlayStream.lnk");
            if (unsetBtn.Enabled)//if unsetBtn is disabled it means the configuration has not been installed. In that case leave the streamDeskShortcutChckBox to the default value
            {
                streamDeskShortcutChckBox.Checked = File.Exists(parentFrm.playStreamDesktopShortcutPath);
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(parentFrm.iceButtDocsPath + @"\playlist.xspf");
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("xspf", "http://xspf.org/ns/0/");
                XmlNode locationNode = doc.SelectSingleNode("//xspf:location", nsmgr);
                string URL = locationNode.InnerText;
                if (Uri.TryCreate(URL, UriKind.Absolute, out Uri uri))//Check if URL is a valid URL. kind of a generic check tho
                {
                    string host = uri.Host;
                    int port = uri.Port;
                    string mountPoint = uri.AbsolutePath;

                    ipAddressTxtBox.Text = host;
                    portTxtBox.Text = port.ToString(); ;
                    mountTxtBox.Text = mountPoint.TrimStart('/');
                }
                else
                {
                    MessageBox.Show("Configuration is malformed. Please re-enter the required fields and then click save.", "Reciever configuration error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch { }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ipAddressTxtBox.Text.Trim() == "" || portTxtBox.Text.Trim() == "" || mountTxtBox.Text.Trim() == "")
            {
                MessageBox.Show("Cannot save. Please fill in all the required fields", "Save configuration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string URL = "http://" + ipAddressTxtBox.Text.Trim() + ":" + portTxtBox.Text.Trim() + "/" + mountTxtBox.Text.Trim();
            string playList = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<playlist version=\"1\" xmlns=\"http://xspf.org/ns/0/\">\n  <title>Icecast Stream</title>\n  <trackList>\n    <track>\n      <location>" + URL + "</location>\n      <title>IceButt Audio Stream</title>\n    </track>\n  </trackList>\n</playlist>\n";
            string startMinimized = "";
            if (startMinimizedChckBox.Checked)
            {
                startMinimized = " --qt-start-minimized";
            }
            string vlcBatFile = '"' + parentFrm.vlcPath + @"\vlc.exe" + '"' + " " + '"' + parentFrm.playListPath + '"' + " --loop" + startMinimized;
            try
            {
                Directory.CreateDirectory(parentFrm.iceButtDocsPath);//create iceButt documents folder if it does not already exist
                File.WriteAllText(parentFrm.playListPath, playList);//Write playlist file
                File.WriteAllText(parentFrm.playStreamBatPath, vlcBatFile);//Write VLC stream start file
                if (streamDeskShortcutChckBox.Checked)//create desktop shortcut
                {
                    parentFrm.CreateShortcut(parentFrm.playStreamDesktopShortcutPath, parentFrm.playStreamBatPath);
                }
                else//or delete it
                {
                    if (File.Exists(parentFrm.playStreamDesktopShortcutPath))
                    {
                        try
                        {
                            File.Delete(parentFrm.playStreamDesktopShortcutPath);
                        }
                        catch
                        {
                            MessageBox.Show(@"Failed to delete the desktop shortcut. ", "Create desktop shortcut for opening and playing the stream", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //do not return
                        }
                    }

                }
                if (playStreamOnStartChckBox.Checked)//create startup shortcut
                {
                    parentFrm.CreateShortcut(parentFrm.playStreamStartupShortcutPath, parentFrm.playStreamBatPath);
                }
                else//or delete it
                {
                    if (File.Exists(parentFrm.playStreamStartupShortcutPath))
                    {
                        try
                        {
                            File.Delete(parentFrm.playStreamStartupShortcutPath);
                        }
                        catch
                        {
                            MessageBox.Show(@"Failed to disable ""Open VLC and play stream on startup"". Please go to the startup folder and manually remove the shortcut.", "Save configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //do not return
                        }
                    }

                }

                if (parentFrm.recieverCfgBtn.FlatStyle == FlatStyle.System && streamDeskShortcutChckBox.Checked)//inform the user about the desktop shortcut for playing the stream
                {
                    MessageBox.Show("This will create a shortcut on your Desktop called \"Play IceButt stream\" which you can use to open and play the stream.", "Desktop shortcut for opening and playing the stream", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MessageBox.Show("Done!", "Save changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Failed to save the configuration." + Environment.NewLine + "DETAILS: " + a.ToString(), "Save configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            parentFrm.refreshBtn.PerformClick();
        }

        private void startMinimizedChckBox_CheckedChanged(object sender, EventArgs e)
        {

        }


        public int unsetReciever(bool showMsg = true)
        {
            int result = 0;
            if (showMsg)
            {
                if (MessageBox.Show("This will unset this computer from working as the reciever and you will be able to use it like normal. For example any shortcuts on your desktop for starting the stream will be removed and if you've set the stream to play on startup, it won't start any more. Continue?", "Unset computer configuration", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return result;
                }
            }

            try
            {
                if (File.Exists(parentFrm.playStreamStartupShortcutPath))//delete startup file
                {
                    File.Delete(parentFrm.playStreamStartupShortcutPath);
                }
                if (File.Exists(parentFrm.playStreamDesktopShortcutPath))//delete desktop shortcut
                {
                    File.Delete(parentFrm.playStreamDesktopShortcutPath);
                }
                if (File.Exists(parentFrm.playListPath))
                {
                    File.Delete(parentFrm.playListPath);
                }
                if (File.Exists(parentFrm.playStreamBatPath))
                {
                    File.Delete(parentFrm.playStreamBatPath);
                }
                result = 1;
                if (showMsg)
                {
                    MessageBox.Show("Done!", "Unset computer configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                result = -1;
                MessageBox.Show("Failed to fully unset the configuration!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            parentFrm.refreshBtn.PerformClick();
            this.Close();
            return result;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            unsetReciever();
        }

        private void portTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            textboxUtils.checkForNumber(portTxtBox, this, e);
        }
    }
}
