using App_Easy_Save.Language;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace App_Easy_Save
{
    
    /// <summary>
    /// Logique d'interaction pour Save_screen.xaml
    /// </summary>
    public partial class Save_screen : Window
    {
        static String App_Language = "";
        public Save_screen()
        {
            InitializeComponent();
            App_Language = ConfigurationManager.AppSettings["Default_Language"];
            Text.Culture = new CultureInfo(App_Language.ToLower());
            int nbr = VueMain.Prepared_number();

            for(int i = 0; i <= nbr; i++)
            {
                Single_save_combo.Items.Add(i);
                Scope_first.Items.Add(i);
                Scope_last.Items.Add(i);
            }

            Single_save.Content = Text.Single_save;
            Scope_save.Content = Text.Scope_save;
            All_save.Content = Text.All_save;


        }

        private void Single_save_Click(object sender, RoutedEventArgs e)
        {
            Boolean crypt = false;
            if(encrypt.IsChecked == true)
            {
                crypt = true;
            }
            String save_name = "Save#" + Single_save_combo.SelectedItem.ToString();
            VueMain.Save_single(save_name, crypt);
            this.Close();
        }

        private void Scope_save_Click(object sender, RoutedEventArgs e)
        {
            Boolean crypt = false;
            if (encrypt.IsChecked == true)
            {
                crypt = true;
            }
            int Scope_first_nbr = int.Parse(Scope_first.SelectedItem.ToString());
            int Scope_last_nbr = int.Parse(Scope_last.SelectedItem.ToString());

            VueMain.Save_sequence(Scope_first_nbr, Scope_last_nbr, crypt);
            this.Close();

        }

        private void All_save_Click(object sender, RoutedEventArgs e)
        {
            Boolean crypt = false;
            if (encrypt.IsChecked == true)
            {
                crypt = true;
            }
            VueMain.Save_all(crypt);
            this.Close();
        }
    }
}
