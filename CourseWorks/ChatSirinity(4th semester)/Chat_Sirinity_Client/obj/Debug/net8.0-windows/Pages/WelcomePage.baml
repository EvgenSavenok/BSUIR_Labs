   M S B A M L   `   `   `  ����  Chat_Sirinity_Client&     Chat_Sirinity_Client.WelcomePage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  WelcomePage��5      $	��450��6   $	��800��6(    � 	Resources 5         BackgroundBrush �� ImageSource  GradientStyle �� 
StartPoint �� EndPoint � Color � Offset  CustomButtonStyle �� 
TargetType �� Property	 �� Value
 �� 
TargetType ��Name �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 6     &	 �     7  �� 5	   
   $" /images/emoji-background.png��6-   �� 5
   
   $ 0.5,1&�64   $ 0.5,0&�6G   .��5      � $ 	LightBlue��6   $ 0Q�6-   � 5      $ Yellow��6   $ 1Q�6*   5      �� 5   
   " ��6*   .�5      ��  � ��8	   6+   �� 5       � ��$	 0q�60   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� $ border��6!   #��z��5   !   #��z��5   !   #��z��5   !   $ 5��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   5       5      P� 5       �@J�IsMouseOver$
 True��6=   . �5   "   �� $ border��6)    � ��	 �#CCE5FF6S   5      5!      5#      5$      5%      .��5&      � ��5'   
   �� 5(       �� Color$ #CCE5FF��6   .+�5*   
   � #��[  6   � 5+   
    � RowDefinitions 5,      �� 5-      $
��0.6* �6    �� 5.      $��1* �6    .+�50      � $��0��6   $��Center=�6    .+�51      � .+�52      ��  �� Padding$ 0, 30, 0, 0q�53      $&�� Добро пожаловать!��54      $��Center=�55      $��29(�56      ���#c49a1a$��Segoe UI)�58      59      5:      5;      �� 5<      
�������$ 10��6(    �� Padding$ 10q�6:   $	��300��6G   $��Center=�5=      $	��Top=�62   $��1��6J   ._�5>      �� .+�5?      �� -   5        $��15(�5?      $��40��6+   $��
Войти��5@      #��[ 5A      $��Segoe UI)�5B      ��5?   7   ��  �� ElementName$ RegisterBtn�� �� Path$ ActualWidth�5D      �� 5E      -   5         ��Name$ RegisterBtn��5E      $��15(�62   $��40��6@   $
��Auto��6L   $*��$Зарегистрироваться��5F      #��[ 5G      $��Segoe UI)�5H      $��0, 10, 0, 0q�5J      5K      5L      5M      5N      5O      5P      