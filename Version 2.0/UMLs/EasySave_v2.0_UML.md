@startuml
package Form <<Rectangle>> {
  class MainMenu{
  void MainMenu()
  void button1_Click(object sender, EventArgs e)
  void button2_Click(object sender, EventArgs e)
  void button3_Click(object sender, EventArgs e)
  void button5_Click(object sender, EventArgs e)
  void button4_Click(object sender, EventArgs e)
  void Images(object sender, EventArgs e)
}
  class PrepareMenu{
void PrepareMenu()
 void button2_Click(object sender, EventArgs e)
}

  class SaveMenu{
void SaveMenu()
void button1_Click(object sender, EventArgs e)

}

  class SettingsMenu{
void SettingsMenu()
button1_Click(object sender, EventArgs e)
}

  class ShowSaveInfo{
void ShowSaveInfo()
void button1_Click(object sender, EventArgs e)
}
}


class Paths{
  String App_Path
  String Log_Path
  String Work_Log_Path
  String Default_save_path
String Source_Path
String Target_Path
void Initialize()
}



class Save_preparer{
String prepared_path
int Nbr_save
int Save_Prearer(String source, String target, String Type)
void Initialize()
int Save_NBR()
}

class Prepared_template
   {
      
       string Save_Name 
       string Save_Type
       string Source_Folder_Path 
       string Target_Folder_Path 
   }

class VueMain{

void Initialization()
int Prepare_save(String source, String target, String type)
string Full_Save(String Source, String Target)
string Differential_Save()
}


class Work_Logger{
  string Work_Log_path
  void Initialize()
  void WorkLogger(String Name, String State, String Source, String Target, String Size, float Files_Total, float Files_Left)
void Update_Worklogger(String SaveName, String State, float Files_Left) 
int Work_Log_Save_Nbr()
}

class Work_Log_template
    {
string Save_Name  
string Start_Time 
string End_Time
string State 

string Source_Folder_Path
string Target_Folder_Path 
string Total_Files_To_Copy
string Total_Files_Size 
string Files_Left_To_Do 
string Progress
}

class Logger{
  string Log_path
  void Initialize()
  void Logger(String Name, String State, String Source, String Target, String Size, float Files_Total, float Files_Left)
void Updatelogger(String SaveName, String State, float Files_Left) 
int Log_Save_Nbr()
}

class Log_template
    {
string Timestamp 
string Save_Name  
string Time 
string File_Source
string File_Target
string File_Size
string File_transfer_Size
}

class Save
{
void Full(string Source, string Target)
void Diff(string Source, string Target)
void Safe(string Source, string Target, string Type)
}

Form o-- VueMain
Form --* VueMain
VueMain ..> Save_preparer
VueMain ..> Save
VueMain ..> Paths
Paths <.. Save_preparer
Paths <.. Work_Logger
Paths <.. Logger
Logger --* Log_template
Paths <.. Save
Save_preparer o-- Save
Save ..> Logger
Work_Logger --* Work_Log_template
Save ..> Work_Logger
Prepared_template --* Save_preparer


PrepareMenu o-- MainMenu
PrepareMenu --* MainMenu
SaveMenu o-- MainMenu
SaveMenu --* MainMenu
SettingsMenu o-- MainMenu
SettingsMenu --* MainMenu
ShowSaveInfo o-- MainMenu
ShowSaveInfo --* MainMenu
@enduml