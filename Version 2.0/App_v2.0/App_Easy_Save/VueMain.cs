using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Diagnostics;

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

        //function to prepare a save (call the prepare save function)
        public static String Prep_save(String Tpe, String src, String trg)
        {
            String Type = Tpe;
            String Source = src;
            String Target = trg;
            String Save_Name = Prepare.Preparing(Source, Target, Type);
            return (Save_Name);

        }

        //Funciton to display the preparations informations
        public static string Display_preps()
        {
            String value = Prepare.Display_preps();
            return value;
        }

        //Variables to get the save informations globally
        public static String Type = "";
        public static String Source = "";
        public static String Target = "";

        //Function to do a single save
        public static String Save_single(String Save_Name, Boolean encrypt)
        {
            //Get the save informations by using it's name
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
                return "Done";
            }

            //Or, do the save, using the informations we got
            else
            {
                Save.save(Source, Target, Type, Save_Name, encrypt);
                return "Done";
            }

        }

        //Function to do all prepared saves
        public static String Save_all(Boolean encrypt)
        {
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
            config.AppSettings.Settings.Add("Default_path", dest);
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

        public static void Default_language(String lang)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Default_Language");
            config.AppSettings.Settings.Add("Default_Language", lang);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            Initialization();

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
    }
}
