   M S B A M L   `   `   `  ����@  <picDb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:picDb.WindowspicDb.Windows  5   	   $    picDb.Windows.PhotographerEdit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:picDb.Windows     5   	     � Title$  PhotographerEdit��5   	   $	��250��6"   $	��500��6/   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��3* �6   .+�5   
   �� $��0��6   $��0��6   .��6-   First Name:6;   �� 5   
   $��0��6   $��1��6   ��6/   �� *1/PhotographersList.CurrentPhotographer.FirstName+�� 5   
   $��1��6   $��0��6   .��6-   
Last Name:69   �� 5   
   $��1��6   $��1��6   ��6/   �� *0.PhotographersList.CurrentPhotographer.LastName+�� 5   
   $��2��6   $��0��6   .��6-   	Birthday:68   �� 5   
   $��2��6   $��1��6   ��6/   �� *0.PhotographersList.CurrentPhotographer.Birthday+�� 5!   
   $��3��6   $��0��6   .��6-   Notes:65   �� 5"   
   $��3��6   $��1��6   ��6/   �� *-+PhotographersList.CurrentPhotographer.Notes+�� 5$   
   -   5        $��4��5$      $��1��6   $��0,15,0,0q�6G   .��6Y   Save6_   �� 5'   
   -   5        $��PhotographersListBox��5'   3   $��6��6   $��2��6#   $��10,0,0,0q�5(   [   ��6   ��  �� Path$% PhotographersList.Photographers���5)      �� 5*      .R�5+      �  5,      �� 5-      $
��Auto �6/   �� 5.      $��* �6/   .+�50      �� $��2q�6$   $��0��6/   ��6?   �� *
LastName+�� 51      $��2q�6$   $��1��6/   ��6?   �� *	FirstName+52      53      55      56      57      