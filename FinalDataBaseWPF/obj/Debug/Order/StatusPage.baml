   M S B A M L   `   `   `  ����K  GFinalDataBaseWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:FinalDataBaseWPF.OrderFinalDataBaseWPF.Order  5      '    !FinalDataBaseWPF.Order.StatusPage   5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:FinalDataBaseWPF.Order     5        N� Title$  
StatusPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��0.25* �6   �� 5      $��0.25* �6   �� 5      $��0.25* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� -   5        $��1��5      $��3��6!   $��Добавить��6.   $��5q�6A   ���	#FFF67D7D$��PT Serif)�6z   $��25��6�   ��6c   Z� 6�   �� 5   
   -   5        $��2��5      $��3��6!   $��Изменить��6.   $��5q�6A   ���	#FFF67D7D$��PT Serif)�6z   $��25��6�   ��6c   Z� 6�   �� 5   
   -   5        $��3��5      $��3��6!   $��Удалить��6.   $��5q�6@   ���	#FFF67D7D$��PT Serif)�6y   $��25��6�   ��6b   Z� 6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
statusList��5      $��4��6'   $��5q�6N   $��PT Serif)�6Y   ��68   Z� 6o   �� 5   
   $��3��6   $��1��6(   $��5q�68   $.��(Данные для заполнения��6C   $��PT Serif)�6`   $��Center=�6v   $��25��6�   �� 5   
   -   5         ��Name$ 	statusTbx��5      $��3��6%   $��1��69   $��1��6I   $��PT Serif)�6V   $��5q�6l   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Статус��6w   $��25��6�   5      5       