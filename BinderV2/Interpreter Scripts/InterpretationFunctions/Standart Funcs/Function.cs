﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows;
using InterpreterScripts.Exceptions;
using InterpreterScripts.Script;
using InterpreterScripts.InterpretationFunctions.Standart;
using System.ComponentModel;
using InterpreterScripts.InterpretationScriptData;

namespace InterpreterScripts.InterpretationFunctions.Standart
{
    public class Function : IInterpreterFunction
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string GroupName { get; private set; }
        public FuncType ReturnType { get; private set; }
        private readonly Func<object[], object> meth;

        public Function(MethodInfo mi, object target, FuncType returnType)
        {
            if (mi == null)
                throw new ArgumentNullException();
            if (!mi.IsStatic && target == null)
                throw new MethodIsNotStaticException();
            
            meth = (Func<object[], object>)mi.CreateDelegate(typeof(Func<object[], object>), target);
            Name = mi.Name;
            ReturnType = returnType;
            
            if (mi.GetCustomAttribute<DescriptionAttribute>() != null)//проверка на наличие атрибута описания
                Description = mi.GetCustomAttribute<DescriptionAttribute>().Description;

            if (mi.GetCustomAttribute<FuncGroupAttribute>() != null)//проверка на наличие атрибута группы
                GroupName = mi.GetCustomAttribute<FuncGroupAttribute>().GroupName;
            else
                GroupName = "None";
        }

        public Function(Delegate func, FuncType returnType, string Name="") : this(func.Method, func.Target, returnType)
        {
            if (Name.Length > 0)
                this.Name = Name;
        }


        public Task<object> GetResult(object[] parameters, InterpretationData data)
        {
            return Task.Run(() =>
            {
                return meth.Invoke(ScriptTools.GetParametersFromArray(parameters));
            });
        }

        public override bool Equals(object obj)
        {
            if(obj is Function f2)
            {
                return Name == f2.Name && meth == f2.meth;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return meth.GetHashCode();
        }
    }
}
