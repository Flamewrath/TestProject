   M S B A M L   `   `   `  ����  
RssWindows    RssWindows.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          �Name$  MainForm��5   	    � Title$ 	RSS-Lenta��5   	   $	��600��6   $
��1200��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��3* �6   �� 5      $��7* �6   .+�5   
   c� $	��Top=�6   $��25��6*   $��2��66   .@�5      �� -   5         ��Name$ ButtonRefresh��5      $��Обновить��6,   $��20��6?   $	��100��6K   ���	#FFE0E0E0
���   �6�   �� 5      -   5        $ UploadToDatabase��5      $��Сохранить��6/   $��20��6C   $	��100��6O   ���	#FFE0E0E0
���   �$��5,0,0,0q�6�   6�   �� 5      -   5        $ ExitApp��5      $��
Выйти��6&   $��20��66   $	��100��6B   ���	#FFE0E0E0
���   �$��5,0,0,0q�6y   6�   5      �� 5   
   -   5         ��Name$ NewsIC��5      $��2��6'   $��0,25,0,0q�6;   ��5      �� 5      .R�5      �� $	��Top=�6=   $	��160��6U   ��6   �� *
GroupTitle+.��5      � $��Stretch=�6   $��0,0,0,5q�6=    5      �� 5   "   $��* �63   �� 5   "   $	��100 �63   .+�5      ��  ��Name$ ImageBox��6$   $
��Left=�66   $	��129��6p   $	��Top=�6}   $	��148��6�   ��6Q   �� *PicturePath+6�   �� 5      $
��Left=�6>   $��	150,0,0,0q�6Y   $	��Top=�6l   $
��Bold"�6�   $��Arial Black)�6�   $��18(�6�   ��6$   �� *Title+6�   �� 5      $
��Left=�6(   $��
150,36,0,0q�6C   $
��Wrap=�6n   $	��Top=�6�   $	��101��6�   ��6W   �� *Descr+6�   5      5       5!      5#      5$      5%      