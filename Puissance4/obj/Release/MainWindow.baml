   M S B A M L   `   `   `  ���� E  APuissance4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Puissance4
Puissance4  'clr-namespace:MiniPuzzle
MiniPuzzle      Puissance4.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:Puissance4     /
MiniPuzzleclr-namespace:MiniPuzzle       � Title$  Puissance 4��$	��900��$	��750��$	��700��$	��700�� � WindowStartupLocation$ CenterScreen=� � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value��%�  '��       '�� �     �� " ��.���  � ��$ Segoe UI Light)���  � �� �	#FF595959��  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ Segoe UI Light)���  �@�Cursor$
 Hand����  � �� �	#FF4F4F4F��  � �� �	#26727272��  � ��
 �������  � ��$ 0q���  � �� �� " ��.R��� #��z��#��z��$��2q�$ 10��._��� $��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ���  � �� �	#FFEEEEEE.��� -    �Name$ grdMain��.+��� -    ��Name$ btnPlay��$��Rejouer��$��Center=�$��21(�$��	0,0,0,110q�$��Bottom=�$	��155��$��47��   MiniPuzzle.Switcher  -     Name$ cbxIA��   MiniPuzzle.Switcher   StateChanged$ cbxIA_StateChanged��   CornerRadius$ 13��$��Center=�$��36��$��0,0,0,15q�$��Bottom=�$��66���� -    ��Name$ lblIA��$��intelligence artificielle��$��Center=�$��0,0,0,50q�$��Bottom=�$��16(��� -   $ lblTitle��$��Puissance 4��$��Center=�$��0,10,0,0q�$	��Top=�$��25(�   Puissance4.Game  -     Name$ grdGame��   Puissance4.Game
   End$ grdGame_End��$��10,66,10,172.4q����	#FFF9F9F9� -   $ grdWin��$��0,164,-0.4,250.4q����	#FF323232$	��156��$��Center=� J� Opacity$ 0Q�$y�	Collapsed=�.+��� -   $ lblWin��$��35(�
�������$	��100��$��0,0,0,70q�$��Center=��� -	   $ lblbtnOk��$��Center=�$��OK��$��25(�
�������$��0,85,0,0q�
�������$��2q����	#26FFFFFF$��47��$��75��$��Center=�$��Center=� � Cursor$
 Hand��   Puissance4.NumberChooser  $
��Left=�$��
10,621,0,0q�$	��Top=�$��69��$��90��$��20(�  $
��Left=�$��815,620,0,0q�$	��Top=�$��69��$��90��$��20(�