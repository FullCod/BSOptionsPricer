   M S B A M L   `   `   `  ����L  HAIL.OptionsPricer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AIL.OptionsPricer.ViewsAIL.OptionsPricer.Views  5      C&clr-namespace:AIL.OptionsPricer.CommonAIL.OptionsPricer.Common  5      '    !AIL.OptionsPricer.Views.LoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:AIL.OptionsPricer.Views     5      9common&clr-namespace:AIL.OptionsPricer.Common     5         screenStyle#��[  5
        � DataContext  5      �� *LoginViewModel+.��5      ��   screenBorder#��[ 6   ��5      �� 5       �� 
StartPoint$ 0.5,0.5&�6    �� EndPoint$ 0.5,1&�5      .��5   
   �  � Color$ 	Gainsboro��6    � Offset$ 0Q�5      � 5   
   $ Lavender��6   $ 1Q�5      5   	   ._�5      �  � RowDefinitions 5      �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6    � ColumnDefinitions 5       �� 5!   
   $
��Auto �6   �� 5"   
   $
��Auto �6   �� 5#   
   $��* �6   .+�5&      �� $��0��6   $��0��5'      $��	4,4,12,20q�5(        buttonShadow J� Effect# [ 5)      $6��0pack://application:,,,/Ressources/Images/Key.png��5*      �� 5+      $��0��6   $��1��5,      $��2��5-      # [ 5.      $��4,4,4,20q�5/       �� CornerRadius$ 10��50      ��51   
   �� 52      $ 0.5,1&�6    $ 0.5,0&�53       .��54      � $ LightSlateGray��6   $ 0Q�55      � 56      $ 	SlateGray��6   $ 1Q�57      58      ._�5:   
   �� $��18(�6     inverseLabel#��[ 5;      $��Center=�5<      $+��%Please login to access Options Pricer��5=      5>   	   �� 5@      $��1��6   $��1��5A      $��	User Name��5B      $��Center=�5C      $��Right=�5D      $��35��5E      $��	5,10,5,20q�5F      $
��Bold"�5G      $��14(�5H      �� 5J      $��1��6   $��2��5K      $��30��5L      $	��250��5M      $��	5,10,5,20q�5N      $��Center=�5O      $
��Left=�5P      ��5Q      �� *CurrentUser.UserName+	 �� Mode$	 TwoWay=�
 �� NotifyOnValidationError
 . " �� ValidatesOnNotifyDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�.��6�   5R   	   �� 5T      $��2��6   $��1��5U      $��35��5V      $��Password��5W      $��	5,10,5,20q�5X      $��Center=�5Y      $
��Bold"�5Z      $��14(�5[      G� 5]      -   5        $��txtPassword��5b      $��2��5]      $��2��5^      $��30��5_      $	��250��5`      $��	5,10,5,20q�5a      $��Center=�5c      $��Center=�5d      $
��Left=�5e      -   'AIL.OptionsPricer.Common.PasswordHelper   Attach .    Password 5g      �� *CurrentUser.Password+
 .  . $	 TwoWay=�5w   	   �� 5y      $��3��6   $��2��5z      $��Right=�5{       �� Orientation$ 
Horizontal=�5|      .+�5}   
   ��  � ToolTip$ Don't Login��6   $��Cancel��5~       �� IsCancel .   cancelButton#��[ 5�      ��5�      �� *CancelLoginCommand+�� 5�   
   $ Login to Application��6   $��Login��5�       �� 	IsDefault .   submitButton#��[ 5�      ��5�      �� *LoginCommand+5�   	   �� 5�      $��4��6   $��2��5�        validationArea#��[ 5�       �� DisplayMemberPath$ Message��5�      y�5�      �� *IsValidationVisible+  visibilityConverter �� 	Converter# [ ��5�      �� *ValidationMessages+5�      5�      5�      5�      