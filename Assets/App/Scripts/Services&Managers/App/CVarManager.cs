using UnityEngine;
using System;
using System.Collections;
using System.Linq;

namespace CHANGE_THE_NAME
{
    [Serializable]
    public class CVarManager
    {
        ConsoleVariables cvars = new ConsoleVariables();

        public void Intialize()
        {
            Debug.Console.Add("Set", this, "SetCvar");
            Debug.Console.Add("Get", this, "GetCvar");
            Debug.Console.Add("Cvars", this, "ListScvars");
        }

        public void SetCvar(string name, string val)
        {
            var props = typeof(ConsoleVariables).GetProperties();
            var prop = props
                        .Where(x => x.Name.ToLower() == name.ToLower())
                        .FirstOrDefault();

            if (prop != null)
            {
                if (prop.CanWrite && prop.CanRead)
                {
                    prop.SetValue(cvars, val, null);
                    Debug.Console.WriteLine("Setting " + name + " to " + prop.GetValue(cvars, null));
                }
                else
                    Debug.Console.PrintErrorMessage("Access denied!");
            }
            else
            {
                Debug.Console.PrintErrorMessage("Wrong name!");
            }
        }
        public void GetCvar(string name)
        {
            var props = typeof(ConsoleVariables).GetProperties();
            var prop = props
                        .Where(x => x.Name.ToLower() == name.ToLower())
                        .FirstOrDefault();

            if (prop != null)
            {
                if(prop.CanRead)
                    Debug.Console.WriteLine(name + " = " + prop.GetValue(cvars, null));
                else
                    Debug.Console.PrintErrorMessage("Access denied!");
            }
            else
                Debug.Console.PrintErrorMessage("Wrong name!");
        }
        public void ListScvars()
        {
            var props = typeof(ConsoleVariables).GetProperties();

            Debug.Console.WriteLine(" - Available Cvars - ");
            Debug.Console.WriteLine(string.Format("{0,-20}   {1}", "Key", "Access"));
            Debug.Console.WriteLine(@"---------------------*------------------------");
            foreach (var x in props)
            {
                Debug.Console.WriteLine(string.Format(
                    "{0,-20}   {1}",
                    x.Name,
                    (x.CanRead ? "Read " : "") + (x.CanWrite ? "Write " : "")));
            }
            Debug.Console.WriteLine(@"---------------------*------------------------");
            Debug.Console.WriteLine("");
        }
    }
}