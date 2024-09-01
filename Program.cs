using System.Diagnostics;
using System.Security.Principal;

bool isAdmin;
var repeat = true;

#pragma warning disable CA1416 // Validate platform compatibility | Should be save to ingnore as this should only ever be ran on windows
using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
{
    WindowsPrincipal principal = new WindowsPrincipal(identity);
    isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
}
#pragma warning restore CA1416 // Validate platform compatibility

if (isAdmin == false)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("RUN AS ADMINISTRATOR OR IT WON'T WORK CORRECTLY!");
    Console.WriteLine();
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
    Console.WriteLine("1 = OVRServer_x64.exe");
    Console.WriteLine("2 = vrserver.exe");
    Console.WriteLine("3 = OVRServer_x64.exe & vrserver.exe");
    Console.WriteLine("4 = Beat Saber.exe");
    Console.WriteLine("5 = All of the above");
    Console.WriteLine("6 = Exit");

    var option = Console.ReadKey();

    switch (option.Key)
    {
        case ConsoleKey.D1: case ConsoleKey.NumPad1:
            Set_Priority("OVRServer_x64", "OVRServer_x64.exe");
            break;
        case ConsoleKey.D2: case ConsoleKey.NumPad2:
            Set_Priority("vrserver", "vrserver.exe");
            break;
        case ConsoleKey.D3: case ConsoleKey.NumPad3:
            Set_Priority("OVRServer_x64", "OVRServer_x64.exe");
            Set_Priority("vrserver", "vrserver.exe");
            break;
        case ConsoleKey.D4: case ConsoleKey.NumPad4:
            Set_Priority("Beat Saber", "Beat Saber.exe");
            break;
        case ConsoleKey.D5: case ConsoleKey.NumPad5:
            Set_Priority("OVRServer_x64", "OVRServer_x64.exe");
            Set_Priority("vrserver", "vrserver.exe");
            Set_Priority("Beat Saber", "Beat Saber.exe");
            break;
        case ConsoleKey.D6: case ConsoleKey.NumPad6:
            repeat = false;
            break;
        default:
            Console.WriteLine(); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Key!"); Console.ForegroundColor = ConsoleColor.White;
            break;
    }
} while (repeat == true);

static void Set_Priority(string process_name, string app_name)
{
    Process[] process = Process.GetProcessesByName(process_name);
        if (process.Length == 0)
        {
            Console.WriteLine(); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{app_name} is not running"); Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            foreach (Process proc in process)
            {
                Console.WriteLine(); Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Changing Priority for: " + proc.Id + " To RealTime");
                proc.PriorityClass = ProcessPriorityClass.RealTime;
                if (proc.PriorityClass == ProcessPriorityClass.RealTime)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{app_name} Priority Changed!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
}