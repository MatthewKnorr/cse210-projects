using System;

namespace MindfulnessApp
{
    class BreathingActivity : Activity
    {
        public override void Start()
        {
            ShowStartingMessage("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

            int breathCount = duration / 2;

            for (int i = 1; i <= breathCount; i++)
            {
                Console.WriteLine("Breathe in...");
                Pause(3);

                Console.WriteLine("Breathe out...");
                Pause(3);
            }

            ShowFinishingMessage("Breathing Activity");
        }
    }
}