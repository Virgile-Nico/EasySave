namespace User_Interface
{
    partial class SaveMenu
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
            this.BackButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TypeOfSaveComboBox = new System.Windows.Forms.ComboBox();
            this.SaveSlotTextBox = new System.Windows.Forms.TextBox();
            this.SequenceBound2TextBox = new System.Windows.Forms.TextBox();
            this.SequenceBound1TextBox = new System.Windows.Forms.TextBox();
            this.ValidateButton = new System.Windows.Forms.Button();
            this.ShowDataLabel = new System.Windows.Forms.Label();
            this.ValidationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackButton.Location = new System.Drawing.Point(285, 351);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(219, 70);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Main Menu";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(118, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(575, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "MAKE ONE OR MORE SAVES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Save Slot :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Type Of Save :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sequence :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "To";
            // 
            // TypeOfSaveComboBox
            // 
            this.TypeOfSaveComboBox.FormattingEnabled = true;
            this.TypeOfSaveComboBox.Items.AddRange(new object[] {
            "Single Save",
            "Sequence Of Saves",
            "All Saves"});
            this.TypeOfSaveComboBox.Location = new System.Drawing.Point(93, 102);
            this.TypeOfSaveComboBox.Name = "TypeOfSaveComboBox";
            this.TypeOfSaveComboBox.Size = new System.Drawing.Size(600, 28);
            this.TypeOfSaveComboBox.TabIndex = 6;
            this.TypeOfSaveComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // SaveSlotTextBox
            // 
            this.SaveSlotTextBox.Location = new System.Drawing.Point(93, 156);
            this.SaveSlotTextBox.Name = "SaveSlotTextBox";
            this.SaveSlotTextBox.Size = new System.Drawing.Size(600, 27);
            this.SaveSlotTextBox.TabIndex = 7;
            this.SaveSlotTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SequenceBound2TextBox
            // 
            this.SequenceBound2TextBox.Location = new System.Drawing.Point(432, 212);
            this.SequenceBound2TextBox.Name = "SequenceBound2TextBox";
            this.SequenceBound2TextBox.Size = new System.Drawing.Size(261, 27);
            this.SequenceBound2TextBox.TabIndex = 8;
            this.SequenceBound2TextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // SequenceBound1TextBox
            // 
            this.SequenceBound1TextBox.Location = new System.Drawing.Point(93, 209);
            this.SequenceBound1TextBox.Name = "SequenceBound1TextBox";
            this.SequenceBound1TextBox.Size = new System.Drawing.Size(252, 27);
            this.SequenceBound1TextBox.TabIndex = 9;
            this.SequenceBound1TextBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // ValidateButton
            // 
            this.ValidateButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ValidateButton.Location = new System.Drawing.Point(285, 245);
            this.ValidateButton.Name = "ValidateButton";
            this.ValidateButton.Size = new System.Drawing.Size(219, 70);
            this.ValidateButton.TabIndex = 10;
            this.ValidateButton.Text = "Validate";
            this.ValidateButton.UseVisualStyleBackColor = true;
            this.ValidateButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // ShowDataLabel
            // 
            this.ShowDataLabel.AutoSize = true;
            this.ShowDataLabel.Location = new System.Drawing.Point(12, 272);
            this.ShowDataLabel.Name = "ShowDataLabel";
            this.ShowDataLabel.Size = new System.Drawing.Size(158, 20);
            this.ShowDataLabel.TabIndex = 11;
            this.ShowDataLabel.Text = "DebugShowDataLabel";
            // 
            // ValidationLabel
            // 
            this.ValidationLabel.AutoSize = true;
            this.ValidationLabel.Location = new System.Drawing.Point(510, 272);
            this.ValidationLabel.Name = "ValidationLabel";
            this.ValidationLabel.Size = new System.Drawing.Size(37, 20);
            this.ValidationLabel.TabIndex = 12;
            this.ValidationLabel.Text = "OK !";
            // 
            // SaveMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ValidationLabel);
            this.Controls.Add(this.ShowDataLabel);
            this.Controls.Add(this.ValidateButton);
            this.Controls.Add(this.SequenceBound1TextBox);
            this.Controls.Add(this.SequenceBound2TextBox);
            this.Controls.Add(this.SaveSlotTextBox);
            this.Controls.Add(this.TypeOfSaveComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BackButton);
            this.Name = "SaveMenu";
            this.Text = "Easy Save";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BackButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox TypeOfSaveComboBox;
        private TextBox SaveSlotTextBox;
        private TextBox SequenceBound2TextBox;
        private TextBox SequenceBound1TextBox;
        private Button ValidateButton;
        private Label ShowDataLabel;
        private Label ValidationLabel;
    }
}