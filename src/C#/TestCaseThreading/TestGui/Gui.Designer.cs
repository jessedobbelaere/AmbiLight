namespace TestCaseThreading {
    partial class Gui {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gui));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.tabPageArduinoMode = new System.Windows.Forms.TabPage();
            this.groupBoxAModeConfig = new System.Windows.Forms.GroupBox();
            this.groupBoxAMode = new System.Windows.Forms.GroupBox();
            this.buttonModeStart = new System.Windows.Forms.Button();
            this.buttonModeStop = new System.Windows.Forms.Button();
            this.comboBoxAMode = new System.Windows.Forms.ComboBox();
            this.tabPageHTPCMode = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxMethode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRegioConfig = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonStartScreen = new System.Windows.Forms.Button();
            this.buttonStopScreen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSource = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.tabPageArduinoMode.SuspendLayout();
            this.groupBoxAMode.SuspendLayout();
            this.tabPageHTPCMode.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(404, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.serverToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click_1);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 433);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(404, 22);
            this.statusStrip.TabIndex = 13;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.textBoxLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageLog.Size = new System.Drawing.Size(376, 384);
            this.tabPageLog.TabIndex = 3;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(4, 14);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(370, 362);
            this.textBoxLog.TabIndex = 3;
            // 
            // tabPageArduinoMode
            // 
            this.tabPageArduinoMode.Controls.Add(this.groupBoxAModeConfig);
            this.tabPageArduinoMode.Controls.Add(this.groupBoxAMode);
            this.tabPageArduinoMode.Location = new System.Drawing.Point(4, 22);
            this.tabPageArduinoMode.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageArduinoMode.Name = "tabPageArduinoMode";
            this.tabPageArduinoMode.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageArduinoMode.Size = new System.Drawing.Size(376, 384);
            this.tabPageArduinoMode.TabIndex = 1;
            this.tabPageArduinoMode.Text = "Arduino Modes";
            this.tabPageArduinoMode.UseVisualStyleBackColor = true;
            // 
            // groupBoxAModeConfig
            // 
            this.groupBoxAModeConfig.Location = new System.Drawing.Point(5, 93);
            this.groupBoxAModeConfig.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxAModeConfig.Name = "groupBoxAModeConfig";
            this.groupBoxAModeConfig.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxAModeConfig.Size = new System.Drawing.Size(368, 246);
            this.groupBoxAModeConfig.TabIndex = 13;
            this.groupBoxAModeConfig.TabStop = false;
            this.groupBoxAModeConfig.Text = "Configuration";
            // 
            // groupBoxAMode
            // 
            this.groupBoxAMode.Controls.Add(this.buttonModeStart);
            this.groupBoxAMode.Controls.Add(this.buttonModeStop);
            this.groupBoxAMode.Controls.Add(this.comboBoxAMode);
            this.groupBoxAMode.Location = new System.Drawing.Point(5, 6);
            this.groupBoxAMode.Name = "groupBoxAMode";
            this.groupBoxAMode.Size = new System.Drawing.Size(368, 81);
            this.groupBoxAMode.TabIndex = 12;
            this.groupBoxAMode.TabStop = false;
            this.groupBoxAMode.Text = "Mode";
            // 
            // buttonModeStart
            // 
            this.buttonModeStart.Location = new System.Drawing.Point(191, 28);
            this.buttonModeStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonModeStart.Name = "buttonModeStart";
            this.buttonModeStart.Size = new System.Drawing.Size(56, 21);
            this.buttonModeStart.TabIndex = 7;
            this.buttonModeStart.Text = "Start";
            this.buttonModeStart.UseVisualStyleBackColor = true;
            this.buttonModeStart.Click += new System.EventHandler(this.buttonModeStartClick);
            // 
            // buttonModeStop
            // 
            this.buttonModeStop.Location = new System.Drawing.Point(251, 28);
            this.buttonModeStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonModeStop.Name = "buttonModeStop";
            this.buttonModeStop.Size = new System.Drawing.Size(56, 21);
            this.buttonModeStop.TabIndex = 8;
            this.buttonModeStop.Text = "Stop";
            this.buttonModeStop.UseVisualStyleBackColor = true;
            this.buttonModeStop.Click += new System.EventHandler(this.buttonModeStop_Click);
            // 
            // comboBoxAMode
            // 
            this.comboBoxAMode.FormattingEnabled = true;
            this.comboBoxAMode.Location = new System.Drawing.Point(17, 29);
            this.comboBoxAMode.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxAMode.Name = "comboBoxAMode";
            this.comboBoxAMode.Size = new System.Drawing.Size(150, 21);
            this.comboBoxAMode.TabIndex = 9;
            this.comboBoxAMode.SelectedIndexChanged += new System.EventHandler(this.updateAModeConfigUC);
            // 
            // tabPageHTPCMode
            // 
            this.tabPageHTPCMode.Controls.Add(this.groupBox2);
            this.tabPageHTPCMode.Controls.Add(this.groupBox1);
            this.tabPageHTPCMode.Location = new System.Drawing.Point(4, 22);
            this.tabPageHTPCMode.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageHTPCMode.Name = "tabPageHTPCMode";
            this.tabPageHTPCMode.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageHTPCMode.Size = new System.Drawing.Size(376, 384);
            this.tabPageHTPCMode.TabIndex = 0;
            this.tabPageHTPCMode.Text = "HTPC Mode";
            this.tabPageHTPCMode.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxMethode);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.panelRegioConfig);
            this.groupBox2.Location = new System.Drawing.Point(5, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 285);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Regio\'s";
            // 
            // comboBoxMethode
            // 
            this.comboBoxMethode.FormattingEnabled = true;
            this.comboBoxMethode.Location = new System.Drawing.Point(82, 26);
            this.comboBoxMethode.Name = "comboBoxMethode";
            this.comboBoxMethode.Size = new System.Drawing.Size(92, 21);
            this.comboBoxMethode.TabIndex = 9;
            this.comboBoxMethode.SelectedIndexChanged += new System.EventHandler(this.comboBoxMethode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Methode:";
            // 
            // panelRegioConfig
            // 
            this.panelRegioConfig.AutoScroll = true;
            this.panelRegioConfig.Location = new System.Drawing.Point(0, 52);
            this.panelRegioConfig.Margin = new System.Windows.Forms.Padding(2);
            this.panelRegioConfig.Name = "panelRegioConfig";
            this.panelRegioConfig.Size = new System.Drawing.Size(362, 228);
            this.panelRegioConfig.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonStartScreen);
            this.groupBox1.Controls.Add(this.buttonStopScreen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxSource);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 72);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ambilight";
            // 
            // buttonStartScreen
            // 
            this.buttonStartScreen.Location = new System.Drawing.Point(246, 27);
            this.buttonStartScreen.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStartScreen.Name = "buttonStartScreen";
            this.buttonStartScreen.Size = new System.Drawing.Size(56, 21);
            this.buttonStartScreen.TabIndex = 1;
            this.buttonStartScreen.Text = "Start";
            this.buttonStartScreen.UseVisualStyleBackColor = true;
            this.buttonStartScreen.Click += new System.EventHandler(this.buttonStartScreen_Click);
            // 
            // buttonStopScreen
            // 
            this.buttonStopScreen.Location = new System.Drawing.Point(306, 28);
            this.buttonStopScreen.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStopScreen.Name = "buttonStopScreen";
            this.buttonStopScreen.Size = new System.Drawing.Size(56, 21);
            this.buttonStopScreen.TabIndex = 2;
            this.buttonStopScreen.Text = "Stop";
            this.buttonStopScreen.UseVisualStyleBackColor = true;
            this.buttonStopScreen.Click += new System.EventHandler(this.buttonStopScreen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Source: ";
            // 
            // comboBoxSource
            // 
            this.comboBoxSource.FormattingEnabled = true;
            this.comboBoxSource.Location = new System.Drawing.Point(82, 28);
            this.comboBoxSource.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSource.Name = "comboBoxSource";
            this.comboBoxSource.Size = new System.Drawing.Size(147, 21);
            this.comboBoxSource.TabIndex = 5;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageHTPCMode);
            this.tabControl.Controls.Add(this.tabPageArduinoMode);
            this.tabControl.Controls.Add(this.tabPageLog);
            this.tabControl.Location = new System.Drawing.Point(9, 25);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(384, 410);
            this.tabControl.TabIndex = 14;
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 455);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Gui";
            this.Text = "Test Ambilight Threading";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPageLog.ResumeLayout(false);
            this.tabPageLog.PerformLayout();
            this.tabPageArduinoMode.ResumeLayout(false);
            this.groupBoxAMode.ResumeLayout(false);
            this.tabPageHTPCMode.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TabPage tabPageArduinoMode;
        private System.Windows.Forms.GroupBox groupBoxAModeConfig;
        private System.Windows.Forms.GroupBox groupBoxAMode;
        private System.Windows.Forms.Button buttonModeStart;
        private System.Windows.Forms.Button buttonModeStop;
        private System.Windows.Forms.ComboBox comboBoxAMode;
        private System.Windows.Forms.TabPage tabPageHTPCMode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonStartScreen;
        private System.Windows.Forms.Button buttonStopScreen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSource;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Panel panelRegioConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMethode;
    }
}

