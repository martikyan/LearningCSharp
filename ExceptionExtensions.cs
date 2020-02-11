using System;
using System.Reflection;

namespace LearningCSharp
{
    public static class ExceptionExtensions
    {
        public static void ShowException(this Exception e)
        {
            switch (e)
            {
                case TargetInvocationException invocationException:
                    invocationException.InnerException.ShowException();
                    break;

                case AggregateException aggregateException:
                    foreach (var innerException in aggregateException.InnerExceptions)
                    {
                        innerException.ShowException();
                    }

                    break;

                default:
                    Console.WriteLine($"Exception of type {e.GetType().Name} has been thrown with the following message: {e.Message}");
                    break;
            }
        }
    }
}