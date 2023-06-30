using System;
using System.Collections.Generic;

public class GoalTracker
{
    private List<Goal> goals;

    public GoalTracker()
    {
        goals = new List<Goal>();
    }

    public void Run()
    {
        LoadGoals();

        string choice = string.Empty;
        while (choice != "0")
        {
            Console.WriteLine("======= Eternal Quest =======");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Display goals");
            Console.WriteLine("4. Display score");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    DisplayGoals();
                    break;
                case "4":
                    DisplayScore();
                    break;
                case "0":
                    SaveGoals();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("======= Create Goal =======");
        Console.WriteLine("Select the goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Enter the goal type number: ");
        string goalType = Console.ReadLine();

        Console.Write("Enter the goal name: ");
        string goalName = Console.ReadLine();

        Console.Write("Enter the goal points: ");
        int goalPoints = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case "1":
                goals.Add(new SimpleGoal(goalName, goalPoints));
                break;
            case "2":
                goals.Add(new EternalGoal(goalName, goalPoints));
                break;
            case "3":
                Console.Write("Enter the desired count: ");
                int desiredCount = int.Parse(Console.ReadLine());

                Console.Write("Enter the bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());

                goals.Add(new ChecklistGoal(goalName, desiredCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid goal type. Goal creation failed.");
                break;
        }

        Console.WriteLine("Goal created successfully.");
    }

    private void RecordEvent()
    {
        Console.WriteLine("======= Record Event =======");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available. Record event failed.");
            return;
        }

        Console.WriteLine("Select the goal to record event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        Console.Write("Enter the goal number: ");
        int goalNumber = int.Parse(Console.ReadLine());

        if (goalNumber < 1 || goalNumber > goals.Count)
        {
            Console.WriteLine("Invalid goal number. Record event failed.");
            return;
        }

        Goal selectedGoal = goals[goalNumber - 1];
        selectedGoal.MarkComplete();

        Console.WriteLine("Event recorded successfully.");
    }

    private void DisplayGoals()
    {
        Console.WriteLine("======= Goals =======");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetCompletionStatus()} {goal.Name}");
        }
    }

    private void DisplayScore()
    {
        Console.WriteLine("======= Score =======");
        int totalPoints = 0;

        foreach (Goal goal in goals)
        {
            totalPoints += goal.Points;
        }

        Console.WriteLine($"Total Score: {totalPoints}");
    }

    private void SaveGoals()
    {
        Console.WriteLine("Saving goals...");

        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (Goal goal in goals)
            {
                string goalType = goal.GetType().Name;
                string goalData = $"{goalType},{goal.Name},{goal.Points},{(goal.IsCompleted ? 1 : 0)}";

                if (goal is ChecklistGoal checklistGoal)
                {
                    goalData += $",{checklistGoal.DesiredCount},{checklistGoal.BonusPoints},{checklistGoal.CompletionCount}";
                }

                writer.WriteLine(goalData);
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    private void LoadGoals()
    {
        Console.WriteLine("Loading goals...");

        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No goals file found. Starting with an empty goal list.");
            return;
        }

        goals.Clear();

        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] goalData = line.Split(',');

                if (goalData.Length < 4)
                {
                    Console.WriteLine("Invalid goal data found in the goals file.");
                    continue;
                }

                string goalType = goalData[0];
                string goalName = goalData[1];
                int goalPoints = int.Parse(goalData[2]);
                bool isCompleted = goalData[3] == "1";

                Goal goal;

                switch (goalType)
                {
                    case nameof(SimpleGoal):
                        goal = new SimpleGoal(goalName, goalPoints);
                        break;
                    case nameof(EternalGoal):
                        goal = new EternalGoal(goalName, goalPoints);
                        break;
                    case nameof(ChecklistGoal):
                        if (goalData.Length < 7)
                        {
                            Console.WriteLine("Invalid checklist goal data found in the goals file.");
                            continue;
                        }

                        int desiredCount = int.Parse(goalData[4]);
                        int bonusPoints = int.Parse(goalData[5]);
                        int completionCount = int.Parse(goalData[6]);
                        goal = new ChecklistGoal(goalName, desiredCount, bonusPoints)
                        {
                            CompletionCount = completionCount
                        };
                        break;
                    default:
                        Console.WriteLine("Invalid goal type found in the goals file.");
                        continue;
                }

                goal.IsCompleted = isCompleted;
                goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}
