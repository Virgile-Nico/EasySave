using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Interface
{
    public partial class SaveMenu : Form
    {
        public SaveMenu()
        {
            InitializeComponent();
            ShowDataLabel.Text = " ";
            ValidationLabel.Text = " ";
        }

        private void button1_Click(object sender, EventArgs e)
        { //Main Menu Button
            this.Close();
            //MainMenu back = new MainMenu();
            //back.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { //Validate Button
            String save_TypeOfSave;
            String save_SaveSlot;
            String save_SequenceBound1;
            String save_SequenceBound2;

            if (TypeOfSaveComboBox.SelectedItem != null)
            {
                save_TypeOfSave = TypeOfSaveComboBox.SelectedItem.ToString();
            }
            else
            {
                save_TypeOfSave = "PreviousTypeOfSave";
            }
            //ShowData(save_TypeOfSave);

            save_SaveSlot = SaveSlotTextBox.Text;
            //ShowData(save_SaveSlot);

            save_SequenceBound1 = SequenceBound1TextBox.Text;
            //ShowData(save_SequenceBound1);

            save_SequenceBound2 = SequenceBound2TextBox.Text;
            //ShowData(save_SequenceBound2);

            ShowValidation();
        }

        public void ShowData(string dataToShow)
        {
            label5.Text = dataToShow;
        }

        public void ShowValidation()
        {
            ValidationLabel.Text = "OK !";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ValidationLabel.Text = " ";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ValidationLabel.Text = " ";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ValidationLabel.Text = " ";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidationLabel.Text = " ";
        }
    }
}
