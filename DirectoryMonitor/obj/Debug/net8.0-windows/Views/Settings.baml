   M S B A M L   `   `   `  ����K  GDirectoryMonitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DirectoryMonitor.ViewsDirectoryMonitor.Views  5   	   %    DirectoryMonitor.Views.Settings   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:DirectoryMonitor.Views     5   	     � Title$  Settings��5   	   $	��200��6   $	��400��6'   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��10 �6   �� 5      $��8* �6   �� 5      $��1* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��10 �6   .+�5   
   �� $��1��6   $��1��6$   $
��Path��61   $	��0 5q�6=   �� 5   
   -   5        $��DirectoryPath��5   2   $��1��6G   $��2��6W   ��6   �� *InputDirectory+6W   �� 5   
   -   5        $��2��5      $��2��6!   $��Right=�6.   $��Center=�6J   $��20��6e   $	��...��6q   6   �� 5   
   $��1��6   $��3��6$   $��	Frequency��61   $	��0 5q�6B   �� 5   
   -   5        $��FrequencyNumber��5   g   $��1��66   $��2��6F   $��4��6Z   $��20��6~   ��6   �� *FrequencyInSeconds+6�   �� 5!   
   -   5        $��2��5!   4   $��5��6D   $��Right=�6Q   $��Center=�6m   $
��Save��6�   $
��0 10q�6�   ��6   �� *ChangeSettings+6�   5"      5#      