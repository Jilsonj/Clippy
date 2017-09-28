using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CLIPPY.NET
{
    public static class ReflectiveEnumerator
    {
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

            return objects;
        }

        public static object CallMethod(string methodName, Type objects, object[] parametersArray)
        {
            MethodInfo methodInfo = objects.GetMethod(methodName);
            object classInstance = Activator.CreateInstance(objects, null);
            var result = methodInfo.Invoke(classInstance, parametersArray);
            return result;
        }
    }
}
