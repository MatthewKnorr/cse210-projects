public class ChecklistGoal : Goal
{
    private int completionCount;
    private int desiredCount;
    private int bonusPoints;

    public ChecklistGoal(string name, int points, int desiredCount, int bonusPoints)
    {
        Name = name;
        Points = points;
        this.desiredCount = desiredCount;
        this.bonusPoints = bonusPoints;
    }

    public override void MarkAsComplete()
    {
        completionCount++;

        if (completionCount >= desiredCount)
        {
            IsCompleted = true;
            Points += bonusPoints;
        }
    }

    public override string GetProgress()
    {
        return $"Completed {completionCount}/{desiredCount} times";
    }
}
