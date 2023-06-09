using System;
class Program
{
    static void Main(string[] args)
    {
        bool runApp = true; // Runs the main loop until user quits

        while (runApp)
        {
            Console.Write("Menu options:\n 1. Start Breathing Activity\n 3. Start Listing Activity\n 4. Quit\nSelect a choice from the menu ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Activity activity = new Breathing();
                    break;

                case "2":
                    Activity activity2 = new Reflection();
                    break;

                case "3":
                    Activity activity3 = new Listing();
                    break;

                case "4":
                    runApp = false;
                    Console.WriteLine("Thanks for using the Mindfulness App.\n");
                    break;

                default:
                    Console.WriteLine($"{option} is not valid entry.");
                    continue;
            }
        }
    }
}