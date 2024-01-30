using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Interface
{
    public partial class PrepareMenu : Form
    {
        public PrepareMenu()
        {
            InitializeComponent();
            ShowDataLabel.Text = " ";
            ValidationLabel.Text = " ";
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidationLabel.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //MainMenu back= new MainMenu();
            //back.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { //Validate Button
            String prepare_SaveMode;
            String prepare_SourcePath;
            String prepare_DestinationPathMode;
            String prepare_DestinationPath;

            if (SaveModeComboBox.SelectedItem != null)
            {
                prepare_SaveMode = SaveModeComboBox.SelectedItem.ToString();
            }
            else
            {
                prepare_SaveMode = "PreviousTypeOfSave";
            }
            //ShowData(prepare_TypeOfSave);

            prepare_SourcePath = SourcePathTextBox.Text;
            //ShowData(prepare_SourcePath);

            prepare_DestinationPath = DestinationPathTextBox.Text;
            //ShowData(prepare_DestinationPath);

            if (DestinationPathModeComboBox.SelectedItem != null)
            {
                prepare_DestinationPathMode = DestinationPathModeComboBox.SelectedItem.ToString();
            }
            else
            {
                prepare_DestinationPathMode = "PreviousDestinationPathMode";
            }
            //ShowData(prepare_DestinationPathMode);

            ShowValidation();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ValidationLabel.Text = " ";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidationLabel.Text = " ";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ValidationLabel.Text = " ";
        }

        public void ShowData(string dataToShow)
        {
            ShowDataLabel.Text = dataToShow;
        }

        public void ShowValidation()
        {
            ValidationLabel.Text = "OK !";
        }
    }
}
