// Exceeding Requirements
// I added log file that save the date, time, name of activity, duration 
// and for the listing activity, it records how many list items were typed
// The log file is saved to mindfulness_log.txt in the local folder
// Every time an activity is complete the log file gets appended.

using System;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        
        while (!quit)
        {
            Console.Clear();
            DisplayMenu();

            string selection = Console.ReadLine();

            switch(selection)
            {
                case "1": //breathing activity
                    BreathingActivity breathe = new BreathingActivity();
                    breathe.Run();
                    break;
                case "2": //reflecting activity
                    ReflectingActivity reflect = new ReflectingActivity();
                    reflect.Run();
                    break;
                case "3": //listing activity
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;
                case "4": //quit
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Not a valid selection. Try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
    static void DisplayMenu()
    {
        Console.WriteLine("--- Welcome to the Mindfulness Program ---");
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listening activity");
        Console.WriteLine("  4. Quit");
        Console.Write("Select a choice from the menu: ");
    }
}