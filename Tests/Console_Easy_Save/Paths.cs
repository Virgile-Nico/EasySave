using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Console_Easy_Save
{
    class Paths
    {
        //Variables to store th differents files
        public static String App_Path = "C:\\Easy_Save"; //Default emplacement 
        public static String Log_Path = "Log";
        public static String Work_Log_Path = "Work_Log";
        public static String Default_save_path = "Saves";

        //Variables to store Files paths
        public static String Source_Path = "";
        public static String Target_Path = "";

        public static void Initialize()
        {
            //Check if the app main directory exists
            if(Directory.Exists(App_Path) == false)
            {
                //If they doesn't exist, create all of them
                Directory.CreateDirectory(App_Path); //Main directory
                Directory.CreateDirectory(App_Path + "\\" + Log_Path); //Log directory
                Directory.CreateDirectory(App_Path + "\\" + Work_Log_Path); //Work_Log directory
                Directory.CreateDirectory(App_Path + "\\" + Default_save_path); //Default save directory, if a save path is not specified
            }
            else
            {
                //If the main directory exists, check if all directories exists, if they don't create them
                //Oterwise, do nothing
                if (Directory.Exists(App_Path + "\\" + Log_Path) == false)
                {
                    Directory.CreateDirectory(App_Path + "\\" + Log_Path);
                }
                if (Directory.Exists(App_Path + "\\" + Work_Log_Path) == false)
                {
                    Directory.CreateDirectory(App_Path + "\\" + Work_Log_Path);
                }
                if (Directory.Exists(App_Path + "\\" + Default_save_path) == false)
                {
                    Directory.CreateDirectory(App_Path + "\\" + Default_save_path);
                }
                else
                {

                }
            }
            
            
        }
    }
}
