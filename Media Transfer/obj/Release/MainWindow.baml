   M S B A M L   `   `   `  ����   Media Transfer    Media_Transfer.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Media Transfer��$��254.667��$��503.667�� � 
ResizeMode$ NoResize=�.��� ���	#FFE0E0E0.+��� $��Source Folder��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��100��$	��258��.��]� ��.  $��4,9,6,0q�$��29��$	��Top=�.+��� -    ��Name$ txbx_SourceFolder�� �� TextWrapping$
 Wrap=�$	��211��$��24��$	��Top=�$��11(��� -    ��Name$ btn_SourceFolder��$	��...��$
��Left=�$��20��$��Right=�$��24��$	��Top=��� $��Target Folder��$
��Left=�$��
10,115,0,0q�$	��Top=�$	��100��$	��258��.��]� ��.  $��4,9,6,0q�$��29��$	��Top=�.+��� -   $ txbx_TargetFolder��$
 Wrap=�$	��211��$��24��$	��Top=�$��11(��� -   $ btn_TargetFolder��$	��...��$
��Left=�$��20��$��Right=�$��24��$	��Top=��� -   $ btn_StartTransfer��$��Start��$
��Left=�$��376,174,0,0q�$	��Top=�$	��100��$��32���� -    ��Name$ chbx_FormatImages��$��Photos (.jpg|.jpeg)��$
��Left=�$��
284,94,0,0q�$	��Top=��� -   $ chbx_FormatVideo��$ ��Video (.avi|.mp4|.mkv|...)��$
��Left=�$��284,115,0,0q�$	��Top=��� -    ��Name$ cmbx_DateFormat��$
��Left=�$��
284,36,0,0q�$	��Top=�$	��155�� �� SelectedIndex$ 0��.@��� $��day/month/year���� $��month/day/year���� $��year/month/day���� $��	Separator��$
��Left=�$��
284,63,0,0q�$	��Top=��� -	   $ txbx_separator��$
��Left=�$��23��$��
350,63,0,0q�$
 Wrap=�$��_��$	��Top=�$��22�� �� TextAlignment$ Center=�$��14(��� $��Options��$
��Left=�$��
273,10,0,0q�$	��Top=�$	��205��$	��212��.��� -
   	 �Name$	 progBar��$��18��$��	5,122,5,0q�$	��Top=����	#FF07F734$��1q�
 � LargeChange$
 50Q� � Minimum$ 20Q� � SmallChange$ 1Q� � Maximum$
 1000Q��� -   $ chbx_reWriteFiles��$��reWrite Files?��$
��Left=�$��
21,179,0,0q�$	��Top=��� -   $ chbx_subFolders��$%��Include subfolders for scaning?��$
��Left=�$��	21,76,0,0q�$	��Top=�