   M S B A M L   `   `   `  ����B  >Clients, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ClientsClients  5   	       Clients.DoctorClient   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Clients     5   	     � Title$  DoctorClient��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ Patients��5
      $��
300,40,0,0q�6%   $
��Left=�69   $	��150��6T   $	��Top=�6a   $	��260��6y    �� View 5      �� 5      .P�5      �� $��
First Name��6%    �� Width$	 130��69    �� DisplayMemberBinding 6F   ��  �� Path$ 	FirstName��� 5      $��	Last Name��6%   $	 130��68    6D   �� $ LastName�5      5      �� 5   
   -   5         ��Name$ Address��5      $��110,200,0,0q�6%   $	��200��6:   
Address:6P   �� 5   
   -   5        $ 	TajNumber��5      $��110,220,0,0q�6'   $	��200��6<   Taj Number:6U   �� 5   
   -   5        $ 	Complaint��5      $��110,240,0,0q�6'   $	��200��6<   
Complaint:6T   �� 5   
   -   5        $��40��5   (   $	��100��64   $��
60,190,0,0q�6@   .��6T   Delete Patient6d   5      5      