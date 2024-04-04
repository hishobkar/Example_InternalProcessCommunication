using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    // Import the necessary WinAPI functions
    [DllImport("Kernel32")]
    private static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate handler, bool add);

    // Delegate for the handler function
    private delegate bool ConsoleCtrlDelegate(int ctrlType);

    // Handler function to handle CTRL+C
    private static bool ConsoleCtrlHandler(int ctrlType)
    {
        if (ctrlType == 0) // CTRL+C event
        {
            Console.WriteLine("Received CTRL+C signal.");
            // Add cleanup logic here if needed
        }
        return true;
    }

    static void Main(string[] args)
    {
        // Register the handler function
        SetConsoleCtrlHandler(new ConsoleCtrlDelegate(ConsoleCtrlHandler), true);

        Console.WriteLine("Press CTRL+C to send a signal.");
        // Keep the application running until CTRL+C is pressed
        while (true)
        {
            Thread.Sleep(1000);
        }
    }
}
