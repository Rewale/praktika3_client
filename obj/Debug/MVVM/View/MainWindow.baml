   M S B A M L   `   `   `  ����L  HServiceClient_app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ServiceClient_appServiceClient_app  5   	   S.clr-namespace:ServiceClient_app.MVVM.ViewModel ServiceClient_app.MVVM.ViewModel  5   	   "    ServiceClient_app.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ServiceClient_app     5   	   D	viewModel.clr-namespace:ServiceClient_app.MVVM.ViewModel     5   	   9i+http://schemas.microsoft.com/xaml/behaviors     5   	     � Title$  
MainWindow��5
   	   $	��650��6   $	��800��6)    � DataContext 5      4   .ServiceClient_app.MVVM.ViewModel.MainViewModel  5   
    � 	Resources 5       �� 
TargetType   DiscountVisibleTrigger �� Triggers �� Binding �� Value �� Property �� Value��%�   &	        �� 5   
   " ��6    5      �� 5       6   �� *
Discount+ 05      .a�5      ��  � y�$ Hidden=�63   5      5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5      6   �� 5      $	��12* �6   6+   �� 5      6   .+�5   
   � 
 � ColumnDefinitions
 5      �� 5       $��* �6#   6/   �� 5!      6%   .+�5#      �� -   5         �� DisplayMemberPath$ Title��5#   ;   ��6   �� *optionsSort+6�   �� 5$      -   5        $��1��5$      $ Title��6O   ��6'   �� *DiscountOptions+6�   5%      �� 5&   
   $��1��6    �� SelectionMode$ Single=�5(      $��Disabled=�5)      $��Stretch=�5*      ��5&       �� *
services+ �� NotifyOnSourceUpdated .  �� SelectedItem 5'      �� *selectedService+��5+      �� 5,      .R�5-      � 	 5.      �� 5/      6.   �� 50      6.   �� 51      6.   �� 52      6.   
 54      �� 55      61   �� 56      $��* �6/   6;   �� 57      61   �� 58      61   .+�5:      �� $	��200��69   $	��150��6E   $��4��6R   ��6    �� *Image+6e   �� 5;      $
��5 10q�6$   $��3��6I   $��WrapWithOverflow=�6]   $��1��6}   ��62   �� *Title+6�   �� 5<      $
��5 10q�6%   $��1��63   $��3��6@    �� Orientation$ 
Horizontal=�6T   $��1��6m   .+�5=      ��   discountPrice#��[ 6C   ��6(   �� *	LastPrice+6l   �� 5>      ��6(   ��  �� StringFormat$  {0} рублей�� �� Path$ CurrentPrice��� 5?      ��6(   �� $  за {0} минут��$ DurationMin�5@      �� 5A      #��[  6$   $
��5 10q�6T   $��1��6b   $��2��6r   ��6   �� $ * скидка {0}%��$ Discount��� 5B      $
��5 10q�6%   $��3��63   $��1��6@   $��3��6P   $ 
Horizontal=�6d   .+�5C      ��  
 addFon#��[ 6%   $��0 0 5 0q�6e   $ ��редактировать��6v   ��6E   �� *EditCommand+6�   �� 5D        attencionFon#��[ 6g   $��удалить��6�   ��6%   �� *DeleteCommand+��6G   �� *id+6�   5E      5F      5G      5I      � 5J   
   $��2��6   
 5K      �� 5L      6%   �� 5M      6%   .+�5O      �� $
��5 10q�6   ��5P      `� 5Q      $ {0} из {1}��6#   .1�5R      �� $ CurrentCount�6"   �� 5S      $ 
TotalCount�6"   5T      5V      �� 5W      #��[ 6   $��0 0 5 0q�6T   $��1��6e   $��Добавить��6u   ��65   �� *
AddCommand+6�   5X      5Y      5Z      