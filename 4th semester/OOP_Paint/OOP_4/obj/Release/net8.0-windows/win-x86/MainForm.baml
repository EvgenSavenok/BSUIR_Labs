   M S B A M L   `   `   `  ���� U  QSystem.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem  	 OOP_4   OOP_3.MainForm   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ?system,clr-namespace:System;assembly=System.Runtime     -     � Title$  Paint��$	��450��$	��800��.���  � RowDefinitions �� $
��Auto ��� $��0.07* ��� $��* �.+�� $��0��.+�o� $��25��$	��Top=�$��16(�
�������.@�m� $��Файл��.@�m� $'��!Открыть в формате:��.@�m� -   $
��JSON��m� -   $��Бинарный��m� -   $	��XML��m� $+��%Сохранить в формате:��.@�m� -   $
��JSON��m� -   $��Бинарный��m� -   $	��XML��m� -   $%��Загрузить модуль��m� -	   $!��О разработчике��m� -
   $��Помощь��� $��1�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $��* �.+��� -    ��Name$ ShapesCb��$��0��$
��Left=�$��10q� �� SelectedIndex$ 0��$
��Auto��$��16(����� *ComboBoxItems+ �� SelectedItem �� *SelectedIndex+�� -    ��Name$ 	CursorBtn��$��1��$
��Left=�$��10q�
���   �$��3q�.���� $��/Images/Cursor.png���� -   $��2��$
��Left=�$��10q�
������$��Очистить��$	��100��$��16(��� -   $��ColorCb��$��3��$��Right=�$��10q�$ 0������  �� 
TargetType" ��.���  �� Property � ��	 �� Value	 �� .R��� $��20��$��20��$��0,2,0,2q����� .@���	Black����	Green����Blue����Pink����Red����
Purple����
Yellow���� -   
 ��Name$
 	CanvasRow��$��2��
���   �$��1q�$��Stretch=�$��Stretch=�$��10q�._��� -    ��Name$ Canvas��$
|�True��
������ 