using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FolderBrowserEx;

namespace App_Easy_Save
{
    /// <summary>
    /// Logique d'interaction pour Prep_screen.xaml
    /// </summary>
    public partial class Prep_screen : Window
    {
        public Prep_screen()
        {
            InitializeComponent();

            Tpe_save.Items.Add("Full");
            Tpe_save.Items.Add("Diff");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String src = Src_input.Text.ToString();
            String trg = trg_input.Text.ToString();
            String tpe = Tpe_save.SelectedItem.ToString();
            if(tpe == "")
            {
                tpe = "Full";
            }
            if(trg == "")
            {
                trg = "DEFAULT";
            }
            VueMain.Prep_save(tpe, src, trg);
            ((MainWindow)this.Owner).Prep_display();
        }

        private void Src_btn_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Title = "Select a folder";
            folderBrowserDialog.InitialFolder = @"C:\";
            folderBrowserDialog.AllowMultiSelect = false;

            folderBrowserDialog.ShowDialog();
            Src_input.Text = folderBrowserDialog.SelectedFolder;

            
        }

        private void Trg_btn_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Title = "Select a folder";
            folderBrowserDialog.InitialFolder = @"C:\";
            folderBrowserDialog.AllowMultiSelect = false;

            folderBrowserDialog.ShowDialog();
            trg_input.Text = folderBrowserDialog.SelectedFolder;

        }
    }
}
