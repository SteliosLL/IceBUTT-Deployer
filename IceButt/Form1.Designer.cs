namespace IceButt
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.refreshBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.modifySenderConfBtn = new System.Windows.Forms.Button();
            this.remVbBtn = new System.Windows.Forms.Button();
            this.remButtBtn = new System.Windows.Forms.Button();
            this.remIceCastBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.vbBtn = new System.Windows.Forms.Button();
            this.iceCastBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.senderCfgBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.setStatusSenderLbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.modifyRecieverConfBtn = new System.Windows.Forms.Button();
            this.remVlcBtn = new System.Windows.Forms.Button();
            this.setStatusRecieverLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.vlcBtn = new System.Windows.Forms.Button();
            this.recieverCfgBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.senderConfigMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editIcecastSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editIcecastxmlToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editPasswordAndMoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editBUTTSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nOTEYOUCANCHANGEBUTTSETTINGSFROMWITHINTHEPROGRAMTOOTHISISJUSTFORCONVENIENCEINMYCASEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.senderGrpBox = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.startSendingBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipLbl = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.noteLbl = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.recieverGrpBox = new System.Windows.Forms.GroupBox();
            this.startRecievingBtn = new System.Windows.Forms.Button();
            this.IPstaticNotifLbl = new System.Windows.Forms.Label();
            this.refreshingLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.senderConfigMenuStrip.SuspendLayout();
            this.senderGrpBox.SuspendLayout();
            this.recieverGrpBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshBtn
            // 
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.refreshBtn.Location = new System.Drawing.Point(7, 2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 21);
            this.refreshBtn.TabIndex = 0;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IPstaticNotifLbl);
            this.groupBox1.Controls.Add(this.modifySenderConfBtn);
            this.groupBox1.Controls.Add(this.remVbBtn);
            this.groupBox1.Controls.Add(this.remButtBtn);
            this.groupBox1.Controls.Add(this.remIceCastBtn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.vbBtn);
            this.groupBox1.Controls.Add(this.iceCastBtn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.senderCfgBtn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.setStatusSenderLbl);
            this.groupBox1.Location = new System.Drawing.Point(6, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 157);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set as Sender";
            // 
            // modifySenderConfBtn
            // 
            this.modifySenderConfBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.modifySenderConfBtn.FlatAppearance.BorderSize = 0;
            this.modifySenderConfBtn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifySenderConfBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.modifySenderConfBtn.Image = global::IceButt.Properties.Resources.icons8_settings_16;
            this.modifySenderConfBtn.Location = new System.Drawing.Point(149, 65);
            this.modifySenderConfBtn.Name = "modifySenderConfBtn";
            this.modifySenderConfBtn.Size = new System.Drawing.Size(23, 23);
            this.modifySenderConfBtn.TabIndex = 24;
            this.toolTip1.SetToolTip(this.modifySenderConfBtn, "Modify sender configuration");
            this.modifySenderConfBtn.UseVisualStyleBackColor = false;
            this.modifySenderConfBtn.Visible = false;
            this.modifySenderConfBtn.Click += new System.EventHandler(this.modifySenderConfBtn_Click);
            // 
            // remVbBtn
            // 
            this.remVbBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.remVbBtn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remVbBtn.ForeColor = System.Drawing.Color.Red;
            this.remVbBtn.Location = new System.Drawing.Point(156, 129);
            this.remVbBtn.Name = "remVbBtn";
            this.remVbBtn.Size = new System.Drawing.Size(23, 23);
            this.remVbBtn.TabIndex = 23;
            this.remVbBtn.Text = "X";
            this.toolTip1.SetToolTip(this.remVbBtn, "Remove VB cable");
            this.remVbBtn.UseVisualStyleBackColor = false;
            this.remVbBtn.Visible = false;
            this.remVbBtn.Click += new System.EventHandler(this.remVbBtn_Click);
            // 
            // remButtBtn
            // 
            this.remButtBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.remButtBtn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remButtBtn.ForeColor = System.Drawing.Color.Red;
            this.remButtBtn.Location = new System.Drawing.Point(149, 41);
            this.remButtBtn.Name = "remButtBtn";
            this.remButtBtn.Size = new System.Drawing.Size(23, 23);
            this.remButtBtn.TabIndex = 22;
            this.remButtBtn.Text = "X";
            this.toolTip1.SetToolTip(this.remButtBtn, "Remove BUTT");
            this.remButtBtn.UseVisualStyleBackColor = false;
            this.remButtBtn.Visible = false;
            this.remButtBtn.Click += new System.EventHandler(this.remButtBtn_Click);
            // 
            // remIceCastBtn
            // 
            this.remIceCastBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.remIceCastBtn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remIceCastBtn.ForeColor = System.Drawing.Color.Red;
            this.remIceCastBtn.Location = new System.Drawing.Point(149, 17);
            this.remIceCastBtn.Name = "remIceCastBtn";
            this.remIceCastBtn.Size = new System.Drawing.Size(23, 23);
            this.remIceCastBtn.TabIndex = 21;
            this.remIceCastBtn.Text = "X";
            this.toolTip1.SetToolTip(this.remIceCastBtn, "Remove Icecast");
            this.remIceCastBtn.UseVisualStyleBackColor = false;
            this.remIceCastBtn.Visible = false;
            this.remIceCastBtn.Click += new System.EventHandler(this.remIceCastBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "-Optional-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "1. VBCable";
            // 
            // vbBtn
            // 
            this.vbBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.vbBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.vbBtn.Location = new System.Drawing.Point(80, 129);
            this.vbBtn.Name = "vbBtn";
            this.vbBtn.Size = new System.Drawing.Size(75, 23);
            this.vbBtn.TabIndex = 17;
            this.vbBtn.Text = "Install";
            this.vbBtn.UseVisualStyleBackColor = false;
            this.vbBtn.Click += new System.EventHandler(this.vbBtn_Click);
            // 
            // iceCastBtn
            // 
            this.iceCastBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.iceCastBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.iceCastBtn.Location = new System.Drawing.Point(73, 17);
            this.iceCastBtn.Name = "iceCastBtn";
            this.iceCastBtn.Size = new System.Drawing.Size(75, 23);
            this.iceCastBtn.TabIndex = 15;
            this.iceCastBtn.Text = "Install";
            this.iceCastBtn.UseVisualStyleBackColor = false;
            this.iceCastBtn.Click += new System.EventHandler(this.iceCastBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "3. Config";
            // 
            // senderCfgBtn
            // 
            this.senderCfgBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.senderCfgBtn.Enabled = false;
            this.senderCfgBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.senderCfgBtn.Location = new System.Drawing.Point(73, 65);
            this.senderCfgBtn.Name = "senderCfgBtn";
            this.senderCfgBtn.Size = new System.Drawing.Size(75, 23);
            this.senderCfgBtn.TabIndex = 10;
            this.senderCfgBtn.Text = "Install";
            this.toolTip1.SetToolTip(this.senderCfgBtn, "Install/Modify sender configuration");
            this.senderCfgBtn.UseVisualStyleBackColor = false;
            this.senderCfgBtn.Click += new System.EventHandler(this.senderCfgBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "2. BUTT";
            // 
            // buttBtn
            // 
            this.buttBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.buttBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttBtn.Location = new System.Drawing.Point(73, 41);
            this.buttBtn.Name = "buttBtn";
            this.buttBtn.Size = new System.Drawing.Size(75, 23);
            this.buttBtn.TabIndex = 7;
            this.buttBtn.Text = "Install";
            this.buttBtn.UseVisualStyleBackColor = false;
            this.buttBtn.Click += new System.EventHandler(this.buttBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "1. Icecast";
            // 
            // setStatusSenderLbl
            // 
            this.setStatusSenderLbl.AutoSize = true;
            this.setStatusSenderLbl.BackColor = System.Drawing.Color.Red;
            this.setStatusSenderLbl.Location = new System.Drawing.Point(94, 0);
            this.setStatusSenderLbl.Name = "setStatusSenderLbl";
            this.setStatusSenderLbl.Size = new System.Drawing.Size(54, 13);
            this.setStatusSenderLbl.TabIndex = 4;
            this.setStatusSenderLbl.Text = "NOT SET";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.modifyRecieverConfBtn);
            this.groupBox2.Controls.Add(this.remVlcBtn);
            this.groupBox2.Controls.Add(this.setStatusRecieverLbl);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.vlcBtn);
            this.groupBox2.Controls.Add(this.recieverCfgBtn);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(197, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 68);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set as Reciever";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // modifyRecieverConfBtn
            // 
            this.modifyRecieverConfBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.modifyRecieverConfBtn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyRecieverConfBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.modifyRecieverConfBtn.Image = global::IceButt.Properties.Resources.icons8_settings_16;
            this.modifyRecieverConfBtn.Location = new System.Drawing.Point(137, 40);
            this.modifyRecieverConfBtn.Name = "modifyRecieverConfBtn";
            this.modifyRecieverConfBtn.Size = new System.Drawing.Size(23, 23);
            this.modifyRecieverConfBtn.TabIndex = 25;
            this.toolTip1.SetToolTip(this.modifyRecieverConfBtn, "Modify reciever configuration");
            this.modifyRecieverConfBtn.UseVisualStyleBackColor = false;
            this.modifyRecieverConfBtn.Visible = false;
            this.modifyRecieverConfBtn.Click += new System.EventHandler(this.modifyRecieverConfBtn_Click);
            // 
            // remVlcBtn
            // 
            this.remVlcBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.remVlcBtn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remVlcBtn.ForeColor = System.Drawing.Color.Red;
            this.remVlcBtn.Location = new System.Drawing.Point(137, 16);
            this.remVlcBtn.Name = "remVlcBtn";
            this.remVlcBtn.Size = new System.Drawing.Size(23, 23);
            this.remVlcBtn.TabIndex = 23;
            this.remVlcBtn.Text = "X";
            this.toolTip1.SetToolTip(this.remVlcBtn, "Remove VLC");
            this.remVlcBtn.UseVisualStyleBackColor = false;
            this.remVlcBtn.Visible = false;
            this.remVlcBtn.Click += new System.EventHandler(this.remVlcBtn_Click);
            // 
            // setStatusRecieverLbl
            // 
            this.setStatusRecieverLbl.AutoSize = true;
            this.setStatusRecieverLbl.BackColor = System.Drawing.Color.Red;
            this.setStatusRecieverLbl.Location = new System.Drawing.Point(101, 0);
            this.setStatusRecieverLbl.Name = "setStatusRecieverLbl";
            this.setStatusRecieverLbl.Size = new System.Drawing.Size(54, 13);
            this.setStatusRecieverLbl.TabIndex = 5;
            this.setStatusRecieverLbl.Text = "NOT SET";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "2. Config";
            // 
            // vlcBtn
            // 
            this.vlcBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.vlcBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.vlcBtn.Location = new System.Drawing.Point(61, 16);
            this.vlcBtn.Name = "vlcBtn";
            this.vlcBtn.Size = new System.Drawing.Size(75, 23);
            this.vlcBtn.TabIndex = 17;
            this.vlcBtn.Text = "Install";
            this.vlcBtn.UseVisualStyleBackColor = false;
            this.vlcBtn.Click += new System.EventHandler(this.vlcBtn_Click);
            // 
            // recieverCfgBtn
            // 
            this.recieverCfgBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.recieverCfgBtn.Enabled = false;
            this.recieverCfgBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.recieverCfgBtn.Location = new System.Drawing.Point(61, 40);
            this.recieverCfgBtn.Name = "recieverCfgBtn";
            this.recieverCfgBtn.Size = new System.Drawing.Size(75, 23);
            this.recieverCfgBtn.TabIndex = 20;
            this.recieverCfgBtn.Text = "Install";
            this.toolTip1.SetToolTip(this.recieverCfgBtn, "Install/Modify reciever configuration");
            this.recieverCfgBtn.UseVisualStyleBackColor = false;
            this.recieverCfgBtn.Click += new System.EventHandler(this.recieverCfgBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "1. VLC";
            // 
            // senderConfigMenuStrip
            // 
            this.senderConfigMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installToolStripMenuItem,
            this.editIcecastSettingsToolStripMenuItem,
            this.editBUTTSettingsToolStripMenuItem});
            this.senderConfigMenuStrip.Name = "senderConfigMenuStrip";
            this.senderConfigMenuStrip.Size = new System.Drawing.Size(219, 70);
            // 
            // installToolStripMenuItem
            // 
            this.installToolStripMenuItem.Name = "installToolStripMenuItem";
            this.installToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.installToolStripMenuItem.Text = "Install";
            // 
            // editIcecastSettingsToolStripMenuItem
            // 
            this.editIcecastSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editIcecastxmlToolStripMenuItem1,
            this.editPasswordAndMoreToolStripMenuItem});
            this.editIcecastSettingsToolStripMenuItem.Name = "editIcecastSettingsToolStripMenuItem";
            this.editIcecastSettingsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.editIcecastSettingsToolStripMenuItem.Text = "Edit Icecast + BUTT settings";
            // 
            // editIcecastxmlToolStripMenuItem1
            // 
            this.editIcecastxmlToolStripMenuItem1.Name = "editIcecastxmlToolStripMenuItem1";
            this.editIcecastxmlToolStripMenuItem1.Size = new System.Drawing.Size(201, 22);
            this.editIcecastxmlToolStripMenuItem1.Text = "Edit icecast.xml";
            // 
            // editPasswordAndMoreToolStripMenuItem
            // 
            this.editPasswordAndMoreToolStripMenuItem.Name = "editPasswordAndMoreToolStripMenuItem";
            this.editPasswordAndMoreToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.editPasswordAndMoreToolStripMenuItem.Text = "Edit password and more";
            // 
            // editBUTTSettingsToolStripMenuItem
            // 
            this.editBUTTSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nOTEYOUCANCHANGEBUTTSETTINGSFROMWITHINTHEPROGRAMTOOTHISISJUSTFORCONVENIENCEINMYCASEToolStripMenuItem});
            this.editBUTTSettingsToolStripMenuItem.Name = "editBUTTSettingsToolStripMenuItem";
            this.editBUTTSettingsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.editBUTTSettingsToolStripMenuItem.Text = "Edit more BUTT settings";
            // 
            // nOTEYOUCANCHANGEBUTTSETTINGSFROMWITHINTHEPROGRAMTOOTHISISJUSTFORCONVENIENCEINMYCASEToolStripMenuItem
            // 
            this.nOTEYOUCANCHANGEBUTTSETTINGSFROMWITHINTHEPROGRAMTOOTHISISJUSTFORCONVENIENCEINMYCASEToolStripMenuItem.Name = "nOTEYOUCANCHANGEBUTTSETTINGSFROMWITHINTHEPROGRAMTOOTHISISJUSTFORCONVENIENCEINMYCA" +
    "SEToolStripMenuItem";
            this.nOTEYOUCANCHANGEBUTTSETTINGSFROMWITHINTHEPROGRAMTOOTHISISJUSTFORCONVENIENCEINMYCASEToolStripMenuItem.Size = new System.Drawing.Size(742, 22);
            this.nOTEYOUCANCHANGEBUTTSETTINGSFROMWITHINTHEPROGRAMTOOTHISISJUSTFORCONVENIENCEINMYCASEToolStripMenuItem.Text = "To change more of BUTT\'s settings open butt, click the stop button to stop it fro" +
    "m trying to connect, and then click the settings";
            // 
            // senderGrpBox
            // 
            this.senderGrpBox.Controls.Add(this.linkLabel1);
            this.senderGrpBox.Controls.Add(this.startSendingBtn);
            this.senderGrpBox.Controls.Add(this.label1);
            this.senderGrpBox.Enabled = false;
            this.senderGrpBox.Location = new System.Drawing.Point(6, 184);
            this.senderGrpBox.Name = "senderGrpBox";
            this.senderGrpBox.Size = new System.Drawing.Size(185, 66);
            this.senderGrpBox.TabIndex = 4;
            this.senderGrpBox.TabStop = false;
            this.senderGrpBox.Text = "Sender Panel";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(114, 42);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(33, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Open";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // startSendingBtn
            // 
            this.startSendingBtn.Image = global::IceButt.Properties.Resources.netshell_1607_9;
            this.startSendingBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.startSendingBtn.Location = new System.Drawing.Point(8, 14);
            this.startSendingBtn.Name = "startSendingBtn";
            this.startSendingBtn.Size = new System.Drawing.Size(108, 23);
            this.startSendingBtn.TabIndex = 9;
            this.startSendingBtn.Text = "  Start sending";
            this.startSendingBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startSendingBtn.UseVisualStyleBackColor = true;
            this.startSendingBtn.Click += new System.EventHandler(this.startSendingBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Icecast web interface:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "This computer\'s local IP:";
            // 
            // ipLbl
            // 
            this.ipLbl.AutoSize = true;
            this.ipLbl.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.ipLbl.ForeColor = System.Drawing.Color.Blue;
            this.ipLbl.Location = new System.Drawing.Point(169, -1);
            this.ipLbl.Name = "ipLbl";
            this.ipLbl.Size = new System.Drawing.Size(80, 18);
            this.ipLbl.TabIndex = 6;
            this.ipLbl.Tag = "";
            this.ipLbl.Text = "Not Found";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.button2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.Location = new System.Drawing.Point(155, 267);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 41);
            this.button2.TabIndex = 7;
            this.button2.Text = "  ?";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.button2, "Info/Help");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // noteLbl
            // 
            this.noteLbl.AutoSize = true;
            this.noteLbl.Location = new System.Drawing.Point(54, 253);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(261, 13);
            this.noteLbl.TabIndex = 8;
            this.noteLbl.Text = "NOTE: Click the gear icon to modify the configuration.";
            this.noteLbl.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 250;
            this.toolTip1.ReshowDelay = 100;
            // 
            // recieverGrpBox
            // 
            this.recieverGrpBox.Controls.Add(this.startRecievingBtn);
            this.recieverGrpBox.Enabled = false;
            this.recieverGrpBox.Location = new System.Drawing.Point(196, 184);
            this.recieverGrpBox.Name = "recieverGrpBox";
            this.recieverGrpBox.Size = new System.Drawing.Size(170, 66);
            this.recieverGrpBox.TabIndex = 11;
            this.recieverGrpBox.TabStop = false;
            this.recieverGrpBox.Text = "Reciever Panel";
            // 
            // startRecievingBtn
            // 
            this.startRecievingBtn.Image = global::IceButt.Properties.Resources.netshell_1607_9_flipped;
            this.startRecievingBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.startRecievingBtn.Location = new System.Drawing.Point(6, 14);
            this.startRecievingBtn.Name = "startRecievingBtn";
            this.startRecievingBtn.Size = new System.Drawing.Size(108, 23);
            this.startRecievingBtn.TabIndex = 10;
            this.startRecievingBtn.Text = "  Start recieving";
            this.startRecievingBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startRecievingBtn.UseVisualStyleBackColor = true;
            this.startRecievingBtn.Click += new System.EventHandler(this.startRecievingBtn_Click);
            // 
            // IPstaticNotifLbl
            // 
            this.IPstaticNotifLbl.AutoSize = true;
            this.IPstaticNotifLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.IPstaticNotifLbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IPstaticNotifLbl.Location = new System.Drawing.Point(16, 91);
            this.IPstaticNotifLbl.Name = "IPstaticNotifLbl";
            this.IPstaticNotifLbl.Size = new System.Drawing.Size(158, 13);
            this.IPstaticNotifLbl.TabIndex = 25;
            this.IPstaticNotifLbl.Text = "-IP NEEDS TO BE STATIC";
            // 
            // refreshingLbl
            // 
            this.refreshingLbl.AutoSize = true;
            this.refreshingLbl.ForeColor = System.Drawing.Color.Green;
            this.refreshingLbl.Location = new System.Drawing.Point(84, 6);
            this.refreshingLbl.Name = "refreshingLbl";
            this.refreshingLbl.Size = new System.Drawing.Size(67, 13);
            this.refreshingLbl.TabIndex = 12;
            this.refreshingLbl.Text = "Refreshing...";
            this.refreshingLbl.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.recieverGrpBox);
            this.panel1.Controls.Add(this.senderGrpBox);
            this.panel1.Controls.Add(this.noteLbl);
            this.panel1.Controls.Add(this.ipLbl);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 312);
            this.panel1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 337);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.refreshingLbl);
            this.Controls.Add(this.refreshBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "IceBUTT Deployer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.senderConfigMenuStrip.ResumeLayout(false);
            this.senderGrpBox.ResumeLayout(false);
            this.senderGrpBox.PerformLayout();
            this.recieverGrpBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label setStatusSenderLbl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label setStatusRecieverLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button vlcBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button iceCastBtn;
        private System.Windows.Forms.ContextMenuStrip senderConfigMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem installToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editIcecastSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editIcecastxmlToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editPasswordAndMoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editBUTTSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nOTEYOUCANCHANGEBUTTSETTINGSFROMWITHINTHEPROGRAMTOOTHISISJUSTFORCONVENIENCEINMYCASEToolStripMenuItem;
        public System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.GroupBox senderGrpBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button vbBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ipLbl;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label noteLbl;
        public System.Windows.Forms.Button senderCfgBtn;
        public System.Windows.Forms.Button recieverCfgBtn;
        private System.Windows.Forms.Button remIceCastBtn;
        private System.Windows.Forms.Button remButtBtn;
        private System.Windows.Forms.Button remVlcBtn;
        private System.Windows.Forms.Button remVbBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button startSendingBtn;
        private System.Windows.Forms.Button startRecievingBtn;
        private System.Windows.Forms.GroupBox recieverGrpBox;
        public System.Windows.Forms.Button modifySenderConfBtn;
        public System.Windows.Forms.Button modifyRecieverConfBtn;
        private System.Windows.Forms.Label IPstaticNotifLbl;
        private System.Windows.Forms.Label refreshingLbl;
        private System.Windows.Forms.Panel panel1;
    }
}

