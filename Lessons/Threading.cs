using System;
using System.Threading;

namespace LearningCSharp.Lessons
{
    public static class Threading
    {
        [Demo]
        public static void ManualResetEvent()
        {
            var manualResetEvent = new ManualResetEvent(false);
            new Thread(() =>
            {
                Console.WriteLine("NonMainThread: Will call Set() after 1 second.");
                Thread.Sleep(1000);
                manualResetEvent.Set();
            }).Start();

            Console.WriteLine("MainThread: Before WaitOne() 1");
            manualResetEvent.WaitOne(); // Blocks Here
            Console.WriteLine("MainThread: After WaitOne() 1");

            Console.WriteLine("MainThread: Before WaitOne() 2");
            manualResetEvent.WaitOne();
            Console.WriteLine("MainThread: After WaitOne() 2");
            Console.WriteLine("We've reached to the end of demo.");
        }

        [Demo]
        public static void AutoResetEvent()
        {
            var manualResetEvent = new AutoResetEvent(false);
            new Thread(() =>
            {
                Console.WriteLine("NonMainThread: Will call Set() after 1 second.");
                Thread.Sleep(1000);
                manualResetEvent.Set();
            }).Start();

            Console.WriteLine("MainThread: Before WaitOne() 1");
            manualResetEvent.WaitOne(); // Blocks Here
            Console.WriteLine("MainThread: After WaitOne() 1");

            Console.WriteLine("MainThread: Before WaitOne() 2");
            // manualResetEvent.WaitOne(); // If you uncomment this you'll never pass. The reset event has been reset.
            Console.WriteLine("MainThread: After WaitOne() 2");
        }
    }
}