using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace App_Easy_Save
{
    class Prepare
    {
        //Global variables to create the paths of the prepare files
        public static string Prepared_Path = "";
        public static string File_Name = "Prepared_Saves";

        //Funcito to initialize the prepared files
        public static void Initialize()
        {
            Prepared_Path = Paths.App_Path + @"Easy_Save";
            //Check if the file exists, if no, create it
            if (File.Exists(Prepared_Path + @"\" + File_Name + ".json") == false)
            {
                using (FileStream fs = File.Create(Prepared_Path + @"\" + File_Name + ".json")) ;
            }
        }

        //Function to display all the prepared saves
        public static String Display_preps()
        {
            //get all the prepared save from the file
            var Read = File.ReadAllText(Prepared_Path + @"\" + File_Name + ".json");

            //return it as a string
            return Read.ToString();
        }

        /// <summary>
        /// Funciton to prepare a save
        /// </summary>
        /// <param name="source">save source</param>
        /// <param name="target">save target</param>
        /// <param name="Type">save type</param>
        /// <returns></returns>
        public static String Preparing(String source, String target, String Type)
        {
            //Prepare the template
            Prepare_template[] read_prepared_save = new Prepare_template[0];

            //read the prepare file
            var Read = File.ReadAllText(Prepared_Path + @"\" + File_Name + ".json");

            //if the read is not empty, input it i the template prepared list, with the template structure
            if (Read != "")
            {
                read_prepared_save = JsonConvert.DeserializeObject<Prepare_template[]>(Read);
            }

            //get the list length and the index
            int length = read_prepared_save.Length + 1;
            int index = length - 1;

            //If the length in , the index has to be 0
            if (length == 1)
            {
                index = 0;
            }

            //resize the list to add something else
            Array.Resize(ref read_prepared_save, length);

            //creathe the save name
            String Save_Name = "Save#" + index;


            //Create the template with informations in i
            Prepare_template Prep = new Prepare_template
            {
                Savename = Save_Name,
                savetype = Type,
                source_folder_path = source,
                target_folder_path = target,
            };

            //Add teh new save to the list
            read_prepared_save[index] = Prep;

            //Re write the file
            using (StreamWriter PS = new StreamWriter(Prepared_Path + @"\" + File_Name + ".json"))
            {
                PS.WriteLine(JsonConvert.SerializeObject(read_prepared_save, Formatting.Indented));
                PS.Close();
            }

            //return the save name
            return Save_Name;

        }

        public static void Del_prepared(int indexToRemove)
        {
            //Prepare the template
            Prepare_template[] read_prepared_save = new Prepare_template[0];

            //read the prepare file
            var Read = File.ReadAllText(Prepared_Path + @"\" + File_Name + ".json");

            //if the read is not empty, input it i the template prepared list, with the template structure
            if (Read != "")
            {
                read_prepared_save = JsonConvert.DeserializeObject<Prepare_template[]>(Read);
            }

            read_prepared_save = read_prepared_save.Where((source, index) => index != indexToRemove).ToArray();

            for(int i = 0; i < read_prepared_save.Length; i++)
            {
                String save_name = "Save#" + i;
                read_prepared_save[i].Savename = save_name;
            }

            //Re write the file
            using (StreamWriter PS = new StreamWriter(Prepared_Path + @"\" + File_Name + ".json"))
            {
                PS.WriteLine(JsonConvert.SerializeObject(read_prepared_save, Formatting.Indented));
                PS.Close();
            }
        }

        public static void Edit_prep(String source, String target, String Type, String Save_name)
        {
            //Prepare the template
            Prepare_template[] read_prepared_save = new Prepare_template[0];

            //read the prepare file
            var Read = File.ReadAllText(Prepared_Path + @"\" + File_Name + ".json");

            //if the read is not empty, input it i the template prepared list, with the template structure
            if (Read != "")
            {
                read_prepared_save = JsonConvert.DeserializeObject<Prepare_template[]>(Read);
            }

            //get the list length and the index
            int length = read_prepared_save.Length;

            for(int i = 0; i < length; i++)
            {
                if(read_prepared_save[i].Savename == Save_name)
                {
                    read_prepared_save[i].savetype = Type;
                    read_prepared_save[i].source_folder_path = source;
                    read_prepared_save[i].target_folder_path = target;
                }
            }

            //Re write the file
            using (StreamWriter PS = new StreamWriter(Prepared_Path + @"\" + File_Name + ".json"))
            {
                PS.WriteLine(JsonConvert.SerializeObject(read_prepared_save, Formatting.Indented));
                PS.Close();
            }

        }

        //function to get the save informations
        public static void Save_infos(String Save_Name)
        {
            //Prepare the template
            Prepare_template[] read_prepared_save = new Prepare_template[0];

            //read the file
            var Read = File.ReadAllText(Prepared_Path + @"\" + File_Name + ".json");

            //If file not empty, set it to the read data
            if (Read != "")
            {
                read_prepared_save = JsonConvert.DeserializeObject<Prepare_template[]>(Read);
            }

            //get the length of the arry
            int length = read_prepared_save.Length;

            //Checking all the data in the array to get the saves informations
            for (int i = 0; i < length; i++)
            {
                //If the save name correspond to the one we wanted, set the global vue main data variables to the ones of the save
                if (read_prepared_save[i].Savename == Save_Name)
                {
                    VueMain.Source = read_prepared_save[i].source_folder_path;
                    VueMain.Target = read_prepared_save[i].target_folder_path;
                    VueMain.Type = read_prepared_save[i].savetype;

                }
            }
        }

        //function to get the save informations fo the client
        public static void ClientSave_infos(String Save_Name)
        {
            //Prepare the template
            Prepare_template[] read_prepared_save = new Prepare_template[0];

            //read the file
            var Read = File.ReadAllText(Prepared_Path + @"\" + File_Name + ".json");

            //If file not empty, set it to the read data
            if (Read != "")
            {
                read_prepared_save = JsonConvert.DeserializeObject<Prepare_template[]>(Read);
            }

            //get the length of the arry
            int length = read_prepared_save.Length;

            //Checking all the data in the array to get the saves informations
            for (int i = 0; i < length; i++)
            {
                //If the save name correspond to the one we wanted, set the global vue main data variables to the ones of the save
                if (read_prepared_save[i].Savename == Save_Name)
                {
                    Server.ReseauSend(Server.client, "src#" + read_prepared_save[i].source_folder_path);
                    Server.ReseauSend(Server.client, "trg#" + read_prepared_save[i].target_folder_path);
                }
            }
        }

        //get the save number
        //read the file, return the number of structures in the array
        //return the number of items in the array
        public static int Save_Number()
        {
            Prepare_template[] read_prepared_save = new Prepare_template[0];
            var Read = File.ReadAllText(Prepared_Path + @"\" + File_Name + ".json");

            if (Read != "")
            {
                read_prepared_save = JsonConvert.DeserializeObject<Prepare_template[]>(Read);
            }

            int length = read_prepared_save.Length;
            return length;
        }
    }

    //Class of the prepare template, contains the template to prepared saves
    class Prepare_template
    {
        public string Savename { get; set; }
        public string savetype { get; set; }
        public string source_folder_path { get; set; }
        public string target_folder_path { get; set; }
    }
}
