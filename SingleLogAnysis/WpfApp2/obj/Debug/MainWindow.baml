   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  Single Log Analysis��5   	   $	��250��6%   $	��500��62   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��PathBox��5      $��30,15q�5      $��0��5      5      �� 5   
   -   5        $��
KeywordBox��5      $��30,15q�5      $��1��5      5      �� 5   
   -   5        $��30,15q�5      $��2��5      $��Analyze��5      $	��150��5      $��40��5       � 5"   
   $��3��6   $��	0,20,30,0q�6   $��Right=�6/    � ColumnDefinitions 5#      �� 5$      $
��Auto �6#   �� 5%      $
��Auto �6#   �� 5&      $��50 �6#   �� 5'      $
��Auto �6#   �� 5(      $
��Auto �6#   .+�5*      �� $��0��6   $��	回数：��6(   �� 5+      -   5        $��TimesBox��5+   (   $��1��6   6(   �� 5,      $��3��6   $��	時間：��6(   �� 5-      -   5        $��	TimingBox��5-   (   $��4��6   6(   5.      5/      50      