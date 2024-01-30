using System;
using System.Configuration;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Globalization;
using Console_Vue.Language;

namespace Console_Vue
{
    class Program
    {
        //Variable for the current language
        static String App_Language = "";

        /// <summary>
        /// Main function
        /// </summary>
        static void Main()
        {
            App_Language = ConfigurationManager.AppSettings["Default_Language"];
            //Set the language for using the correct language file
            Text.Culture = new CultureInfo(App_Language.ToLower());

            //Call app initialisation
            VueMain.Initialization();
            Console.WriteLine("init done");

            //Clear console 
            Console.Clear();

            //Set console colors
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Easy Save";
            
            
            //Display the app logo
            Console.WriteLine(@"
  ______                   _____                 
 |  ____|                 / ____|                
 | |__   __ _ ___ _   _  | (___   __ ___   _____ 
 |  __| / _` / __| | | |  \___ \ / _` \ \ / / _ \
 | |___| (_| \__ \ |_| |  ____) | (_| |\ V /  __/
 |______\__,_|___/\__, | |_____/ \__,_| \_/ \___|
                   __/ |                         
                  |___/                          
             ");


            //By getting the informations from the texts files, we can print te correct language text, we set up

            //Writing the main menu

            //Divider
            Console.WriteLine(Text.Divider);

            //Displaying welcome in app
            Console.WriteLine(Text.Welcome);

            //Asking what we want to do
            Console.WriteLine(Text.Main_question);

            //Display all options
            Console.WriteLine(Text.Main_opt1);
            Console.WriteLine(Text.Main_opt2);
            Console.WriteLine(Text.Main_opt3);
            Console.WriteLine(Text.Main_opt4);
            Console.WriteLine(Text.Main_opt5);

            //Divider
            Console.WriteLine(Text.Divider);

            //Getting the choice
            String Entry = Console.ReadLine();

            //Checking the choice values and going to the corresponding function
            if(Entry == "1")
            {
                Prepare();
            }
            if (Entry == "2")
            {
                Save();
            }
            if (Entry == "3")
            {
                Display_preps();
            }
            if (Entry == "4")
            {
                Settings();
            }
            if (Entry == "5")
            {
                //if we want to stop the app write it, wait a bit, then exit the app with code 1
                Console.WriteLine(Text.Main_exit);
                Thread.Sleep(1000);
                Environment.Exit(1);
            }
            else
            {
                //If the entry does not match any vales, go back to main
                Console.WriteLine(Text.Main_error);
                Main();
            }
        }
        static void Display_preps()
        {
            //Display preps main menu

            //Clear console + Divider
            Console.Clear();
            Console.WriteLine(Text.Divider);

            //Display the question (if we want to see all prepared saves)
            Console.WriteLine(Text.Display_question);

            //opt1 for yes
            Console.WriteLine(Text.Display_opt1);

            //nothing for going back to main menu
            Console.WriteLine(Text.Display_back);

            //Divider
            Console.WriteLine(Text.Divider);

            //Getting the entry + checking its value, and doing the associated thing
            String Entry = Console.ReadLine();
            if(Entry == "1")
            {
                //Getting the values of preparations
                String Display = VueMain.Display_preps();

                //Clear the console, place dividers, display preps value
                Console.Clear();
                Console.WriteLine(Text.Divider);
                Console.WriteLine(Display);
                Console.WriteLine(Text.Divider);

                //Say to the user that he can press return to go back to main menu
                Console.WriteLine(Text.Display_back2);
                Console.WriteLine(Text.Divider);

                //Wait for entry of the user
                Console.ReadLine();
            }
            else
            {
                //if entry does not match any entry, go back to main menu
                Thread.Sleep(1000);
                Main();
            }
        }
        static void Prepare()
        {

            //Variables used further on
            String Entry = "";
            String Type = "";
            String sourceToSave = "";
            String destinationOfSave = "";

            //ETAPE 1 : TYPE DE SAUVEGARDE

            //Display prepare main menu
            Console.Clear();
            Console.WriteLine(Text.Divider);
            Console.WriteLine(Text.Prepare_question);
            Console.WriteLine(Text.Prepare_opt1);
            Console.WriteLine(Text.Prepare_opt2);
            Console.WriteLine(Text.Prepare_opt3);
            Console.WriteLine(Text.Divider);

            //Get the entry
            Entry = Console.ReadLine();
            switch (Entry)
            {
                case "1":
                    Type = "Full";
                    Console.WriteLine(Text.Prepare_full);
                    break;
                case "2":
                    Type = "Diff";
                    Console.WriteLine(Text.Prepare_diff);
                    break;
                case "3":
                    Console.WriteLine(Text.Prepare_back);
                    Thread.Sleep(1000);
                    Main();
                    break;
                default:
                    Console.WriteLine(Text.Prepare_error);
                    Thread.Sleep(1000);
                    Prepare();
                    break;
            }

            //STEP 2 : SOURCE PATH
            if(Entry == "1" || Entry == "2")
            {

                //Display source menu
                Console.Clear();
                Console.WriteLine(Text.Divider);
                Console.WriteLine(Text.Prepare_source);
                Console.WriteLine(Text.Prepare_back2);
                Console.WriteLine(Text.Divider);

                //Get source value
                sourceToSave = Console.ReadLine();
                 
                if(sourceToSave == "")
                {
                   Console.WriteLine(Text.Prepare_back);
                }
            }

            //STEP 3 : DESTINATION PATH
            if ((Entry == "1" || Entry == "2") && (sourceToSave != ""))
            {

                //Display target menu
                Console.Clear();
                Console.WriteLine(Text.Divider);
                Console.WriteLine(Text.Prepare_target);
                Console.WriteLine(Text.Prepare_diff2);
                Console.WriteLine(Text.Prepare_back2);
                Console.WriteLine(Text.Divider);

                //Get target value
                destinationOfSave = Console.ReadLine();

                //Go back to main menu
                if(destinationOfSave=="")
                {
                    Console.WriteLine(Text.Prepare_back);
                }

                //Set target to default
                else if(destinationOfSave=="D")
                {
                    destinationOfSave="DEFAULT";
                }
            }

            //STEP 4 : SHOW ENTERED INFORMATION
            if (sourceToSave != "" && destinationOfSave != "" && Type != "")
            {

                //Clear console
                Console.Clear();

                //Display save informations
                Console.WriteLine(Text.Divider);
                if (Type == "Full")
                {
                    Console.WriteLine(Text.Prepare_info_full);
                }
                if (Type == "Diff")
                {
                    Console.WriteLine(Text.Prepare_info_diff);
                }

                Console.WriteLine(Text.Prepare_from + sourceToSave);
                Console.WriteLine(Text.Prepare_to + destinationOfSave);
                Console.WriteLine(Text.Divider);

                //Display save preparation, working
                Console.Clear();
                Console.WriteLine(Text.Divider);
                Console.WriteLine(Text.Prepare_working);
                Console.WriteLine(Text.Divider);

                //Ask for the preparation of the save, getting done or error in return
                String Prep = VueMain.Prep_save(Type, sourceToSave, destinationOfSave);

                //Display save prepared or error
                Console.Clear();
                Console.WriteLine(Text.Divider);
                Console.WriteLine(Prep + Text.Prepare_done);
                Console.WriteLine(Text.Divider);

                //Go back to main menu
                Thread.Sleep(1000);
                Main();
            }

            

        }
        static void Save()
        {
            string Entry = "";
            int saveSlot = 0;

            //Display save main menu
            Console.Clear();

            //STEP 1 : NUMBER OF SAVES
            Console.WriteLine(Text.Divider);
            Console.WriteLine(Text.Save_question);
            Console.WriteLine(Text.Save_opt1);
            Console.WriteLine(Text.Save_opt2);
            Console.WriteLine(Text.Save_opt3);
            Console.WriteLine(Text.Save_back);
            Console.WriteLine(Text.Divider);

            //get entry
            Entry = Console.ReadLine();

            //Do what each entry is supposed to do
            switch (Entry)
            {
                case "1":

                    //Display save single menu + ask wich save we want to do
                    Console.WriteLine(Text.Save_single);
                    Thread.Sleep(1000);

                    //STEP 2 : SAVE SLOT
                    Console.WriteLine(Text.Divider);
                    Console.WriteLine(Text.Save_single_question);
                    Console.WriteLine(Text.Save_single_opt1, VueMain.Prepared_number());
                    Console.WriteLine(Text.Save_back);
                    Console.WriteLine(Text.Divider);

                    //get the save number we wont to do
                    Entry = Console.ReadLine();

                    //STEP 3 : EXTRACT SAVE SLOT NUMBER IF POSSIBLE
                    bool isNumeric = int.TryParse(Entry, out saveSlot);
                    if (isNumeric)
                    {
                        if (0 < saveSlot && saveSlot < (VueMain.Prepared_number() + 1))
                        {
                            Entry = "0";
                        }
                    }

                    //Checking entry value doing save associated to the value or display error, or go back to main menu
                    switch (Entry)
                    {
                        case "0":
                            Console.WriteLine(Text.Save_exec1 + " " + saveSlot + " " + Text.Save_exec2);
                            Console.Clear();
                            Console.WriteLine(Text.Divider);
                            String done = VueMain.Save_single("Save#" + saveSlot);
                            Console.WriteLine("Save#" + saveSlot + " " + done);
                            Console.WriteLine(Text.Divider);
                            Thread.Sleep(1000);
                            break;
                        case "":
                            Console.WriteLine(Text.Save_back2);
                            Thread.Sleep(1000);
                            Main();
                            break;
                        default:
                            Console.WriteLine(Text.Save_error);
                            Thread.Sleep(1000);
                            Save();
                            break;
                    }
                    break;

                //entry 2 (save sequence)
                case "2":

                    int LowerBound = 0;
                    int UpperBound = 0;


                    //STEP 1 : GET ENTRY FROM USER
                    Console.WriteLine(Text.Divider);
                    Console.WriteLine(Text.Save_sequence1);
                    Console.WriteLine(Text.Save_sequence2);
                    Console.WriteLine(Text.Save_back);
                    Console.WriteLine(Text.Divider);
                    Entry=Console.ReadLine();

                    //STEP 2 : TRY TO EXTRACT FIRST SEQUENCE BOUNDARY
                    int sequenceBoundary1;
                    isNumeric = int.TryParse(Entry, out sequenceBoundary1);
                    if (isNumeric)
                    {
                        if (0 <= sequenceBoundary1)
                        {
                            Entry = "0";
                        }
                    }
                    //Continues execution, or display error, or go back to main menu
                    switch (Entry)
                    {
                        case "0":
                            //STEP 3 : GET ENTRY FROM USER
                            Console.WriteLine(Text.Divider);
                            Console.WriteLine(Text.Save_sequence3);
                            Console.WriteLine(Text.Save_back);
                            Console.WriteLine(Text.Divider);
                            Entry = Console.ReadLine();

                            //STEP 4 : TRY TO EXTRACT SECOND SEQUENCE BOUNDARY
                            
                            int sequenceBoundary2;
                            isNumeric = int.TryParse(Entry, out sequenceBoundary2);
                            if (isNumeric)
                            {
                                if (0 <= sequenceBoundary2)
                                {
                                    //STEP 5 : DETERMINE WHICH BOUNDARY IS SMALLER
                                    if (sequenceBoundary2 < sequenceBoundary1)
                                    {
                                        LowerBound = sequenceBoundary2;
                                        UpperBound= sequenceBoundary1;
                                    }
                                    else
                                    {
                                        LowerBound = sequenceBoundary1;
                                        UpperBound = sequenceBoundary2;
                                    }
                                    Entry = "0";
                                }
                            }

                            //Confirms data entry, or display error, or go back to main menu
                            switch (Entry)
                            {
                                case "0":
                                    //STEP 6 : DISPLAY UPPER AND LOWER BOUND OF THE SEQUENCE
                                    Console.Clear();
                                    Console.WriteLine(Text.Divider);
                                    Console.WriteLine(Text.Save_sequence_exec1 + " " + LowerBound + " " + Text.Save_sequence_exec2 + " " + UpperBound + ".");
                                    Console.WriteLine(Text.Divider);
                                    Thread.Sleep(1000);
                                    break;
                                case "":
                                    Console.WriteLine(Text.Save_back2);
                                    Thread.Sleep(1000);
                                    Main();
                                    break;
                                default:
                                    Console.WriteLine(Text.Save_error);
                                    Thread.Sleep(1000);
                                    Save();
                                    break;
                            }
                            break;
                        case "":
                            Console.WriteLine(Text.Save_back2);
                            Thread.Sleep(1000);
                            Main();
                            break;
                        default:
                            Console.WriteLine(Text.Save_error);
                            Thread.Sleep(1000);
                            Save();
                            break;

                    }
                    String state = VueMain.Save_sequence(LowerBound, UpperBound);

                    Console.Clear();
                    Console.WriteLine(Text.Divider);
                    Console.WriteLine(state);
                    Console.WriteLine(Text.Divider);
                    Thread.Sleep(1000);

                    break;

                //If save all ask to do all saves
                case "3":
                    Console.WriteLine(Text.Save_all);
                    VueMain.Save_all();
                    break;

                //if we want to go back to main menu
                case "":
                    Console.WriteLine(Text.Save_back2);
                    Thread.Sleep(1000);
                    Main();
                    break;

                //If value does not match wanted value, display save main menu
                default:
                    Console.WriteLine(Text.Save_error);
                    Thread.Sleep(1000);
                    Save();
                    break;
            }
        }
        static void Language()
        {

            //Display Language selection menu
            Console.Clear();

            Console.WriteLine(Text.Divider);
            Console.WriteLine(Text.Lang_question);
            Console.WriteLine(Text.Lang_opt1);
            Console.WriteLine(Text.Lang_opt2);
            Console.WriteLine(Text.Lang_opt3);
            Console.WriteLine(Text.Lang_opt4);
            Console.WriteLine(Text.Lang_opt5);
            Console.WriteLine(Text.Divider);

            //get the language entry, set the new language to the value of the entry, go back to main
            String Entry = Console.ReadLine();
            if (Entry == "1")
            {
                VueMain.Default_language("FR");
                Console.WriteLine(Text.Lang_used + " " + Text.FR);
                Thread.Sleep(1000);
                Main();
            }
            if (Entry == "2")
            {
                VueMain.Default_language("EN");
                Console.WriteLine(Text.Lang_used + " " + Text.EN);
                Thread.Sleep(1000);
                Main();
            }
            if (Entry == "3")
            {
                VueMain.Default_language("ES");
                Console.WriteLine(Text.Lang_used + " " + Text.ES);
                Thread.Sleep(1000);
                Main();
            }
            if (Entry == "4")
            {
                VueMain.Default_language("DE");
                Console.WriteLine(Text.Lang_used + " " + Text.DE);
                Thread.Sleep(1000);
                Main();
            }
            if (Entry == "5")
            {
                VueMain.Default_language("IT");
                Console.WriteLine(Text.Lang_used + " " + Text.IT);
                Thread.Sleep(1000);
                Main();
            }
            else
            {
                Console.WriteLine(Text.Lang_error);
                Thread.Sleep(1000);
                Main();
            }
        }

        static void Settings()
        {
            //Display settings main menu
            Console.Clear();

            Console.WriteLine(Text.Divider);
            Console.WriteLine(Text.Settings_question);
            Console.WriteLine(Text.Settings_opt1);
            Console.WriteLine(Text.Settings_opt2);
            Console.WriteLine(Text.Settings_opt3);
            Console.WriteLine(Text.Settings_back);
            Console.WriteLine(Text.Divider);

            //get the entry
            String Entry = Console.ReadLine();

            //Go to the menu of settings associated to the entry
            //1 => Language
            //2 => Default folders locations
            //empty => go back to main
            if(Entry == "1")
            {
                Language();
            }
            if (Entry == "2")
            {
                Default_location();
            }
            if (Entry == "3")
            {
                Default_log();
            }
            if (Entry == "")
            {
                Thread.Sleep(1000);
                Main();
            }
        }

        static void Default_location()
        {
            //Display default location menu
            Console.Clear();

            Console.WriteLine(Text.Divider);
            Console.WriteLine(Text.Default_question);
            Console.WriteLine(Text.Default_opt1);
            Console.WriteLine(Text.Default_opt2);
            Console.WriteLine(Text.Default_back);
            Console.WriteLine(Text.Divider);

            //get the entry
            String Entry = Console.ReadLine();

            //If, entry D / default set the default app path
            if(Entry == "D")
            {
                VueMain.Default_location("default");
                Console.Clear();

                Console.WriteLine(Text.Divider);
                Console.WriteLine(Text.Default_default);
                Console.WriteLine(Text.Divider);

                Thread.Sleep(1000);
                Main();
            }

            //If entry empty, go back to main
            if(Entry == "")
            {
                Console.Clear();

                Console.WriteLine(Text.Divider);
                Console.WriteLine(Text.Default_back2);
                Console.WriteLine(Text.Divider);

                Thread.Sleep(1000);
                Main();
            }

            //If entry something, set default location to the new entered path
            else
            {
                VueMain.Default_location(Entry);
                Console.Clear();

                Console.WriteLine(Text.Divider);
                Console.WriteLine(Text.Default_New + Entry);
                Console.WriteLine(Text.Divider);

                Thread.Sleep(1000);
                Main();
            }
        }

        static void Default_log()
        {
            //Display default location menu
            Console.Clear();

            Console.WriteLine(Text.Divider);
            Console.WriteLine(Text.Default_log_question);
            Console.WriteLine(Text.Default_log_opt1);
            Console.WriteLine(Text.Default_log_opt2);
            Console.WriteLine(Text.Default_back);
            Console.WriteLine(Text.Divider);

            //get the entry
            String Entry = Console.ReadLine();

            //If, entry D / default set the default app path
            if (Entry == "1")
            {
                VueMain.Default_log_extension("json");
                Console.Clear();

                Console.WriteLine(Text.Divider);
                Console.WriteLine(Text.Default_log_back, "json");
                Console.WriteLine(Text.Divider);

                Thread.Sleep(1000);
                Main();
            }
            if (Entry == "2")
            {
                VueMain.Default_log_extension("XML");
                Console.Clear();

                Console.WriteLine(Text.Divider);
                Console.WriteLine(Text.Default_log_back, "XML");
                Console.WriteLine(Text.Divider);

                Thread.Sleep(1000);
                Main();
            }

            //If entry empty, go back to main
            if (Entry == "")
            {
                Console.Clear();

                Console.WriteLine(Text.Divider);
                Console.WriteLine(Text.Default_back2);
                Console.WriteLine(Text.Divider);

                Thread.Sleep(1000);
                Main();
            }
        }
    }        
}

