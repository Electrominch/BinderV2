﻿#pragma checksum "..\..\..\..\..\MVVM\Views\Bind\BindElement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3BAAE0DC82EE70D25B8C1E76D2AACF5CF5EFF4AA708E0013957EE60CC562ECC0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using BinderV2.WpfControls.BindControl;
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


namespace BinderV2.WpfControls.BindControl {
    
    
    /// <summary>
    /// BindElement
    /// </summary>
    public partial class BindElement : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\..\..\MVVM\Views\Bind\BindElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BinderV2.WpfControls.BindControl.BindElement BindControl;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\MVVM\Views\Bind\BindElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelName;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\MVVM\Views\Bind\BindElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxName;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\MVVM\Views\Bind\BindElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditNameButton;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\MVVM\Views\Bind\BindElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TriggerEditButton;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\MVVM\Views\Bind\BindElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EnableButton;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\MVVM\Views\Bind\BindElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBindButton;
        
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
            System.Uri resourceLocater = new System.Uri("/BinderV2;component/mvvm/views/bind/bindelement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\Views\Bind\BindElement.xaml"
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
            this.BindControl = ((BinderV2.WpfControls.BindControl.BindElement)(target));
            return;
            case 2:
            this.labelName = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.textBoxName = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\..\..\..\MVVM\Views\Bind\BindElement.xaml"
            this.textBoxName.KeyDown += new System.Windows.Input.KeyEventHandler(this.textBoxName_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EditNameButton = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\..\MVVM\Views\Bind\BindElement.xaml"
            this.EditNameButton.Click += new System.Windows.RoutedEventHandler(this.EditNameButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TriggerEditButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.EnableButton = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.DeleteBindButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
