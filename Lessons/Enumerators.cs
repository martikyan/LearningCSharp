using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningCSharp.Lessons
{
    public static class Enumerators
    {
        [Demo]
        public static void YieldBreakVsBreak()
        {
            Console.WriteLine("Simple break: ");
            Break().Print();

            Console.WriteLine("Yield break: ");
            YieldBreak().Print();
        }

        private static IEnumerable<int> Break()
        {
            foreach (var i in Enumerable.Range(1, 5))
            {
                yield return i;
                break;
            }

            yield return 10;
        }

        private static IEnumerable<int> YieldBreak()
        {
            foreach (var i in Enumerable.Range(1, 5))
            {
                yield return i;
                yield break;
            }

            yield return 10;
        }

        private static void Print<T>(this IEnumerable<T> enumerable)
        {
            foreach (var e in enumerable)
            {
                Console.Write(e.ToString() + " ");
            }

            Console.WriteLine();
        }
    }
}