using System;
using System.Threading;

namespace MindfulnessApp
{
    // Base class for activities
    public abstract class Activity
    {
        protected int duration;

        public void Start()
        {
            ShowStartingMessage();
            PrepareToBegin();
            PerformActivity();
            ShowEndingMessage();
        }

        protected void ShowStartingMessage()
        {
            Console.WriteLine($"--- {GetType().Name} ---");
            Console.WriteLine(GetDescription());
            Console.Write("Enter the duration in seconds: ");
            duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Get ready to begin...");
            Thread.Sleep(3000); // Pause for 3 seconds
        }

        protected void PrepareToBegin()
        {
            Console.WriteLine("Starting in...");
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000); // Pause for 1 second
            }
        }

        protected void ShowEndingMessage()
        {
            Console.WriteLine("Good job!");
            Console.WriteLine($"You have completed {GetType().Name} for {duration} seconds.");
            Thread.Sleep(3000); // Pause for 3 seconds
        }

        protected abstract string GetDescription();
        protected abstract void PerformActivity();
    }

    // Breathing activity
    public class BreathingActivity : Activity
    {
        protected override string GetDescription()
        {
            return "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        protected override void PerformActivity()
        {
            int breathCount = duration / 2; // Half of the duration for each breath

            for (int i = 0; i < breathCount; i++)
            {
                Console.WriteLine("Breathe in...");
                Thread.Sleep(3000); // Pause for 3 seconds

                Console.WriteLine("Breathe out...");
                Thread.Sleep(3000); // Pause for 3 seconds
            }
        }
    }

    // Reflection activity
    public class ReflectionActivity : Activity
    {
        private string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        protected override string GetDescription()
        {
            return "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }

        protected override void PerformActivity()
        {
            int questionCount = duration / 5; // One question every 5 seconds

            Random random = new Random();

            for (int i = 0; i < questionCount; i++)
            {
                string prompt = prompts[random.Next(prompts.Length)];
                Console.WriteLine(prompt);
                Thread.Sleep(3000); // Pause for 3 seconds

                foreach (string question in questions)
                {
                    Console.WriteLine(question);
                    Thread.Sleep(5000); // Pause for 5 seconds
                }
            }
        }
    }

    // Listing activity
    public class ListingActivity : Activity
    {
        private string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        protected override string GetDescription()
        {
            return "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }

        protected override void PerformActivity()
        {
            Console.WriteLine("Think about the following prompt:");
            string prompt = prompts[new Random().Next(prompts.Length)];
            Console.WriteLine(prompt);
            Console.WriteLine("Starting in...");
            Thread.Sleep(3000); // Pause for 3 seconds

            Console.WriteLine("Go!");
            Thread.Sleep(duration * 1000); // Pause for the specified duration

            Console.WriteLine($"You listed {duration} items.");
        }
    }

    // Main program
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                Activity activity;

                switch (choice)
                {
                    case 1:
                        activity = new BreathingActivity();
                        break;
                    case 2:
                        activity = new ReflectionActivity();
                        break;
                    case 3:
                        activity = new ListingActivity();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        continue;
                }

                Console.Clear();
                activity.Start();
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}