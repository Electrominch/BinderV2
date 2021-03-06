﻿using Microsoft.Win32;

namespace Utilities
{
    public static class AutoRun
    {
        public static void RegisterAutoRun()//включить автозапуск
        {
            const string applicationName = "BinderV2";
            const string pathRegistryKeyStartup =
                        "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            using (RegistryKey registryKeyStartup =
                        Registry.CurrentUser.OpenSubKey(pathRegistryKeyStartup, true))
            {
                registryKeyStartup.SetValue(
                    applicationName,
                    string.Format("\"{0}\"", System.Reflection.Assembly.GetExecutingAssembly().Location));
            }
        }

        public static void UnRegisterAutoRun()//выключить автозапуск
        {
            const string applicationName = "BinderV2";
            const string pathRegistryKeyStartup =
                        "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            using (RegistryKey registryKeyStartup =
                        Registry.CurrentUser.OpenSubKey(pathRegistryKeyStartup, true))
            {
                registryKeyStartup.DeleteValue(applicationName, false);
            }
        }
    }
}
