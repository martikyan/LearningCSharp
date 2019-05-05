using System;

namespace Sololearn
{
    public static class ExceptionExtensions
    {
        public static void ShowException(this Exception e)
        {
            if (e is AggregateException aggregateException)
            {
                foreach (var innerException in aggregateException.InnerExceptions)
                {
                    innerException.ShowException();
                }
            }
            else
            {
                Console.WriteLine($"Exception of type {e.GetType().Name} has thrown with message {e.Message}");
            }
        }
    }
}