   M S B A M L   `   `   `  ����L  HServiceClient_app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ServiceClient_app.MVVM.ViewServiceClient_app.MVVM.View  5   	   -    'ServiceClient_app.MVVM.View.ZapisWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ServiceClient_app.MVVM.View     5   	     � Title$  ZapisWindow��5   	   $	��300��6   $	��300��6*   .��5	      ��  �� Orientation$ Vertical=�6   $��Center=�6(   .+�5
   
   �� -   5         ��Name$ serviceTextBlock��5
   "   $
��5 10q�6   ��5      `� 5       �� StringFormat$" Услгуа {0} {1} мин.��6   .1�5      ��  �� Path$ Title�6   �� 5      $ DurationMin�6   5      5      �� 5   
   $
��5 10q�6   Клиент:6+   �� 5   
   -   5         ��Name$ clients��5   9   $
��5 10q�6    �� DisplayMemberPath$	 FIO��6!   6L   �� 5   
   $
��5 10q�6   Время записи:61   :  4System.Windows.Controls.Primitives.DatePickerTextBox  5   
   -   5          Name$
 date��5      6,   �� 5   
   -   5        $
��5 10q�5       
  addFon#��[  6   $��Center=�6T   $��Записать��6q   6�   5      5      