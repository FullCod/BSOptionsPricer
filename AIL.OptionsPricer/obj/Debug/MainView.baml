   M S B A M L   `   `   `  ����L  HAIL.OptionsPricer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AIL.OptionsPricerAIL.OptionsPricer  5   	   A%clr-namespace:AIL.OptionsPricer.ViewsAIL.OptionsPricer.Views  5   	   K*clr-namespace:AIL.OptionsPricer.ViewModelsAIL.OptionsPricer.ViewModels  5   	        AIL.OptionsPricer.MainView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:AIL.OptionsPricer     5   	   4uc%clr-namespace:AIL.OptionsPricer.Views     5   	   A
viewModels*clr-namespace:AIL.OptionsPricer.ViewModels     5   	     � Title$  Options Pricing��5
   	   $	��455��6!   $	��960��6.   $	��400��5   	    � SizeToContent$ Height=�5   	    � Icon$&  Ressources/Images/calculator.ico��5   	    � 	Resources 5       �� DataType1   +AIL.OptionsPricer.ViewModels.LoginViewModel'   !AIL.OptionsPricer.Views.LoginViewA   ;AIL.OptionsPricer.ViewModels.BlackScholesQuotationViewModel7   1AIL.OptionsPricer.Views.BlackScholesQuotationView9   3AIL.OptionsPricer.ViewModels.UserManagmentViewModel/   )AIL.OptionsPricer.Views.UserManagmentView�� 5      %�   (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)�� 5      "  6   .R�5   
     5   	   �� 5      "  6   .R�5   
     5   	   �� 5      "  6   .R�5   
     5   	   5      .��5      �    gridBackgroundColor#��[  6	    � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $��* �6   .+�5#      o� $��0��6    o� 
IsMainMenu . ��5%      �� 5&   
   .R�5'      ]� $��Stretch=�6   5(      .@�5*      m� $��_File��6   .@�5+   
   m� $��E_xit��6   
 � Tag$
 exit��5,       m� Command 5-      �� *ExitCommand+	 m� CommandParameter	 5.      �� 
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType" �5/   	   m� 50      $��Users��6   $ UserManagment��52      {�51      �� *CurrentUser.IsLoggedIn+ �� UpdateSourceTrigger$ PropertyChanged=� 53      �� *SwitchViewCommand+	 54      �� *Tag+
 �� *Self+m� 55      $��BlackScholes��6   $ BlackScholes��56      {�57      �� *CurrentUser.IsLoggedIn+$ PropertyChanged=� 58      �� *SwitchViewCommand+	 59      �� *Tag+
 �� *Self+m� 5:      $ login��5;      $��Right=�5<      ��5:      �� *LoginMenuHeader+ 5=      �� *DataContext.SwitchViewCommand+
 �� *Self+	 5>      �� *Tag+
 �� *Self+5?      � 5C      $��1��6   .+�5E      �� $��Center=�67   ��6   �� *CurrentView+67   5F      �� 5I      $��2��6   $��Bottom=�5J      $��Center=�5K      $3��-BlackScholes Options Pricer By Alexis ILBOUDO��5L        statusAreaStyle#��[ 5M      5O      5P      