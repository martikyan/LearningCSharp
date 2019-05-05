using System;

namespace LearningCSharp.Lessons
{
    public class InterviewLesson
    {
        [Demo]
        public static void BoxingAndPolymorphism()
        {
            Point point = new Point();
            Console.WriteLine(point); // Point.ToString(), (0, 0)

            point.Change(1, 5);
            Object boxedPoint = point;
            Console.WriteLine(boxedPoint); // Point.ToString(), (1, 5)

            ((Point)boxedPoint).Change(2, 3);
            Console.WriteLine(point); // Point.ToString(), (1, 5)
            Console.WriteLine(boxedPoint); // Point.ToString(), (1, 5)
        }

        [Demo]
        public static void ChangingBoxedValue()
        {
            Point point = new Point(1, 2);
            Object boxedPoint = point;

            ((IChangeable)boxedPoint).Change(4, 5);

            Console.WriteLine(point); // Point.ToString(), (1, 2)
            Console.WriteLine(boxedPoint); // Point.ToString(), (3, 4)
        }

        private struct Point : IChangeable
        {
            public double x, y;

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public void Change(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return $"({x}, {y})";
            }
        }

        private interface IChangeable
        {
            void Change(double x, double y);
        }
    }
}