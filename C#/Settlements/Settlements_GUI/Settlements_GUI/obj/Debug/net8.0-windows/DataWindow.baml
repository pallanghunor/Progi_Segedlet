   M S B A M L   `   `   `  ����J  FSettlements_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Settlements_GUISettlements_GUI  5   	        Settlements_GUI.DataWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Settlements_GUI     5   	     � Title$  
Új város��5   	   $	��450��6   $	��400��6'   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��Név:��6   $��0��6   $��Center=�6,   �� 5   
   $��Megye:��6   $��1��6!   $��Center=�6.   �� 5   
   $��Régió:��6   $��2��6!   $��Center=�6.   �� 5   
   $��Népesség:��6   $��3��6$   $��Center=�61   �� 5   
   $��	Terület:��6   $��4��6#   $��Center=�60   �� 5   
   $��0��6   $��1��6   $��30��6/   ��6;   �� *NewSettlement.Name+�� 5   
   $��1��6   $��1��6    $��30��60    �� DisplayMemberPath$
 Name��6]   ��6<   �� *
Counties+ �� SelectedItem 6v   �� *NewSettlement.County+�� 5   
   $��2��6   $��1��6   $��30��6/   ��6;   �� *NewSettlement.Region+�� 5   
   $��3��6   $��1��6   $��30��6/   ��6;   �� *NewSettlement.Population+�� 5   
   $��4��6   $��1��6   $��30��6/   ��6;   �� *NewSettlement.Areasize+�� 5    
   -   5         ��Name$ save_BTN��5       $��5��6#   $��2��60   $	��150��6D   $��40��6P   $��Mentés��6\   6m   5!      5"      