using System;
using System.Diagnostics;

namespace Sololearn
{
    public static class Demonstrator
    {
        public delegate void Demonstrate();
        public static readonly Demonstrate Demonstrations;

        static Demonstrator()
        {
            Demonstrations += ListInsertFailure.Demonstrate;
        }

        public static void RunDemonstrations()
        {
            var delegates = Demonstrations.GetInvocationList();

            for (int i = 0; i < delegates.Length; i++)
            {
                Console.WriteLine($"***** Name: {delegates[i].Method.DeclaringType} ******\n");
                var demo = (Demonstrate)delegates[i];

                try
                {
                    Debugger.Break();
                    demo();
                }
                catch (Exception e)
                {
                    e.ShowException();
                }
                finally
                {
                    Console.WriteLine($"\n***** Done: {delegates[i].Method.DeclaringType} ******");
                    Debugger.Break();
                }
            }
        }
    }
}