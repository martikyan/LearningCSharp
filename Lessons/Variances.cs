using System;
using System.Collections.Generic;

namespace LearningCSharp.Lessons
{
    public static class Variances
    {
        [Demo]
        public static void ArrayTypeMismatch()
        {
            Terrier[] terriers = new Terrier[3];
            Dog[] dogs = (Dog[])terriers;
            dogs[0] = new Pitbull();
            Console.WriteLine(dogs[0]);
        }

        [Demo]
        public static void Covariance()
        {
            // Assignment compatibility.   
            string str = "test";
            // An object of a more derived type is assigned to an object of a less derived type.   
            object obj = str;

            // Covariance.   
            IEnumerable<string> strings = new List<string>();
            // An object that is instantiated with a more derived type argument   
            // is assigned to an object instantiated with a less derived type argument.   
            // Assignment compatibility is preserved.   
            IEnumerable<object> objects = strings;
        }

        [Demo]
        public static void Contravariance()
        {
            // Assignment compatibility.   
            string str = "test";
            // An object of a more derived type is assigned to an object of a less derived type.   
            object obj = str;

            // Contravariance.             
            // Assume that the following method is in the class:   
            // static void SetObject(object o) { }   
            Action<object> actObject = (object o) => { };
            // An object that is instantiated with a less derived type argument   
            // is assigned to an object instantiated with a more derived type argument.   
            // Assignment compatibility is reversed.   
            Action<string> actString = actObject;
        }

        private class Dog
        {
        }

        private class Terrier : Dog
        {
        }

        private class Pitbull : Dog
        {
        }
    }
}
