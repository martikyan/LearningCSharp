using System;
using System.Linq;

namespace LearningCSharp.Lessons
{
    public static class SololearnLessons
    {
        [Demo]
        public static void EnumerableAggregate()
        {
            int[] nums = { 1, 2, 3 };
            int s = nums.Aggregate(0, (sum, n) => n * n + sum);
            Console.Out.Write(s);
        }

        [Demo]
        public static void NullString1()
        {
            Object obj1 = null;
            Object obj2 = "Hi";
            Console.WriteLine((string)obj1 + (string)obj2);
            Console.WriteLine((string)obj2 + (string)obj1);
        }

        [Demo]
        public static void NullString2()
        {
            Console.WriteLine(((string)null).ToString());
        }

        [Demo]
        public static void StringFunctions()
        {
            string one = "sololearn";
            string two = one;
            string three = one.Remove(2);
            string four = two.Substring(4);
            Console.WriteLine(three + four);
        }

        [Demo]
        public static void Increment()
        {
            int x = 5;
            x += ++x;
            Console.Write(x);
        }

        [Demo]
        public static void Staticness()
        {
            new Person();
        }

        private class Person
        {
            // Assignment takes place in order.
            private static int a = b++;
            private static int b = ++c;
            private static int c = 3;

            public Person()
            {
                Console.Write(a + ":" + b + ":" + c);
            }
        }
    }
}