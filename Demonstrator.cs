using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace LearningCSharp
{
    public static class Demonstrator
    {
        private static MethodInfo[] _methodInfos;
        private const BindingFlags _bindingFlags = BindingFlags.Public | BindingFlags.Static;

        static Demonstrator()
        {
            var methods = Assembly.GetExecutingAssembly().GetTypes()
                .SelectMany(t => t.GetMethods(_bindingFlags))
                .Where(m => m.GetCustomAttributes(typeof(DemoAttribute)).Count() > 0);

            _methodInfos = methods.ToArray();
        }

        public static void RunDemonstrations()
        {
            for (int i = 0; i < _methodInfos.Length; i++)
            {
                Console.WriteLine($"***** Name: {_methodInfos[i].Name} ******\n");
                try
                {
                    Debugger.Break();
                    _methodInfos[i].Invoke(null, null);
                }
                catch (Exception e)
                {
                    e.ShowException();
                }
                finally
                {
                    Console.WriteLine($"\n***** Done: {_methodInfos[i].Name} ******\n");
                }
            }
        }
    }
}