public class ChecklistGoal : Goal
{
    public int DesiredCount { get; set; }
    public int BonusPoints { get; set; }
    public int CompletionCount { get; set; }

    public ChecklistGoal(string name, int desiredCount, int bonusPoints) : base(name, 0)
    {
        DesiredCount = desiredCount;
        BonusPoints = bonusPoints;
        CompletionCount = 0;
    }

    public override void MarkComplete()
    {
        CompletionCount++;
        if (CompletionCount >= DesiredCount)
        {
            IsCompleted = true;
            Points = Points + BonusPoints;
        }
        else
        {
            Points = Points + Points;
        }
    }

    public override string GetCompletionStatus()
    {
        return $"Completed {CompletionCount}/{DesiredCount} times";
    }
}

