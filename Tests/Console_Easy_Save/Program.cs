using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Easy_Save
{
    class Program
    {
        static void Main()
        {
            //Starting the program
            Console.WriteLine("Initialisation");
            Console.WriteLine("Checking for Log folders");

            //Initializing all the needed functions
            VueMain.Initialization();

            //Returning the end of initialisation
            Console.WriteLine("Log files found / created");

            //Asking the type of save we want
            Console.WriteLine("What do you want to do ? [Prepare save / Do Save / Do all saves");

            //Readig the choice of save we want
            String choice = Console.ReadLine();

            //Creating the source and target paths variable
            String SourcePath = "";
            String TargetPath = "";
            String SaveType = "";

            if (choice == "Prepare save")
            {
                //Asking the path of the folder we want to save + adding this path to the source path variable
                Console.WriteLine("Path of the folder to save :");
                SourcePath = Console.ReadLine();

                //Asking the path of the folder to save the files, letting the option to set it as empty to use the default save folder
                Console.WriteLine("Path of the target Folder (empty for default folder) :");
                TargetPath = Console.ReadLine();

                //Checking if we let the path empy
                if (TargetPath == "")
                {
                    //if so, set TargetPath to DEFAULT
                    TargetPath = "DEFAULT";
                }

                //Asking the save type, the user want
                Console.WriteLine("Wich type of save do you want ? [Full / Differencial]");
                SaveType = Console.ReadLine();

                //Writing the Save informations (From / To)
                Console.WriteLine(SaveType + " save From :");
                Console.WriteLine(SourcePath);
                Console.WriteLine("To :");
                Console.WriteLine(TargetPath);

                int save_Nbr = VueMain.Prepare_save(SourcePath, TargetPath, SaveType);

                Console.WriteLine("Your save, is the save number : " + save_Nbr);
            }

            if (choice == "Do Save")
            {
                Console.WriteLine("Wich number of save ? (1 - 5 depending on te number prepared)");
            }
            if (choice == "Do all saves")
            {
                Console.WriteLine("Do all saves");
            }

            /*
            //Checking if the save we want is the Full save
            if (choice == "Full")
            {
                

                

                //Writing the Save informations (From / To)
                Console.WriteLine("Full save From :");
                Console.WriteLine(SourcePath);
                Console.WriteLine("To :");
                Console.WriteLine(TargetPath);

                //Calling the vue main full save function
                Console.WriteLine(VueMain.Full_Save(SourcePath, TargetPath));

                //When exiting the vue main full save function, the save is done
                //So we write that the save is Done
                Console.WriteLine("==========================");
                Console.WriteLine("Done !");
                Console.WriteLine("==========================");

            }

            //Checking if the save we want is the Differencial save
            if (choice == "Differencial")
            {
                //Asking the path of the folder we want to save + adding this path to the source path variable
                Console.WriteLine("Path of the folder to save :");
                SourcePath = Console.ReadLine();

                //Asking the path of the folder to save the files, letting the option to set it as empty to use the default save folder
                Console.WriteLine("Path of the target Folder (empty for default folder) :");
                TargetPath = Console.ReadLine();

                //Checking if we let the path empy
                if (TargetPath == "")
                {
                    //if so, set TargetPath to DEFAULT
                    TargetPath = "DEFAULT";
                }

                //Writing the Save informations (From / To)
                Console.WriteLine("Differencial save From :");
                Console.WriteLine(SourcePath);
                Console.WriteLine("To :");
                Console.WriteLine(TargetPath);

                //Calling the vue main differencial save function
                //============
                //NOT DONE YET
                //============

                //When exiting the vue main differencial save function, the save is done
                //So we write that the save is Done
                Console.WriteLine("==========================");
                Console.WriteLine("Done !");
                Console.WriteLine("==========================");
            }
            */
            //Waiting to close the software
            Console.WriteLine("Press return to close this software....");
            Console.ReadLine();
        }
    }
}