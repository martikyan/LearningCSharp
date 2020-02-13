using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LearningCSharp
{
    public static class Demonstrator
    {
        private static Menu _menu;
        private const BindingFlags _bindingFlags = BindingFlags.Public | BindingFlags.Static;

        static Demonstrator()
        {
            var methods = Assembly.GetExecutingAssembly().GetTypes()
                .SelectMany(t => t.GetMethods(_bindingFlags))
                .Where(m => m.GetCustomAttributes(typeof(DemoAttribute)).Any());

            _menu = new Menu(methods.ToArray());
        }

        public static void RunDemonstrations()
        {
            _menu.ShowMenu();
            var methodInfo = _menu.Select();

            Console.WriteLine($"***** Name: {methodInfo.Name} ******\n");
            try
            {
                InvokeDemoMethod(methodInfo);
            }
            catch (Exception e)
            {
                e.ShowException();
            }

            Console.WriteLine($"\n***** Done: {methodInfo.Name} ******\n");

            var quit = Console.ReadKey();
            if (quit.Key == ConsoleKey.Q)
            {
                Environment.Exit(0);
            }
            else
            {
                RunDemonstrations();
            }
        }

        private static void InvokeDemoMethod(MethodInfo methodInfo)
        {
            var taskObj = methodInfo.Invoke(null, null);
            if (taskObj != null && taskObj is Task)
            {
                ((Task)taskObj).Wait();
            }
        }
    }
}