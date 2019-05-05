using System;
using System.Collections.Generic;

namespace LearningCSharp.Lessons
{
    public class Delegates
    {
        private delegate void Printer();

        [Demo]
        public static void DelegateTrick()
        {
            List<Printer> printers = new List<Printer>(); // Printer or Action
            int i = 0;
            for (; i < 10; i++)
            {
                printers.Add(delegate { Console.WriteLine(i); });
            }

            foreach (var printer in printers)
            {
                printer(); // 10 times the number 10
            }
        }
    }
}