   M S B A M L   `   `   `  ����K  GClient interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Client_interfaceClient_interface  5   	   &     Client_interface.Progress_Screen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Client_interface     5   	     � Title$  Easy Save Client��5   	   $	��450��6"   $	��800��6/   ���	#FF9FC5D6.��5	      � .+�5
   
   � -   5        $��Save_Progress_Bar��5
      $��Center=�6/   $��33��6L   $	��Top=�6X   $	��596��6p   $��	0,145,0,0q�6|    � Minimum$ 0Q�6�    � Maximum$	 100Q�6�   �� 5   
   -   5         ��Name$ Save_Name_Label��5      $��SaveName��6)   $
��Left=�6<   $��	40,33,0,0q�6W   $	��Top=�6j   �� 5   
   -   5        $��Source_Path_Label��5      $��Source Path��6)   $
��Left=�6?   $��112,291,0,0q�6Z   $	��Top=�6o   �� 5   
   -   5        $ Target_Path_Label��5      $��Target Path��6+   $
��Left=�6A   $��111,343,0,0q�6\   $	��Top=�6q   �� 5   
   $
��Left=�6   $	��135��6+   $��	332,4,0,0q�68   $	��Top=�6K   $	��140��6c   $��/img/Easy_Save.png��6o   �� 5   
   -   5        $��Save_Name_Value_Label��5      $��SaveNameValue��6-   $
��Left=�6E   $��	52,59,0,0q�6`   $	��Top=�6s   �� 5   
   -   5        $ Source_Label��5      $��Source��6&   $
��Left=�67   $��111,265,0,0q�6R   $	��Top=�6g   �� 5   
   -   5        $ Destination_Label��5      $��Destination��6+   $
��Left=�6A   $��111,317,0,0q�6\   $	��Top=�6q   �� 5   
   -   5        $ Progress_Percent_Label��5      $��	Progress%��60   $
��Left=�6D   $��703,149,0,0q�6_   $	��Top=�6t   $��87��6�   �� 5   
   -	   5        $'��!Progress_As_Number_Of_Files_Label��5      $��Nb_Done/Total_Nb��69   $
��Left=�6T   $��586,191,0,0q�6o   $	��Top=�6�   $	��112��6�   �� 5   
   -
   5        $��Start��5      $
��Left=�6!   $��586,265,0,0q�6<   $	��Top=�6Q   $��39��6i   $	��136��6u   6�   �� 5   
   -   5        $
��Stop��5      $
��Left=�6    $��586,330,0,0q�6;   $	��Top=�6P   $��39��6h   $	��136��6t   6�   5      5      