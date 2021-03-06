﻿using BinderV2.MVVM.ViewModels;
using BinderV2.MVVM.Views;
using BinderV2.Settings;
using BinderV2.MVVM.Models;
using InterpreterScripts;
using InterpreterScripts.InterpretationFunctions;
using InterpreterScripts.InterpretationFunctions.Standart;
using InterpreterScripts.Script;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using Trigger.Types;
using Utilities;

namespace BinderV2.MVVM.Models.MainModels
{
    class BindsManager : INotifyPropertyChanged
    {
        public ObservableCollection<BindViewModel> Binds { get; private set; }
        private BindViewModel selectedBind;
        public BindViewModel SelectedBind 
        {
            get { return selectedBind; }
            set 
            {
                if (selectedBind != null)
                    selectedBind.IsSelected = false;
                if (value == null)
                    return;
                selectedBind = value;
                selectedBind.IsSelected = true;
                OnPropertyChanged("SelectedBindScript");
            }
        }

        public string SelectedBindScript
        {
            get { return ScriptTools.FormateScript(selectedBind != null ? selectedBind.Bind.Script : ""); }
            private set 
            {
                if (selectedBind == null)
                    throw new NullReferenceException();
                selectedBind.Bind.Script = ScriptTools.FormateScript(value);
                OnPropertyChanged("SelectedBindScript");
            }
        }

        private string LastPath = "";

        public BindViewModel CreateNewBind()
        {
            BindViewModel result = new BindViewModel();
            Binds.Add(result);
            OnPropertyChanged("Binds");
            return result;
        }
        public bool RemoveBind(BindViewModel toRemove)
        {
            toRemove.Bind.Dispose();
            OnPropertyChanged("Binds");
            return Binds.Remove(toRemove);
        }
        public void ClearBinds()
        {
            foreach (var bvm in Binds)
                bvm.Bind.Dispose();
            Binds.Clear();
            SelectedBind = null;
            OnPropertyChanged("Binds");
            OnPropertyChanged("SelectedBind");
        }
        public void SaveScriptToSelectedBind(string script)
        {
            SelectedBindScript = script;
        }

        public void SaveBinds()
        {
            if (LastPath.Length == 0)
                if (!GetSavePathFromUser())//если у нас нет пути, выходим
                    return;

            Bind[] binds = new Bind[Binds.Count];
            for (int i = 0; i < binds.Length; i++)
                binds[i] = Binds[i].Bind;
            JsonUtilities.SerializeToFile(binds, LastPath);
            MessageBox.Show("Сохранено в " + LastPath, "Успех!");
        }
        public void SaveBindsInNewPath()
        {
            if (GetSavePathFromUser())
                SaveBinds();
        }
        public void OpenBinds()
        {
            if (GetOpenPathFromUser())
                OpenBindsInPath(LastPath);
        }
        public void OpenBindsInPath(string path)
        {
            LastPath = path;
            ClearBinds();
            Bind[] binds = JsonUtilities.Deserialize<Bind[]>(File.ReadAllText(LastPath));
            int count = 0;
            var temp = new List<BindViewModel>();
            foreach (Bind b in binds)
            {
                var bindVM = new BindViewModel(b);
                temp.Add(bindVM);

                if (count++ % 5 == 0)
                {
                    temp.ForEach(bvm => Binds.Add(bvm)); OnPropertyChanged("Binds");
                    temp.Clear();
                }
            }
            temp.ForEach(bvm => Binds.Add(bvm)); OnPropertyChanged("Binds");
        }

        private bool GetSavePathFromUser()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (sfd.ShowDialog().Value)
                LastPath = sfd.FileName;
            else
                return false;
            return true;
        }
        private bool GetOpenPathFromUser()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (ofd.ShowDialog().Value)
                LastPath = ofd.FileName;
            else
                return false;
            return true;
        }


        public BindsManager()
        {
            Binds = new ObservableCollection<BindViewModel>();
            AutoLoadBindsWorking();
            AddFuncs();//добавить функции EnableBindsByNames и DisableBindsByNames
        }

        private void AutoLoadBindsWorking()
        {
            if (ProgramSettings.RuntimeSettings.AutoLoadBinds)
            {
                LastPath = ProgramSettings.RuntimeSettings.AutoLoadBindsPath;
                try { OpenBindsInPath(LastPath); }//пытаемся загрузить бинды
                catch//при неудаче выключаем автозагрузку биндов
                {
                    ProgramSettings.RuntimeSettings.AutoLoadBinds = false;
                    ProgramSettings.RuntimeSettings.AutoLoadBindsPath = "";
                    ClearBinds();
                }
            }
        }

        #region FuncsEnableDisableToInterpreter
        private void AddFuncs()
        {
            Interpreter.AddToLibrary(new Function(new Func<object[], object>(EnableBindsByNames), FuncType.Parameters));
            Interpreter.AddToLibrary(new Function(new Func<object[], object>(DisableBindsByNames), FuncType.Parameters));
            Interpreter.AddToLibrary(new Function(new Func<object[], object>(StartBindsByNames), FuncType.Other));
        }

        [Description("EnableBindsByNames(string name1, string name2...) - включает бинды с переданными именами.")]
        [FuncGroup("BindControl")]
        public object[] EnableBindsByNames(params object[] ps)
        {
            foreach (var currentName in ps)
            {
                foreach (BindViewModel bvm in Binds.Where(BindVM=>BindVM.Name == currentName.ToString()))
                    bvm.IsEnabled = true;
            }

            return ps;
        }

        [Description("DisableBindsByNames(string name1, string name2...) - выключает бинды с переданными именами.")]
        [FuncGroup("BindControl")]
        public object[] DisableBindsByNames(params object[] ps)
        {
            foreach (var currentName in ps)
            {
                foreach (BindViewModel bvm in Binds.Where(BindVM => BindVM.Name == currentName.ToString()))
                    bvm.IsEnabled = false;
            }

            return ps;
        }

        [Description("StartBindsByNames(string name1, string name2...) - начинает выполнение скриптов биндов по именам.")]
        [FuncGroup("ScriptRuntimeControl")]
        public object[] StartBindsByNames(params object[] ps)
        {
            foreach (var currentName in ps)
            {
                foreach (BindViewModel bvm in Binds.Where(BindVM => BindVM.Name == currentName.ToString()))
                    bvm.Bind.Invoke(null, new Trigger.Events.TriggeredEventArgs("StartBindsByNames", "StartBind();"));
            }

            return ps;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
