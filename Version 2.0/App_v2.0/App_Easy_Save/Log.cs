using System;
using System.IO;

using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace App_Easy_Save
{
    class Log_Save
    {
        //Variables of the paths for the logs
        public static string Log_Save_Path = "";
        public static string Log_extension = "";
        public static DateTime Today = DateTime.Now;
        public static string File_Name = "[" + Today.Day.ToString() + "-" + Today.Month.ToString() + "-" + Today.Year.ToString() + "] - Save Log";

        //Initialisation of thelog funcitons
        public static void Initialize()
        {
            Log_Save_Path = Paths.App_Path + @"Easy_Save\" + Paths.Log_Save_path + @"\";
            Log_extension = "json";

            //if file does not exist, create it
            if (File.Exists(Log_Save_Path + File_Name + "." + Log_extension) == false)
            {
                using (FileStream fs = File.Create(Log_Save_Path + File_Name + "." + Log_extension)) ;
            }
        }

        //Function to get the total file size of the folder to save
        private static String TotalFilesSize(string[] filesPath)
        {
            long size = 0;

            //getting all the files size, and adding them to the size variable
            foreach (string path in filesPath)
            {
                FileInfo info = new FileInfo(path);
                size += info.Length;
            }

            //Return the size as a string
            return size.ToString();
        }


        /// <summary>
        /// Funciton to create the Save Log
        /// </summary>
        /// <param name="saveName">Save name</param>
        /// <param name="Source">Source folder</param>
        /// <param name="target">Source target</param>
        public static void Log_Write(String saveName, String Source, String target)
        {
            //get the flie informations
            Log_Save_Template[] read_save_log = new Log_Save_Template[0];

            var read = "";

            read = File.ReadAllText(Log_Save_Path + File_Name + "." + Log_extension);
            if (read != "")
            {
                read_save_log = JsonConvert.DeserializeObject<Log_Save_Template[]>(read);
            }

            //Create the new log to add in the file
            Log_Save_Template Log = new Log_Save_Template
            {
                Save_Name = saveName,
                Start_Time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString(),
                End_Time = "",
                State = "Active",
                Source_Folder_Path = Source,
                Target_Folder_Path = target,
                Total_Files_To_Copy = File.Exists(Source) ? 1.ToString() : Directory.GetFiles(Source, "*.*", SearchOption.AllDirectories).Length.ToString(),
                Total_Files_Size = File.Exists(Source) ? new FileInfo(Source).Length.ToString() : TotalFilesSize(Directory.GetFiles(Source, "*.*", SearchOption.AllDirectories)),
                Files_Left_To_Do = File.Exists(Source) ? 1.ToString() : Directory.GetFiles(Source, "*.*", SearchOption.AllDirectories).Length.ToString(),
                Progress = "0%",
            };

            //get the array index to not overwrite a log
            int length = read_save_log.Length + 1;
            int index = length - 1;

            if (length == 1)
            {
                index = 0;
            }
            //resize the arry
            Array.Resize(ref read_save_log, length);

            //add the new log to the read data
            read_save_log[index] = Log;

            //write the data in the file
            using (StreamWriter LS = new StreamWriter(Log_Save_Path + File_Name + "." + Log_extension))
            {
                LS.WriteLine(JsonConvert.SerializeObject(read_save_log, Newtonsoft.Json.Formatting.Indented));
                LS.Close();
            }
        }


        /// <summary>
        /// Function to edit the save log
        /// </summary>
        /// <param name="saveName">Save name</param>
        /// <param name="Source">Source folder</param>
        /// <param name="target">Source target</param>
        public static void Log_update(String SaveName, String Source, String target)
        {
            //Prepare the Log to update, with static informations
            Log_Save_Template[] read_save_log = new Log_Save_Template[0];
            Log_Save_Template Log = new Log_Save_Template
            {
                Save_Name = SaveName,
                Start_Time = "",
                End_Time = "",
                State = "Active",
                Source_Folder_Path = Source,
                Target_Folder_Path = target,
                Total_Files_To_Copy = "",
                Total_Files_Size = "",
                Files_Left_To_Do = "",
                Progress = "",
            };

            //get the file data + set it in the array
            var read = "";

            read = File.ReadAllText(Log_Save_Path + File_Name + "." + Log_extension);
            if (read != "")
            {
                read_save_log = JsonConvert.DeserializeObject<Log_Save_Template[]>(read);
            }


            //get the total index in the log
            int length = read_save_log.Length + 1;
            int index = length - 1;

            //While to check all the structures
            for (int i = 0; i < index; i++)
            {
                //If the structure has the same savename as the one we wont to edit, edit the data
                if (read_save_log[i].Save_Name == SaveName)
                {
                    Log.Start_Time = read_save_log[i].Start_Time;
                    Log.Total_Files_To_Copy = read_save_log[i].Total_Files_To_Copy;
                    Log.Total_Files_Size = read_save_log[i].Total_Files_Size;
                    int value = (int.Parse(read_save_log[i].Total_Files_To_Copy) - 1);
                    Log.Files_Left_To_Do = value.ToString();
                    long progress = 100 * (1 - (value / int.Parse(read_save_log[i].Total_Files_To_Copy)));
                    Log.Progress = progress.ToString();

                    read_save_log[i] = Log;
                }
            }

            //write the data in the file
            using (StreamWriter LS = new StreamWriter(Log_Save_Path + File_Name + "." + Log_extension))
            {
                LS.WriteLine(JsonConvert.SerializeObject(read_save_log, Newtonsoft.Json.Formatting.Indented));
                LS.Close();
            }
        }

        /// <summary>
        /// Function to end the save in the log file
        /// </summary>
        /// <param name="saveName">Save name</param>
        /// <param name="Source">Source folder</param>
        /// <param name="target">Source target</param>
        public static void Log_End(String SaveName, String Source, String target)
        {
            //Prepare the Log to update, with static informations
            Log_Save_Template[] read_save_log = new Log_Save_Template[0];
            Log_Save_Template Log = new Log_Save_Template
            {
                Save_Name = SaveName,
                Start_Time = "",
                End_Time = "",
                State = "Active",
                Source_Folder_Path = Source,
                Target_Folder_Path = target,
                Total_Files_To_Copy = "",
                Total_Files_Size = "",
                Files_Left_To_Do = "",
                Progress = "",
            };

            //get the file data + set it in the array
            var read = "";
            read = File.ReadAllText(Log_Save_Path + File_Name + "." + Log_extension);
            if (read != "")
            {
                read_save_log = JsonConvert.DeserializeObject<Log_Save_Template[]>(read);
            }
            //get the total index in the log
            int length = read_save_log.Length + 1;
            int index = length - 1;

            //While to check all the structures
            for (int i = 0; i < index; i++)
            {
                //If the structure has the same savename as the one we wont to edit, edit the data
                if (read_save_log[i].Save_Name == SaveName)
                {
                    Log.Start_Time = read_save_log[i].Start_Time;
                    Log.End_Time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                    Log.State = "inactive";
                    Log.Total_Files_To_Copy = read_save_log[i].Total_Files_To_Copy;
                    Log.Total_Files_Size = read_save_log[i].Total_Files_Size;
                    Log.Files_Left_To_Do = "0";
                    Log.Progress = "100%";

                    read_save_log[i] = Log;
                }
            }

            //write the data in the file
            using (StreamWriter LS = new StreamWriter(Log_Save_Path + File_Name + "." + Log_extension))
            {
                LS.WriteLine(JsonConvert.SerializeObject(read_save_log, Newtonsoft.Json.Formatting.Indented));
                LS.Close();
            }
        }

    }

    class Log_Daily
    {
        //Variables of the paths for the logs
        public static string Log_Daily_Path = "";
        public static string Log_extension = "";
        public static DateTime Today = DateTime.Now;
        public static string File_Name = "[" + Today.Day.ToString() + "-" + Today.Month.ToString() + "-" + Today.Year.ToString() + "] - Daily Log";

        //Initialisation of thelog funcitons
        public static void Initialize()
        {
            Log_Daily_Path = Paths.App_Path + @"Easy_Save\" + Paths.Log_Daily_Path + @"\";
            Log_extension = ConfigurationManager.AppSettings["Default_log_extension"];

            //if files does not exist, create them
            if (File.Exists(Log_Daily_Path + @"\" + File_Name + "." + Log_extension) == false)
            {
                using (FileStream fs = File.Create(Log_Daily_Path + @"\" + File_Name + "." + Log_extension)) ;
            }

        }

        public static void Log_Write(String SaveName, String Source, String target, String TimeElapsed)
        {
            //get the flie informations
            Log_Daily_template[] read_daily_log = new Log_Daily_template[0];

            var read = "";

            if (Log_extension == "json")
            {
                read = File.ReadAllText(Log_Daily_Path + File_Name + "." + Log_extension);
                if (read != "")
                {
                    read_daily_log = JsonConvert.DeserializeObject<Log_Daily_template[]>(read);
                }
            }
            if (Log_extension == "XML")
            {
                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.LoadXml(Log_Daily_Path + File_Name + "." + Log_extension);
                    read = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, true);
                    read_daily_log = JsonConvert.DeserializeObject<Log_Daily_template[]>(read);
                }
                catch (XmlException exc)
                {
                    read = "";
                }
            }


            //Create the new log to add in the file
            Log_Daily_template Log = new Log_Daily_template
            {
                Timestamp = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "." + DateTime.Now.Millisecond.ToString(),
                Save_Name = SaveName,
                File_Source = Source,
                File_Target = target,
                File_Size = new FileInfo(Source).Length.ToString(),
                File_transfer_Time = TimeElapsed + " ms",
            };

            //get the array index to not overwrite a log
            int length = read_daily_log.Length + 1;
            int index = length - 1;

            if (length == 1)
            {
                index = 0;
            }

            //resize the arry
            Array.Resize(ref read_daily_log, length);

            //add the new log to the read data
            read_daily_log[index] = Log;

            //Write data
            if (Log_extension == "json")
            {
                //write the data in the file
                using (StreamWriter LS = new StreamWriter(Log_Daily_Path + File_Name + "." + Log_extension))
                {
                    LS.WriteLine(JsonConvert.SerializeObject(read_daily_log, Newtonsoft.Json.Formatting.Indented));
                    LS.Close();
                }
            }
            if (Log_extension == "XML")
            {

                for (int i = 0; i < read_daily_log.Length; i++)
                {
                    String savename = read_daily_log[i].Save_Name.Replace("#", "_");
                    XElement data = new XElement("Save",
                        new XElement("Save_Name", read_daily_log[i].Save_Name),
                        new XElement("Timestamp", read_daily_log[i].Timestamp),
                        new XElement("File_Source", read_daily_log[i].File_Source),
                        new XElement("File_Target", read_daily_log[i].File_Target),
                        new XElement("File_Size", read_daily_log[i].File_Size),
                        new XElement("File_Transfer_Time", read_daily_log[i].File_transfer_Time)
                    );


                    using (StreamWriter LS = new StreamWriter(Log_Daily_Path + File_Name + "." + Log_extension, true))
                    {
                        LS.Write(data.ToString(), System.Xml.Formatting.Indented);
                        LS.Close();
                    }
                }
            }
        }
    }

    //Class of the Save log template
    public class Log_Save_Template
    {
        public string Save_Name { get; set; } //Name of the save
        public string Start_Time { get; set; } //Time where the save started
        public string End_Time { get; set; } //Time where the save ended
        public string State { get; set; } //State of the save (Pending / Active / Done)

        //Files data
        public string Source_Folder_Path { get; set; } //Source folder of the copy
        public string Target_Folder_Path { get; set; } //Target folder of the save
        public string Total_Files_To_Copy { get; set; } //Total number of files to copy
        public string Total_Files_Size { get; set; } //Total size of the files
        public string Files_Left_To_Do { get; set; } //Number of files left to save
        public string Progress { get; set; } //progress of the save
    }

    //Class of the daily log template
    public class Log_Daily_template
    {
        public string Timestamp { get; set; }
        public string Save_Name { get; set; }
        public string File_Source { get; set; }
        public string File_Target { get; set; }
        public string File_Size { get; set; }
        public string File_transfer_Time { get; set; }
    }
}