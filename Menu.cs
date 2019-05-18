using System;
using System.Reflection;

namespace LearningCSharp
{
    public class Menu
    {
        private readonly MethodInfo[] _methods;

        public Menu(MethodInfo[] methods)
        {
            _methods = methods ?? throw new ArgumentNullException(nameof(methods));
        }

        public void ShowMenu()
        {
            for (int i = 0; i < _methods.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {_methods[i].Name}");
            }
        }

        public MethodInfo Select()
        {
            while (true)
            {
                try
                {
                    var num = Convert.ToInt32(Console.ReadLine());
                    if (num > _methods.Length)
                        throw new ArgumentOutOfRangeException();

                    return _methods[num - 1];
                }
                catch
                {
                    Console.WriteLine("Please try again.");
                }
            }
        }
    }
}