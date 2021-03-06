﻿using InterpreterScripts.Exceptions;
using InterpreterScripts.InterpretationScriptData;
using InterpreterScripts.ScriptCommand;
using InterpreterScripts.SyntacticConstructions.Constructions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterpreterScripts.SyntacticConstructions.Constructions
{
    class While : ISyntacticConstruction
    {
        public string Name { get { return "While"; } }
        public string Description { get { return "while(<условие>)\n{\n  <скрипт>\n} - выполняет скрипт, пока условие == true."; } }

        public Task<object> TryExecute(CommandModel cmd, InterpretationData data)
        {
            if (IsValidConstruction(cmd, data))
                return Execute(cmd, data);
            return null;
        }

        private Task<object> Execute(CommandModel cmd, InterpretationData data)
        {
            return Task.Run(new Func<object>(() =>
            {
                var parameters = cmd.GetParameters();
                if (parameters.Length != 1)
                    throw new WrongNumberOfParametersException(parameters.Length, 1);
                object cond = Interpreter.ExecuteCommand(parameters[0], data);
                if (!(cond is bool))
                    throw new ConversionFailedException("Не удаётся конвертировать " + parameters[0] + " в bool.");
                string script = cmd.Command;
                int bracerIndex = script.IndexOf('{');
                script = script.Substring(bracerIndex + 1, (script.Length - 1) - bracerIndex - 1).Trim();
                while ((bool)Interpreter.ExecuteCommand(parameters[0], data))
                {
                    try { Interpreter.ExecuteScript(script, data); }
                    catch (BreakException) { break; }
                    catch (Exception e) { throw e; }//прокидываем выше
                }
                return null;
            }));
        }

        private bool IsValidConstruction(CommandModel cmd, InterpretationData data)
        {
            return cmd.Command.StartsWith("while");
        }
    }
}
