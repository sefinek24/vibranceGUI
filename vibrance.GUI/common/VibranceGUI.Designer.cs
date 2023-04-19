namespace vibrance.GUI.common
{
    partial class VibranceGUI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VibranceGUI));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.twitterToolStripTextBox = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.checkBoxAutostart = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxNeverChangeResolutions = new System.Windows.Forms.CheckBox();
            this.checkBoxPrimaryMonitorOnly = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelWindowsLevel = new System.Windows.Forms.Label();
            this.trackBarWindowsLevel = new System.Windows.Forms.TrackBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.observerStatusLabel = new System.Windows.Forms.Label();
            this.labelTwitter = new System.Windows.Forms.Label();
            this.linkLabelTwitter = new System.Windows.Forms.LinkLabel();
            this.settingsBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.buttonPaypal = new System.Windows.Forms.Button();
            this.labelPaypal = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonProcessExplorer = new System.Windows.Forms.Button();
            this.buttonRemoveProgram = new System.Windows.Forms.Button();
            this.listApplications = new System.Windows.Forms.ListView();
            this.buttonAddProgram = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWindowsLevel)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Running minimized... Like the program? Consider donating!";
            this.notifyIcon.BalloonTipTitle = "vibranceGUI";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "vibranceGUI";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.twitterToolStripTextBox,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(217, 48);
            this.contextMenuStrip.Text = "Vibrance Control";
            // 
            // twitterToolStripTextBox
            // 
            this.twitterToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.twitterToolStripTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(69)))), ((int)(((byte)(173)))));
            this.twitterToolStripTextBox.Image = ((System.Drawing.Image)(resources.GetObject("twitterToolStripTextBox.Image")));
            this.twitterToolStripTextBox.Name = "twitterToolStripTextBox";
            this.twitterToolStripTextBox.Size = new System.Drawing.Size(216, 22);
            this.twitterToolStripTextBox.Text = "https://twitter.com/juvlarN";
            this.twitterToolStripTextBox.Click += new System.EventHandler(this.twitterToolStripTextBox_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // checkBoxAutostart
            // 
            this.checkBoxAutostart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxAutostart.AutoSize = true;
            this.checkBoxAutostart.ForeColor = System.Drawing.Color.White;
            this.checkBoxAutostart.Location = new System.Drawing.Point(6, 19);
            this.checkBoxAutostart.Name = "checkBoxAutostart";
            this.checkBoxAutostart.Size = new System.Drawing.Size(131, 17);
            this.checkBoxAutostart.TabIndex = 8;
            this.checkBoxAutostart.Text = "Autostart vibranceGUI";
            this.checkBoxAutostart.UseVisualStyleBackColor = true;
            this.checkBoxAutostart.CheckedChanged += new System.EventHandler(this.checkBoxAutostart_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.checkBoxNeverChangeResolutions);
            this.groupBox1.Controls.Add(this.checkBoxPrimaryMonitorOnly);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.checkBoxAutostart);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 146);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // checkBoxNeverChangeResolutions
            // 
            this.checkBoxNeverChangeResolutions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxNeverChangeResolutions.AutoSize = true;
            this.checkBoxNeverChangeResolutions.ForeColor = System.Drawing.Color.White;
            this.checkBoxNeverChangeResolutions.Location = new System.Drawing.Point(163, 42);
            this.checkBoxNeverChangeResolutions.Name = "checkBoxNeverChangeResolutions";
            this.checkBoxNeverChangeResolutions.Size = new System.Drawing.Size(147, 17);
            this.checkBoxNeverChangeResolutions.TabIndex = 16;
            this.checkBoxNeverChangeResolutions.Text = "Never change resolutions";
            this.toolTip.SetToolTip(this.checkBoxNeverChangeResolutions, "When checking this, VibranceGUI will never change the resolution on any of your m" +
        "onitors.");
            this.checkBoxNeverChangeResolutions.UseVisualStyleBackColor = true;
            this.checkBoxNeverChangeResolutions.CheckedChanged += new System.EventHandler(this.checkBoxNeverChangeResolutions_CheckedChanged);
            // 
            // checkBoxPrimaryMonitorOnly
            // 
            this.checkBoxPrimaryMonitorOnly.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxPrimaryMonitorOnly.AutoSize = true;
            this.checkBoxPrimaryMonitorOnly.ForeColor = System.Drawing.Color.White;
            this.checkBoxPrimaryMonitorOnly.Location = new System.Drawing.Point(6, 42);
            this.checkBoxPrimaryMonitorOnly.Name = "checkBoxPrimaryMonitorOnly";
            this.checkBoxPrimaryMonitorOnly.Size = new System.Drawing.Size(151, 17);
            this.checkBoxPrimaryMonitorOnly.TabIndex = 15;
            this.checkBoxPrimaryMonitorOnly.Text = "Affect Primary Monitor only";
            this.toolTip.SetToolTip(this.checkBoxPrimaryMonitorOnly, "When checking this, VibranceGUI will only change vibrance values on your primary " +
        "monitor.");
            this.checkBoxPrimaryMonitorOnly.UseVisualStyleBackColor = true;
            this.checkBoxPrimaryMonitorOnly.CheckedChanged += new System.EventHandler(this.checkBoxPrimaryMonitorOnly_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.labelWindowsLevel);
            this.groupBox3.Controls.Add(this.trackBarWindowsLevel);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(6, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 72);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Windows vibrance level";
            // 
            // labelWindowsLevel
            // 
            this.labelWindowsLevel.AutoSize = true;
            this.labelWindowsLevel.Location = new System.Drawing.Point(148, 22);
            this.labelWindowsLevel.Name = "labelWindowsLevel";
            this.labelWindowsLevel.Size = new System.Drawing.Size(0, 13);
            this.labelWindowsLevel.TabIndex = 1;
            // 
            // trackBarWindowsLevel
            // 
            this.trackBarWindowsLevel.Location = new System.Drawing.Point(6, 22);
            this.trackBarWindowsLevel.Maximum = 63;
            this.trackBarWindowsLevel.Name = "trackBarWindowsLevel";
            this.trackBarWindowsLevel.Size = new System.Drawing.Size(371, 45);
            this.trackBarWindowsLevel.TabIndex = 0;
            this.trackBarWindowsLevel.Scroll += new System.EventHandler(this.trackBarWindowsLevel_Scroll);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(122, 518);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(61, 13);
            this.statusLabel.TabIndex = 14;
            this.statusLabel.Text = "Initializing...";
            // 
            // observerStatusLabel
            // 
            this.observerStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.observerStatusLabel.AutoSize = true;
            this.observerStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.observerStatusLabel.ForeColor = System.Drawing.Color.White;
            this.observerStatusLabel.Location = new System.Drawing.Point(12, 518);
            this.observerStatusLabel.Name = "observerStatusLabel";
            this.observerStatusLabel.Size = new System.Drawing.Size(104, 13);
            this.observerStatusLabel.TabIndex = 13;
            this.observerStatusLabel.Text = "Observer status: ";
            // 
            // labelTwitter
            // 
            this.labelTwitter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTwitter.AutoSize = true;
            this.labelTwitter.ForeColor = System.Drawing.Color.White;
            this.labelTwitter.Location = new System.Drawing.Point(9, 11);
            this.labelTwitter.Name = "labelTwitter";
            this.labelTwitter.Size = new System.Drawing.Size(192, 13);
            this.labelTwitter.TabIndex = 11;
            this.labelTwitter.Text = "Follow @juvlarN on twitter for updates: ";
            // 
            // linkLabelTwitter
            // 
            this.linkLabelTwitter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabelTwitter.AutoSize = true;
            this.linkLabelTwitter.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabelTwitter.Location = new System.Drawing.Point(208, 11);
            this.linkLabelTwitter.Name = "linkLabelTwitter";
            this.linkLabelTwitter.Size = new System.Drawing.Size(132, 13);
            this.linkLabelTwitter.TabIndex = 10;
            this.linkLabelTwitter.TabStop = true;
            this.linkLabelTwitter.Text = "https://twitter.com/juvlarN";
            this.linkLabelTwitter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelTwitter_LinkClicked);
            // 
            // settingsBackgroundWorker
            // 
            this.settingsBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.settingsBackgroundWorker_DoWork);
            this.settingsBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.settingsBackgroundWorker_RunWorkerCompleted);
            // 
            // buttonPaypal
            // 
            this.buttonPaypal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPaypal.BackColor = System.Drawing.Color.Transparent;
            this.buttonPaypal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPaypal.Image = ((System.Drawing.Image)(resources.GetObject("buttonPaypal.Image")));
            this.buttonPaypal.Location = new System.Drawing.Point(211, 31);
            this.buttonPaypal.Name = "buttonPaypal";
            this.buttonPaypal.Size = new System.Drawing.Size(80, 48);
            this.buttonPaypal.TabIndex = 16;
            this.toolTip.SetToolTip(this.buttonPaypal, "Click here to donate to vibranceGUI through Paypal");
            this.buttonPaypal.UseVisualStyleBackColor = false;
            this.buttonPaypal.Click += new System.EventHandler(this.buttonPaypal_Click);
            // 
            // labelPaypal
            // 
            this.labelPaypal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPaypal.AutoSize = true;
            this.labelPaypal.ForeColor = System.Drawing.Color.White;
            this.labelPaypal.Location = new System.Drawing.Point(9, 34);
            this.labelPaypal.Name = "labelPaypal";
            this.labelPaypal.Size = new System.Drawing.Size(183, 13);
            this.labelPaypal.TabIndex = 17;
            this.labelPaypal.Text = "Like the program? Consider donating:";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox5.Controls.Add(this.buttonProcessExplorer);
            this.groupBox5.Controls.Add(this.buttonRemoveProgram);
            this.groupBox5.Controls.Add(this.listApplications);
            this.groupBox5.Controls.Add(this.buttonAddProgram);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(12, 336);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(395, 172);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Programs";
            // 
            // buttonProcessExplorer
            // 
            this.buttonProcessExplorer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonProcessExplorer.ForeColor = System.Drawing.Color.Black;
            this.buttonProcessExplorer.Location = new System.Drawing.Point(6, 20);
            this.buttonProcessExplorer.Name = "buttonProcessExplorer";
            this.buttonProcessExplorer.Size = new System.Drawing.Size(94, 23);
            this.buttonProcessExplorer.TabIndex = 3;
            this.buttonProcessExplorer.Text = "Add";
            this.buttonProcessExplorer.UseVisualStyleBackColor = true;
            this.buttonProcessExplorer.Click += new System.EventHandler(this.buttonProcessExplorer_Click);
            // 
            // buttonRemoveProgram
            // 
            this.buttonRemoveProgram.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRemoveProgram.ForeColor = System.Drawing.Color.Black;
            this.buttonRemoveProgram.Location = new System.Drawing.Point(295, 19);
            this.buttonRemoveProgram.Name = "buttonRemoveProgram";
            this.buttonRemoveProgram.Size = new System.Drawing.Size(94, 23);
            this.buttonRemoveProgram.TabIndex = 2;
            this.buttonRemoveProgram.Text = "Remove";
            this.buttonRemoveProgram.UseVisualStyleBackColor = true;
            this.buttonRemoveProgram.Click += new System.EventHandler(this.buttonRemoveProgram_Click);
            // 
            // listApplications
            // 
            this.listApplications.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listApplications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.listApplications.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listApplications.HideSelection = false;
            this.listApplications.Location = new System.Drawing.Point(6, 49);
            this.listApplications.Name = "listApplications";
            this.listApplications.Size = new System.Drawing.Size(383, 117);
            this.listApplications.TabIndex = 1;
            this.listApplications.UseCompatibleStateImageBehavior = false;
            this.listApplications.DoubleClick += new System.EventHandler(this.listApplications_DoubleClick);
            // 
            // buttonAddProgram
            // 
            this.buttonAddProgram.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddProgram.ForeColor = System.Drawing.Color.Black;
            this.buttonAddProgram.Location = new System.Drawing.Point(151, 20);
            this.buttonAddProgram.Name = "buttonAddProgram";
            this.buttonAddProgram.Size = new System.Drawing.Size(94, 23);
            this.buttonAddProgram.TabIndex = 0;
            this.buttonAddProgram.Text = "Add manually";
            this.buttonAddProgram.UseVisualStyleBackColor = true;
            this.buttonAddProgram.Click += new System.EventHandler(this.buttonAddProgram_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 26);
            this.label1.TabIndex = 19;
            this.label1.Text = "Improved version by Sefinek.\r\nPoprawiona wersja przez Sefinek.";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabel1.Location = new System.Drawing.Point(208, 85);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(95, 13);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://sefinek.net";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSefinek_LinkClicked);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(395, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "You can find the latest versions on GitHub.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabel2.Location = new System.Drawing.Point(12, 146);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(395, 21);
            this.linkLabel2.TabIndex = 22;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://github.com/sefinek24/vibranceGUI";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGitHub_LinkClicked);
            // 
            // VibranceGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(419, 543);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.labelPaypal);
            this.Controls.Add(this.buttonPaypal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.observerStatusLabel);
            this.Controls.Add(this.labelTwitter);
            this.Controls.Add(this.linkLabelTwitter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VibranceGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "vibranceGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWindowsLevel)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem twitterToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.CheckBox checkBoxAutostart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelWindowsLevel;
        private System.Windows.Forms.TrackBar trackBarWindowsLevel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label observerStatusLabel;
        private System.Windows.Forms.Label labelTwitter;
        private System.Windows.Forms.LinkLabel linkLabelTwitter;
        private System.ComponentModel.BackgroundWorker settingsBackgroundWorker;
        private System.Windows.Forms.Button buttonPaypal;
        private System.Windows.Forms.Label labelPaypal;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox checkBoxPrimaryMonitorOnly;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonRemoveProgram;
        private System.Windows.Forms.ListView listApplications;
        private System.Windows.Forms.Button buttonAddProgram;
        private System.Windows.Forms.Button buttonProcessExplorer;
        private System.Windows.Forms.CheckBox checkBoxNeverChangeResolutions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}

