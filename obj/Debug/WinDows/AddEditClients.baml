   M S B A M L   `   `   `  ����F  BAutoservice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Autoservice.WinDowsAutoservice.WinDows  5   	   (    "Autoservice.WinDows.AddEditClients   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Autoservice.WinDows     5   	     � Title$  AddEditClients��5   	   $	��450��6    $	��800��6-    � WindowStartupLocation$ CenterOwner=�69   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ LblID��5      $��0��6   $	��ID:��6,   $��Center=�6:   $��Center=�6W   $��15(�6r   �� 5   
   -   5         ��Name$ TxtID��5      {�.  $��1��63   $��Center=�6C   $��15(�6^   $��0,0,20,0q�6l   �� 5   
   $��1��6   $��Name:��6   $��Center=�6-   $��Center=�6J   $��15(�6e   �� 5   
   -   5        $ TxtFirstName��5      $��1��6(   $��1��68   $��Center=�6E   $��15(�6`   $��0,0,20,0q�6n   �� 5!   
   $��2��6   $��Surname:��6   $��Center=�60   $��Center=�6M   $��15(�6h   �� 5"   
   -   5        $ TxtLastName��5"      $��1��6'   $��2��67   $��Center=�6D   $��15(�6_   $��0,0,20,0q�6m   �� 5$   
   $��3��6   $��MiddleName:��6   $��Center=�63   $��Center=�6P   $��15(�6k   �� 5%   
   -   5        $ TxtMiddleName��5%      $��1��6)   $��3��69   $��Center=�6F   $��15(�6a   $��0,0,20,0q�6o   �� 5'   
   $��4��6   $��Email:��6   $��Center=�6.   $��Center=�6K   $��15(�6f   �� 5(   
   -   5        $ TxtEmall��5(      $��1��6$   $��4��64   $��Center=�6A   $��15(�6\   $��0,0,20,0q�6j   �� 5*   
   $��5��6   $��Phone:��6   $��Center=�6.   $��Center=�6K   $��15(�6f   �� 5+   
   -   5        $ TxtPhone��5+      $��1��6$   $��5��64   $��Center=�6A   $��15(�6\   $��0,0,20,0q�6j   �� 5-   
   $��7��6   $��Gender:��6   $��Center=�6/   $��Center=�6L   $��15(�6g   �� 5.   
   -   5         ��Name$ ComboGender��5.       �� DisplayMemberPath$
 Name��6(   $��1��6A   $��7��6Q   $��Center=�6^   $��15(�6y   $��0,0,20,0q�6�   �� 50   
   $��8��6   $��	BithDate:��6   $��Center=�61   $��Center=�6N   $��15(�6i   (  "System.Windows.Controls.DatePicker  51   
   -	   5          Name$ DtPikerBithDate��51      $��1��6.   $��8��6>   $��Center=�6K   $��15(�6f   $��0,0,20,0q�6t   �� 53   
   $��0��6   $��2��6   $��Foto:��6-   $��Center=�6=   $��Center=�6Z   $��15(�6u   �� 54   
   -
   5        	 ��Name$	 ImgFoto��54      $��2��6!   $��1��61   $��	20,0,20,0q�6>   $��3��6Q   �� 55   
   -   5        
 ��Name$
 BtnOpenFileDialog��55      $��Open...��6,   $��2��6>   $��4��6N   $��15(�6[   $��	20,0,20,0q�6i   $��Center=�6|   
��� ���6�   �� 57   
   $��5��6   $��2��6   $
��Tag:��6-   $��Center=�6<   $��Center=�6Y   $��15(�6t   &   System.Windows.Controls.DataGrid  58   
   -   5          Name$ DgTag��58      $��2��6"   $��6��62   $��	20,0,20,0q�6?   $��3��6R      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly .    Columns 59      4  .System.Windows.Controls.DataGridTemplateColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$
 Tags��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 67      CellTemplate 5;      �� 5<      .R�5=      �� ��6(   �� *	NameTag+��5>   "   �� 5?   &    �� Color 66   �� *
ColorTag+5A      5B      5D      5F      � 5H   
   $��9��6   $��2��6    5I      �� 5J      �� 5K      .+�5M      �� -   5        $
 	BtnAddTag��5M      $��Add Tag��6(   $��0��6:   $��15(�6J   $��	20,0,20,0q�6X   $��Center=�6k   
��� ���6�   �� 5N      -   5        $
 BtnDelateTag��5N      $��Del Tag��6+   $��1��6=   $��15(�6M   $��	20,0,20,0q�6[   $��Center=�6n   
��� ���6�   5O      �� 5R   
   -   5        $
 BtnSave��5R      $
��Save��6"   $��1��61   $��9��6A   $��15(�6N   $��0,0,20,0q�6\   $��Center=�6n   
��� ���6�   5S      5T      