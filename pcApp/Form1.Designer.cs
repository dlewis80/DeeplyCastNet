namespace AcousticModem
{
    partial class AcousticModemForm
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.StatusDisplay = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.ConnectionPanel = new System.Windows.Forms.Panel();
            this.BaudSelect = new System.Windows.Forms.ComboBox();
            this.COMSelect = new System.Windows.Forms.ComboBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.sendSerialButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BinCombo = new System.Windows.Forms.ComboBox();
            this.SettingsButtonPanel = new System.Windows.Forms.Panel();
            this.SendSettingsButton = new System.Windows.Forms.Button();
            this.ResetSettingsButton = new System.Windows.Forms.Button();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.A3TextBox = new System.Windows.Forms.TextBox();
            this.A2TextBox = new System.Windows.Forms.TextBox();
            this.A3Label = new System.Windows.Forms.Label();
            this.A1TextBox = new System.Windows.Forms.TextBox();
            this.A2Label = new System.Windows.Forms.Label();
            this.A1Label = new System.Windows.Forms.Label();
            this.FilterLabel = new System.Windows.Forms.Label();
            this.BinLabel = new System.Windows.Forms.Label();
            this.Target1Combo = new System.Windows.Forms.ComboBox();
            this.TargetLabel = new System.Windows.Forms.Label();
            this.IdComboBox = new System.Windows.Forms.ComboBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.TotalTextBox = new System.Windows.Forms.TextBox();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.SettingsLabel = new System.Windows.Forms.Label();
            this.EnergyLabel = new System.Windows.Forms.Label();
            this.EnergyCombo = new System.Windows.Forms.ComboBox();
            this.GainCombo = new System.Windows.Forms.ComboBox();
            this.GainLabel = new System.Windows.Forms.Label();
            this.Target2Combo = new System.Windows.Forms.ComboBox();
            this.StatusPanel.SuspendLayout();
            this.ConnectionPanel.SuspendLayout();
            this.MessagePanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SettingsButtonPanel.SuspendLayout();
            this.FilterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // StatusPanel
            // 
            this.StatusPanel.AutoSize = true;
            this.StatusPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StatusPanel.Controls.Add(this.StatusDisplay);
            this.StatusPanel.Controls.Add(this.StatusLabel);
            this.StatusPanel.Location = new System.Drawing.Point(3, 27);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(134, 30);
            this.StatusPanel.TabIndex = 1;
            // 
            // StatusDisplay
            // 
            this.StatusDisplay.AutoSize = true;
            this.StatusDisplay.BackColor = System.Drawing.Color.Red;
            this.StatusDisplay.Location = new System.Drawing.Point(46, 0);
            this.StatusDisplay.MinimumSize = new System.Drawing.Size(85, 30);
            this.StatusDisplay.Name = "StatusDisplay";
            this.StatusDisplay.Size = new System.Drawing.Size(85, 30);
            this.StatusDisplay.TabIndex = 1;
            this.StatusDisplay.Text = "Not Connected";
            this.StatusDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(5, 0);
            this.StatusLabel.MinimumSize = new System.Drawing.Size(40, 30);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(40, 30);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Status:";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.Location = new System.Drawing.Point(3, 60);
            this.connectButton.MaximumSize = new System.Drawing.Size(134, 30);
            this.connectButton.MinimumSize = new System.Drawing.Size(134, 30);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(134, 30);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // ConnectionPanel
            // 
            this.ConnectionPanel.AutoSize = true;
            this.ConnectionPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ConnectionPanel.Controls.Add(this.connectButton);
            this.ConnectionPanel.Controls.Add(this.StatusPanel);
            this.ConnectionPanel.Controls.Add(this.BaudSelect);
            this.ConnectionPanel.Controls.Add(this.COMSelect);
            this.ConnectionPanel.Location = new System.Drawing.Point(12, 12);
            this.ConnectionPanel.MinimumSize = new System.Drawing.Size(140, 0);
            this.ConnectionPanel.Name = "ConnectionPanel";
            this.ConnectionPanel.Size = new System.Drawing.Size(146, 93);
            this.ConnectionPanel.TabIndex = 3;
            // 
            // BaudSelect
            // 
            this.BaudSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaudSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudSelect.FormattingEnabled = true;
            this.BaudSelect.Location = new System.Drawing.Point(76, 0);
            this.BaudSelect.Name = "BaudSelect";
            this.BaudSelect.Size = new System.Drawing.Size(67, 21);
            this.BaudSelect.TabIndex = 7;
            // 
            // COMSelect
            // 
            this.COMSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMSelect.FormattingEnabled = true;
            this.COMSelect.Location = new System.Drawing.Point(0, 0);
            this.COMSelect.Name = "COMSelect";
            this.COMSelect.Size = new System.Drawing.Size(67, 21);
            this.COMSelect.Sorted = true;
            this.COMSelect.TabIndex = 6;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(63, 4);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(141, 20);
            this.messageTextBox.TabIndex = 4;
            this.messageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.messageTextBox_KeyPress);
            // 
            // MessagePanel
            // 
            this.MessagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MessagePanel.AutoSize = true;
            this.MessagePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MessagePanel.Controls.Add(this.logTextBox);
            this.MessagePanel.Controls.Add(this.sendSerialButton);
            this.MessagePanel.Controls.Add(this.label1);
            this.MessagePanel.Controls.Add(this.messageTextBox);
            this.MessagePanel.Location = new System.Drawing.Point(240, 12);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(255, 149);
            this.MessagePanel.TabIndex = 5;
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.BackColor = System.Drawing.Color.White;
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.logTextBox.DetectUrls = false;
            this.logTextBox.Location = new System.Drawing.Point(0, 30);
            this.logTextBox.MinimumSize = new System.Drawing.Size(250, 90);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.logTextBox.Size = new System.Drawing.Size(255, 100);
            this.logTextBox.TabIndex = 6;
            this.logTextBox.TabStop = false;
            this.logTextBox.Text = "";
            this.logTextBox.WordWrap = false;
            // 
            // sendSerialButton
            // 
            this.sendSerialButton.AutoSize = true;
            this.sendSerialButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sendSerialButton.Location = new System.Drawing.Point(210, 2);
            this.sendSerialButton.Name = "sendSerialButton";
            this.sendSerialButton.Size = new System.Drawing.Size(42, 23);
            this.sendSerialButton.TabIndex = 5;
            this.sendSerialButton.Text = "Send";
            this.sendSerialButton.UseVisualStyleBackColor = true;
            this.sendSerialButton.Click += new System.EventHandler(this.sendSerialButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Message:";
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.Target2Combo);
            this.panel4.Controls.Add(this.GainLabel);
            this.panel4.Controls.Add(this.SettingsButtonPanel);
            this.panel4.Controls.Add(this.FilterPanel);
            this.panel4.Controls.Add(this.GainCombo);
            this.panel4.Controls.Add(this.EnergyCombo);
            this.panel4.Controls.Add(this.EnergyLabel);
            this.panel4.Controls.Add(this.BinCombo);
            this.panel4.Controls.Add(this.BinLabel);
            this.panel4.Controls.Add(this.Target1Combo);
            this.panel4.Controls.Add(this.TargetLabel);
            this.panel4.Controls.Add(this.IdComboBox);
            this.panel4.Controls.Add(this.IdLabel);
            this.panel4.Controls.Add(this.TotalTextBox);
            this.panel4.Controls.Add(this.TotalLabel);
            this.panel4.Controls.Add(this.SettingsLabel);
            this.panel4.Location = new System.Drawing.Point(13, 109);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(215, 256);
            this.panel4.TabIndex = 6;
            // 
            // BinCombo
            // 
            this.BinCombo.FormattingEnabled = true;
            this.BinCombo.Location = new System.Drawing.Point(139, 93);
            this.BinCombo.Name = "BinCombo";
            this.BinCombo.Size = new System.Drawing.Size(48, 21);
            this.BinCombo.TabIndex = 15;
            // 
            // SettingsButtonPanel
            // 
            this.SettingsButtonPanel.AutoSize = true;
            this.SettingsButtonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SettingsButtonPanel.Controls.Add(this.SendSettingsButton);
            this.SettingsButtonPanel.Controls.Add(this.ResetSettingsButton);
            this.SettingsButtonPanel.Location = new System.Drawing.Point(6, 222);
            this.SettingsButtonPanel.Name = "SettingsButtonPanel";
            this.SettingsButtonPanel.Size = new System.Drawing.Size(204, 31);
            this.SettingsButtonPanel.TabIndex = 9;
            // 
            // SendSettingsButton
            // 
            this.SendSettingsButton.Location = new System.Drawing.Point(3, 3);
            this.SendSettingsButton.Name = "SendSettingsButton";
            this.SendSettingsButton.Size = new System.Drawing.Size(96, 25);
            this.SendSettingsButton.TabIndex = 7;
            this.SendSettingsButton.Text = "Send Settings";
            this.SendSettingsButton.UseVisualStyleBackColor = true;
            this.SendSettingsButton.Click += new System.EventHandler(this.SendSettingsButton_Click);
            // 
            // ResetSettingsButton
            // 
            this.ResetSettingsButton.Location = new System.Drawing.Point(105, 3);
            this.ResetSettingsButton.MinimumSize = new System.Drawing.Size(96, 25);
            this.ResetSettingsButton.Name = "ResetSettingsButton";
            this.ResetSettingsButton.Size = new System.Drawing.Size(96, 25);
            this.ResetSettingsButton.TabIndex = 8;
            this.ResetSettingsButton.Text = "Reset To Default";
            this.ResetSettingsButton.UseVisualStyleBackColor = true;
            // 
            // FilterPanel
            // 
            this.FilterPanel.AutoSize = true;
            this.FilterPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FilterPanel.Controls.Add(this.A3TextBox);
            this.FilterPanel.Controls.Add(this.A2TextBox);
            this.FilterPanel.Controls.Add(this.A3Label);
            this.FilterPanel.Controls.Add(this.A1TextBox);
            this.FilterPanel.Controls.Add(this.A2Label);
            this.FilterPanel.Controls.Add(this.A1Label);
            this.FilterPanel.Controls.Add(this.FilterLabel);
            this.FilterPanel.Location = new System.Drawing.Point(6, 176);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(204, 40);
            this.FilterPanel.TabIndex = 10;
            // 
            // A3TextBox
            // 
            this.A3TextBox.Location = new System.Drawing.Point(175, 17);
            this.A3TextBox.Name = "A3TextBox";
            this.A3TextBox.Size = new System.Drawing.Size(26, 20);
            this.A3TextBox.TabIndex = 12;
            // 
            // A2TextBox
            // 
            this.A2TextBox.Location = new System.Drawing.Point(103, 17);
            this.A2TextBox.Name = "A2TextBox";
            this.A2TextBox.Size = new System.Drawing.Size(26, 20);
            this.A2TextBox.TabIndex = 12;
            // 
            // A3Label
            // 
            this.A3Label.AutoSize = true;
            this.A3Label.Location = new System.Drawing.Point(145, 20);
            this.A3Label.Name = "A3Label";
            this.A3Label.Size = new System.Drawing.Size(23, 13);
            this.A3Label.TabIndex = 11;
            this.A3Label.Text = "A3:";
            // 
            // A1TextBox
            // 
            this.A1TextBox.Location = new System.Drawing.Point(33, 17);
            this.A1TextBox.Name = "A1TextBox";
            this.A1TextBox.Size = new System.Drawing.Size(26, 20);
            this.A1TextBox.TabIndex = 2;
            // 
            // A2Label
            // 
            this.A2Label.AutoSize = true;
            this.A2Label.Location = new System.Drawing.Point(73, 20);
            this.A2Label.Name = "A2Label";
            this.A2Label.Size = new System.Drawing.Size(23, 13);
            this.A2Label.TabIndex = 11;
            this.A2Label.Text = "A2:";
            // 
            // A1Label
            // 
            this.A1Label.AutoSize = true;
            this.A1Label.Location = new System.Drawing.Point(3, 20);
            this.A1Label.Name = "A1Label";
            this.A1Label.Size = new System.Drawing.Size(23, 13);
            this.A1Label.TabIndex = 1;
            this.A1Label.Text = "A1:";
            // 
            // FilterLabel
            // 
            this.FilterLabel.AutoSize = true;
            this.FilterLabel.Location = new System.Drawing.Point(3, 0);
            this.FilterLabel.Name = "FilterLabel";
            this.FilterLabel.Size = new System.Drawing.Size(56, 13);
            this.FilterLabel.TabIndex = 0;
            this.FilterLabel.Text = "Filter Taps";
            // 
            // BinLabel
            // 
            this.BinLabel.AutoSize = true;
            this.BinLabel.Location = new System.Drawing.Point(84, 96);
            this.BinLabel.Name = "BinLabel";
            this.BinLabel.Size = new System.Drawing.Size(48, 13);
            this.BinLabel.TabIndex = 10;
            this.BinLabel.Text = "Bin Size:";
            // 
            // Target1Combo
            // 
            this.Target1Combo.FormattingEnabled = true;
            this.Target1Combo.Location = new System.Drawing.Point(111, 65);
            this.Target1Combo.Name = "Target1Combo";
            this.Target1Combo.Size = new System.Drawing.Size(48, 21);
            this.Target1Combo.TabIndex = 14;
            // 
            // TargetLabel
            // 
            this.TargetLabel.AutoSize = true;
            this.TargetLabel.Location = new System.Drawing.Point(11, 68);
            this.TargetLabel.Name = "TargetLabel";
            this.TargetLabel.Size = new System.Drawing.Size(99, 13);
            this.TargetLabel.TabIndex = 10;
            this.TargetLabel.Text = "Target Frequencies";
            // 
            // IdComboBox
            // 
            this.IdComboBox.FormattingEnabled = true;
            this.IdComboBox.Location = new System.Drawing.Point(139, 39);
            this.IdComboBox.Name = "IdComboBox";
            this.IdComboBox.Size = new System.Drawing.Size(48, 21);
            this.IdComboBox.TabIndex = 13;
            this.IdComboBox.DropDown += new System.EventHandler(this.IdComboBox_DropDown);
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(33, 42);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(99, 13);
            this.IdLabel.TabIndex = 12;
            this.IdLabel.Text = "Modem ID Number:";
            // 
            // TotalTextBox
            // 
            this.TotalTextBox.Location = new System.Drawing.Point(139, 17);
            this.TotalTextBox.Name = "TotalTextBox";
            this.TotalTextBox.Size = new System.Drawing.Size(48, 20);
            this.TotalTextBox.TabIndex = 11;
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Location = new System.Drawing.Point(3, 20);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(129, 13);
            this.TotalLabel.TabIndex = 10;
            this.TotalLabel.Text = "Total Number of Modems:";
            // 
            // SettingsLabel
            // 
            this.SettingsLabel.Location = new System.Drawing.Point(3, 0);
            this.SettingsLabel.Name = "SettingsLabel";
            this.SettingsLabel.Size = new System.Drawing.Size(100, 23);
            this.SettingsLabel.TabIndex = 0;
            this.SettingsLabel.Text = "Modem Settings";
            // 
            // EnergyLabel
            // 
            this.EnergyLabel.AutoSize = true;
            this.EnergyLabel.Location = new System.Drawing.Point(48, 124);
            this.EnergyLabel.Name = "EnergyLabel";
            this.EnergyLabel.Size = new System.Drawing.Size(84, 13);
            this.EnergyLabel.TabIndex = 11;
            this.EnergyLabel.Text = "Energy Bin Size:";
            // 
            // EnergyCombo
            // 
            this.EnergyCombo.FormattingEnabled = true;
            this.EnergyCombo.Location = new System.Drawing.Point(139, 121);
            this.EnergyCombo.Name = "EnergyCombo";
            this.EnergyCombo.Size = new System.Drawing.Size(47, 21);
            this.EnergyCombo.TabIndex = 16;
            // 
            // GainCombo
            // 
            this.GainCombo.FormattingEnabled = true;
            this.GainCombo.Location = new System.Drawing.Point(139, 149);
            this.GainCombo.Name = "GainCombo";
            this.GainCombo.Size = new System.Drawing.Size(46, 21);
            this.GainCombo.TabIndex = 17;
            // 
            // GainLabel
            // 
            this.GainLabel.AutoSize = true;
            this.GainLabel.Location = new System.Drawing.Point(68, 152);
            this.GainLabel.Name = "GainLabel";
            this.GainLabel.Size = new System.Drawing.Size(64, 13);
            this.GainLabel.TabIndex = 18;
            this.GainLabel.Text = "Digital Gain:";
            // 
            // Target2Combo
            // 
            this.Target2Combo.FormattingEnabled = true;
            this.Target2Combo.Location = new System.Drawing.Point(164, 65);
            this.Target2Combo.Name = "Target2Combo";
            this.Target2Combo.Size = new System.Drawing.Size(48, 21);
            this.Target2Combo.TabIndex = 15;
            // 
            // AcousticModemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 367);
            this.Controls.Add(this.MessagePanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.ConnectionPanel);
            this.MinimumSize = new System.Drawing.Size(490, 300);
            this.Name = "AcousticModemForm";
            this.Text = "AcousticModem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            this.ConnectionPanel.ResumeLayout(false);
            this.ConnectionPanel.PerformLayout();
            this.MessagePanel.ResumeLayout(false);
            this.MessagePanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.SettingsButtonPanel.ResumeLayout(false);
            this.FilterPanel.ResumeLayout(false);
            this.FilterPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Panel StatusPanel;
        private System.Windows.Forms.Label StatusDisplay;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Panel ConnectionPanel;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Panel MessagePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendSerialButton;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.ComboBox BaudSelect;
        private System.Windows.Forms.ComboBox COMSelect;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label SettingsLabel;
        private System.Windows.Forms.Button SendSettingsButton;
        private System.Windows.Forms.Button ResetSettingsButton;
        private System.Windows.Forms.Panel SettingsButtonPanel;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.TextBox TotalTextBox;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Label TargetLabel;
        private System.Windows.Forms.ComboBox IdComboBox;
        private System.Windows.Forms.ComboBox Target1Combo;
        private System.Windows.Forms.ComboBox BinCombo;
        private System.Windows.Forms.Label BinLabel;
        private System.Windows.Forms.Panel FilterPanel;
        private System.Windows.Forms.TextBox A3TextBox;
        private System.Windows.Forms.TextBox A2TextBox;
        private System.Windows.Forms.Label A3Label;
        private System.Windows.Forms.TextBox A1TextBox;
        private System.Windows.Forms.Label A2Label;
        private System.Windows.Forms.Label A1Label;
        private System.Windows.Forms.Label FilterLabel;
        private System.Windows.Forms.Label GainLabel;
        private System.Windows.Forms.ComboBox GainCombo;
        private System.Windows.Forms.ComboBox EnergyCombo;
        private System.Windows.Forms.Label EnergyLabel;
        private System.Windows.Forms.ComboBox Target2Combo;
    }
}

