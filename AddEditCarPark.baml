   M S B A M L   `   `   `  ����I  EFleetEquipment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FleetEquipmentFleetEquipment  5   	   #    FleetEquipment.AddEditCarPark   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:FleetEquipment     5   	     � Title$D  >Добавление/изменение таблицы CarPark��5   	   $	��380��66   $	��400��6C    � Icon$# /icons8-add-properties-24.png��6O    � WindowStartupLocation$ CenterScreen=�6t   .��5	      � ���	#FFFFC68C.+�5
   
   �� -   5         ��Name$ ExecuteCarPark��5
      $��Выполнить��6)   $��Center=�6=   $��	0,292,0,0q�6Z   $	��Top=�6m   $��38��6�   $	��162��6�   $��Source Sans Pro Black)�6�   $��14(�6�   ���	#FFFFA608
�������
���   � � 	Resources 5       �� 
TargetType �� Property �� Value��%_   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 10��65   5      5      5      �� 5   
   -   5         ��Name$ NameTextBox��5      $
��Left=�6'   $��
150,80,0,0q�6B   	 �� TextWrapping$
	 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��200��6�   $��35��6�   $��Source Sans Pro Black)�6�   $��16(�6�   �� 5   
   -   5        $ AddressTextBox��5      $
��Left=�6*   $��150,130,0,0q�6E   $
	 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��200��6�   $��35��6�   $��Source Sans Pro Black)�6�   $��16(�6�   �� 5   
   -   5        $ PhoneTextBox��5      $
��Left=�6(   $��150,182,0,0q�6C   $
	 Wrap=�6X   $�� ��6l   $	��Top=�6t   $	��200��6�   $��35��6�   $��Source Sans Pro Black)�6�   $��16(�6�   �� 5   
   -   5        
 ��Name$
 NumberVehicleComboBox��5      $
��Left=�62   $��150,235,0,0q�6M   $	��Top=�6b   $	��200��6z   $��35��6�   $��Source Sans Pro Black)�6�   $��16(�6�    �� DisplayMemberPath$
 Name��5   *   5      �� 5   
   $
��Left=�6   $��33��6+   $��
309,30,0,0q�67   $	��Top=�6K   $��40��6c   $��/icons8-truck-96.png��6n    J� OpacityMask 5      �� 5       �� ImageSource$ /icons8-truck-96.png��6   5      �� 5   
   $
��Left=�6   $��33��6+   $��
351,30,0,0q�67   $	��Top=�6K   $��40��6c   $ ��/icons8-shuttle-bus-96.png��6n   �� 5   
   $
��Left=�6   $��32��6+   $��	331,3,0,0q�67   $	��Top=�6J   $��40��6b   $��/icons8-sedan-96.png��6m   �� 5    
   $
��Left=�6   $��
321,27,0,0q�6/   $
��Wrap=�6C   $��Techno-Auto��6W   $	��Top=�6j   $��Source Sans Pro Black)�6�   $��46��6�   $
��Bold"�6�   ���	#FFFFA608$��11��6�   ���	#FFECCEA9$��8(�6�   �� 5!   
   -   5         ��Name$ 
BackButton��5!      $
��Left=�6$   $��22��6?   $��	10,10,0,0q�6K   $	��Top=�6^   $��22��6v   $��/icons8-return-24.png��6�   6�   �� 5"   
   $'��!Добавьте/измените��6   $��Center=�6,   $��0,15,0,0q�6I   $	��Top=�6[   
���   �$��Source Sans Pro Black)�6�   $��20(�6�   �� 5#   
   $��Название:��6   $
��Left=�6$   $��	21,80,0,0q�6?   $	��Top=�6R   $��35��6j   $��83��6v   $��Source Sans Pro Black)�6�   $��14(�6�   �� 5$   
   $��Адрес:��6   $
��Left=�6!   $��
21,130,0,0q�6<   $	��Top=�6P   $��35��6h   $��83��6t   $��Source Sans Pro Black)�6   $��14(�6�   �� 5%   
   $��Телефон:��6   $
��Left=�6#   $��
21,182,0,0q�6>   $	��Top=�6R   $��35��6j   $��83��6v   $��Source Sans Pro Black)�6�   $��14(�6�   �� 5&   
   $��Номер трансп.:��6   $
��Left=�6)   $��
21,235,0,0q�6D   $	��Top=�6X   $��35��6p   $	��126��6|   $��Source Sans Pro Black)�6�   $��14(�6�   5(      5)      