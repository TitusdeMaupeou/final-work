using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// The IronPython and Dynamic Language Runtime (DLR)
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

//Created by Dmitry Pursanov
//https://medium.com/emoney-engineering/running-python-script-from-c-and-working-with-the-results-843e68d230e5
public class PythonInstance : MonoBehaviour
{
    public string PatchParameter(string parameter, int serviceid, string path)
    {
        ScriptEngine engine = Python.CreateEngine(); // Extract Python language engine from their grasp
        ScriptScope scope = engine.CreateScope(); // Introduce Python namespace (scope)
        Dictionary<string, object> d = new Dictionary<string, object>
            {
                { "serviceid", serviceid},
                { "parameter", parameter}
            }; // Add some sample parameters. Notice that there is no need in specifically setting the object type, interpreter will do that part for us in the script properly with high probability

//      scope.SetVariable("params", d); // This will be the name of the dictionary in python script, initialized with previously created .NET Dictionary
        ScriptSource source = engine.CreateScriptSourceFromFile(path); // Load the script
        object result = source.Execute(scope);
        parameter = scope.GetVariable<string>("fill_nas_from_config"); // To get the finally set variable 'parameter' from the python script
        Debug.Log(parameter);
        return parameter;
    }
}
