using System.Diagnostics;

var repeat = true;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("RUN AS ADMINISTRATOR OR IT WON'T WORK CORRECTLY!");
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.White;

do
{
    Console.WriteLine("-----------------------");
    Console.WriteLine("VR App Priority Changer");
    Console.WriteLine("-----------------------");
    Console.WriteLine();
    Console.WriteLine("1 = OVRServer_x64.exe");
    Console.WriteLine("2 = vrserver.exe");
    Console.WriteLine("3 = Beat Saber.exe");
    Console.WriteLine("4 = All of the above");
    Console.WriteLine("5 = Exit");

    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Process[] process1 = Process.GetProcessesByName("OVRServer_x64");
            if (process1.Length == 0)
            {
                Console.WriteLine("OVRServer_x64.exe is not running");
            }
            else
            {
                foreach (Process proc in process1)
                {
                    Console.WriteLine("Changing Priority for: " + proc.Id + " To RealTime");
                    proc.PriorityClass = ProcessPriorityClass.RealTime;
                    if (proc.PriorityClass == ProcessPriorityClass.RealTime)
                    {
                        Console.WriteLine("Priority Changed!");
                    }
                }
            }
            break;
        case "2":
            Process[] process2 = Process.GetProcessesByName("vrserver");
            if (process2.Length == 0)
            {
                Console.WriteLine("vrserver.exe is not running");
            }
            else
            {
                foreach (Process proc in process2)
                {
                    Console.WriteLine("Changing Priority for: " + proc.Id + " To RealTime");
                    proc.PriorityClass = ProcessPriorityClass.RealTime;
                    if (proc.PriorityClass == ProcessPriorityClass.RealTime)
                    {
                        Console.WriteLine("Priority Changed!");
                    }
                }
            }
            break;
        case "3":
            Process[] process3 = Process.GetProcessesByName("Beat Saber");
            if (process3.Length == 0)
            {
                Console.WriteLine("Beat Saber.exe is not running");
            }
            else
            {
                foreach (Process proc in process3)
                {
                    Console.WriteLine("Changing Priority for: " + proc.Id + " To RealTime");
                    proc.PriorityClass = ProcessPriorityClass.RealTime;
                    if (proc.PriorityClass == ProcessPriorityClass.RealTime)
                    {
                        Console.WriteLine("Priority Changed!");
                    }
                }
            }
            break;
        case "4":
            Process[] process1_all = Process.GetProcessesByName("OVRServer_x64");
            if (process1_all.Length == 0)
            {
                Console.WriteLine("OVRServer_x64.exe is not running");
            }
            else
            {
                foreach (Process proc in process1_all)
                {
                    Console.WriteLine("Changing Priority for: " + proc.Id + " To RealTime");
                    proc.PriorityClass = ProcessPriorityClass.RealTime;
                    if (proc.PriorityClass == ProcessPriorityClass.RealTime)
                    {
                        Console.WriteLine("Priority Changed!");
                    }
                }
            }
            Process[] process2_all = Process.GetProcessesByName("vrserver");
            if (process2_all.Length == 0)
            {
                Console.WriteLine("vrserver.exe is not running");
            }
            else
            {
                foreach (Process proc in process2_all)
                {
                    Console.WriteLine("Changing Priority for: " + proc.Id + " To RealTime");
                    proc.PriorityClass = ProcessPriorityClass.RealTime;
                    if (proc.PriorityClass == ProcessPriorityClass.RealTime)
                    {
                        Console.WriteLine("Priority Changed!");
                    }
                }
            }
            Process[] process3_all = Process.GetProcessesByName("Beat Saber");
            if (process3_all.Length == 0)
            {
                Console.WriteLine("Beat Saber.exe is not running");
            }
            else
            {
                foreach (Process proc in process3_all)
                {
                    Console.WriteLine("Changing Priority for: " + proc.Id + " To RealTime");
                    proc.PriorityClass = ProcessPriorityClass.RealTime;
                    if (proc.PriorityClass == ProcessPriorityClass.RealTime)
                    {
                        Console.WriteLine("Priority Changed!");
                    }
                }
            }
            break;
        case "5":
            repeat = false;
            break;
        default:
            Console.WriteLine("Invalid Key!");
            break;
    }
} while (repeat == true);