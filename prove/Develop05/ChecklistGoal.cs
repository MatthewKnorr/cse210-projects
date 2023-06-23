public class ChecklistGoal : Goal
{
    public int DesiredCount { get; }
    public int BonusPoints { get; }
    public int CompletionCount { get; private set; }

    public ChecklistGoal(string name, int desiredCount, int bonusPoints) : base(name)
    {
        DesiredCount = desiredCount;
        BonusPoints = bonusPoints;
        CompletionCount = 0;
    }

    public override void MarkAsComplete()
    {
        CompletionCount++;
        if (CompletionCount >= DesiredCount)
        {
            SetIsCompleted(true);
            SetPoints(GetPoints() + BonusPoints);
        }
    }

    public int GetCompletionCount()
    {
        return CompletionCount;
    }

    public override string ToString()
    {
        return $"Checklist Goal - {Name} ({CompletionCount}/{DesiredCount}) [Points: {GetPoints()}, Completed: {GetIsCompleted()}]";
    }
}
