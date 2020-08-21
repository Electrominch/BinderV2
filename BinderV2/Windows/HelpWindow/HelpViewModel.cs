﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using InterpreterScripts.InterpretationScriptData.StandartFunctions;
using System.Security.Cryptography;
using InterpreterScripts;
using System.Windows.Forms;
using InterpreterScripts.SyntacticConstructions;

namespace BinderV2.Windows.Help
{
    class HelpViewModel : INotifyPropertyChanged
    {
        private Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();

        private string parametersFuncsHelp = "";
        public string ParametersFuncsHelp
        {
            get { return parametersFuncsHelp; }
            set 
            {
                parametersFuncsHelp = value; 
                OnPropertyChanged("ParametersFuncsHelp"); 
            }
        }

        private string boolFuncsHelp = "";
        public string BoolFuncsHelp
        {
            get { return boolFuncsHelp; }
            set
            {
                boolFuncsHelp = value;
                OnPropertyChanged("BoolFuncsHelp");
            }
        }

        private string doubleFuncsHelp = "";
        public string DoubleFuncsHelp
        {
            get { return doubleFuncsHelp; }
            set
            {
                doubleFuncsHelp = value;
                OnPropertyChanged("DoubleFuncsHelp");
            }
        }

        private string intFuncsHelp = "";
        public string IntFuncsHelp
        {
            get { return intFuncsHelp; }
            set
            {
                intFuncsHelp = value;
                OnPropertyChanged("IntFuncsHelp");
            }
        }

        private string stringFuncsHelp = "";
        public string StringFuncsHelp
        {
            get { return stringFuncsHelp; }
            set
            {
                stringFuncsHelp = value;
                OnPropertyChanged("StringFuncsHelp");
            }
        }

        private string otherFuncsHelp="";
        public string OtherFuncsHelp
        {
            get { return otherFuncsHelp; }
            set
            {
                otherFuncsHelp = value;
                OnPropertyChanged("OtherFuncsHelp");
            }
        }

        private string funcsHelpByGroups = "";
        public string FuncsHelpByGroups
        {
            get { return funcsHelpByGroups; }
            set
            {
                funcsHelpByGroups = value;
                OnPropertyChanged("FuncsHelpByGroups");
            }
        }

        private string сonstructionsHelp = "";
        public string ConstructionsHelp
        {
            get { return сonstructionsHelp; }
            set
            {
                сonstructionsHelp = value;
                OnPropertyChanged("ConstructionsHelp");
            }
        }


        public HelpViewModel()
        {
            SetHelpTexts();
        }

        private void SetHelpTexts()
        {
            foreach (Function f in Interpreter.GetAllLibrary())
            {
                AddForType(f.Description, f.ReturnType);
                AddToGroups(f);
            }

            AddToConstructions();

            foreach (string key in groups.Keys)
            {
                FuncsHelpByGroups += "Группа " + key + ":" + Environment.NewLine;
                int count = 0;
                foreach (string desc in groups[key])
                    FuncsHelpByGroups += "    " + count++  + ") "+ desc + Environment.NewLine;
                FuncsHelpByGroups += Environment.NewLine;
            }
        }

        private void AddToGroups(Function f)
        {
            if (!groups.ContainsKey(f.GroupName))
                groups.Add(f.GroupName, new List<string>());

            groups[f.GroupName].Add(f.Description);
        }

        private void AddForType(string desc, FuncType type)
        {
            desc+='\n';
            switch (type)
            {
                case FuncType.Boolean:
                    {
                        BoolFuncsHelp += BoolFuncsHelp.Count(ch=>ch=='\n').ToString() + ") ";
                        BoolFuncsHelp += desc;
                        break;
                    }
                case FuncType.Double:
                    {
                        DoubleFuncsHelp += DoubleFuncsHelp.Count(ch => ch == '\n').ToString() + ") ";
                        DoubleFuncsHelp += desc;
                        break;
                    }
                case FuncType.Int:
                    {
                        IntFuncsHelp += IntFuncsHelp.Count(ch => ch == '\n').ToString() + ") ";
                        IntFuncsHelp += desc;
                        break;
                    }
                case FuncType.String:
                    {
                        StringFuncsHelp += StringFuncsHelp.Count(ch => ch == '\n').ToString() + ") ";
                        StringFuncsHelp += desc;
                        break;
                    }
                case FuncType.Parameters:
                    {
                        ParametersFuncsHelp += ParametersFuncsHelp.Count(ch => ch == '\n').ToString() + ") ";
                        ParametersFuncsHelp += desc;
                        break;
                    }
                case FuncType.Other:
                    {
                        OtherFuncsHelp += OtherFuncsHelp.Count(ch => ch == '\n').ToString() + ") ";
                        OtherFuncsHelp += desc;
                        break;
                    }
            }
        }

        private void AddToConstructions()
        {
            ConstructionsHelp = "После каждой команды нужно писать ;.\nЧтобы сделать команду асинхронной нужно добавить async перед ней. Конструкции так же считаются командами. Нераспознанные команды превращаются в строку.\nСписок всех доступных конструкций для интерпретатора.\n";
            int count = 0;
            foreach (ISyntacticConstruction sc in SyntacticConstructionsManager.GetSyntacticConstructs())
            {
                ConstructionsHelp += count++ + ") " +  sc.Description + "\n\n";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
