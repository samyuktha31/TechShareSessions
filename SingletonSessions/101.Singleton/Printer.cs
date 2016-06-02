using System;
using System.Threading;

namespace _101.Singleton
{
    // Static singleton that lives throughout the application (process) lifetime
    public class Printer
    {
        static Printer _printerInstance;
        public static object PrinterInstanceLock = new object();
        

        public static Printer Instance
        {
            get
            {
                if (null == _printerInstance)
                {
                    lock (PrinterInstanceLock)
                    {
                        if (null == _printerInstance)
                        {
                            _printerInstance = new Printer();
                        }
                    }
                }

                return _printerInstance;
            }
            set { _printerInstance = value; }
        }

        

        public void Print(string content)
        {
            lock (PrinterInstanceLock) // comment and uncomment during demo
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
