using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Console_Easy_Save
{
    class Save_preparer
    {
        public static String prepared_path = "";
        public static void Initialize()
        {
            //Creating the file name
            String file_Name = "prepared_saves";

            //Updating the path of prepared saves, to load later on
            prepared_path = Paths.App_Path + "\\" + file_Name + ".json";

            //Checking if the file doesn't exists
            if (File.Exists(prepared_path) == false)
            {
                //if it doesn't exists, creating a new file
                using (FileStream fs2 = File.Create(prepared_path));

            }
            else
            {
                //otherwise, do nothing
            }
        }

        public static int Nbr_save = 0;

        public static int Save_Prearer(String source, String target, String Type)
        {
            Nbr_save = Save_NBR() + 1;

            //Creating a list of objects using our template
            Prepared_template[] prepared_save = new Prepared_template[0];

            //Reading all the data from our log file
            var Read = File.ReadAllText(prepared_path);

            //Checking if the file is not empty
            if (Read != "")
            {
                //If so, reading the data from the file
                prepared_save = JsonConvert.DeserializeObject<Prepared_template[]>(Read);
            }

            String Savename = "Save#" + Nbr_save;
            Prepared_template Save = new Prepared_template
            {
                Save_Name = Savename,
                Save_Type = Type,
                Source_Folder_Path = source,
                Target_Folder_Path = target,
            };

            int length = prepared_save.Length + 1;
            int index = length - 1;

            if (length == 1)
            {
                index = 0;
            }

            Array.Resize(ref prepared_save, length);

            prepared_save[index] = Save;

            using (StreamWriter PS = new StreamWriter(prepared_path))
            {
                //Wrinting the object in the file by serializing the log object, with indentation
                PS.WriteLine(JsonConvert.SerializeObject(prepared_save, Formatting.Indented));

                //Closing the File
                PS.Close();
            }

            return Nbr_save;
        }

        public static int Save_NBR()
        {
            //Reading the Log
            Prepared_template[] read_prepared_save;
            var Read = File.ReadAllText(prepared_path);

            //If the Log is not empty
            if (Read != "")
            {
                //Getting data from the Log 
                read_prepared_save = JsonConvert.DeserializeObject<Prepared_template[]>(Read);

                //getting the index of the last Log
                int index = read_prepared_save.Length - 1;

                //Getting the Last Save Name
                String save_Name = read_prepared_save[index].Save_Name;

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

        class Prepared_template
        {
            //Save data 
            public string Save_Name { get; set; } //Name of the save
            public string Save_Type { get; set; } //Type of save
            public string Source_Folder_Path { get; set; } //Source folder of the copy
            public string Target_Folder_Path { get; set; } //Target folder of the save
        }
    }
}
