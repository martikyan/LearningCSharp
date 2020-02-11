using System;

namespace LearningCSharp.Lessons
{
    public class Structs
    {
        [Demo]
        public static void ShowReadOnlyStructEvilness()
        {
            StructsMutability mutability = new StructsMutability();

            Console.WriteLine("Incrementing Field 2 times, initial value = 1");
            Console.WriteLine(mutability.FieldIncrement.Increment());
            Console.WriteLine(mutability.FieldIncrement.Increment());

            Console.WriteLine("Incrementing Property 2 times, initial value = 1");
            Console.WriteLine(mutability.ProperyIncrement.Increment());
            Console.WriteLine(mutability.ProperyIncrement.Increment());

            Console.WriteLine("Incrementing Readonly Field 2 times, initial value = 1");
            Console.WriteLine(mutability.ReadonlyFieldIncrement.Increment());
            Console.WriteLine(mutability.ReadonlyFieldIncrement.Increment());
        }
    }

    public class StructsMutability
    {
        public NumberIncrement FieldIncrement;
        public NumberIncrement ProperyIncrement { get; }
        public readonly NumberIncrement ReadonlyFieldIncrement;

        public StructsMutability()
        {
            this.FieldIncrement = new NumberIncrement(1);
            this.ProperyIncrement = new NumberIncrement(1);
            this.ReadonlyFieldIncrement = new NumberIncrement(1);
        }
    }

    public struct NumberIncrement
    {
        private int _number;

        public NumberIncrement(int number) : this()
        {
            this._number = number;
        }

        public int Increment()
        {
            this._number++;
            return this._number;
        }
    }
}