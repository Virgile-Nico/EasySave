using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Diagnostics;
using System.Threading;
using App_Easy_Save.Language;
using System.Globalization;
using System.Net.NetworkInformation;

namespace App_Easy_Save
{
    public class VueMain
    {
        //Function to initialize the app
        public static void Initialization()
        {
            Paths.Initialize();
            Prepare.Initialize();
            Log_Daily.Initialize();
            Log_Save.Initialize();
            
        }
        public static void Server_start()
        {
            Server.Init();
        }

        //function to prepare a save (call the prepare save function)
        public static String Prep_save(String Tpe, String src, String trg)
        {
            String Type = Tpe;
            String Source = src;
            String Target = trg;
            String Save_Name = Prepare.Preparing(Source, Target, Type);
            return (Save_Name);

        }

        public static void Del_save(int save_id)
        {
            Prepare.Del_prepared(save_id);
        }

        //Funciton to display the preparations informations
        public static string Display_preps()
        {
            String value = Prepare.Display_preps();
            return value;
        }

        public static void Save_info(String Save_name)
        {
            Prepare.Save_infos(Save_name);
        }

        public static void Edit_prep(String source, String Target, String Type, String Save_name)
        {
            Prepare.Edit_prep(source, Target, Type, Save_name);
        }

        //Variables to get the save informations globally
        public static String Type = "";
        public static String Source = "";
        public static String Target = "";

        //Function to do a single save
        public async static void Save_single(String Save_Name, Boolean encrypt)
        {
            Done = 0;
            To_Do = 0;
            Progress = 0;
            //Get the save informations by using it's name
            Prepare.Save_infos(Save_Name);

            //If the values are empty, returrn that the preparation has errors
            if (Type == "" || Source == "" || Target == "")
            {
                Trace.WriteLine("Error preparation");
            }

            //If the target is default, prepare the save path, using the default path + the save name
            //Create the save directory
            //Do the save
            if (Target == "DEFAULT")
            {
                string trgt = Paths.App_Path + @"Easy_Save\" + Paths.Default_save_path + @"\" + Save_Name;
                if (Directory.Exists(trgt) == false)
                {
                    Directory.CreateDirectory(trgt);
                }
                Save.save(Source, trgt, Type, Save_Name, encrypt);
                Trace.WriteLine("Done");
            }

            //Or, do the save, using the informations we got
            else
            {
                Save.save(Source, Target, Type, Save_Name, encrypt);
                Trace.WriteLine("Done");
            }

        }

        //Function to do all prepared saves
        public static String Save_all(Boolean encrypt)
        {
            Done = 0;
            To_Do = 0;
            Progress = 0;
            //get the number of saves
            int range = Prepare.Save_Number();

            //While to do all saves
            for (int i = 0; i < range; i++)
            {
                //set the save name to get informations
                String Save_Name = "Save#" + i;

                //Get save informations
                Prepare.Save_infos(Save_Name);

                //If the values are empty, returrn that the preparation has errors
                if (Type == "" || Source == "" || Target == "")
                {
                    return "Error preparation";
                }

                //If the target is default, prepare the save path, using the default path + the save name
                //Create the save directory
                //Do the save
                if (Target == "DEFAULT")
                {
                    string trgt = Paths.App_Path + @"Easy_Save\" + Paths.Default_save_path + @"\" + Save_Name;
                    if (Directory.Exists(trgt) == false)
                    {
                        Directory.CreateDirectory(trgt);
                    }
                    Save.save(Source, trgt, Type, Save_Name, encrypt);
                }

                //Or, do the save, using the informations we got
                else
                {
                    Save.save(Source, Target, Type, Save_Name, encrypt);
                }
            }
            return "Done";
        }

        public static String Save_sequence(int lower_save, int upper_save, Boolean encrypt)
        {
            Done = 0;
            To_Do = 0;
            Progress = 0;
            int range = upper_save + 1;

            //While to do all saves
            for (int i = lower_save; i < range; i++)
            {
                //set the save name to get informations
                String Save_Name = "Save#" + i;

                //Get save informations
                Prepare.Save_infos(Save_Name);

                //If the values are empty, returrn that the preparation has errors
                if (Type == "" || Source == "" || Target == "")
                {
                    return "Error preparation";
                }

                //If the target is default, prepare the save path, using the default path + the save name
                //Create the save directory
                //Do the save
                if (Target == "DEFAULT")
                {
                    string trgt = Paths.App_Path + @"Easy_Save\" + Paths.Default_save_path + @"\" + Save_Name;
                    if (Directory.Exists(trgt) == false)
                    {
                        Directory.CreateDirectory(trgt);
                    }
                    Save.save(Source, trgt, Type, Save_Name, encrypt);
                }

                //Or, do the save, using the informations we got
                else
                {
                    Save.save(Source, Target, Type, Save_Name, encrypt);
                }
            }
            return "Done";
        }

        //Function to set the default app folders location
        public static void Default_location(String dest)
        {
            //Set the default app destination
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Default_path");
            config.AppSettings.Settings.Add("Default_path", dest + @"\");
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            Initialization();
        }

        public static void Work_Process(String process)
        {
            //Set the work app name
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Work_Process");
            config.AppSettings.Settings.Add("Work_Process", process);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            Initialization();
        }

        public static int Prepared_number()
        {
            int nombre = Prepare.Save_Number() - 1;
            return nombre;
        }

        static String App_Language = "";

        public static void Default_language(String lang)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Default_Language");
            config.AppSettings.Settings.Add("Default_Language", lang);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            Initialization();



            App_Language = ConfigurationManager.AppSettings["Default_Language"];
            //Set the language for using the correct language file
            Text.Culture = new CultureInfo(App_Language);
            //Set all labels txt

            Application.Current.Dispatcher.Invoke(() =>
            {
                Window parentWindow = Application.Current.MainWindow;
                var yourInstanceOfWindow = (MainWindow)parentWindow;
                yourInstanceOfWindow.Setting_Lang.Content = Text.Settings_Language;
                yourInstanceOfWindow.New_save_btn.Content = Text.New_save_btn;
                yourInstanceOfWindow.Settings_label.Content = Text.Settings;
                yourInstanceOfWindow.Log_label.Content = Text.Log;
                yourInstanceOfWindow.Default_label.Content = Text.Default_folder;
                yourInstanceOfWindow.File_size_label.Content = Text.File_size;
                yourInstanceOfWindow.File_number_label.Content = Text.File_number;
                yourInstanceOfWindow.All_save_btn.Content = Text.All_btn;
                yourInstanceOfWindow.Scope_btn.Content = Text.Scope_btn;
                yourInstanceOfWindow.Progress_label.Content = Text.Progress;
                yourInstanceOfWindow.Simul_files.Text = ConfigurationManager.AppSettings["Files_same_time"];
                yourInstanceOfWindow.Size_files.Text = ConfigurationManager.AppSettings["Files_max_size"];
                yourInstanceOfWindow.Src_path.Text = ConfigurationManager.AppSettings["Default_path"];
            });
        }

        public static void Default_log_extension(String ext)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Default_log_extension");
            config.AppSettings.Settings.Add("Default_log_extension", ext);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            Initialization();
        }

        public static void Files_simul(String nbr)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Files_same_time");
            config.AppSettings.Settings.Add("Files_same_time", nbr);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }


        public static void Pause_btn_click()
        {
            Save.Pause.state = !Save.Pause.state;
            Save.pauseListener.PauseListen(Save.Pause);
        }

        public static void Stop_btn_click()
        {
            
            Save.Stop.state = true;
            Save.stopListener.StopListen(Save.Stop);
        }

        public static double Progress = 0;
        public static double Done = 0;
        public static double To_Do = 0;

        public static void ProgressConverter(int files_total)
        {
            Done++;
            if(Done != To_Do)
            {
                Progress = ((Done / (double)files_total) * 10);
            }
            else
            {
                Progress = 100;
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                Window parentWindow = Application.Current.MainWindow;
                var yourInstanceOfWindow = (MainWindow)parentWindow;
                yourInstanceOfWindow.Progress_bar.Value = Progress;
            });

            Server.ReseauSend(Server.client, "To_Do#" + To_Do);
            Server.ReseauSend(Server.client, "Done#" + Done);
            //Server.ReseauSend(Server.client, "Progress#" + Progress);
            
        }

        public static void Files_size(String nbr)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Files_max_size");
            config.AppSettings.Settings.Add("Files_max_size", nbr);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings"); 
        }

    }
}
