﻿using System.Diagnostics;
using System.Security.Principal;

bool isAdmin;

#pragma warning disable CA1416 // Validate platform compatibility | Should be safe to ingnore as this should only ever be ran on windows
using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
{
    WindowsPrincipal principal = new(identity);
    isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
}
#pragma warning restore CA1416 // Validate platform compatibility

if (isAdmin == false)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("THIS PROGRAM MUST BE RAN AS ADMINISTRATOR OR IT WON'T WORK CORRECTLY!");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Press any key to exit");
    Console.ReadKey();
    Environment.Exit(1);
    Console.ForegroundColor = ConsoleColor.White;
}

do
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("-----------------------");
    Console.WriteLine("VR App Priority Changer");
    Console.WriteLine("-----------------------");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine();
    Console.WriteLine("---------Oculus---------");
    Console.WriteLine("1 = OVRServer_x64.exe & OVRRedir.exe (RealTime)");
    Console.WriteLine("2 = OculusDash.exe (High)");
    Console.WriteLine("---------Other----------");
    Console.WriteLine("3 = vrserver.exe (RealTime)");
    Console.WriteLine("4 = Beat Saber.exe (RealTime)");
    Console.WriteLine("------------------------");
    Console.WriteLine("5 = All of the above");
    Console.WriteLine("ESC = Exit");

    var option = Console.ReadKey();

    switch (option.Key)
    {
        case ConsoleKey.D1: case ConsoleKey.NumPad1:
            Set_Priority("OVRServer_x64", "OVRServer_x64.exe", ProcessPriorityClass.RealTime);
            Set_Priority("OVRRedir", "OVRRedir.exe", ProcessPriorityClass.RealTime);
            break;
        case ConsoleKey.D2: case ConsoleKey.NumPad2:
            Set_Priority("OculusDash", "OculusDash.exe", ProcessPriorityClass.High);
            break;
        case ConsoleKey.D3: case ConsoleKey.NumPad3:
            Set_Priority("vrserver", "vrserver.exe", ProcessPriorityClass.RealTime);
            break;
        case ConsoleKey.D4: case ConsoleKey.NumPad4:
            Set_Priority("Beat Saber", "Beat Saber.exe", ProcessPriorityClass.RealTime);
            break;
        case ConsoleKey.D5: case ConsoleKey.NumPad5:
            Set_Priority("OVRServer_x64", "OVRServer_x64.exe", ProcessPriorityClass.RealTime);
            Set_Priority("OVRRedir", "OVRRedir.exe", ProcessPriorityClass.RealTime);
            Set_Priority("OculusDash", "OculusDash.exe", ProcessPriorityClass.High);
            Set_Priority("vrserver", "vrserver.exe", ProcessPriorityClass.RealTime);
            Set_Priority("Beat Saber", "Beat Saber.exe", ProcessPriorityClass.RealTime);
            break;
        case ConsoleKey.Escape:
            Environment.Exit(0);
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Invalid Key!");
            Console.ForegroundColor = ConsoleColor.White;
            break;
    }
} while (true);

static void Set_Priority(string process_name, string app_name, ProcessPriorityClass priority)
{
    Process[] process = Process.GetProcessesByName(process_name);
        if (process.Length == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($"{app_name} is not running");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            foreach (Process proc in process)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("Changing Priority for: " + proc.Id + " To " + Convert.ToString(priority));
                proc.PriorityClass = priority;
                if (proc.PriorityClass == priority)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{app_name} Priority Changed!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
}