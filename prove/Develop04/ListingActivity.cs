using System;

namespace MindfulnessApp
{
    class ListingActivity : Activity
    {
        private string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public override void Start()
        {
            ShowStartingMessage("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

            Random random = new Random();

            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            Pause(5);

            Console.WriteLine("Start listing...");
            Pause(duration);

            // Assume the user inputs the items during the listing duration
            int itemCount = 5; // Placeholder, replace with the actual count

            Console.WriteLine($"Number of items listed: {itemCount}");
            Pause(3);

            ShowFinishingMessage("Listing Activity");
        }
    }
}