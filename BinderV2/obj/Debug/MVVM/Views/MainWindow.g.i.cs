﻿#pragma checksum "..\..\..\..\MVVM\Views\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F9E523C17B2404FA172DF0B7F67BD6F9C73FB41A7A6C53000EA18C5E3E5F31A5"
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
using Hardcodet.Wpf.TaskbarNotification;
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


namespace BinderV2.MVVM.Views {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\MVVM\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Hardcodet.Wpf.TaskbarNotification.TaskbarIcon TaskBarIcon;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\MVVM\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ShowWindowButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\MVVM\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem HideWindowButton;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\MVVM\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ExitBut;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\MVVM\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer BindsScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\MVVM\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ScriptBox;
        
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
            System.Uri resourceLocater = new System.Uri("/BinderV2;component/mvvm/views/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVM\Views\MainWindow.xaml"
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
            
            #line 11 "..\..\..\..\MVVM\Views\MainWindow.xaml"
            ((BinderV2.MVVM.Views.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\..\MVVM\Views\MainWindow.xaml"
            ((BinderV2.MVVM.Views.MainWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TaskBarIcon = ((Hardcodet.Wpf.TaskbarNotification.TaskbarIcon)(target));
            
            #line 26 "..\..\..\..\MVVM\Views\MainWindow.xaml"
            this.TaskBarIcon.TrayMouseDoubleClick += new System.Windows.RoutedEventHandler(this.TaskBarIcon_TrayMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ShowWindowButton = ((System.Windows.Controls.MenuItem)(target));
            
            #line 29 "..\..\..\..\MVVM\Views\MainWindow.xaml"
            this.ShowWindowButton.Click += new System.Windows.RoutedEventHandler(this.ShowWindowButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.HideWindowButton = ((System.Windows.Controls.MenuItem)(target));
            
            #line 30 "..\..\..\..\MVVM\Views\MainWindow.xaml"
            this.HideWindowButton.Click += new System.Windows.RoutedEventHandler(this.HideWindowButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ExitBut = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 6:
            
            #line 47 "..\..\..\..\MVVM\Views\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BindsScrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 60 "..\..\..\..\MVVM\Views\MainWindow.xaml"
            this.BindsScrollViewer.ScrollChanged += new System.Windows.Controls.ScrollChangedEventHandler(this.BindsScrollViewer_ScrollChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ScriptBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

