using System;

namespace LearningCSharp.Lessons
{
    public static class Arithmetics
    {
        [Demo]
        public static void DivisionByZero()
        {
            const double doubleZero = 0.0;
            var intZero = 0;

            Console.WriteLine($"double: {doubleZero} / {doubleZero} = {doubleZero / doubleZero}");
            Console.WriteLine($"int: {intZero} / {intZero} = {intZero / intZero}");
        }

        [Demo]
        public static void NaN()
        {
            Console.WriteLine($"1.0 / 0.0 is infinity: {double.IsInfinity(1.0 / 0.0)}");
            Console.WriteLine($"1.0 / 0.0 is NaN: {double.IsNaN(1.0 / 0.0)}");
            Console.WriteLine($"0.0 / 0.0 is infinity: {double.IsInfinity(0.0 / 0.0)}");
            Console.WriteLine($"0.0 / 0.0 is NaN: {double.IsNaN(0.0 / 0.0)}");
            Console.WriteLine($"Infinity is NaN: {double.IsNaN(double.PositiveInfinity)}");
        }

        [Demo]
        public static void CastingToInt()
        {
            Console.WriteLine("Casting floating numbers to int.");

            Console.WriteLine($"Rounded 1.1 = {(int)1.1}");
            Console.WriteLine($"Rounded 1.9 = {(int)1.9}");
            Console.WriteLine($"Rounded -1.1 = {(int)-1.1}");
            Console.WriteLine($"Rounded -1.9 = {(int)-1.9}");

            Console.WriteLine("Always rounding to zero.");
        }

        [Demo]
        public static void MathRounding()
        {
            Console.WriteLine("Rounding floating numbers using Math.");

            Console.WriteLine($"Math.Rounded 1.5 = {Math.Round(1.5)}");
            Console.WriteLine($"Math.Rounded 2.5 = {Math.Round(2.5)}");
            Console.WriteLine($"Math.Rounded 1.5 = {Math.Round(1.5, MidpointRounding.ToEven)}");
            Console.WriteLine($"Math.Rounded 2.5 = {Math.Round(2.5, MidpointRounding.ToEven)}");

            Console.WriteLine($"It defaults rounding to {nameof(MidpointRounding)}.{nameof(MidpointRounding.ToEven)}");
        }
    }
}