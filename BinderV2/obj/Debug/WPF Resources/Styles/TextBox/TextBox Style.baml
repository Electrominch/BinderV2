   M S B A M L   `   `   `  ����C  ?BinderV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BinderV2.CommandsBinderV2.Commands  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089_ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a  �� 
TargetType �� Property   TextBoxColor �� Value  	TextColor  TextBoxSelectionColor  TextBoxBorderColor �� 
TargetType ��Name J� SnapsToDevicePixels ��Name*   $Microsoft.Xaml.Behaviors.Interaction    Triggers+  %Microsoft.Xaml.Behaviors.EventTrigger   	EventName*  $Microsoft.Xaml.Behaviors.TriggerBase	   Actions2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction
   Command-   'BinderV2.Commands.EnableDisableTriggers   DisableTriggersCommand �� Source   EnableTriggersCommand �� Triggers P� Property P� Value �� 
TargetName  TextBoxBorderMouseOverColor  UnselectedTextBox�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      3i+http://schemas.microsoft.com/xaml/behaviors  5      9EnableDisableTriggersclr-namespace:BinderV2.Commands  5      %�  '��       &	 �    �� 5      "  ��6   .�5   
   ��  � ��# �   6'   �� 5   
    � ��# �  6'   �� 5	   
    �@��SelectionBrush# �  6+   �� 5
   
    �@��
CaretBrush# �  6'   �� 5   
    � ��# �  6(   �� 5   
    � ��$	 1.5q�6,   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� $ Bd��6   #��z��5   )   #��z��5   )   #��z��5   )    . ._�5      �� $ PART_ContentHost��6'   # z 6A    5        5   "   $ GotFocus��61   .	 5   &     
 6<   �� # Z 5   #     5   "   $ 	LostFocus��61   .	 5   &     
 6<   �� # Z 5   #   5      5       5       P� 5!       � {� .  . �5"      �� $ Bd��6;   # � ��6K    � ���� 5#      # � ��6;    � ��5$      P� 5%       �@J�	IsFocused . . �5&      �� $ Bd��6<   # �  6L    � ��5'      P� 5(       �@J�IsMouseOver . . �5)      �� $ Bd��6<   # �  6L    � ��5*      5,      5.      5/      �� 52      "  ��6   .�53   
   ��  �@��
IsReadOnly . 6'   �� 54   
    � ��# �   6'   �� 55   
    � ��# �  6'   �� 56   
    �@��SelectionBrush# �  6+   �� 57   
    �@��
CaretBrush# �  6'   �� 58   
    � ��# �  6(   �� 59   
    � ��$	 1.5q�6,   �� 5:   
    � ��$ 14(�6%   �� 5;   
    �@��TextWrapping$
 Wrap=�6)   �� 5<   
    � ��$ Normal"�6'   �� 5=   
   # �@��VerticalScrollBarVisibility$
 Auto=�68   �� 5>   
   % �@��HorizontalScrollBarVisibility$
 Auto=�6:   �� 5?   
    � �� 5@      �� 5A      " ��6"   .R�5B      �� $ Bd��6   #��z��5C   )   #��z��5D   )   #��z��5E   )    . ._�5G      �� $ PART_ContentHost��6'   # z 6A   5H       5I      P� 5J       � {� .  . �5K      �� $ Bd��6;   # � ��6K    � ���� 5L      # � ��6;    � ��5M      5O      5Q      5R      5S      