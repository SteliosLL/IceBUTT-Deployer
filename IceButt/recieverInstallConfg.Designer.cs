namespace IceButt
{
    partial class recieverInstallConfg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(recieverInstallConfg));
            this.playStreamOnStartChckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.streamDeskShortcutChckBox = new System.Windows.Forms.CheckBox();
            this.startMinimizedChckBox = new System.Windows.Forms.CheckBox();
            this.ipAddressTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mountTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.portTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.unsetBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // playStreamOnStartChckBox
            // 
            this.playStreamOnStartChckBox.AutoSize = true;
            this.playStreamOnStartChckBox.Location = new System.Drawing.Point(7, 39);
            this.playStreamOnStartChckBox.Name = "playStreamOnStartChckBox";
            this.playStreamOnStartChckBox.Size = new System.Drawing.Size(202, 17);
            this.playStreamOnStartChckBox.TabIndex = 0;
            this.playStreamOnStartChckBox.Text = "Open VLC and play stream on startup";
            this.playStreamOnStartChckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(342, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.streamDeskShortcutChckBox);
            this.groupBox1.Controls.Add(this.startMinimizedChckBox);
            this.groupBox1.Controls.Add(this.playStreamOnStartChckBox);
            this.groupBox1.Location = new System.Drawing.Point(5, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 85);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extra options";
            // 
            // streamDeskShortcutChckBox
            // 
            this.streamDeskShortcutChckBox.AutoSize = true;
            this.streamDeskShortcutChckBox.Checked = true;
            this.streamDeskShortcutChckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.streamDeskShortcutChckBox.Location = new System.Drawing.Point(7, 18);
            this.streamDeskShortcutChckBox.Name = "streamDeskShortcutChckBox";
            this.streamDeskShortcutChckBox.Size = new System.Drawing.Size(304, 17);
            this.streamDeskShortcutChckBox.TabIndex = 2;
            this.streamDeskShortcutChckBox.Text = "Create desktop shortcut for opening and playing the stream";
            this.streamDeskShortcutChckBox.UseVisualStyleBackColor = true;
            // 
            // startMinimizedChckBox
            // 
            this.startMinimizedChckBox.AutoSize = true;
            this.startMinimizedChckBox.Location = new System.Drawing.Point(7, 60);
            this.startMinimizedChckBox.Name = "startMinimizedChckBox";
            this.startMinimizedChckBox.Size = new System.Drawing.Size(176, 17);
            this.startMinimizedChckBox.TabIndex = 1;
            this.startMinimizedChckBox.Text = "Open VLC minimized on the tray";
            this.startMinimizedChckBox.UseVisualStyleBackColor = true;
            this.startMinimizedChckBox.CheckedChanged += new System.EventHandler(this.startMinimizedChckBox_CheckedChanged);
            // 
            // ipAddressTxtBox
            // 
            this.ipAddressTxtBox.Location = new System.Drawing.Point(6, 34);
            this.ipAddressTxtBox.Name = "ipAddressTxtBox";
            this.ipAddressTxtBox.Size = new System.Drawing.Size(202, 20);
            this.ipAddressTxtBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sender\'s local IP address:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mountTxtBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.portTxtBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ipAddressTxtBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 75);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stream settings";
            // 
            // mountTxtBox
            // 
            this.mountTxtBox.Location = new System.Drawing.Point(294, 34);
            this.mountTxtBox.Name = "mountTxtBox";
            this.mountTxtBox.Size = new System.Drawing.Size(113, 20);
            this.mountTxtBox.TabIndex = 10;
            this.mountTxtBox.Text = "stream.mp3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mountpoint:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Make sure to set the sender\'s IP as static!";
            // 
            // portTxtBox
            // 
            this.portTxtBox.Location = new System.Drawing.Point(218, 34);
            this.portTxtBox.Name = "portTxtBox";
            this.portTxtBox.Size = new System.Drawing.Size(64, 20);
            this.portTxtBox.TabIndex = 7;
            this.portTxtBox.Text = "8000";
            this.portTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.portTxtBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sender port:";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(5, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // unsetBtn
            // 
            this.unsetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unsetBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.unsetBtn.ForeColor = System.Drawing.Color.Red;
            this.unsetBtn.Location = new System.Drawing.Point(103, 175);
            this.unsetBtn.Name = "unsetBtn";
            this.unsetBtn.Size = new System.Drawing.Size(215, 23);
            this.unsetBtn.TabIndex = 9;
            this.unsetBtn.Text = "UNSET FROM BEING A RECIEVER\r\n";
            this.unsetBtn.UseVisualStyleBackColor = true;
            this.unsetBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // recieverInstallConfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 201);
            this.Controls.Add(this.unsetBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "recieverInstallConfg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurate VLC on reciever";
            this.Load += new System.EventHandler(this.recieverInstallConfg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox playStreamOnStartChckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ipAddressTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox portTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mountTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox startMinimizedChckBox;
        private System.Windows.Forms.Button unsetBtn;
        private System.Windows.Forms.CheckBox streamDeskShortcutChckBox;
    }
}