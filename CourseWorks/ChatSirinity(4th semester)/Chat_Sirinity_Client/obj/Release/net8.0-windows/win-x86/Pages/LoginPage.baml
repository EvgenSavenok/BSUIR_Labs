   M S B A M L   `   `   `  ����   Chat_Sirinity_Client$    Chat_Sirinity_Client.LoginPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  	LoginPage��$	��450��$	��800�� � 	Resources    BackgroundBrush �� ImageSource  GradientStyle �� 
StartPoint �� EndPoint � Color � Offset  CustomButtonStyle �� 
TargetType �� Property	 �� Value
 �� 
TargetType ��Name �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName  HoverLabelStyle �� Triggers  UnderlineLabel��%�  &	        &	 (     &	      7  &	 v    &	 �    �� $" /images/emoji-background.png���� $ 0.5,1&�$ 0.5,0&�.��� $ 	LightBlue��$ 0Q�� $ Yellow��$ 1Q��� " ��.���  � ��8	   ��  � ��$	 0q���  � ��	 �� "
 ��.R��� $ border��#��z��#��z��#��z��$ 5��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � ��	 �#CCE5FF�� " �� P�  �@J�IsMouseOver$
 True��. ���  � ��
	 ��  ��� " ��.���  � ��	 �#c49a1a��  � ��	 �� "
 ��.R��� #��z��$��	Underline{� P�  �@J�IsMouseOver$
 True��. ���  � ��
	 ��  �.��� ����  �� Color$ #CCE5FF��.+�� #��[   � RowDefinitions �� $
��0.4* ��� $
��0.7* ��� $
��0.6* �.+�� $��0��$��Center=�.+��� $��Вход��$��Center=�$��29(����#c49a1a$��Segoe UI)� �� Padding$ 0, 30, 0, 0q��� 
�������$ 10�� �� Padding$ 10q�$	��300��$��Center=�$��Center=�$��1��._��� .+�� $��0, 0, 10, 0q� � ColumnDefinitions �� $
��0.5* ��� $��* �.+��� $��0��$��Логин:�����#c49a1a$��Segoe UI)�$��18(��� -    ��Name$ LoginTb��$��1��$��16(�$
��Auto��$��24��.��� $��0, 0, 10, 0q� �� $
��0.5* ��� $��* �.+��� $��0��$��Пароль:�����#c49a1a$��Segoe UI)�$��18(��� -   $ 
PasswordTb��$��1��$��16(�$
��Auto��$��24��.��� .+��� -   $��0, 10, 0, 0q�$��
Войти��$��18(�$��40��$
��Auto��#��[ � .+��� -    ��Name$ ErrorLoginLabel��$=��7Неправильный логин или пароль��$��12(�
���  ��$y�	Collapsed=�$��0, 0, 0, -15q�� $��0, 15, 0, 0q� �� $
��Auto ��� $
��Auto ��� $��* �.+�� $��0��.+���  d� 	IsChecked$ FalseY�� $��1��.+��� $!��Запомнить меня��$��Segoe UI)�$��14(�$��
5, 0, 0, 5q�� $��2��$��Right=�.+��� $��0, 0, 0, 10q�$ ��Забыли пароль?��$��Segoe UI)�$��14(�#��[ � $��2��$
��Left=�.+��� -   $��0, 0, 0, 10q�$��На главную��$��Segoe UI)�$��Center=�$��Center=�$��40, 0 , 0, 0q�$��24(�#��[ 