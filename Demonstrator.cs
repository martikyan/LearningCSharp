using System;
using System.Linq;
using System.Reflection;

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
                .Where(m => m.GetCustomAttributes(typeof(DemoAttribute)).Count() > 0);

            _menu = new Menu(methods.ToArray());
        }

        public static void RunDemonstrations()
        {
            while (true)
            {
                _menu.ShowMenu();
                var methodInfo = _menu.Select();

                Console.WriteLine($"***** Name: {methodInfo.Name} ******\n");
                try
                {
                    methodInfo.Invoke(null, null);
                }
                catch (Exception e)
                {
                    e.ShowException();
                }

                Console.WriteLine($"\n***** Done: {methodInfo.Name} ******\n");
                var quit = Console.ReadKey();
                if (quit.Key == ConsoleKey.Q)
                {
                    break;
                }
            }
        }
    }
}