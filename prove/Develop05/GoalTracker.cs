using System;
using System.Collections.Generic;
using System.IO;

public class GoalTracker
{
    private List<Goal> goals;
    private string goalsFilePath;

    public GoalTracker()
    {
        goals = new List<Goal>();
        goalsFilePath = "goals.txt";
    }

    public void Run()
    {
        LoadGoals();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("======= Goal Tracker =======");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Mark Goal as Complete");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddGoal();
                    break;
                case "2":
                    MarkGoalAsComplete();
                    break;
                case "3":
                    DisplayGoals();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private void AddGoal()
    {
        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Select the goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                goals.Add(new SimpleGoal(name));
                Console.WriteLine("Simple Goal added successfully.");
                break;
            case "2":
                goals.Add(new EternalGoal(name));
                Console.WriteLine("Eternal Goal added successfully.");
                break;
            case "3":
                Console.Write("Enter the desired count for the Checklist Goal: ");
                int desiredCount;
                if (int.TryParse(Console.ReadLine(), out desiredCount))
                {
                    Console.Write("Enter the bonus points for the Checklist Goal: ");
                    int bonusPoints;
                    if (int.TryParse(Console.ReadLine(), out bonusPoints))
                    {
                        goals.Add(new ChecklistGoal(name, desiredCount, bonusPoints));
                        Console.WriteLine("Checklist Goal added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid bonus points. Checklist Goal not added.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid desired count. Checklist Goal not added.");
                }
                break;
            default:
                Console.WriteLine("Invalid choice. Goal not added.");
                break;
        }
    }

    private void MarkGoalAsComplete()
    {
        Console.Write("Enter the name of the goal to mark as complete: ");
        string name = Console.ReadLine();

        Goal goal = GetGoalByName(name);
        if (goal != null)
        {
            goal.MarkAsComplete();
            Console.WriteLine("Goal marked as complete.");
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    private void DisplayGoals()
    {
        Console.WriteLine("======= Goals =======");
        if (goals.Count > 0)
        {
            foreach (Goal goal in goals)
            {
                Console.WriteLine(goal);
            }
        }
        else
        {
            Console.WriteLine("No goals found.");
        }
    }

    private void SaveGoals()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(goalsFilePath))
            {
                foreach (Goal goal in goals)
                {
                    string goalType = goal.GetType().Name;
                    string goalData = $"{goalType}|{goal.Name}|{goal.GetPoints()}|{goal.GetIsCompleted()}";

                    if (goal is ChecklistGoal checklistGoal)
                    {
                        goalData += $"|{checklistGoal.DesiredCount}|{checklistGoal.BonusPoints}|{checklistGoal.GetCompletionCount()}";
                    }

                    writer.WriteLine(goalData);
                }
            }

            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while saving goals: {ex.Message}");
        }
    }

    private void LoadGoals()
    {
        if (File.Exists(goalsFilePath))
        {
            try
            {
                goals.Clear();

                using (StreamReader reader = new StreamReader(goalsFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length < 4)
                        {
                            Console.WriteLine($"Invalid goal data format: {line}. Skipping.");
                            continue;
                        }

                        string goalType = parts[0];
                        string name = parts[1];
                        int points = int.Parse(parts[2]);
                        bool isCompleted = bool.Parse(parts[3]);

                        Goal goal = null;
                        switch (goalType)
                        {
                            case "SimpleGoal":
                                goal = new SimpleGoal(name);
                                break;
                            case "EternalGoal":
                                goal = new EternalGoal(name);
                                break;
                            case "ChecklistGoal":
                                if (parts.Length < 7)
                                {
                                    Console.WriteLine($"Invalid checklist goal data format: {line}. Skipping.");
                                    continue;
                                }

                                int desiredCount = int.Parse(parts[4]);
                                int bonusPoints = int.Parse(parts[5]);
                                int completionCount = int.Parse(parts[6]);
                                goal = new ChecklistGoal(name, desiredCount, bonusPoints)
                                {
                                    CompletionCount = completionCount
                                };
                                break;
                            default:
                                Console.WriteLine($"Invalid goal type: {goalType}. Skipping.");
                                continue;
                        }  
                        goal.SetPoints(points);
                        goal.SetIsCompleted(isCompleted);
                        goals.Add(goal);
                    }
                }

                Console.WriteLine("Goals loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while loading goals: {ex.Message}");
            }
        }
    }

    private Goal GetGoalByName(string name)
    {
        foreach (Goal goal in goals)
        {
            if (goal.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return goal;
            }
        }
        return null;
    }
}
