   M S B A M L   `   `   `  ����   OnlineTradingSystem$    OnlineTradingSystem.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Online Trading System��$	��460��$	��568�� � Topmost .  � Icon$ IconPaint.ico�� � 	Resources  �� MergedDictionaries �� Source��  �� $ Style\ButtonStyle.xaml?��� $ Style\TabStyle.xaml?��� $ Style\BorderStyle.xaml?��� $ Style\DatagridStyle.xaml?�%    .��� .+�� -   $��grid1��$	��311��$
��Left=�$��Stretch=�$	��503��.+��� -   $��	groupBox1��$
��Menu��$
��Left=�$��Stretch=�$	��114��$	��305�� J� 	AllowDrop . .��� $��97�����	#FFAAAAAA J� SnapsToDevicePixels .  .+��� -   $��ItemAdd��$��Add Item��$��43��$
��Left=�$	��Top=�$��Stretch=�$��89��$��2,6,0,0q�d� -   $��
RemoveItem��$��Remove Item��$��43��$
��Left=�$��	1,203,0,0q�$	��Top=�$��89���� -   $��addcolum��$��	Add Colum��$��43��$
��Left=�$��2,55,0,0q�$	��Top=�$��89���� -   $��Export_data��$��Export Data��$��43��$
��Left=�$��	2,104,0,0q�$	��Top=�$��89���� -   $��BackMainWindow��$��Main Window��$��43��$
��Left=�$��	2,353,0,0q�$	��Top=�$��89���� -	   $��Import_data��$��Import Data��$��43��$
��Left=�$��	2,153,0,0q�$	��Top=�$��89���� -
   $��Product_Sales��$��Product Sales��$��43��$
��Left=�$��	2,303,0,0q�$	��Top=�$��89���� -   $��Costumer_List��$��Costumer List��$��43��$
��Left=�$��	2,253,0,0q�$	��Top=�$��89������  �� EndPoint$ 1,0.5&�	 �� 
StartPoint$	 0,0.5&�.��� 
 � Color$
 Black�� � Offset$ 0Q�� $
 	#FFF8EFEF��$ 1Q�� $
��auto��$��0,0,35,0q��� -   $��canvas1��$��331,0,60,278q�.+��� -   $��NameofStore��$��33��$��	TextBlock�� �� Left$ 45��
 �� Top$ 3��$��25(�$��Showcard Gothic)�$	��Top=��� -   $��image1��$��36��$
��Fill=�$��37��$6��0/OnlineTradingSystem;component/Images/market.jpg��$ 0��$ 3����  �� TabStripPlacement$	 Top=�$��120,1,60,-1q�$
��Left=�.@���  �� 
IsSelected . $��Salse��$��35��.���� .��� -   $
��Warp��$	��300��$	��370��$	��600��$
��Auto��$
��Left=�$��10,5,0,0q�$	��Top=�$
��Auto���� -   $��Product List��.���� $
��Auto=�.��&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .    CanUserSortColumns .    RowBackground
 �����   AlternatingRowBackground
 ��ح�   SelectionMode$ Extended=�   	RowHeight$ 30Q�   CanUserAddRows .     CanUserDeleteRows .    CanUserReorderColumns .    CanUserResizeColumns .    CanUserResizeRows .     RowDetailsTemplate �� .R��� 
���   �._��� $��50���� -   $��tabItem1��$��
Youre Site��.��� .+�(  "System.Windows.Controls.WebBrowser  -   $��MyWebrowser��$
��auto��$
��Left=�$��6,6,0,0q�$	��Top=�$
��auto��