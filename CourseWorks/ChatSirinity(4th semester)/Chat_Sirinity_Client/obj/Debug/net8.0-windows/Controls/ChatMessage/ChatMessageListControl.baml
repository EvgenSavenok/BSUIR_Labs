   M S B A M L   `   `   `  ����O  KChat_Sirinity_Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Chat_Sirinity_Client.ControlsChat_Sirinity_Client.Controls  5      G(clr-namespace:Chat_Sirinity_Client.PagesChat_Sirinity_Client.Pages  5      U/clr-namespace:Chat_Sirinity_Client.Chats.Design!Chat_Sirinity_Client.Chats.Design  5      i9clr-namespace:Chat_Sirinity_Client.Chats.InputChatMessage+Chat_Sirinity_Client.Chats.InputChatMessage  5	      �Gclr-namespace:Chat_Sirinity_Client.Chats.InputChatMessage.MessageDesign9Chat_Sirinity_Client.Chats.InputChatMessage.MessageDesign  5
      :    4Chat_Sirinity_Client.Controls.ChatMessageListControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Chat_Sirinity_Client.Controls     5      :pages(clr-namespace:Chat_Sirinity_Client.Pages     5      Bdesign/clr-namespace:Chat_Sirinity_Client.Chats.Design     5      Mmessage9clr-namespace:Chat_Sirinity_Client.Chats.InputChatMessage     5	      amessageDesignGclr-namespace:Chat_Sirinity_Client.Chats.InputChatMessage.MessageDesign     5
      .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   
�������$��30��6/    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5!      �� $
��Lera��6   
���   �$��14(�5#      $��Center=�5$      $��Center=�5%      �� 5&      $��1��6    �� Orientation$ 
Horizontal=�5'      $��0 0 5 0q�5(      .+�5)      ��    TitleBarBtnStyle#��[  6   .��5*      �� $*��$/Images/TatleBarIcons/SearchIcon.png��6   6L   5+      5,      5-      � 5/   
   $��1��6   Z   TChat_Sirinity_Client.Chats.InputChatMessage.MessageDesign.ChatMessageListDesignModel   DesignInstance � DataContext# Z 6   .+�50      �� $
��Auto=�6   .��51      �� ��6   �� *Items+��52      �� 53      .R�54      >   8Chat_Sirinity_Client.Controls.ChatMessageListItemControl  55      57      58      59      � 5;   
   $��2��6   $��70��6   
������� 5>      �� 5@      $
��Auto �6#   �� 5B      $��* �6#   �� 5D      $
��Auto �6#   .+�5H      �� $��3 0 0 5q�6   #��[  5J      ��5I      �� *Height+ �� RelativeSource ��  �� AncestorType Grid.��5K      �� $,��&/Images/TextBoxIcons/PaperclipIcon.png��6   6J   5L      �� 5O      $��1��6   $��0 0 0 7q�5P      
 � Tag$$ Царапать здесь...��5Q      $��16(�5S      $��0q�5T       �� AcceptsReturn$
 True��5U      	 �� 
AcceptsTab$
	 True��5V      $��Center=�5W      ��5R      �� *PendingMessageText+
 �� UpdateSourceTrigger$
 PropertyChanged=�5W      �� 5Z      $��2��6   $ 
Horizontal=�5[      .+�5]      �� $��0 0 5 0q�6   #��[  5_      ��5^      �� *Height+ ��  Grid.��5`      �� $)��#/Images/TextBoxIcons/SmileIcon2.png��6   6K   5a      �� 5c      #��[  6   $��0 0 5 0 q�5d      ��5e      �� *SendCommand+.��5f      �� $'��!/Images/TextBoxIcons/SendIcon.png��6    6M   5g      5h      5j      5l      5n      