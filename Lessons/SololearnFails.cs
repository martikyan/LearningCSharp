using System;
using System.Linq;

namespace LearningCSharp.Lessons
{
    public static class SololearnFails
    {
        [Demo]
        public static void EnumerableAggregate()
        {
            int[] nums = { 1, 2, 3 };
            int s = nums.Aggregate(0, (sum, n) => n * n + sum);
            Console.Out.Write(s);
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