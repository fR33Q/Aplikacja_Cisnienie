   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   "    WpfApplication1.Measurements   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	     � WindowStyle$
  None=�5   	    � Icon$ icon.png��5	   	    � 
ResizeMode$ NoResize=�5
   	    � Title$ Dodaj pomiar��5   	   $	��516��6   $	��669��6+   .��5      �� ._�5   
   � ��5      �� 5       �� ImageSource$ Images/back.jpg��6   .+�5      �� -   5         ��Name$ txt_systolic��5      
���   �
�������$��18(�6R   
���   � J� Opacity$	 0.5Q�6t   $��445,100,69,381q�6�   $��30��6�   $��0q�6�   $��Center=�6�   $��Center=�6�   �� 5      -   5        $ txt_diastolic��5      
���   �
�������$��18(�6S   
���   �$	 0.5Q�6u   $��445,147,69,331q�6�   $��0q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��Center=�6�   $��Center=�6�   �� 5      -   5        $ 	txt_pulse��5      
���   �
�������$��18(�6O   
���   �$	 0.5Q�6q   $��445,54,69,424q�6   $ 0.507,1.196&�6�   $��0q�6�   $��Center=�6�   $��Center=�6�   �� 5      -   5           MyButton#��[  5      $�� ��67   $
��Left=�6V   $��80��6q   $��516,194,0,0q�6}   $	��Top=�6�   $��91��6�   ��5      �� 5      $ Images/add.png��6!   5      �� 5      $��WARTOSC PULSU��6   $
��Left=�6,   $��288,54,0,424q�6G   $	��138��6]   
�������$��OCR A Extended)�6|   $��16(�6�   ���	#00000000$��5q�6�   �� 5      $#��WARTOSC CISNIENIA SKURCZOWEGO��6   $
��Left=�6<   $��132,100,0,378q�6W   $	��294��6n   
�������$��OCR A Extended)�6�   $��16(�6�   �� 5      $%��WARTOSC CISNIENIA ROZKURCZOWEGO��6   $
��Left=�6>   $��113,147,0,0q�6Y   $	��Top=�6n   $	��313��6�   $��30��6�   
�������$��OCR A Extended)�6�   $��16(�6�   �� 5      $��DODAJ POMIAR:��6   $
��Left=�6,   $��329,215,0,0q�6G   $	��Top=�6\   $��44��6t   $	��182��6�   
�������$��OCR A Extended)�6�   $��22(�6�   �� 5      -   5         ��Name$ Exit_bt��5   7   #��[  6   $
��Left=�6^   $��	604,3,3,3q�6y   $	��Top=�6�   $��45��6�   $��45��6�   ��5      �� 5      $ Images/exit_1.png��6!   5!      5#      5$      5%      