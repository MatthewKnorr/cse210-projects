using System;

namespace MindfulnessApp
{
    abstract class Activity
    {
        protected int duration; 

        protected void ShowStartingMessage(string activityName, string description)
        {
            Console.WriteLine($"==== {activityName} ====");
            Console.WriteLine(description);
            Console.Write("Enter the duration (in seconds): ");
            duration = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Prepare to begin...");   
            Pause(3);
        }

        protected void ShowFinishingMessage(string activityName)
        {
            Console.WriteLine("Good job!");
            Console.WriteLine($"You have completed the {activityName} for {duration} seconds.");
            Pause(3);
        }

        protected void Pause(int seconds)
        {
            // Implement your desired animation or countdown timer here
            Console.WriteLine("Pause...");
            System.Threading.Thread.Sleep(seconds * 1000);
        }

        public abstract void Start();
    }
}