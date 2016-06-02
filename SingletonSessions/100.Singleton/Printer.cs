using System;
using System.Threading;

namespace _100.Singleton
{
    // Static singleton that lives throughout the application (process) lifetime
    public static class Printer
    {
        public static object PrinterLock = new object();

        public static void Print(string content)
        {
            lock (PrinterLock) // comment and uncomment during demo
            {
                Console.WriteLine("Printing 1: {0}", content);
                Thread.Sleep(TimeSpan.FromMilliseconds(1));
                Console.WriteLine("Printing 2: {0}", content);
                Thread.Sleep(TimeSpan.FromMilliseconds(1));
                Console.WriteLine("Printing 3: {0}", content);
                Thread.Sleep(TimeSpan.FromMilliseconds(1));
                Console.WriteLine("Printing 4: {0}", content);
                Thread.Sleep(TimeSpan.FromMilliseconds(1));
                Console.WriteLine("Printing 5: {0}", content);
                Thread.Sleep(TimeSpan.FromMilliseconds(1));
                Console.WriteLine("Printing 6: {0}", content);
                Thread.Sleep(TimeSpan.FromMilliseconds(1));
            }
        }
    }
}
