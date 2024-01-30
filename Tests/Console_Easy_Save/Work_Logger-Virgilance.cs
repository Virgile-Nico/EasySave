using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Console_Easy_Save
{
    class Work_Logger
    {
        //Variable to store the path of the current day log file
        public static String Work_Log_path = "";

        //Function for initialisation
        public static void Initialize()
        {
            //loading the date to create the file name
            DateTime date = DateTime.Today;
            //Creating the file name by assembling data from the date
            String file_Name = date.Day + "-" + date.Month + "-" + date.Year;

            //Updating the Log_path variable to get the new path, to reuse it further on
            Work_Log_path = Paths.App_Path + "\\" + Paths.Work_Log_Path + "\\" + file_Name + ".json";

            //Checking if the file doesn't exists
            if (File.Exists(Work_Log_path) == false)
            {
                //if it doesn't exists, creating a new file
                using (FileStream fs2 = File.Create(Work_Log_path));

            }
            else
            {
                //otherwise, do nothing
            }
        }

        //Logging function to Log data in the Work_Log file
        public static void WorkLogger(String Name, String State, String Source, String Target, String Size, float Files_Total, float Files_Left)
        {
            Work_Log_template[] read_Work_log = new Work_Log_template[0];
            var Read = File.ReadAllText(Work_Log_path);
            if(Read != "")
            {
                read_Work_log = JsonConvert.DeserializeObject<Work_Log_template[]>(Read);
            }
            
            

            //Getting the time to do the timestamp and the time where the transfer finished
            String Time = "";
            DateTime now = DateTime.Now;
            DateTime date = DateTime.Today;
            //formating the time
            Time = now.Hour + ":" + now.Minute + ":" + now.Second;

            //Calculating the progress of the save
            float Progress = Files_Left * 100 / Files_Total;

            //Creating the Log object, using the template created
            Work_Log_template Log = new Work_Log_template
            {
                Save_Name = Name,
                Start_Time = Time,
                End_Time = "",
                State = State,
                Source_Folder_Path = Source,
                Target_Folder_Path = Target,
                Total_Files_To_Copy = Files_Total.ToString(),
                Total_Files_Size = Size,
                Files_Left_To_Do = Files_Left.ToString(),
                Progress = Progress.ToString(),
            };

            int length = read_Work_log.Length + 1;
            int index = length - 1;
            if (length == 1)
            {
                index = 0;
            }
            Array.Resize(ref read_Work_log, length);
            
            read_Work_log[index] = Log;

            //Creating the writer to write in the file, using the saved path, and using the option "true" to not overwrite the written data
            using (StreamWriter WL = new StreamWriter(Work_Log_path))
            {
                //Wrinting the object in the file by serializing the log object, with indentation
                WL.WriteLine(JsonConvert.SerializeObject(read_Work_log, Formatting.Indented));

                //Closing the File
                WL.Close();
            }
        }

        public static void Update_Worklogger() //String Name, String State, String Size, float Files_Left
        {
            Work_Log_template[] read_Work_log;
            var Read = File.ReadAllText(Work_Log_path);
            read_Work_log = JsonConvert.DeserializeObject<Work_Log_template[]>(Read);


            Console.WriteLine(JsonConvert.SerializeObject(read_Work_log[0], Formatting.Indented));
            Console.WriteLine(read_Work_log[0].Save_Name);

        }
    }

    //Template for the Log we're gonna use
    class Work_Log_template
    {
        //Save data 
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
}
