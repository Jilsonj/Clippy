using CLIPPY.NET.Executers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CLIPPY.NET
{
    public static class ExecuterFinder
    {

        public static string FindAndExecute(string input)
        {
            object[] parametersArray = new object[] { input };
            var executers = ReflectiveEnumerator.GetEnumerableOfInterface<IBaseExecuter>();

            foreach (var executer in executers)
            {
                var canExecute = Convert.ToBoolean(ReflectiveEnumerator.CallMethod("CanExecute", executer, parametersArray));
                if (canExecute)
                {
                    return Convert.ToString(ReflectiveEnumerator.CallMethod("Execute", executer, parametersArray));
                }
            }

            //if (new XmlFormatter().CanExecute(input))
            //return XmlFormatter.FormatXml(input);

            return string.Empty;
        }
    }
       
}
