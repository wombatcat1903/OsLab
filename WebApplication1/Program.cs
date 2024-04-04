using System.Diagnostics;
namespace WebApplication1
{
    class Program
    {
        static void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
        static void Main(string[] args)
        {
            Process[] prlist = Process.GetProcesses();
            while (true)
            {
                Console.WriteLine("which operation?" + "\n" + "1.start process" + "\n" + "2.show list of processes\n3.kill process\n4.show the parent of a process");
                String choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nSTART PROCESS");
                        Console.WriteLine("which process would you like to start?");
                        String proc = Console.ReadLine();
                        try
                        {
                            Process.Start(proc);
                            Console.Write("Loading... ");
                            Thread.Sleep(1000);
                            ClearLine();
                            Console.WriteLine(proc + " was started");
                            prlist = Process.GetProcesses();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("there was a problem\n" + e.Message);
                        }

                        break;
                    case "2":
                        Console.WriteLine("\nSHOW LIST");
                        foreach (Process p in prlist)
                        {
                            Console.WriteLine(p.Id + "\t" + p.ProcessName);
                        }
                        break;
                    case "3":
                        Console.WriteLine("\nKILL A PROCESS");
                        Console.WriteLine("which process?");
                        int pid3 = int.Parse(Console.ReadLine());
                        foreach (Process p in prlist)
                        {
                            if (p.Id == pid3)
                            {
                                p.Kill();
                                Console.WriteLine("process was killed");
                            }
                        }
                        break;
                    case "4":
                        Console.WriteLine("\nPARENT OF A PROCESS");
                        Console.WriteLine("which process?");
                        int pid4 = int.Parse(Console.ReadLine());
                        foreach (Process p in prlist)
                        {
                            if (p.Id == pid4)
                            {
                                IntPtr pp = p.Handle;

                                Console.WriteLine(p.Id + "\t" + p.ProcessName + "->" + "\t" + p.Handle +
                                    "\nthis is the native handle of the process");
                                Console.WriteLine(p.Id + "\t" + p.ProcessName + "->" + "\t" + p.MainWindowHandle + "\t" + p.MainWindowTitle +
                                    "\nthis is the window handle of the main window of the process");

                            }
                        }
                        break;
                    default:
                        Console.WriteLine("not found");
                        break;
                }
                Console.WriteLine("---------------------------------------\n");

            }
        }
    }
}