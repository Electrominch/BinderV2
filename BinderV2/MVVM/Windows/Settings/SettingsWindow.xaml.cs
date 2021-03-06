﻿using Trigger.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BinderV2.Settings.Visuals;
using BinderV2.MVVM.ViewModels;

namespace BinderV2.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            StateChanged += CustomizedWindow.WindowStyle.Window_StateChanged;
            DataContext = new SettingsViewModel();
        }

        private void AutoLoadPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            AutoLoadPath.ScrollToHorizontalOffset(AutoLoadPath.Text.Length);
        }
    }
}
