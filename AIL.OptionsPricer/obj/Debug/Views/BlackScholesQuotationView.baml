   M S B A M L   `   `   `  ����L  HAIL.OptionsPricer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AIL.OptionsPricer.ViewsAIL.OptionsPricer.Views  5      K*clr-namespace:AIL.OptionsPricer.ViewModelsAIL.OptionsPricer.ViewModels  5      K*clr-namespace:AIL.OptionsPricer.ConvertersAIL.OptionsPricer.Converters  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      7    1AIL.OptionsPricer.Views.BlackScholesQuotationView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:AIL.OptionsPricer.Views     5      9vm*clr-namespace:AIL.OptionsPricer.ViewModels     5      A
converters*clr-namespace:AIL.OptionsPricer.Converters     5      9system&clr-namespace:System;assembly=mscorlib     5	         screenStyle#��[  5        � 	Resources  5      9   3AIL.OptionsPricer.Converters.DoubleToEmptyConverter  dblToEmptConv�� 5      %   &	         5      6*   5      .��5      ��   screenBorder#��[ 6   ._�5      � $��5q�6    � ColumnDefinitions 5      �� 5   
   $��* �6   �� 5   
   $��* �6   �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6    � RowDefinitions 5      �� 5   
   $��* �6   �� 5   
   $��* �6   �� 5   
   $��* �6   �� 5    
   $��* �6   �� 5!   
   $��* �6   �� 5"   
   $��* �6   .+�5$      �� $��0��6   $��0��5%      $��4��5&      $��80��5'      $
��Bold"�5(      $��Normal$�6   $��Center=�5)      $��Center=�5*      $��Center=�5+      $��Stretch=�5,      $��24(�5-      $"��Black Scholes Options Pricer��5.      $��5q�63   �� 5/      $��1��50      $��0��51      $��Stock Price (S)��52      $
��Bold"�53      $��40��54      $��Right=�55      $��Center=�56      $��Center=�57      $��Center=�58      �� 5:      $��1��5;      $��1��5<      $��Stretch=�5=      $	��150��5>      $��26��5?      $��Stretch=�5@      $��Center=�5A      $��14(�5B      ��5C      �� *QuotationInput.StockPrice+ �� Mode$ TwoWay=� �� NotifyOnValidationError . " �� ValidatesOnNotifyDataErrors .  �� UpdateSourceTrigger$ 	LostFocus=�.��6�   5F   	   �� 5H      $��2��5I      $��0��5J      $��Strike Price (K)��5K      $
��Bold"�5L      $��40��5M      $��Right=�5N      $��Center=�5O      $��Stretch=�5P      $��Center=�5Q      �� 5U      $��2��5V      $��1��5W      $��Stretch=�5X      $	��150��5Y      $��26��5Z      $��Stretch=�5[      $��Center=�5\      $��14(�5]      ��5^      �� *QuotationInput.StrikePrice+$ TwoWay=� �� TargetNullValue$  ��$ 	LostFocus=��� 5`      $��1��5a      $��2��5b      $��Volatility (%) (v)��5c      $
��Bold"�5d      $��40��5e      $��Right=�5f      $��Right=�5g      $��Center=�5i      $��Center=�5j      �� 5m      $��1��5n      $��3��5o      $
��Left=�5p      $	��150��5q      $��26��5r      $��Stretch=�5s      $��Center=�5t      $��14(�5u      ��5v      �� *QuotationInput.Volatility+$ TwoWay=�$ 	LostFocus=��� 5x      $��2��5y      $��2��5z      $%��Risk free interest rate (%) (r)��5{      $
��Bold"�5|      $��40��5}      $��Right=�5~      $��Center=�5      $��Center=�5�      $��Center=�5�      �� 5�      $��2��5�      $��3��5�      $
��Left=�5�      $	��150��5�      $��26��5�      $��Stretch=�5�      $��Center=�5�      $��14(�5�      ��5�      �� *QuotationInput.InterestRate+$ TwoWay=�$ 	LostFocus=��� 5�      $��3��5�      $��0��5�      $"��Time to maturity (years) (T)��5�      $
��Bold"�5�      $��40��5�      $��Right=�5�      $��Center=�5�      $��0,0,0,0q�5�      $��Center=�5�      $��Center=�5�      �� 5�      $��3��5�      $��1��5�      $��Stretch=�5�      $	��0,7q�5�      $	��150��5�      $��26��5�      $��Stretch=�5�      $��14(�5�      ��5�      �� *QuotationInput.TimeToMaturity+$ TwoWay=�$ 	LostFocus=��� 5�      $��3��6   $��2��5�      $��2��5�        validationArea#��[ 5�       �� DisplayMemberPath$ Message��5�      y�5�      �� *IsValidationVisible+  visibilityConverter	 �� 	Converter#	 [ ��5�      �� *ValidationMessages+5�      �� 5�      $��4��6   $��3��6    
 �� Orientation$
 Vertical=�60   .+�5�      �� $��Center=�6   $
 
Horizontal=�5�      .+�5�      �� $��	Get Quote��5�      $	��100��5�      $��30��5�      $
��Bold"�5�      $��16(�5�      $��Center=�5�      $��Center=�5�      ��5�      �� *GetQuoteCommand+5�      �� 5�      $��Clear��5�      $��80��5�      $��30��5�      $
��Bold"�5�      $��16(�5�      $
��Left=�5�      $��Center=�5�      $��	20,5,20,5q�5�      ��5�      �� *ClearCommand+5�      5�      �� 5�      $
 
Horizontal=�6   .+�5�      �� $��Close��5�      $��80��5�      $��30��5�      $
��Bold"�5�      $��16(�5�      $
��Left=�5�      $��Center=�5�      ��5�      �� *CloseCommand+5�      5�      5�   	   �� 5�      $
 
Horizontal=�6   $��4��6,   $��2��69   $��3��6J   $��0��6^   $��Center=�6n   .+�5�   
   �� $
 Vertical=�6   $��0,5,20,5q�6,   .+�5�      �� $
 
Horizontal=�6   $��5,5,5,10q�60   .+�5�      �� $��Call :��6   $��Center=�6%   $
��Bold"�6@   6U   �� 5�       �� Padding$ 5q�6n   
����·�$��Center=�6�   $	��140��6�   $
��Bold"�6�   ��6   �� *QuotationResult.CallPremium+#	 [ 5�      5�      �� 5�      $
 
Horizontal=�6   $��5,5,5,10q�60   .+�5�      �� $��Put :��6   $��Center=�6$   $
��Bold"�6?   6S   �� 5�      $ 5q�6n   
����·�$��Center=�6�   $	��140��6�   $
��Bold"�6�   ��6   �� *QuotationResult.PutPremium+#	 [ 5�      5�      5�      �� 5�   
   $
 Vertical=�6   $��5,5,50,5q�6,   .+�5�      �� $
 
Horizontal=�6   $��5,5,5,10q�60   .+�5�      �� $
��d1 :��6   $��Center=�6#   $
��Bold"�6>   6R   �� 5�      $ 5q�6e   
�������$��Center=�6�   $	��141��6�   ��6   �� *QuotationResult.D1+#	 [ 5�      5�      �� 5�      $
 
Horizontal=�6   $��5,5,5,10q�60   .+�5�      �� $
��d2 :��6   $��Center=�6#   $
��Bold"�6>   6R   �� 5�      $ 5q�6f   
�������$��Center=�6�   $	��141��6�   ��6   �� *QuotationResult.D2+#	 [ 5�      5�      5�      5�   	   5�      5�      5�      