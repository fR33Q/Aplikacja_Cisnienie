   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   !    WpfApplication1.LoginWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Icon$ icon.png��5
   	    � Title$' !Zaloguj się do naszej aplikacji!��5   	   $	��435��62   $	��540��6?   $��14(�6K   .��5      � $��0,0,0,0q�6   ��5   
   �� 5       �� ImageSource$ Images/backgr.png��6   .+�5   
   � $��183,69,34,85q�6   ���	#FFFDFDFD J� Opacity$	 0.5Q�6<   .+�5      �� $��Nazwa użytkownika��6   ���#050505$��OCR A Extended)�6E   $��16(�6a   $��58,0,52,237q�6o   �� 5      -   5         ��Name$ txtnazwa_uzytkownika��5      
���   �
�������$��18(�6Z   
���   �$	 0.5Q�6|   $��58,36,52,206q�6�    �� SelectionBrush
 �����$��Center=�6�   $��Center=�6�   �� 5      $��Hasło��6   ���#050505$
��Bold"�69   $��OCR A Extended)�6K   $��16(�6g   $��58,72,52,170q�6u   G� 5      -   5         G�Name$ txthaslo��5      
���   �
�������$��18(�6R   $��1q�6`   
���   �$	 0.5Q�6�   $��58,103,52,139q�6�   $��Center=�6�   $��Center=�6�   �� 5      -   5        	 ��Name$	 	btnSubmit��5   H      MyButton#��[  6   
 �� 	IsDefault
 . $��220,150,10,65q�6t   ���	#FF020000$��18(�6�    J� RenderTransformOrigin$ 1.327,0.617&�6�    � Cursor$
 Hand��6�   $��OCR A Extended)�6�   $��85��6�   $��58��6	  ��5      �� 5      $ Images/login_bt.png��6!   5      �� 5      -   5        $	 btnRegister��5   8   #��[  6   $��142,202,109,10q�6h   
���   �$��12(�6�   $
 Hand��6�   $��OCR A Extended)�6�   $��61��6�   $��Stretch=�6�   ��5       �� 5!      $ Images/regi.png��6!   5#      �� 5$      $��ZALOGUJ SIĘ:��6   $
��Left=�6+   $��122,160,0,0q�6F   $	��Top=�6[   $	��114��6s   $��27��6   $��OCR A Extended)�6�   �� 5%      $��ZAREJESTRUJ SIĘ:��6   $
��Left=�6/   $��	0,225,0,0q�6J   $	��Top=�6]   $��38��6u   $	��142��6�   $��OCR A Extended)�6�   5(      �� 5)   
   -   5        #��[  5)      $��Stretch=�6F   $��	490,0,5,0q�6d   $	��Top=�6w   $��40��6�   $��40��6�   ��5*      �� 5+      $ Images/exit_1.png��6   5-      5.      5/      