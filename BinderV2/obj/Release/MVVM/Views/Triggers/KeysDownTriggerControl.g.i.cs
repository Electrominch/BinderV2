﻿#pragma checksum "..\..\..\..\..\MVVM\Views\Triggers\KeysDownTriggerControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5FE566C0F19F6785240905BDCAF50560B4C15BF6BACCF9EC2359C2A2E2507A2C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using BinderV2.MVVM.Views.Triggers;
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BinderV2.MVVM.Views.Triggers {
    
    
    /// <summary>
    /// KeysDownTriggerControl
    /// </summary>
    public partial class KeysDownTriggerControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\..\..\MVVM\Views\Triggers\KeysDownTriggerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BinderV2.MVVM.Views.Triggers.KeysDownTriggerControl TriggerView;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\MVVM\Views\Triggers\KeysDownTriggerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\MVVM\Views\Triggers\KeysDownTriggerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelName;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\MVVM\Views\Triggers\KeysDownTriggerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxName;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\MVVM\Views\Triggers\KeysDownTriggerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditNameButton;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\MVVM\Views\Triggers\KeysDownTriggerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelKeys;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\MVVM\Views\Triggers\KeysDownTriggerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EnableButton;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\..\MVVM\Views\Triggers\KeysDownTriggerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteTriggerButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BinderV2;component/mvvm/views/triggers/keysdowntriggercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\Views\Triggers\KeysDownTriggerControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TriggerView = ((BinderV2.MVVM.Views.Triggers.KeysDownTriggerControl)(target));
            return;
            case 2:
            this.border = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.labelName = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.textBoxName = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\..\..\..\MVVM\Views\Triggers\KeysDownTriggerControl.xaml"
            this.textBoxName.KeyDown += new System.Windows.Input.KeyEventHandler(this.textBoxName_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EditNameButton = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\..\MVVM\Views\Triggers\KeysDownTriggerControl.xaml"
            this.EditNameButton.Click += new System.Windows.RoutedEventHandler(this.EditNameButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.labelKeys = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.EnableButton = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.DeleteTriggerButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

