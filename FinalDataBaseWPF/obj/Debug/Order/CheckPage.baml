   M S B A M L   `   `   `  ����K  GFinalDataBaseWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:FinalDataBaseWPF.OrderFinalDataBaseWPF.Order  5      &     FinalDataBaseWPF.Order.CheckPage   5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:FinalDataBaseWPF.Order     5        N� Title$  	CheckPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��0.25* �6   �� 5      $��0.25* �6   �� 5      $��0.25* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� -   5        $��1��5      $��7��6!   $��Добавить��6.   $��5q�6A   ���	#FFF67D7D$��PT Serif)�6z   $��25��6�   ��6c   Z� 6�   �� 5   
   -   5        $��2��5      $��7��6!   $��Изменить��6.   $��5q�6A   ���	#FFF67D7D$��PT Serif)�6z   $��25��6�   ��6c   Z� 6�   �� 5   
   -   5        $��3��5      $��7��6!   $��Удалить��6.   $��5q�6@   ���	#FFF67D7D$��PT Serif)�6y   $��25��6�   ��6b   Z� 6�   �� 5    
   -   5        $��0��5       $��7��6!   $3��-Оплатить и выгрузить чек��6.   $��5q�6Q   ���	#FFF67D7D$��PT Serif)�6�   $��25��6�   ��6s   Z� 6�   &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ 	checkList��5!      $��7��6&   $��5q�6M   $��PT Serif)�6X   ��67   Z� 6n   �� 5"   
   $��3��6   $��1��6(   $��5q�68   $.��(Данные для заполнения��6C   $��PT Serif)�6`   $��Center=�6v   $��25��6�   �� 5#   
   -   5         ��Name$ orderBox��5#      $��3��6%   $��1��69   $��1��6I   $��PT Serif)�6V   $��5q�6l   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Номер заказа��6w   $��25��6�   6�   �� 5$   
   -   5         ��Name$	 sum��5$      $��3��6   $��1��61   $��2��6A   $��PT Serif)�6N   $��5q�6d   $ 
Сумма��6o   $��25��6�   �� 5%   
   -   5         ��Name$ contrTbx��5%      $��3��6$   $��1��68   $��3��6H   $��25��6U   $��PT Serif)�6a   $��5q�6w   $ Внесенно��6�   �� 5&   
   -	   5        $ OddTbx��5&      $��3��6"   $��1��66   $��4��6F   $��25��6S   $��PT Serif)�6_   $��5q�6u   $ 
Сдача��6�   (  "System.Windows.Controls.DatePicker  5'   
   -
   5          Name$ 
datePicker��5'      $��3��6)   $��1��6=   $��5��6M   $��25��6Z   $��PT Serif)�6f   $��5q�6|   $ Дата чека��6�   6�   5(      5)      