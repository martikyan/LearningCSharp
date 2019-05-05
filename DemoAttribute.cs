using System;

namespace LearningCSharp
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class DemoAttribute : Attribute
    {
    }
}