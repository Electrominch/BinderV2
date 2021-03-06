﻿using System;
using BinderV2.Settings.Visuals;
using BinderV2.Settings.Interpreter;
using Utilities;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace BinderV2.Settings
{
    public class ProgramSettings
    {
        public static readonly string SaveSettingsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\BinderV2";
        public static ProgramSettings RuntimeSettings { get; private set; }

        public VisualsSettings VisualSettings { get; private set; } = new VisualsSettings();
        public InterpreterSettings InterpreterSettings { get; private set; } = new InterpreterSettings();
        private bool startWithWindows = false;
        public bool HideOnStart { get; set; }
        public bool AutoLoadBinds { get; set; }
        public string AutoLoadBindsPath { get; set; }
        public bool SaveMainWindowSize { get; set; }
        public bool CloseEqualsHide { get; set; } = true;
        public Size MainWindowSize { get; set; }
        public bool StartWithWindows
        {
            get { return startWithWindows; }
            set
            {
                startWithWindows = value;
                if (startWithWindows)
                    AutoRun.RegisterAutoRun();
                else
                    AutoRun.UnRegisterAutoRun();
            }
        }

        private ProgramSettings()
        {
             
        }


        static ProgramSettings()//начинаем тут
        {
            LoadSettings();
        }

        ~ProgramSettings()
        {
            SaveSettings();
        }

        private static void SaveSettings()
        {
            JsonUtilities.SerializeToFile(RuntimeSettings, ProgramSettings.SaveSettingsDirectory + @"\settings.txt");
        }

        private static void LoadSettings()
        {
            try
            {
                RuntimeSettings = JsonUtilities.Deserialize<ProgramSettings>(File.ReadAllText(ProgramSettings.SaveSettingsDirectory + @"\settings.txt"));
                VisualsSettings.ApplyVisuals(RuntimeSettings.VisualSettings);
            }
            catch{ Reset(); }
        }


        public static void Reset()
        {
            RuntimeSettings = new ProgramSettings();
            VisualsSettings.ApplyVisuals(RuntimeSettings.VisualSettings);
            SaveSettings();
        }
    }
}
