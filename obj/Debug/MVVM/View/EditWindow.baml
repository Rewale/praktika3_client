   M S B A M L   `   `   `  ����L  HServiceClient_app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ServiceClient_app.MVVM.ViewServiceClient_app.MVVM.View  5   	   K*clr-namespace:ServiceClient_app.MVVM.ModelServiceClient_app.MVVM.Model  5   	   ,    &ServiceClient_app.MVVM.View.EditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ServiceClient_app.MVVM.View     5   	   <model*clr-namespace:ServiceClient_app.MVVM.Model     5   	     � Title$  
EditWindow��5
   	   $	��750��6   $	��600��6)    � DataContext 5      *   $ServiceClient_app.MVVM.Model.Service  5   
   .��5      �  � 	Resources 5   
    �� 
TargetType   	baseStyle �� BasedOn �� Property �� Value��%T  '��       7   '�� u     �� 5      " ��6   8   .�5      ��  � ��$ Center=�66   �� 5       � ��$ 32��6+   5      �� 5      " ��6   .�5      ��  � ��$ 20(�6-   �� 5       � ��$ Comic Sans MS)�6/   �� 5       � ��$ Center=�68   �� 5       � ��$ Center=�66   5      5       � ColumnDefinitions 5   
   �� 5      6!   �� 5      $��3* �6   6,    � RowDefinitions 5   
   �� 5       �� 5!      �� 5"      �� 5#      $��2* �6   �� 5$      �� 5%      �� 5&      .+�5)   
   �� $��0��6   $��Название��6!   63   �� 5*   
   $��1��6   ��6"   �� *Title+6;   �� 5,   
   $��1��6   $��Стоимость��6"   65   �� 5-   
   $��1��6   $��1��6   ��6/   �� *Cost+6G   �� 5/   
   $��2��6   $��Длительность��6"   68   �� 50   
   $��2��6   $��1��6   ��6/   �� *DurationMin+6N   �� 52   
   $��3��6   $��Описание��6"   65   �� 53   
   $��3��6   $��5q�6   $��1��6*   	 �� AcceptsReturn	 . 
 �� TextWrapping$

 Wrap=�6O   ��6c   �� *Description+6�   �� 55   
   $��4��6   $��Скидка��6"   63   �� 56   
   $��4��6   $��1��6   ��6/   �� *
Discount+6K   �� 58   
   $��5��6   $+��%Главное изображение��6!   6>   �� 59   
   $��5��6   $��1��6   ��6-   �� *Image+�� 5;   
   -   5        $��
button_add��5<   $   $��6��5;      $��Добавить��5<      $��Center=�6O   $��Center=�5=      6.   �� 5>   
   -   5        $��button_zapis��5?   "   $��6��5>      $��1��6   $��Запись��5?      $��Center=�6J   $��Center=�5@      6.   5B      5C      