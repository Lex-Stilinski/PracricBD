   M S B A M L   `   `   `  ����K  GFinalDataBaseWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FinalDataBaseWPFFinalDataBaseWPF  5   	   #    FinalDataBaseWPF.ClientWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:FinalDataBaseWPF     5   	     � Title$  ClientWindow��5	   	   $	��450��6   $	��450��6+   $	��800��6;   $	��500��6G   ���	#FFF7B4B4.��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� -   5        $��4��5      $��2��6!   $��5q�6.   ���	#FFF67D7D$��PT Serif)�6g   $��Сбросить��6}   $��12(�6�   $��25��6�   ��6P   Z� 6�   �� 5   
   -   5        $��0��5      $��2��6!   $��5q�6.   ���	#FFF67D7D$��PT Serif)�6g   $)��#Смена пользователя��6}   $��12(�6�   $��25��6�   ��6P   Z� 6�   �� 5   
   -   5         ��Name$ 
ComboGenre��5      $��0��6'   $��5q�67   $��PT Serif)�6B   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Жанр��6X   6~   �� 5   
   -   5        $ 
ComboLabel��5      $��1��6'   $��5q�67   $��PT Serif)�6B   $ 
Лейбл��6X   6   �� 5   
   -   5        $ 	ComboType��5      $��2��6&   $��5q�66   $��PT Serif)�6A   $ Тип��6W   6|   �� 5   
   -   5        $ ComboGroupe��5      $��3��6(   $��5q�68   $��PT Serif)�6C   $ Группа��6Y   6�   �� 5   
   -   5        $ 	ComboYear��5      $��4��6&   $��5q�66   $��PT Serif)�6A   $ Год релиза��6W   $��25��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataProduct��5      $��1��6(   $��5��65   $��5q�6I   ���	#FFF6CFCF$��PT Serif)�6k   5      5       