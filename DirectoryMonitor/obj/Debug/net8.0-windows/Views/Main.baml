   M S B A M L   `   `   `  ����K  GDirectoryMonitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DirectoryMonitor.ViewsDirectoryMonitor.Views  5   	   !    DirectoryMonitor.Views.Main   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:DirectoryMonitor.Views     5   	   -   5        $
��main��5	   	     � Title$
  Main��5   	   $	��650��6   $
��1200��6#   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6   .+�5   
   �� $��1��6   $��1��6$   $��Trade Monitor��61   $��20(�6F   $
��Bold"�6T   $��Center=�6f   �� 5   
   $��1��6   $��2��6$   $��Files found:��62   $
��Left=�6F   $��Center=�6a   �� 5   
   $��1��6   $��2��6!   $��Settings��6�   $��Right=�6�   $
��Left=�6�   ��6.   �� *ShowSettingsWindowCommand+��6\   %  System.Windows.Markup.Reference     Name$
 main��6�   �� 5    
   -   5        $��DirectoryItems��5    W   $��1��6   $��4��6#   ���#cdcdcd��60   �� *DirectoryFiles+ �� View 5!      �� 5"      .P�5#      �� $��FileName��6K    �� Width$
 auto��6]    �� DisplayMemberBinding 6%   �� *Name+6]   �� 5$      $
��Path��6K   $
 auto��6Y    6%   �� *Path+6Y   �� 5%      $��	Extension��6P   $
 auto��6c    6%   �� *	Extension+6c   �� 5&      $��Action��6%   $
 auto��65    �� CellTemplate 5'      �� 5(      .R�5)   "   �� $
��Open��6)   $��Center=�6�   $��Center=�6�   ��68   �� *&$DataContext.ShowContentWindowCommand+ �� RelativeSource �� 	 �� AncestorType
	 Window��6�   �� 6�   5*      5,      5-      5/      50      51      