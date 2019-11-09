using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using UnityEngine;
using Verse.AI;
using System.Diagnostics;

namespace {{cookiecutter.mod_name.replace(' ', '_')}}
{
    public class {{cookiecutter.mod_name.replace(' ', '_')}}
    {
    }

    internal class Debug
    {
        [Conditional("DEBUG")]
        internal static void Log(string s)
        {
            Verse.Log.Message(s);
        }
		
        [Conditional("DEBUG")]
        internal static void Warning(string s)
        {
            Verse.Log.Warning(s);
        }

        [Conditional("DEBUG")]
        internal static void Error(string s)
        {
            Verse.Log.Error(s);
        }
    }
}