   M S B A M L   `   `   `  ����D  @Lab3-View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Lab3_View	Lab3_View  5   	       Lab3_View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Lab3_View     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��325��6)   .��5	      � $��0,0,0,-6q�6    � ColumnDefinitions 5
   
   �� 5      $��81 �6   �� 5      $��81 �6   �� 5      $��81 �6   �� 5      $��81 �6   .+�5   
   �� -   5         ��Name$ ConnectButton��5      $��Connect��6(   $��Center=�6:   $��0,39,0,0q�6W   $	��Top=�6i   $��3��6�   6�   �� 5   
   -   5        $ 
SendButton��5      $
��Send��6%   $��10,368,10,0q�64   $��5��6I   $��26��6Y   $	��Top=�6e   6}   �� 5   
   -   5         ��Name$ 	IpTextBox��5      $
��Left=�6%   $��4,14,0,0q�6@    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $	��120��6~   $��1��6�   $��2��6�   $��	127.0.0.1��6�   �� 5   
   -   5        $ UserNameTextBox��5      $
��Left=�6+   $��4,44,0,0q�6F   $
 Wrap=�6X   $	��Top=�6l   $	��120��6�   $��1��6�   $��2��6�   �� 5   
   -   5        $ ReceivedMessageTextBox��5      $
 Wrap=�62   $	��Top=�6F   $��0��6^   $��4��6n   $
��True��6�   " �� VerticalScrollBarVisibility$ Visible=�6�   $	��291��6�   $��
10,72,10,0q�6�   �� 5   
   -   5        $ SendMessageTextBox��5      $��10,368,10,0q�6.   $
 Wrap=�6C   $��0��6W   $��3��6g   $��25��6{   $	��Top=�6�   �� 5   
   $��Address��6   $
��Left=�6"   $��	10,10,0,0q�6=   $	��Top=�6P   $��70��6h   �� 5   
   $��	User Name��6   $
��Left=�6$   $��	10,40,0,0q�6?   $	��Top=�6R   5      5      