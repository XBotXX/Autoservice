   M S B A M L   `   `   `  ����F  BAutoservice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Autoservice.PagesAutoservice.Pages  5      '    !Autoservice.Pages.PageListClients   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Autoservice.Pages     5        N� Title$  PageListClients��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      �� 5      $��30 �6   �� 5      $��50 �6   .+�5   
   �� $��List Clients��6   $��Center=�6'   $��Center=�6D   $��Center=�6_   $��15(�6�   $��DemiBold"�6�   $��0,5,0,0q�6�   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $	��150 �6#   �� 5      .+�5      �� $��15(�6   $
��5,10q�6"   $��Center=�60   $��Center=�6R   $��0��6v   $��Search:��6�   
�������$��1q�6�   
���   �6�   �� 5      -   5         ��Name$ TxtSearchClients��5   A   $��15(�6[   $
��5,10q�6i   $��Center=�6w   $��1��6�   5      � 5    
   $��2��6    5!      �� 5"      �� 5#      �� 5$      .+�5'      �  5(      �� 5)      $	��100 �6'   �� 5*      .+�5,      �� $��Gender:��6   $��Center=�6*   $��15(�6E   $��Center=�6S   �� 5-      -   5         ��Name$ ComboNameGender��5-      $��1��64   $��	0,10,5,10q�6D   $��Center=�6W   $��15(�6r   $��Center=�6�   6�   5.      �� 50       �� Orientation$ 
Horizontal=�6   $��1��62   $��Center=�6B   .+�51      �� $��DateBirth this month:��6   $��Center=�68   $��15(�6S   $��Center=�6a   �� 52      -   5         ��Name$ 
checkMonth��52      $��1��6/   $
��10,5q�6?   $��Center=�6M   $��Center=�6o   $��Center=�6�   
��� ���6�   53      � 55      $��2��6    56      �� 57      �� 58      �� 59      .+�5;      �� -   5         ��Name$ BtnAddClents��5;      $��15(�6/   $
��5,10q�6=   $��Center=�6K   $��0��6m   $��
Add Client��6}   
��� ���6�   �� 5<      -   5        $ BtnDeleteClient��5<      $��15(�62   $
��5,10q�6@   $��Center=�6N   $��1��6p   $��Delete Client��6�   
��� ���6�   �� 5=      -   5        $ BtnViewVisitsClient��5=      $��15(�66   $
��5,10q�6D   $��Center=�6R   $��2��6t   $��Visits��6�   
��� ���6�   5>      5A      &   System.Windows.Controls.DataGrid  5C   
   -   5          Name$ 	DgClients��5C       $��3��6   $	��5,0q�63   	   AutoGenerateColumns	 .  
   CanUserAddRows
 .     CanUserDeleteRows .     
IsReadOnly .    Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn   Header$  идентификатор��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *
IdClient+6Y     5F      $ пол��6%   $ * 6R    62   �� *Gender.Name+6R     5G      $ имя��6%   $ * 6O    62   �� *
LastName+6O     5H      $ фамилия��6%   $ * 6T    66   �� *	FirstName+6T     5I      $ отчество��6%   $ * 6V    67   �� *
MiddleName+6V     5J      $ дата рождения��6%   $ * 6i    6<   �� *
BirhDate+ �� StringFormat$ d��6i     5K      $ телефон��6%   $ * 6P    66   �� *Phone+6P     5L      $' !электронная почта��6%   $ * 6Z    6@   �� *Email+6Z     5M      $# дата добавления��6%   $ * 6j    6>   �� *	RegDate+$ d��6j     5N      $6 0дата последнего посещения��6%   $ * 6h    6H   �� *LastService+6h     5O      $- 'количество посещений��6%   $ * 6]    6C   �� *Count+6]   4  .System.Windows.Controls.DataGridTemplateColumn  5P      $ * 6)   $ теги��63      CellTemplate 5Q      �� 5R      .R�5S      �� ��6+   �� *	ListTag+��5T   "   �� 5U   &   .R�5V   *   �� ��64   �� *	NameTag+��5W   .   �� 5X   2    �� Color 6B   �� *
ColorTag+5Z   +   5[   '   5]      5^      5`      5b      �� 5d   
   -   5         ��Name$ LblCountRowFromAll��5d      $��230 from 450��6,   $��Right=�6C   $��Center=�6_   $��15(�6z   $��4��6�   $��0,0,5,0q�6�   � 5f   
   $��5��6    5g      �� 5h      �� 5i      �� 5j      .+�5l      �� -	   5        $ BtnLastList��5l      $��15(�6*   $��10,10q�68   $��Center=�6G   $��0��6i   $
��Back��6y   
��� ���6�   �� 5m      -
   5        $ ComboCountRow��5m      $��1��6.   $��10,10q�6>   $��Center=�6M   $��15(�6h   $��Center=�6v   6�   �� 5n      -   5        $ BtnNextList��5n      $��15(�6*   $��10,10q�68   $��Center=�6G   $��2��6i   $
��Next��6y   
��� ���6�   5o      5q      5r      