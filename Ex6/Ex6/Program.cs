using System;
namespace sayna6
{
    class Program
    {
        static Semaphore s = new Semaphore(2, 2);
        static Mutex mut = new Mutex(false);
        static readonly object lockObject = new object();
        private static AutoResetEvent event_1 = new AutoResetEvent(true);

        static readonly object lockMontiror = new object();

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                //Thread th = new Thread( waitOne);
                //Thread th = new Thread(lockFunc);
                //Thread th = new Thread(autoFunc);
                Thread th = new Thread(mutexFunc);
                Thread.monitor(th);
                th.Start();
            }


            Console.ReadKey();
        }
        private static void waitOne(object obj)
        {
            s.WaitOne();
            Console.WriteLine("start with: " + obj.ToString());
            Thread.Sleep(1000);
            Console.WriteLine("end with: " + obj.ToString());
            s.Release();
        }
        private static void lockFunc(object obj)
        {

            lock (lockMontiror)
            {
                Console.WriteLine("start with: " + obj.ToString());
                Thread.Sleep(1000);
                Console.WriteLine("end with: " + obj.ToString());
                Monitor.Pulse(lockMontiror);
                Monitor.Wait(lockMontiror);
            }

        }
        private static void mutexFunc(object obj)
        {
            mut.WaitOne();
            Console.WriteLine("start with: " + obj.ToString());
            Thread.Sleep(1000);
            Console.WriteLine("end with: " + obj.ToString());
            mut.ReleaseMutex();
        }
        private static void monitorFunc(object obj)
        {
            Monitor.Enter(lockObject);

            Console.WriteLine("start with: " + obj.ToString());
            Thread.Sleep(1000);
            Console.WriteLine("end with: " + obj.ToString());

            Monitor.Exit(lockObject);

        }
        private static void autoFunc(object obj)
        {
            Console.WriteLine("start with: " + obj.ToString());
            Thread.Sleep(1000);
            Console.WriteLine("end with: " + obj.ToString());
            event_1.WaitOne();
        }
    }
}