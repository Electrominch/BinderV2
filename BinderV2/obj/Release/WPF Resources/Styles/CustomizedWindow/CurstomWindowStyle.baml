   M S B A M L   `   `   `  ����   BinderV2"    CustomizedWindow.WindowStyle\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   WindowStyleTitleBarButton  �� 
TargetType �� Property �� Value  WindowButtonsColorInactive �� 
TargetType ��Name �� Triggers P� Property P� Value �� 
TargetName  WindowButtonsMouseOverColor  WindowBorderBrush  CurstomWindowStyle  WindowBorderThickness'  !System.Windows.Shell.WindowChrome  CaptionWindowHeight	   CaptionHeight&   System.Windows.Media.TextOptions
   TextRenderingMode   TextFormattingMode  WindowBorderBrushInactive  TitleBarBackgroundBrush 	 HeightWindowTitle � ColumnDefinitions ��Name 
 WindowIconSize  WindowIconMargin �� Path �� Mode �� RelativeSource ��Name  TitleFontSize J� Opacity  TitleBarForegroundBrush ��Name   IsHitTestVisibleInChrome �� Stretch �� EdgeMode �� AncestorType F�Name  WindowBackground  WindowButtonsColor �� 	Resources �� Triggers �� Binding �� Value  WindowStatusForeground " WindowStatusForegroundInactive   D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     %�
  &	        &	     �� "  ��.���  � |� .  ��  � ��# �  ��  � �� �� " ��.R�� .+��� $ PART_border��
������ ��  P�  �@J�IsMouseOver . . ��� $ PART_border��# �   � ��P�  � �� . . ��� $ PART_border��# �   � ���� "  �.���  � ��# �  ��  �@�AllowsTransparency . ��  �@�WindowStyle$
 None=���  � ��
 ���� ��  �@�
ResizeMode$ CanResizeWithGrip=���  �@ WindowChrome   #	 �  ��  � �� �� " �.R�� $��7q�$
 	ClearType=�$ Display=�.+��� $ Border��#��z��#���  ._�]� $��Stretch=�
������ $��Stretch=�.+��� $ TitleBar��$	��Top=�#���  $��0q�._�� #��� 	  �� $
��Auto ��� �� $��34 ��� $��34 ��� $��34 �.+��� $
 Icon��$��0��$��Right=�#��� 
 #��� 
 #���  ���� $
 Icon�$ OneWay=� �� *TemplatedParent+�� $ Caption��$��1��$
��Left=�$��Center=�$��4,0,0,0q�$��Segoe UI)�#���  $
 0.66Q�#���  ���� $ Title�$ OneWay=� �� *TemplatedParent+�� $ 	MinButton��-   $��2��$	��Top=�$��34��$��26��#���    . .��� $��9��$��9��.+�F� $��1��$
 None=�$ Aliased=�=����     z � z  z �    ��j � z ��j �    ��[ � z ��[ 	����  �� $ ButtonL�$ 
Foreground��� $ 	MaxButton��-   $��3��$	��Top=�$��34��$��26��#���    . .��� $��9��$��9��.+�F� $ PART_MaxButton_Path��$��1��$
 None=�$ Aliased=�X����        � z     � z  z �     z �        �    @B � z @B �    �� � z �� 	����  �� $ ButtonL�$ 
Foreground��� $ CloseButton��-   $��4��$	��Top=�$��34��$��26��#���    . .��� $��9��$��9��.+�F� $	��1.5��$
 None=�+����        � z  z �     z � z     	����  �� $ ButtonL�$ 
Foreground��� #���  $��0q�._���  P�  �@�
ResizeMode$ NoResize=�. ��� $ 	MaxButton�� � {� .  �� $ 	MinButton�� � {� .  P�  �@�
ResizeMode$ CanMinimize=�. ��� $ 	MaxButton�� � {� .  P�  �@�WindowState$ 	Maximized=�. ��� $ PART_MaxButton_Path�� � ��| ��    ��- �@KL ��- �@KL  z �     z �    ��- �     	= �@KL  	= ���-     � z     � z @KL ���j @KL ���- @B � z @B 	P�  �@�IsActive . . ��� $ Border��# �   � ���� $ 	MinButton��# �   � ���� $ 	MaxButton��# �   � ���� $ CloseButton��# �   � �� ���� '��       "  �� ��  �� *
IsActive+ �� $ WindowL� True.a���  � ��# �  ��  � ��# �  ��  �� *
IsActive+ �� $ WindowL�	 False.a���  � ��# �  ��  � ��# �  