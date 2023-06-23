using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalTracker
{
    private List<Goal> goals;
    private int totalScore;

    public GoalTracker()
    {
        goals = new List<Goal>();
        totalScore = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void MarkGoalAsComplete(Goal goal)
    {
        if (!goal.IsCompleted)
        {
            goal.MarkAsComplete();
            totalScore += goal.Points;
        }
    }

    public Goal GetGoalByName(string name)
    {
        return goals.FirstOrDefault(goal => goal.Name == name);
    }

    public void DisplayGoals()
    {
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal);
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Score: {totalScore}");
    }

    public void SaveGoals(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetType().Name);
                writer.WriteLine(goal.Name);
                writer.WriteLine(goal.IsCompleted);
                writer.WriteLine(goal.Points);

                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine(checklistGoal.GetProgress());
                    writer.WriteLine(checklistGoal.GetType().Name);
                    writer.WriteLine(((ChecklistGoal)goal).completionCount);
                    writer.WriteLine(checklistGoal.desiredCount);
                    writer.WriteLine(checklistGoal.bonusPoints);
                }
            }
        }
    }

    public void LoadGoals(string fileName)
    {
        if (File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string goalType = reader.ReadLine();
                    string name = reader.ReadLine();
                    bool isCompleted = bool.Parse(reader.ReadLine());
                    int points = int.Parse(reader.ReadLine());

                    if (goalType == nameof(SimpleGoal))
                    {
                        SimpleGoal goal = new SimpleGoal(name, points);
                        goal.IsCompleted = isCompleted;
                        goals.Add(goal);
                    }
                    else if (goalType == nameof(EternalGoal))
                    {
                        EternalGoal goal = new EternalGoal(name, points);
                        goal.IsCompleted = isCompleted;
                        goals.Add(goal);
                    }
                    else if (goalType == nameof(ChecklistGoal))
                    {
                        string progress = reader.ReadLine();
                        int completionCount = int.Parse(reader.ReadLine());
                        int desiredCount = int.Parse(reader.ReadLine());
                        int bonusPoints = int.Parse(reader.ReadLine());

                        ChecklistGoal goal = new ChecklistGoal(name, points, desiredCount, bonusPoints);
                        goal.IsCompleted = isCompleted;
                        goal.SetCompletionCount(completionCount);
                        goals.Add(goal);
                    }
                }
            }
        }
    }
}
