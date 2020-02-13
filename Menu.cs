using System;
using System.Linq;
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
            var iteration = 0;
            var groupedMethods = _methods.GroupBy(m => m.DeclaringType.Name);
            foreach (var group in groupedMethods)
            {
                Console.WriteLine(group.Key);
                foreach (var method in group)
                {
                    Console.WriteLine($"\t{iteration + 1}. {method.Name}");
                    iteration++;
                }

                Console.WriteLine();
            }
        }

        public MethodInfo Select()
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
                throw;
            }
        }
    }
}