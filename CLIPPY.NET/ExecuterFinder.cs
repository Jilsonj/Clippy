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
            var executers = GetEnumerableOfInterface<IBaseExecuter>();

            foreach (var executer in executers)
            {
               var canExecute = Convert.ToBoolean(CallMethod("CanExecute", executer, parametersArray));
               if (canExecute)
               {
                   return Convert.ToString(CallMethod("Execute", executer, parametersArray));
               }
            }
           
            //var y = GetEnumerableOfInterface<IBaseExecuter>();

            if (new XmlFormatter().CanExecute(input))
                return XmlFormatter.FormatXml(input);

            return string.Empty;
        }
        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class, IComparable<T>
        {
            List<T> objects = new List<T>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }
            objects.Sort();
            return objects;
        }

        public static IEnumerable<Type> GetEnumerableOfInterface<T>() where T : class
        {
            var objects = Assembly
                 .GetAssembly(typeof(T))
                 .GetTypes()
                 .Where(myType => myType.IsClass && !myType.IsAbstract && !myType.IsInterface && typeof(T).IsAssignableFrom(myType))
                 .ToList();

            object[] parametersArray = new object[] { "Hello" };

            //CallMethod(objects, parametersArray);

            return objects;
        }

        private static object CallMethod(string methodName, Type objects, object[] parametersArray)
        {
            MethodInfo methodInfo = objects.GetMethod(methodName);
            object classInstance = Activator.CreateInstance(objects, null);
            var result = methodInfo.Invoke(classInstance, parametersArray);
            return result;
        }
    }
}
