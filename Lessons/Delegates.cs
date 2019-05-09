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
            for (; i < 3; i++)
            {
                printers.Add(delegate { Console.WriteLine(i); });
            }

            foreach (var printer in printers)
            {
                printer(); // 3 times the number 3
            }
        }

        [Demo]
        public static void DelegateTrickOvercome()
        {
            var printers = new List<Printer>();
            var i = 0;

            for (; i < 3; i++)
            {
                int _i = i; // Copy of the i;
                printers.Add(delegate { Console.WriteLine(_i); });
            }

            foreach (var printer in printers)
            {
                printer(); // 0, 1, 2
            }
        }
    }
}