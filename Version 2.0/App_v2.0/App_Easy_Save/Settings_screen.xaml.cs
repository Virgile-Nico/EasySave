using System;
using System.Diagnostics;
using System.Configuration;
using System.Globalization;
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
using System.Windows.Navigation;
using App_Easy_Save.Language;

namespace App_Easy_Save
{
    /// <summary>
    /// Logique d'interaction pour Settings_screen.xaml
    /// </summary>
    public partial class Settings_screen : Window
    {
        static String App_Language = "";
        public Settings_screen()
        {
            InitializeComponent();

            App_Language = ConfigurationManager.AppSettings["Default_Language"];
            //Set the language for using the correct language file
            Text.Culture = new CultureInfo(App_Language.ToLower());
            Default_Language.Content = Text.Settings_Language;
            Default_language_button.Content = Text.Settings_Language_Button;
            Default_log_button.Content = Text.Settings_Language_Button;
            Default_path_button.Content = Text.Settings_Language_Button;
            Default_log_Type.Content = Text.Settings_Extension;
            Default_path_Type.Content = Text.Settings_path;
            Work_process_Type.Content = Text.Settings_process;
            work_process_button.Content = Text.Settings_Language_Button;

            Combo_Language.Items.Add("Français");
            Combo_Language.Items.Add("English");
            Combo_Language.Items.Add("Español");
            Combo_Language.Items.Add("Deutsch");
            Combo_Language.Items.Add("Italiano");

            Combo_Log.Items.Add("json");
            Combo_Log.Items.Add("XML");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String value = Combo_Language.SelectedItem.ToString();
            if (value == "Français")
            {
                VueMain.Default_language("FR");
            }
            if (value == "English")
            {
                VueMain.Default_language("EN");
            }
            if (value == "Español")
            {
                VueMain.Default_language("ES");
            }
            if (value == "Deutsch")
            {
                VueMain.Default_language("DE");
            }
            if (value == "Italiano")
            {
                VueMain.Default_language("IT");
            }
            Default_Language_return.Content = "Done, restart your app to apply changes !";
        }

        private void Default_log_button_Click(object sender, RoutedEventArgs e)
        {
            String value = Combo_Log.SelectedItem.ToString();
            VueMain.Default_log_extension(value);
            Default_Log_return.Content = "Done, restart your app to apply changes !";
        }

        private void Default_path_button_Click(object sender, RoutedEventArgs e)
        {
            String value = Default_path_input.Text.ToString();
            if(value != "")
            {
                VueMain.Default_location(value);
            }
            Default_path_return.Content = "Done, restart your app to apply changes !";
        }

        private void work_process_button_Click(object sender, RoutedEventArgs e)
        {
            String value = Work_process_input.Text.ToString();
            if(value != "")
            {
                VueMain.Work_Process(value);
            }
            work_process_return.Content = "Done, restart your app to apply changes !";
        }
    }
}
