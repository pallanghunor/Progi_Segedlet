   M S B A M L   `   `   `  ����J  FSettlements_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Settlements_GUISettlements_GUI  5   	        Settlements_GUI.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Settlements_GUI     5   	     � Title$  Települések��5   	   $	��450��6   $	��800��6*   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��6      
IsReadOnly$
 True��6/      SelectionMode$ Single=�6A   ��6X   �� *Settlements+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Id+  5      $
 Név��6%   $ * 62    6<   �� *Name+  5      $ Megye��6%   $ * 64    6>   �� *County.Name+  5      $ Régió��6%   $ * 64    6>   �� *Region+  5      $ 
Népesség��6%   $
 Auto 67    6D   �� *
Population+  5      $ Terület��6%   $
 Auto 66    6C   �� *
Areasize+5      �� 5   
   -   5        	 ��Name$	 new_BTN��5      $��Új felvétel��6"   $��1��68   $	��150��6E   $��40��6Q   $��20q�6]   6i   5      5      