using System;
using System.Reflection;

namespace LearningCSharp
{
    public static class ExceptionExtensions
    {
        public static void ShowException(this Exception e)
        {
            if (e is TargetInvocationException invocationException)
            {
                invocationException.InnerException.ShowException();
            }
            else if (e is AggregateException aggregateException)
            {
                foreach (var innerException in aggregateException.InnerExceptions)
                {
                    innerException.ShowException();
                }
            }
            else
            {
                Console.WriteLine($"Exception of type {e.GetType().Name} has been thrown with the following message: {e.Message}");
            }
        }
    }
}