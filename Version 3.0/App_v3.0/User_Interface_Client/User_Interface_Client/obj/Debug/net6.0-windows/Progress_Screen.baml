   M S B A M L   `   `   `  ����P  LUser_Interface_Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:User_Interface_ClientUser_Interface_Client  5   	   +    %User_Interface_Client.Progress_Screen   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:User_Interface_Client     5   	   -   5          �Name$  Easy_Save_Client��5   	    � Title$ Easy Save Client��5   	   $	��450��6"   $	��800��6/    � Icon$ /Easy_Save_logo.png��6;   ���	#FF9FC5D6.��5	      � .+�5
   
   � -   5         �Name$ Save_Progress_Bar��5
      $��Center=�61   $��33��6N   $	��Top=�6Z   $	��596��6r   $��	0,145,0,0q�6~   6�   �� 5   
   -   5         ��Name$ Back_Button��5      $
��Back��6&   $
��Left=�65   $��586,262,0,0q�6P   $	��Top=�6e   $��25��6}   $��95��6�   6�   �� 5   
   -   5        $ Main_Menu_Button��5      $��	Main Menu��6+   $
��Left=�6?   $��586,327,0,0q�6Z   $	��Top=�6o   $��25                 ��6�   $��95��5      6   �� 5   
   -   5         ��Name$ Save_Name_Label��5      $��SaveName��6)   $
��Left=�6<   $��	40,33,0,0q�6W   $	��Top=�6j   �� 5   
   -   5        $ Status_Label��5      $��Status :��6&   $
��Left=�69   $��
577,33,0,0q�6T   $	��Top=�6h   �� 5   
   -   5        $ Source_Path_Label��5      $��Source Path��6+   $
��Left=�6A   $��112,291,0,0q�6\   $	��Top=�6q   �� 5   
   -   5        $ Target_Path_Label��5      $��Target Path��6+   $
��Left=�6A   $��111,343,0,0q�6\   $	��Top=�6q   �� 5   
   $
��Left=�6   $	��135��6+   $��	332,4,0,0q�68   $	��Top=�6K   $	��140��6c   $��/Easy_Save.png��6o   �� 5   
   -	   5        $ Save_Name_Value_Label��5      $��SaveNameValue��6/   $
��Left=�6G   $��	52,59,0,0q�6b   $	��Top=�6u   �� 5   
   -
   5        $ Status_Label_Value��5      $��StatusValue��6,   $
��Left=�6B   $��
586,54,0,0q�6]   $	��Top=�6q   �� 5   
   -   5        $ Source_Label��5      $��Source��6&   $
��Left=�67   $��111,265,0,0q�6R   $	��Top=�6g   �� 5   
   -   5        $ Destination_Label��5      $��Destination��6+   $
��Left=�6A   $��111,317,0,0q�6\   $	��Top=�6q   �� 5   
   -   5        $ 
File_Label��5      $��File : ��6$   $
��Left=�66   $��102,191,0,0q�6Q   $	��Top=�6f   �� 5   
   -   5        $$ File_Name_And_Path_Value_Label��5      $��File_Name_And_Path��68   $
��Left=�6U   $��148,191,0,0q�6p   $	��Top=�6�   �� 5   
   -   5        $ Progress_Percent_Label��5      $��	Progress%��60   $
��Left=�6D   $��703,149,0,0q�6_   $	��Top=�6t   $��87��6�   �� 5   
   -   5        $' !Progress_As_Number_Of_Files_Label��5      $��Nb_Done/Total_Nb��6;   $
��Left=�6V   $��586,183,0,0q�6q   $	��Top=�6�   $	��112��6�   5      5      