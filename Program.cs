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
    Console.WriteLine("3 = OVRServer_x64.exe & vrserver.exe");
    Console.WriteLine("4 = Beat Saber.exe");
    Console.WriteLine("5 = All of the above");
    Console.WriteLine("6 = Exit");

    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Set_Priority("OVRServer_x64", "OVRServer_x64.exe");
            break;
        case "2":
            Set_Priority("vrserver", "vrserver.exe");
            break;
        case "3":
            Set_Priority("OVRServer_x64", "OVRServer_x64.exe");
            Set_Priority("vrserver", "vrserver.exe");
            break;
        case "4":
            Set_Priority("Beat Saber", "Beat Saber.exe");
            break;
        case "5":
            Set_Priority("OVRServer_x64", "OVRServer_x64.exe");
            Set_Priority("vrserver", "vrserver.exe");
            Set_Priority("Beat Saber", "Beat Saber.exe");
            break;
        case "6":
            repeat = false;
            break;
        default:
            Console.WriteLine("Invalid Key!");
            break;
    }
} while (repeat == true);

static void Set_Priority(string process_name, string app_name)
{
    Process[] process = Process.GetProcessesByName(process_name);
        if (process.Length == 0)
        {
            Console.WriteLine($"{app_name} is not running");
        }
        else
        {
            foreach (Process proc in process)
            {
                Console.WriteLine("Changing Priority for: " + proc.Id + " To RealTime");
                proc.PriorityClass = ProcessPriorityClass.RealTime;
                if (proc.PriorityClass == ProcessPriorityClass.RealTime)
                {
                    Console.WriteLine($"{app_name} Priority Changed!");
                }
            }
        }
}