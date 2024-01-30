@startuml
!theme carbon-gray


User -> Program : Open software
Progress -> VueMain : init
Path <- VueMain : init
Save <- VueMain : init
Logger <- VueMain : init
Save_preparer <- VueMain : init
Work_logger <- VueMain : init

User -> Program: Request Save preparation
Program-> VueMain : Save Preparation
Save_preparer <- VueMain : Save Preparation
Save_preparer --> Path : Request Path infos
Save_preparer <- Path : Send Path infos
Save_preparer --> VueMain : Return Save Preparation
VueMain --> Program : Print Save Preparation
Program --> User : Display Save Preparation's name

User -> Program: Request one save
Program-> VueMain : Request one save
VueMain -> Save_preparer : Request save's informations
VueMain <-- Save_preparer : Request save's informations
VueMain -> Save : Save informations
Save -> Work_logger : Save informations
Save -> Logger : Request files' informations
Save --> VueMain : Return save
Program <-- VueMain : Print save
User <-- Program : Display save

User -> Program: Request all saves
Program-> VueMain : Request all saves
VueMain -> Save_preparer : Request saves' informations
VueMain <-- Save_preparer : Request saves' informations
VueMain -> Save : Save informations from all saves
Save -> Work_logger : Save informations from all saves
Save -> Logger : Request files' informations
Save --> VueMain : Return save
Program <-- VueMain : Print save
User <-- Program : Display save
@enduml