﻿using InterpreterScripts.DataVault;
using InterpreterScripts.InterpretationScriptData;
using InterpreterScripts.ScriptCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterpreterScripts.SyntacticConstructions.Constructions
{
    class CheckVar : ISyntacticConstruction
    {
        public string Name { get { return "CheckVar"; } }
        public string Description { get { return "CheckVar(Name) - проверяет наличие переменной Name в пределах данного скрипта."; } }

        public Task<object> TryExecute(CommandModel cmd, InterpretationData data)
        {
            if (cmd.KeyWord == "CheckVar" && cmd.GetParameters().Length == 1)
                return Execute(cmd, data);
            return null;
        }

        private Task<object> Execute(CommandModel cmd, InterpretationData data)
        {
            return Task.Run(new Func<object>(() =>
            {
                var pars = cmd.GetParameters();
                if (pars.Length == 1)
                    return data.Vars.HasVar(Interpreter.ExecuteCommand(pars[0].Trim(), data).ToString());
                return false;
            }));
        }
    }
}
