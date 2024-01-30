using System;
using System.Diagnostics;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using App_Easy_Save.Language;
using Newtonsoft.Json;
using System.Threading;
using WpfSingleInstanceByEventWaitHandle;
using FolderBrowserEx;

namespace App_Easy_Save
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double Progress = 0;
        public static String[] Avail_laguages = { "Francais", "English", "Italiano", "Español", "Deutsch", "繁體中文" };
        public static String[] Avail_logs = { "json", "XML" };

        static String App_Language = "";
        public MainWindow()
        {
            InitializeComponent();

            WpfSingleInstance.Make("MyWpfApplication", uniquePerUser: false);
            VueMain.Initialization();
            VueMain.Server_start();

            App_Language = ConfigurationManager.AppSettings["Default_Language"];
            //Set the language for using the correct language file
            Text.Culture = new CultureInfo(App_Language.ToLower());
            VueMain.Default_language(App_Language);
            Progress_bar.Value = Progress;
            Lang_combo.ItemsSource = Avail_laguages;
            Log_combo.ItemsSource = Avail_logs;

            Prep_display();
        }

        public void Prep_display()
        {
            String Prepared_saves = "";
            Prepared_saves = VueMain.Display_preps();
            Prepare_template[] read_prepared_save = new Prepare_template[0];

            if(Prepared_saves != "")
            {
                read_prepared_save = JsonConvert.DeserializeObject<Prepare_template[]>(Prepared_saves);
            }

            Scope_first.Items.Clear();
            Scope_last.Items.Clear();
            int nbr = VueMain.Prepared_number();
            for (int i = 0; i <= nbr; i++)
            {
                Scope_first.Items.Add(i);
                Scope_last.Items.Add(i);
            }

            PrepList.ItemsSource = read_prepared_save;

        }

        private void Prep_Click(object sender, RoutedEventArgs e)
        {
            Prep_screen prep_win = new Prep_screen();
            prep_win.Owner = this;
            prep_win.Show();
        }

        private void Display_Click(object sender, RoutedEventArgs e)
        {
            Prep_display();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button del = (Button)sender;
            string saveName = del.Tag.ToString();
            String[] splited = saveName.Split("#");
            VueMain.Del_save(int.Parse(splited[1]));

            Prep_display();
        }

        public static void Progress_updater(double value)
        {
            Progress = value;
            Trace.WriteLine(Progress);
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            VueMain.Stop_btn_click();

            Prep_display();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Button del = (Button)sender;
            string saveName = del.Tag.ToString();

            VueMain.Save_info(saveName);
            string src = VueMain.Source;
            string trg = VueMain.Target;
            string type = VueMain.Type;

            Edit_Prep edit_win = new Edit_Prep(src, trg, type, saveName);
            edit_win.Owner = this;
            edit_win.Show();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton del = (ToggleButton)sender;
            
            string saveName = del.Tag.ToString();
            String[] splited = saveName.Split("#");

            if (del.Content == "Play.")
            {
                VueMain.Pause_btn_click();
            }
            else
            {
                VueMain.Save_single(saveName, false);
                
            }

            del.Content = "Pause";
        }
        private void pause_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton del = (ToggleButton)sender;
            del.Content = "Play.";

            VueMain.Pause_btn_click();
        }

        private void Scope_Save_btn(object sender, RoutedEventArgs e)
        {
            Boolean crypt = false;
            int Scope_first_nbr = int.Parse(Scope_first.SelectedItem.ToString());
            int Scope_last_nbr = int.Parse(Scope_last.SelectedItem.ToString());

            VueMain.Save_sequence(Scope_first_nbr, Scope_last_nbr, crypt);
        }

        private void All_saves_Click(object sender, RoutedEventArgs e)
        {
            Boolean crypt = false;
            VueMain.Save_all(crypt);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Lang_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String value = Lang_combo.SelectedItem.ToString();
            if (value == Avail_laguages[0])
            {
                VueMain.Default_language("FR");
            }
            if (value == Avail_laguages[1])
            {
                VueMain.Default_language("EN");
            }
            if (value == Avail_laguages[2])
            {
                VueMain.Default_language("IT");
            }
            if (value == Avail_laguages[3])
            {
                VueMain.Default_language("ES");
            }
            if (value == Avail_laguages[4])
            {
                VueMain.Default_language("DE");
            }
            if (value == Avail_laguages[5])
            {
                VueMain.Default_language("CT");
            }
        }

        private void Log_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String value = Log_combo.SelectedItem.ToString();
            if (value == Avail_logs[0])
            {
                VueMain.Default_log_extension(Avail_logs[0]);
            }
            if (value == Avail_logs[1])
            {
                VueMain.Default_log_extension(Avail_logs[1]);
            }
        }

        private void Simul_files_TextChanged(object sender, TextChangedEventArgs e)
        {
            String value = Simul_files.Text.ToString();

            Trace.WriteLine(value);
            VueMain.Files_simul(value);
        }

        private void Btn_src_folder_select_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Title = "Select a folder";
            folderBrowserDialog.InitialFolder = @"C:\";
            folderBrowserDialog.AllowMultiSelect = false;

            folderBrowserDialog.ShowDialog();
            Src_path.Text = folderBrowserDialog.SelectedFolder;
        }

        private void Src_path_TextChanged(object sender, TextChangedEventArgs e)
        {
            String value = Src_path.Text.ToString();

            Trace.WriteLine(value);
            VueMain.Default_location(value);
        }

        private void Size_files_TextChanged(object sender, TextChangedEventArgs e)
        {
            String value = Size_files.Text.ToString();

            Trace.WriteLine(value);

            VueMain.Files_size(value);
        }
    }
}
