﻿using InterpreterScripts.Exceptions;
using InterpreterScripts.InterpretationScriptData;
using InterpreterScripts.ScriptCommand;
using InterpreterScripts.SyntacticConstructions.Constructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterScripts.SyntacticConstructions
{
    public static class SyntacticConstructionsManager
    {
        static readonly List<ISyntacticConstruction> syntacticConstructs = GetSyntacticConstructs().ToList();

        public static ISyntacticConstruction[] GetSyntacticConstructs()
        {
            //сюда добавлять конструкции
            return new ISyntacticConstruction[] 
            { 
                new Delay(),
                new IfThenConstruction(),
                new FunctionDefinition(),
                new Return(), 
                new Break(), 
                new Repeat(),
                new While(),
                new SetVar(),
                new GetVar(),
                new CheckVar(),
                new SetVarNamespaced(),
                new GetVarNamespaced(),
                new CheckVarNamespaced(),
                new CodeBlock(),
                new ParallelRepeat()
            };
        }

        public static bool IsValidConstruction(CommandModel command, InterpretationData data)
        {
            foreach (var sc in syntacticConstructs)
            {
                if (sc.IsValidConstruction(command, data))
                    return true;
            }
            return false;
        }

        public static bool IsValidConstruction(CommandModel command, InterpretationData data, out ISyntacticConstruction construction)
        {
            foreach (var sc in syntacticConstructs)
            {
                if (sc.IsValidConstruction(command, data))
                {
                    construction = sc;
                    return true;
                }
            }

            construction = null;
            return false;
        }

        public static Task<object> ExecuteConstruction(CommandModel command, InterpretationData data)
        {
            ISyntacticConstruction construction;
            if (!IsValidConstruction(command, data, out construction))
                throw new NotFoundScriptConstructException(command.Command);
            return construction.Execute(command, data);//вызываем подходяющую конструкцию
        }

        
    }
}
