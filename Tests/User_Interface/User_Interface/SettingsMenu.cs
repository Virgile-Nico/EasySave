using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace User_Interface
{
    public partial class SettingsMenu : Form
    {
        public SettingsMenu()
        {
            InitializeComponent();
            ShowDataLabel.Text = " ";
            ValidationLabel.Text = " ";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   //Main Menu Button
            //var back = new MainMenu();
            //back.Show();
            this.Close();
        }

        public void PathBox_TextChanged(object sender, EventArgs e)
        {
            ValidationLabel.Text = " ";
        }

        public void defaultPathMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidationLabel.Text = " ";
        }

        public void ShowData(string dataToShow)
        {
            label5.Text = dataToShow;
        }

        public void ShowValidation()
        {
            ValidationLabel.Text = "OK !";
        }

        private void button2_Click(object sender, EventArgs e)
        { //Validate Button
            String settings_SelectedLanguage;
            String settings_DefaultPathMode;
            String settings_DefaultPath;
            String settings_LogMode;

            if (LanguageComboBox.SelectedItem != null)
            {
                settings_SelectedLanguage = LanguageComboBox.SelectedItem.ToString();
            }
            else
            {
                settings_SelectedLanguage = "PreviousLanguage";
            }
            //ShowData(settings_SelectedLanguage);

                        if (DefaultPathComboBox.SelectedItem != null)
            {
                settings_DefaultPathMode = DefaultPathComboBox.SelectedItem.ToString();
            }
            else
            {
                settings_DefaultPathMode = "PreviousDefaultPath";
            }
            //ShowData(settings_DefaultPathMode);

            settings_DefaultPath = DefaultPathTextBox.Text;
            //ShowData(settings_DefaultPath);

            if (LogComboBox.SelectedItem != null)
            {
                settings_LogMode = LogComboBox.SelectedItem.ToString();
            }
            else
            {
                settings_LogMode = "PreviousLogMode";
            }
            //ShowData(settings_LogMode);

            ShowValidation();
        }

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidationLabel.Text = " ";
        }

        private void LogComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidationLabel.Text = " ";
        }

        private void ShowDataLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
