   M S B A M L   `   `   `  ���� C  ?BinderV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BinderV2BinderV2  (    "BinderV2.MVVM.Views.SettingsWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  %BinderV2clr-namespace:BinderV2     CurstomWindowStyle#���     � Title$  Настройки�� � Icon$A ;/BinderV2;component/WPF Resources/Images/Icons/Settings.png��$	��513��$	��300��$	��513��$	��300��.��� -    �Name$ 
GridWindow�� � RowDefinitions �� $
��Auto ��� .+��� $��0��$��2q�$��4,4,4,2q�._��� $��5q�.+��� $C��=Запускать программу вместе с Windows��$
��Left=� d� 	IsChecked �� *StartWithWindows+�� $>��8Сворачивать в трей при запуске��$
��Left=� �� *HideOnStart+�� $>��8Автоматически загружать бинды��$
��Left=� �� *AutoLoadBinds+�  � ColumnDefinitions �� �� $��35 �.+��� -    ��Name$ AutoLoadPath��$��Stretch=�$��35,1,0,1q�$	��150�� �� 
IsReadOnly . ���� *AutoLoadBindsPath+ �� Mode$ OneWay=��� $��1��$	��...��$��5,1,0,1q�$��25��$
��Left=����� *!ChooseAutoLoadBindsPathCommands+�� $A��;Сохранять размер основного окна��$
��Left=� �� *SaveMainWindowSize+�� $#��Закрыть = скрыть��$
��Left=� �� *CloseEqualsHide+�� $��1��$��2q�$��4,2,4,4q�._�]� ��. .+��� $��5,5,5,0q�$	��Top=�$	��Top=�.+��� $��23��$
��Left=�$��0,0,0,5q����� *ColorParameters+	 �� SelectedItem	 �� *SelectedColorParameter+�� $��0��$��2q�._�� $��0,5,0,0q� ��  �� �� �� �� .+��� $��0��$��0,0,0,10q�.+��� 
 �� Orientation$
 
Horizontal=�.+��� $��R=���� $��	-10,0,0,0q�����  �� ElementName$ 	RedSlider�� �� Path$ Value��� -   $��	RedSlider�� �� Orientation$ Vertical=�$��Center=�$��Bottom=� � Maximum$	 255Q�$	��128�� � Value �� *
CurrentRed+$ TwoWay=��� $��1��.+��� $
 
Horizontal=�.+��� $��G=���� $��	-10,0,0,0q����� $ GreenSlider��$ Value��� -   $��GreenSlider��$ Vertical=�$��Center=�$��Bottom=�$	 255Q�$	��128�� �� *CurrentGreen+�� $��2��.+��� $
 
Horizontal=�.+��� $��B=���� $��	-10,0,0,0q����� $ 
BlueSlider��$ Value��� -   $��
BlueSlider��$ Vertical=�$��Center=�$��Bottom=�$	 255Q�$	��128�� �� *CurrentBlue+�� $��3��.+��� $
 
Horizontal=�.+��� $��A=���� $��	-10,0,0,0q����� $ 
AphaSlider��$ Value��� -    ��Name$ 
AphaSlider��$ Vertical=�$��Center=�$��Bottom=�$	 255Q�$	��128�� �� *CurrentAlpha+�� $��2q�$��0,5,0,0q� �� Padding$ 5q�._��  �� �� $��70 � �� �� .+��� $��23��$
��Left=����� *TextParameters+	 �� *SelectedTextParameter+�� $��1��$��5,0,5,5q�$��75������ *CurrentTextValue+�� $��1��$��1��$��27��$��60��$��5,0,5,5q�$��Right=�$��OK���� $��27��$��60��$��5q�$
��Left=�$��Bottom=�$��
Сброс��$��2������ *ResetSettingsCommand+