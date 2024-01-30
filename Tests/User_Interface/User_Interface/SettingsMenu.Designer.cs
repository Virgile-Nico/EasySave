namespace User_Interface
{
    partial class SettingsMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.DefaultPathComboBox = new System.Windows.Forms.ComboBox();
            this.DefaultPathTextBox = new System.Windows.Forms.TextBox();
            this.ValidateButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LogComboBox = new System.Windows.Forms.ComboBox();
            this.ShowDataLabel = new System.Windows.Forms.Label();
            this.ValidationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(284, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "SETTINGS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Languages :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(123, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Default Path :";
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackButton.Location = new System.Drawing.Point(284, 355);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(227, 70);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Main Menu";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Items.AddRange(new object[] {
            "English",
            "Français",
            "Deutsch",
            "Italiano",
            "Spanish"});
            this.LanguageComboBox.Location = new System.Drawing.Point(123, 87);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(549, 28);
            this.LanguageComboBox.TabIndex = 4;
            this.LanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_SelectedIndexChanged);
            // 
            // DefaultPathComboBox
            // 
            this.DefaultPathComboBox.FormattingEnabled = true;
            this.DefaultPathComboBox.Items.AddRange(new object[] {
            "Default",
            "Custom"});
            this.DefaultPathComboBox.Location = new System.Drawing.Point(123, 138);
            this.DefaultPathComboBox.Name = "DefaultPathComboBox";
            this.DefaultPathComboBox.Size = new System.Drawing.Size(549, 28);
            this.DefaultPathComboBox.TabIndex = 5;
            this.DefaultPathComboBox.SelectedIndexChanged += new System.EventHandler(this.defaultPathMode_SelectedIndexChanged);
            // 
            // DefaultPathTextBox
            // 
            this.DefaultPathTextBox.Location = new System.Drawing.Point(123, 172);
            this.DefaultPathTextBox.Name = "DefaultPathTextBox";
            this.DefaultPathTextBox.Size = new System.Drawing.Size(549, 27);
            this.DefaultPathTextBox.TabIndex = 6;
            this.DefaultPathTextBox.TextChanged += new System.EventHandler(this.PathBox_TextChanged);
            // 
            // ValidateButton
            // 
            this.ValidateButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ValidateButton.Location = new System.Drawing.Point(284, 259);
            this.ValidateButton.Name = "ValidateButton";
            this.ValidateButton.Size = new System.Drawing.Size(227, 70);
            this.ValidateButton.TabIndex = 7;
            this.ValidateButton.Text = "Validate";
            this.ValidateButton.UseVisualStyleBackColor = true;
            this.ValidateButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Logs";
            // 
            // LogComboBox
            // 
            this.LogComboBox.FormattingEnabled = true;
            this.LogComboBox.Items.AddRange(new object[] {
            "JSON",
            "XML"});
            this.LogComboBox.Location = new System.Drawing.Point(123, 225);
            this.LogComboBox.Name = "LogComboBox";
            this.LogComboBox.Size = new System.Drawing.Size(549, 28);
            this.LogComboBox.TabIndex = 9;
            this.LogComboBox.SelectedIndexChanged += new System.EventHandler(this.LogComboBox_SelectedIndexChanged);
            // 
            // ShowDataLabel
            // 
            this.ShowDataLabel.AutoSize = true;
            this.ShowDataLabel.Location = new System.Drawing.Point(12, 286);
            this.ShowDataLabel.Name = "ShowDataLabel";
            this.ShowDataLabel.Size = new System.Drawing.Size(158, 20);
            this.ShowDataLabel.TabIndex = 10;
            this.ShowDataLabel.Text = "DebugShowDataLabel";
            this.ShowDataLabel.Click += new System.EventHandler(this.ShowDataLabel_Click);
            // 
            // ValidationLabel
            // 
            this.ValidationLabel.AutoSize = true;
            this.ValidationLabel.Location = new System.Drawing.Point(517, 286);
            this.ValidationLabel.Name = "ValidationLabel";
            this.ValidationLabel.Size = new System.Drawing.Size(37, 20);
            this.ValidationLabel.TabIndex = 11;
            this.ValidationLabel.Text = "OK !";
            // 
            // SettingsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ValidationLabel);
            this.Controls.Add(this.ShowDataLabel);
            this.Controls.Add(this.LogComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ValidateButton);
            this.Controls.Add(this.DefaultPathTextBox);
            this.Controls.Add(this.DefaultPathComboBox);
            this.Controls.Add(this.LanguageComboBox);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingsMenu";
            this.Text = "Easy Save";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button BackButton;
        private ComboBox LanguageComboBox;
        private ComboBox DefaultPathComboBox;
        private TextBox DefaultPathTextBox;
        private Button ValidateButton;
        private Label label4;
        private ComboBox LogComboBox;
        private Label label5;
        private Label ValidationLabel;
        private Label ShowDataLabel;
    }
}