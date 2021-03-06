﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InterpreterScripts.InterpretationFunctions;
using InterpreterScripts.InterpretationFunctions.Standart.Library;

namespace InterpreterScripts.InterpretationFunctions.Standart
{
    static class FuncsLibManager
    {
        private static Function[] library = new Function[0];

        static FuncsLibManager()
        {
            GetFuncsFromType(typeof(DoubleScripts), FuncType.Double);
            GetFuncsFromType(typeof(StringScripts), FuncType.String);
            GetFuncsFromType(typeof(BoolScripts), FuncType.Boolean);
            GetFuncsFromType(typeof(VoidScripts), FuncType.Parameters);
            GetFuncsFromType(typeof(AHKScripts), FuncType.Parameters);
            GetFuncsFromType(typeof(IntScripts), FuncType.Int);
        }

        private static void GetFuncsFromType(Type typeWithMethods, FuncType funcType)
        {
            foreach (MethodInfo mi in typeWithMethods.GetRuntimeMethods())
            {
                Function buffer;
                try
                {
                    buffer = new Function(mi, null, funcType);
                    AddToArray(ref library, buffer);
                }
                catch {  };
            }
        }

        private static void AddToArray<T>(ref T[] array, T value)
        {
            int indexToAdd = array.Length;
            Array.Resize(ref array, array.Length + 1);
            array[indexToAdd] = value;
        }

        public static Function[] GetLibrary()
        {
            return (Function[])library.Clone();
        }
    }
}
