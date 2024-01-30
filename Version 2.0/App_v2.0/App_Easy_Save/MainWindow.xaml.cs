using System;
using System.Diagnostics;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using App_Easy_Save.Language;
using Newtonsoft.Json;

namespace App_Easy_Save
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static String App_Language = "";
        
        public MainWindow()
        {
            VueMain.Initialization();
            
            
            App_Language = ConfigurationManager.AppSettings["Default_Language"];
            //Set the language for using the correct language file
            Text.Culture = new CultureInfo(App_Language.ToLower());

            InitializeComponent();
            Welcome.Text = Text.Welcome;
            Prep.Content = Text.Prepare;
            Save.Content = Text.Save;
            Display.Content = Text.Display;
            Settings.Content = Text.Settings;

            Prep_display();
        }

        public void Prep_display()
        {
            String Prepared_saves = "";
            Preps_display.Content = "";
            Prepared_saves = VueMain.Display_preps();
            Prepare_template[] read_prepared_save = new Prepare_template[0];
            
            if(Prepared_saves != "")
            {
                read_prepared_save = JsonConvert.DeserializeObject<Prepare_template[]>(Prepared_saves);
            }
            for (int i = 0; i < read_prepared_save.Length; i++)
            {
                Preps_display.Content = Preps_display.Content + Text.Divider;
                Preps_display.Content = Preps_display.Content + "\n";
                Preps_display.Content = Preps_display.Content + read_prepared_save[i].Savename;
                Preps_display.Content = Preps_display.Content + "\n";
                Preps_display.Content = Preps_display.Content + read_prepared_save[i].savetype;
                Preps_display.Content = Preps_display.Content + "\n";
                Preps_display.Content = Preps_display.Content + read_prepared_save[i].source_folder_path;
                Preps_display.Content = Preps_display.Content + "\n";
                Preps_display.Content = Preps_display.Content + read_prepared_save[i].target_folder_path;
                Preps_display.Content = Preps_display.Content + "\n";
            }
            Preps_display.Content = Preps_display.Content + Text.Divider;
        }

        private void Prep_Click(object sender, RoutedEventArgs e)
        {
            Prep_screen prep_win = new Prep_screen();
            prep_win.Owner = this;
            prep_win.Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            String Work_Process_Name = ConfigurationManager.AppSettings["Work_Process"];
            Process[] pname = Process.GetProcessesByName(Work_Process_Name);
            if(pname.Length > 0)
            {
                MessageBox.Show("Unable to save, the " + Work_Process_Name + " Process is currently running", "Save can't launch", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Save_screen save_win = new Save_screen();
                save_win.Owner = this;
                save_win.Show();
            }
        }

        private void Display_Click(object sender, RoutedEventArgs e)
        {
            Prep_display();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings_screen settings_win = new Settings_screen();
            settings_win.Owner = this;
            settings_win.Show();
        }
    }
}
