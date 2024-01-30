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
                using (FileStream fs2 = File.Create(Work_Log_path)) ;

            }
            else
            {
                //otherwise, do nothing
            }
        }

        //Logging function to Log data in the Work_Log file
        public static void WorkLogger(String Name, String State, String Source, String Target, String Size, float Files_Total, float Files_Left)
        {
            //Reading the Log file
            Work_Log_template[] read_Work_log = new Work_Log_template[0];
            var Read = File.ReadAllText(Work_Log_path);

            //Checking if the log file is not empty
            if (Read != "")
            {
                //If so, reading the data from the log file
                read_Work_log = JsonConvert.DeserializeObject<Work_Log_template[]>(Read);
            }



            //Getting the time to do the timestamp and the time where the transfer finished
            String Time = "";
            DateTime now = DateTime.Now;
            DateTime date = DateTime.Today;

            //formating the time
            Time = now.Hour + ":" + now.Minute + ":" + now.Second;

            //Calculating the progress of the save
            float Progress = 100 - (Files_Left * 100 / Files_Total);

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

            //getting the length of the old Log list (adding 1 to not get the list index)
            int length = read_Work_log.Length + 1;

            //Setting an index for our new log
            int index = length - 1;

            //Checking if the log was empty (if the log is empty, the length will be 0 plus 1 to get the real length and not the index
            if (length == 1)
            {
                //If the file was empty set the index to 0
                index = 0;
            }

            //Resizing the array to be capable of adding a Log in it
            Array.Resize(ref read_Work_log, length);

            //Adding the Log in it's place, using the idex calculated before
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

        //function to update the work_Log
        public static void Update_Worklogger(String SaveName, String State, float Files_Left) //
        {
            //Creating a list of objects using our template
            Work_Log_template[] read_Work_log;

            //Reading all the data from our log file
            var Read = File.ReadAllText(Work_Log_path);

            //Adding all the read data to the list of objects
            read_Work_log = JsonConvert.DeserializeObject<Work_Log_template[]>(Read);

            //Setting up an index to update the correct log data
            int index = 0;

            //Checking all the Logs one by one in our list of objetcs to see if the Save name, is the same as the one we wnat to update
            for (int i = 0; i < read_Work_log.Length; i++)
            {
                if (read_Work_log[i].Save_Name == SaveName)
                {
                    index = i;
                }
            }

            //Updating the Data under this :

            //Setting up the new state of the save
            read_Work_log[index].State = State;

            //Setting the number of files left to save
            read_Work_log[index].Files_Left_To_Do = Files_Left.ToString();

            //Calculating and setting the new value of progress of the copy
            float Progress = 100 - (Files_Left * 100 / float.Parse(read_Work_log[index].Total_Files_To_Copy));
            read_Work_log[index].Progress = Progress.ToString();

            //Checking if there is no more files to copy
            if (Files_Left == 0)
            {
                //If so, getting the current time
                String Time = "";
                DateTime now = DateTime.Now;

                //formating the time
                Time = now.Hour + ":" + now.Minute + ":" + now.Second;

                //Setting the end time of the copy
                read_Work_log[index].End_Time = Time;

                //Setting the state on DONE
                read_Work_log[index].State = "DONE";
            }




            //Writer for the Log
            using (StreamWriter WL = new StreamWriter(Work_Log_path))
            {
                //Wrinting the object in the file by serializing the log object, with indentation
                WL.WriteLine(JsonConvert.SerializeObject(read_Work_log, Formatting.Indented));

                //Closing the File
                WL.Close();
            }
        }

        //Function to get the Number of a New save
        public static int Work_Log_Save_Nbr()
        {
            //Reading the Log
            Work_Log_template[] read_Work_log;
            var Read = File.ReadAllText(Work_Log_path);

            //If the Log is not empty
            if (Read != "")
            {
                //Getting data from the Log 
                read_Work_log = JsonConvert.DeserializeObject<Work_Log_template[]>(Read);

                //getting the index of the last Log
                int index = read_Work_log.Length - 1;

                //Getting the Last Save Name
                String save_Name = read_Work_log[index].Save_Name;

                //splitting the Sav Name in parts, divided by #
                String[] values = save_Name.Split('#');

                //returning The Number
                return int.Parse(values[1]);
            }
            else
            {
                //If the file is empty, returning -1 as the save number, because we add 1 to the save number each time we create a new one
                return -1;
            }


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
