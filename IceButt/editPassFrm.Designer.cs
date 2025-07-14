namespace IceButt
{
    partial class editPassFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editPassFrm));
            this.adminpassTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceTxtBox = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.adminNameTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.relayBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.portTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.streamMountPointtxtBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.automaticSetIPStaticChckBox = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.streamDeskShortcutChckBox = new System.Windows.Forms.CheckBox();
            this.startMinimizedChckBOX = new System.Windows.Forms.CheckBox();
            this.runOnStartCheckBox = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.unsetBtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // adminpassTxtBox
            // 
            this.adminpassTxtBox.Location = new System.Drawing.Point(9, 75);
            this.adminpassTxtBox.Name = "adminpassTxtBox";
            this.adminpassTxtBox.Size = new System.Drawing.Size(211, 20);
            this.adminpassTxtBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Admin password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Source password (Used by BUTT):";
            // 
            // sourceTxtBox
            // 
            this.sourceTxtBox.Location = new System.Drawing.Point(9, 148);
            this.sourceTxtBox.Name = "sourceTxtBox";
            this.sourceTxtBox.Size = new System.Drawing.Size(211, 20);
            this.sourceTxtBox.TabIndex = 2;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(402, 369);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Admin username: (for web interface)";
            // 
            // adminNameTxtBox
            // 
            this.adminNameTxtBox.Location = new System.Drawing.Point(9, 32);
            this.adminNameTxtBox.Name = "adminNameTxtBox";
            this.adminNameTxtBox.Size = new System.Drawing.Size(211, 20);
            this.adminNameTxtBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Relay password:";
            // 
            // relayBox2
            // 
            this.relayBox2.Enabled = false;
            this.relayBox2.Location = new System.Drawing.Point(9, 196);
            this.relayBox2.Name = "relayBox2";
            this.relayBox2.Size = new System.Drawing.Size(211, 20);
            this.relayBox2.TabIndex = 7;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(122, 179);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Same as source";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.adminpassTxtBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.relayBox2);
            this.groupBox1.Controls.Add(this.sourceTxtBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.adminNameTxtBox);
            this.groupBox1.Location = new System.Drawing.Point(5, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 224);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Icecast Authentication";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.portTxtBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.streamMountPointtxtBox);
            this.groupBox2.Location = new System.Drawing.Point(238, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 224);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stream settings (Used by reciever)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Port:";
            // 
            // portTxtBox
            // 
            this.portTxtBox.Location = new System.Drawing.Point(6, 75);
            this.portTxtBox.Name = "portTxtBox";
            this.portTxtBox.Size = new System.Drawing.Size(84, 20);
            this.portTxtBox.TabIndex = 12;
            this.portTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.portTxtBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mountpoint:";
            // 
            // streamMountPointtxtBox
            // 
            this.streamMountPointtxtBox.Location = new System.Drawing.Point(6, 32);
            this.streamMountPointtxtBox.Name = "streamMountPointtxtBox";
            this.streamMountPointtxtBox.Size = new System.Drawing.Size(224, 20);
            this.streamMountPointtxtBox.TabIndex = 10;
            this.streamMountPointtxtBox.Text = "stream.mp3";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(7, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(388, 39);
            this.label7.TabIndex = 14;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.automaticSetIPStaticChckBox);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.streamDeskShortcutChckBox);
            this.groupBox3.Controls.Add(this.startMinimizedChckBOX);
            this.groupBox3.Controls.Add(this.runOnStartCheckBox);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(5, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(470, 82);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other settings";
            // 
            // automaticSetIPStaticChckBox
            // 
            this.automaticSetIPStaticChckBox.AutoSize = true;
            this.automaticSetIPStaticChckBox.Checked = true;
            this.automaticSetIPStaticChckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.automaticSetIPStaticChckBox.Location = new System.Drawing.Point(7, 40);
            this.automaticSetIPStaticChckBox.Name = "automaticSetIPStaticChckBox";
            this.automaticSetIPStaticChckBox.Size = new System.Drawing.Size(259, 17);
            this.automaticSetIPStaticChckBox.TabIndex = 7;
            this.automaticSetIPStaticChckBox.Text = "Automatically set static IP address (IMPORTANT)";
            this.automaticSetIPStaticChckBox.UseVisualStyleBackColor = true;
            this.automaticSetIPStaticChckBox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            this.automaticSetIPStaticChckBox.Click += new System.EventHandler(this.automaticSetIPStaticChckBox_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(364, 36);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Open BUTT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // streamDeskShortcutChckBox
            // 
            this.streamDeskShortcutChckBox.AutoSize = true;
            this.streamDeskShortcutChckBox.Checked = true;
            this.streamDeskShortcutChckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.streamDeskShortcutChckBox.Location = new System.Drawing.Point(7, 19);
            this.streamDeskShortcutChckBox.Name = "streamDeskShortcutChckBox";
            this.streamDeskShortcutChckBox.Size = new System.Drawing.Size(243, 17);
            this.streamDeskShortcutChckBox.TabIndex = 5;
            this.streamDeskShortcutChckBox.Text = "Create desktop shortcut for starting the stream";
            this.streamDeskShortcutChckBox.UseVisualStyleBackColor = true;
            // 
            // startMinimizedChckBOX
            // 
            this.startMinimizedChckBOX.AutoSize = true;
            this.startMinimizedChckBOX.Location = new System.Drawing.Point(159, 61);
            this.startMinimizedChckBOX.Name = "startMinimizedChckBOX";
            this.startMinimizedChckBOX.Size = new System.Drawing.Size(187, 17);
            this.startMinimizedChckBOX.TabIndex = 2;
            this.startMinimizedChckBOX.Text = "Start Icecast and BUTT minimized";
            this.startMinimizedChckBOX.UseVisualStyleBackColor = true;
            this.startMinimizedChckBOX.CheckedChanged += new System.EventHandler(this.startMinimizedChckBOX_CheckedChanged);
            // 
            // runOnStartCheckBox
            // 
            this.runOnStartCheckBox.AutoSize = true;
            this.runOnStartCheckBox.Location = new System.Drawing.Point(7, 61);
            this.runOnStartCheckBox.Name = "runOnStartCheckBox";
            this.runOnStartCheckBox.Size = new System.Drawing.Size(146, 17);
            this.runOnStartCheckBox.TabIndex = 1;
            this.runOnStartCheckBox.Text = "Start streaming on startup";
            this.runOnStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(364, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Edit icecast.xml";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // unsetBtn
            // 
            this.unsetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unsetBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.unsetBtn.ForeColor = System.Drawing.Color.Red;
            this.unsetBtn.Location = new System.Drawing.Point(132, 369);
            this.unsetBtn.Name = "unsetBtn";
            this.unsetBtn.Size = new System.Drawing.Size(217, 23);
            this.unsetBtn.TabIndex = 16;
            this.unsetBtn.Text = "UNSET FROM BEING A SENDER";
            this.unsetBtn.UseVisualStyleBackColor = true;
            this.unsetBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.button4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button4.Location = new System.Drawing.Point(441, 321);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 41);
            this.button4.TabIndex = 17;
            this.button4.Text = "?";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // editPassFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 395);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.unsetBtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "editPassFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurate Icecast and BUTT on sender";
            this.Load += new System.EventHandler(this.editPassFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox adminpassTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sourceTxtBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox adminNameTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox relayBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox portTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox streamMountPointtxtBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox runOnStartCheckBox;
        private System.Windows.Forms.CheckBox startMinimizedChckBOX;
        private System.Windows.Forms.Button unsetBtn;
        private System.Windows.Forms.CheckBox streamDeskShortcutChckBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox automaticSetIPStaticChckBox;
    }
}