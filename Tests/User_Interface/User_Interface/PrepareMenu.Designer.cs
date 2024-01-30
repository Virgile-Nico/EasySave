namespace User_Interface
{
    partial class PrepareMenu
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
            this.button1 = new System.Windows.Forms.Button();
            this.SaveModeComboBox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SourcePathTextBox = new System.Windows.Forms.TextBox();
            this.DestinationPathTextBox = new System.Windows.Forms.TextBox();
            this.DestinationPathModeComboBox = new System.Windows.Forms.ComboBox();
            this.ValidationLabel = new System.Windows.Forms.Label();
            this.ShowDataLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(305, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "Validate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SaveModeComboBox
            // 
            this.SaveModeComboBox.FormattingEnabled = true;
            this.SaveModeComboBox.Items.AddRange(new object[] {
            "Full Save",
            "Differential Save"});
            this.SaveModeComboBox.Location = new System.Drawing.Point(108, 98);
            this.SaveModeComboBox.Name = "SaveModeComboBox";
            this.SaveModeComboBox.Size = new System.Drawing.Size(581, 28);
            this.SaveModeComboBox.TabIndex = 3;
            this.SaveModeComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(305, 362);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 62);
            this.button2.TabIndex = 4;
            this.button2.Text = "Main Menu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(216, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 48);
            this.label1.TabIndex = 5;
            this.label1.Text = "PREPARE A SAVE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(108, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mode :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Source Path :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Destination Path :";
            // 
            // SourcePathTextBox
            // 
            this.SourcePathTextBox.Location = new System.Drawing.Point(108, 151);
            this.SourcePathTextBox.Name = "SourcePathTextBox";
            this.SourcePathTextBox.Size = new System.Drawing.Size(581, 27);
            this.SourcePathTextBox.TabIndex = 9;
            this.SourcePathTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // DestinationPathTextBox
            // 
            this.DestinationPathTextBox.Location = new System.Drawing.Point(108, 238);
            this.DestinationPathTextBox.Name = "DestinationPathTextBox";
            this.DestinationPathTextBox.Size = new System.Drawing.Size(581, 27);
            this.DestinationPathTextBox.TabIndex = 10;
            this.DestinationPathTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // DestinationPathModeComboBox
            // 
            this.DestinationPathModeComboBox.FormattingEnabled = true;
            this.DestinationPathModeComboBox.Items.AddRange(new object[] {
            "Default",
            "Custom"});
            this.DestinationPathModeComboBox.Location = new System.Drawing.Point(108, 204);
            this.DestinationPathModeComboBox.Name = "DestinationPathModeComboBox";
            this.DestinationPathModeComboBox.Size = new System.Drawing.Size(581, 28);
            this.DestinationPathModeComboBox.TabIndex = 11;
            this.DestinationPathModeComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // ValidationLabel
            // 
            this.ValidationLabel.AutoSize = true;
            this.ValidationLabel.Location = new System.Drawing.Point(520, 294);
            this.ValidationLabel.Name = "ValidationLabel";
            this.ValidationLabel.Size = new System.Drawing.Size(37, 20);
            this.ValidationLabel.TabIndex = 13;
            this.ValidationLabel.Text = "OK !";
            // 
            // ShowDataLabel
            // 
            this.ShowDataLabel.AutoSize = true;
            this.ShowDataLabel.Location = new System.Drawing.Point(12, 294);
            this.ShowDataLabel.Name = "ShowDataLabel";
            this.ShowDataLabel.Size = new System.Drawing.Size(158, 20);
            this.ShowDataLabel.TabIndex = 14;
            this.ShowDataLabel.Text = "DebugShowDataLabel";
            // 
            // PrepareMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShowDataLabel);
            this.Controls.Add(this.ValidationLabel);
            this.Controls.Add(this.DestinationPathModeComboBox);
            this.Controls.Add(this.DestinationPathTextBox);
            this.Controls.Add(this.SourcePathTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SaveModeComboBox);
            this.Controls.Add(this.button1);
            this.Name = "PrepareMenu";
            this.Text = "Easy Save";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private ComboBox SaveModeComboBox;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox SourcePathTextBox;
        private TextBox DestinationPathTextBox;
        private ComboBox DestinationPathModeComboBox;
        private Label ValidationLabel;
        private Label ShowDataLabel;
    }
}