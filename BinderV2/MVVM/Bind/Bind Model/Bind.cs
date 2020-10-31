﻿using System;
using System.Collections.Generic;
using Trigger.Events;
using Trigger.Types;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using BindModel.Events;
using BindModel.Exeptions;
using InterpreterScripts;
using InterpreterScripts.InterpretationScriptData;
using InterpreterScripts.InterpretationScriptData.StandartFunctions;
using System.Reflection;
using System.Windows;
using System.Threading.Tasks;

namespace BindModel
{
    public sealed class Bind : IDisposable
    {
        public event EnableBindChangedEventHandler EnableChanged;
        private bool enable = true;
        public string Name { get; set; }
        public string Script { get; set; }
        public ObservableCollection<BaseTrigger> Triggers { get; private set; }
        public bool Enable
        {
            get { return enable; }
            set
            {
                enable = value;
                EnableChanged?.Invoke(this, new EnableBindChangedEventArgs(enable));
            }
        }
        

        public Bind()
        {
            Triggers = new ObservableCollection<BaseTrigger>();
            Name = "Без имени";
            Script = "";
            Triggers.CollectionChanged += TriggersChanged;
        }


        public void Dispose()
        {
            foreach (BaseTrigger bt in Triggers)
                bt.Dispose();
            GC.SuppressFinalize(this);
        }

        private void Invoked(object sender, TriggeredEventArgs e)
        {
            if (!Enable)//если выключено - выходим
                return;
            e.triggerData.Vars["TriggerName"] = e.TriggerName;

            object StartBind(params object[] ps)
            {
                Interpreter.ExecuteScript(Script, e.triggerData);
                return ps;
            }

            e.triggerData.AdditionalFunctions.Add(new Function(new Func<object[], object>(StartBind), FuncType.Parameters, "StartBind"));
            Interpreter.ExecuteScript(e.TriggerScript, e.triggerData);
        }

        

        private void TriggersChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                foreach (BaseTrigger newBt in e.NewItems)
                    newBt.AddCallback(Invoked);
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                foreach (BaseTrigger newBt in e.OldItems)
                    newBt.RemoveCallback(Invoked);
        }

        ~Bind()
        {
            foreach (BaseTrigger bt in Triggers)
                bt.Dispose();
        }
    }
}
