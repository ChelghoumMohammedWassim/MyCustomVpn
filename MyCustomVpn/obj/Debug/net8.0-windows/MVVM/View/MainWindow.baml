   M S B A M L   `   `   `  ����F  BMyCustomVpn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MyCustomVpnMyCustomVpn  5   	   G(clr-namespace:MyCustomVpn.MVVM.ViewModelMyCustomVpn.MVVM.ViewModel  5   	   3clr-namespace:MyCustomVpn.CoreMyCustomVpn.Core  5   	       MyCustomVpn.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MyCustomVpn     5   	   >	viewmodel(clr-namespace:MyCustomVpn.MVVM.ViewModel     5   	   5
extensionsclr-namespace:MyCustomVpn.Core     5   	     � Title$  
MainWindow��5
   	   $	��650��6   $
��1200��6)    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency$
 True��5   	    � 
ResizeMode$ 	CanResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      .  (MyCustomVpn.MVVM.ViewModel.MainViewModel  5   
   .��5      ]� ���#1E1E1E$��7q�5   	   .+�5   
   �� $��28��5      ���#252525$	��Top=�5!       J� InputBindings 5$      d� 5%       d� MouseAction$ 	LeftClicke�5&       �� Command 5'      �� *MoveWindowCommand+._�5+      � 	 � ColumnDefinitions	 5,      �� 5-      �� 5.      $	��100 �6'   .+�51      �� $��SurfHub 3.4.2��52      
�������$��Consolas)�54      $��Center=�55      $��Center=�56      $��100, 0, 0, 0q�57      �� 5:      $��1��5;      
 �� Orientation$
 
Horizontal=�5<      $��Right=�5=      $��
0, 0, 4, 0q�5>      .+�5A      �� $��-��6   $��
0, 0, 0, 2q�6)   ��6>   �� *MinimizeWindowCommand+�� 5B      $
��🗖��6   $��
0, 0, 0, 3q�6*   ��6?   �� *MaximizeWindowCommand+�� 5C      $
��🗙��6   $��
0, 0, 0, 2q�6*   ��6?   �� *ShutdownWindowCommand+5E      5G      5K      �� 5O   
   $��48��5P      $
��Left=�5Q      ���#252525��5U      �� 5V       �� Triggers 5X      :� 5Y       :� RoutedEvent$ Border.MouseEnter��6'   [�5[      �� 5\   "   .��5]   &   �� .��5^   *   W�  �� TargetProperty$ (Border.Width)�6:   	 W� To 2006e    g� Duration$ 0:0:.1D�6n   5_   '   5`   #   5d      :� 5g      $ Border.MouseLeave��6'   [�5i      �� 5j   "   .��5k   &   �� .��5l   *   W� $ (Border.Width)�6:    486e   $ 0:0:.1D�6m   5m   '   5n   #   5r      5v      ._�5y      �� .+�5{      	� "  MyCustomVpn.Core.Extetnsions   Icon$
 🛡��5|      $	��VPN��5}      $��16(�5~      $��4, 3.5, 8, 0q�5      $��Normal"�5�      
������� d� 	IsChecked$
 TrueY�5�      ��5�      �� *ShowProtectionViewCommand+	� 5�      $	 セ��5�      $��About��5�      $��4, 3.5, 8, 0q�5�      $��16(�5�      $��Normal"�5�      
�������$ FalseY�5�      	� 5�      $ ⚙️��5�      $��Settings��5�      $��16(�5�      $��1.5, 3.5, 8, 0q�5�      $��Normal"�5�      
�������$ FalseY�5�      ��5�      �� *ShowSettingsViewCommand+5�      5�      �� 5�   
   ��6   �� *CurrentView+5�      5�      