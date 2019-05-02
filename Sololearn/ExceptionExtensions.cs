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
                Console.WriteLine(e.Message);
            }
        }
    }
}