   M S B A M L   `   `   `  ����   PROG6221_ST10043367_POEPart3-    'PROG6221_ST10043367_POEPart3.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$?  9Reece's Recipe App - PROG6221 Final Portfolio of Evidence��5   	   $	��450��6K   $	��800��6X   .��5      � -   5         �Name$ CurrentRecipes��5      
����·�.+�5   
   �� -   5         ��Name$ lblMainHeading��5      $��Arial)�6(   $��Normal$�6;   $+��%Welcome to Reece's Recipe Application��6N   $��30(�6~   $��Center=�6�   $��0,25,0,0q�6�   $	��Top=�6�   $	��538��6�   �� 5   
   -   5         ��Name$ btnInput��5      $��Arial)�6#   $��Input new recipe��66   
���  ��$
��Left=�6b   $��
30,337,0,0q�6}   $	��Top=�6�   $��58��6�   $	��105��6�   6�   �� 5   
   -   5        $ 
btnDisplay��5      $��Arial)�6%   $��Display Recipe��68   
��� ���$
��Left=�6e   $��159,337,0,0q�6�   $	��Top=�6�   $	��106��6�   $��58��6�   6�   �� 5	   
   -   5        $ btnScale��5	      $��Arial)�6#   $��Scale Recipe��66   
��� ���$
��Left=�6a   $��289,337,0,0q�6|   $	��Top=�6�   $��58��6�   $	��105��6�   6�   �� 5
   
   -   5        $ 	btnFilter��5
      $��Arial)�6$   $��Filter Recipe��67   
������$
��Left=�6g   $��419,337,0,0q�6�   $	��Top=�6�   $��58��6�   $	��105��6�   6�   �� 5   
   -   5        $ btnReset��5      $��Delete all recipes��6#   $��Arial)�6@   
����� �$
��Left=�6e   $��58��6�   $	��106��6�   $��545,337,0,0q�6�   $	��Top=�6�   6�   �� 5   
   -   5        $ lblSmallHeading��5      $��Oblique$�6)   $��Arial)�6=   $��15(�6P   $��Center=�6^   $��	0,298,0,0q�6{   $	��Top=�6�   .��5      �� $6��0Please select from one of the following options:��6   $��	Underline{�6P   5      �� 5   
   -	   5         ��Name$ 
lbxDisplay��5      $
��Left=�6&   $	��172��6A   $��	67,99,0,0q�6N   $	��Top=�6a   $	��333��6y   �� 5   
   -
   5         ��Name$ tbxFilterFoodGroup��5      $
��Left=�6.   $��30��6I   $��538,233,0,0q�6U    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��200��6�   �� 5   
   -   5        $ tbxRecipeName��5      $
��Left=�6)   $��30��6D   $��538,130,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��200��6�   �� 5   
   -   5        $ tbxScaleFactor��5      $
��Left=�6*   $��30��6E   $��538,165,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��200��6�   �� 5   
   -   5        $ lblFoodGroup��5      $��10(�6&   $��Food group:��64   $��Arial)�6J   $
��Left=�6]   $��465,237,0,0q�6x   $	��Top=�6�    J� RenderTransformOrigin$ 0.845,0.591&�6�   �� 5   
   -   5        $ lblRecipeName��5      $��10(�6'   $��Recipe name:��65   $��Arial)�6L   $
��Left=�6_   $��461,134,0,0q�6z   $	��Top=�6�   �� 5   
   -   5        $ lblScale��5      $��Scaling factor��6"   $��10(�6;   $��Arial)�6I   $
��Left=�6\   $��462,169,0,0q�6w   $	��Top=�6�   $ -0.12,-0.374&�6�   �� 5   
   -   5        $ lblRecipeHeading��5      $��Arial)�6*   $
��Left=�6=   $��	67,75,0,0q�6X   $	��Top=�6k   $	��226��6�   .��5      �� $��Current recipes stored:��6   $��	Underline{�67   $
��Bold"�6S   5      �� 5   
   -   5        $ btnResettoOrigional��5      $��Reset to Original��6.   
�������$��Arial)�6a   $
��Left=�6t   $��670,337,0,0q�6�   $	��Top=�6�   $	��106��6�   $��58��6�   6�   �� 5   
   -   5        $ lblScaleHeading��5      $��Arial)�6)   $
��Left=�6=   $��462,101,0,0q�6X   $	��Top=�6m   $	��294��6�   .��5      �� $��Scale Recipe:��6   $��	Underline{�6-   $
��Bold"�6I   5      �� 5   
   -   5        $ lblFilterHeading��5      $��Arial)�6*   $
��Left=�6=   $��462,206,0,0q�6X   $	��Top=�6m   $��26��6�   $	��266��6�   .��5      �� $��Filter Recipe:��6   $��	Underline{�6.   $
��Bold"�6J   5      5       5!      