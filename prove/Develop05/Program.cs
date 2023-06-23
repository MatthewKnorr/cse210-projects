using System;

public class Program
{
    public static void Main()
    {
        GoalTracker goalTracker = new GoalTracker();
        string fileName = "goals.txt";

        // Load goals from a file (if any)
        goalTracker.LoadGoals(fileName);

        // Add goals
        goalTracker.AddGoal(new SimpleGoal("Run a marathon", 1000));
        goalTracker.AddGoal(new EternalGoal("Read scriptures", 100));
        goalTracker.AddGoal(new ChecklistGoal("Attend the temple", 50, 10, 500));

        // Display goals
        Console.WriteLine("Current Goals:");
        goalTracker.DisplayGoals();

        // Mark goals as complete
        goalTracker.MarkGoalAsComplete(goalTracker.GetGoalByName("Run a marathon"));
        goalTracker.MarkGoalAsComplete(goalTracker.GetGoalByName("Read scriptures"));
        goalTracker.MarkGoalAsComplete(goalTracker.GetGoalByName("Attend the temple"));

        // Display goals and score
        Console.WriteLine("\nUpdated Goals:");
        goalTracker.DisplayGoals();
        goalTracker.DisplayScore();

        // Save goals to a file
        goalTracker.SaveGoals(fileName);
    }
}
