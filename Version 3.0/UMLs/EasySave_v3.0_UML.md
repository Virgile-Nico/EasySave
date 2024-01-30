@startuml
package Client <<Rectangle>> {

class _Client{}

class ViewMain_Client{}

package Client_views <<Rectangle>> {

  class MainMenu_Client{
  void MainMenu()
  void button1_Click(object sender, EventArgs e)
  void button2_Click(object sender, EventArgs e)
  void button3_Click(object sender, EventArgs e)
  void button5_Click(object sender, EventArgs e)
  void button4_Click(object sender, EventArgs e)
  void Images(object sender, EventArgs e)
}
  class SaveMenu_Client{
void SaveMenu()
void button1_Click(object sender, EventArgs e)

}
 
  class ShowSaveInfo_Client{
void ShowSaveInfo()
void button1_Click(object sender, EventArgs e)
}
}
}

package Server <<Rectangle>> {

class VueMain_Server{

void Initialization()
int Prepare_save(String source, String target, String type)
string Full_Save(String Source, String Target)
string Differential_Save()
}

class _Server{}

package Server_views <<Rectangle>> 
{
class MainMenu_Server{
  void MainMenu()
  void button1_Click(object sender, EventArgs e)
  void button2_Click(object sender, EventArgs e)
  void button3_Click(object sender, EventArgs e)
  void button5_Click(object sender, EventArgs e)
  void button4_Click(object sender, EventArgs e)
  void Images(object sender, EventArgs e)
}
  class SaveMenu_Server{
void SaveMenu()
void button1_Click(object sender, EventArgs e)

}
}

package Server_classes <<Rectangle>> {
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


class CryptoSoft
{
byte Secret
void EncryptFile(string inputFile, string outputFile)
static void EncryptBytes(byte[] buffer, int count)
}
}
}


VueMain_Server ..> Save_preparer
VueMain_Server ..> Save
VueMain_Server ..> Paths
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
CryptoSoft --* Save
Save --o CryptoSoft

ShowSaveInfo_Client o-- MainMenu_Client
ShowSaveInfo_Client --* MainMenu_Client

SaveMenu_Client o-- MainMenu_Client
SaveMenu_Client --* MainMenu_Client


_Client o-- ViewMain_Client
_Client --* ViewMain_Client

Client_views --o ViewMain_Client
Client_views *-- ViewMain_Client

SaveMenu_Server o-- MainMenu_Server
SaveMenu_Server --* MainMenu_Server


_Server o-- VueMain_Server
_Server --* VueMain_Server

Server_views --o VueMain_Server
Server_views *-- VueMain_Server


Client --* Server
Client o-- Server
@enduml