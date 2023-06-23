public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override void MarkAsComplete()
    {
        IsCompleted = true;
    }

    public override string GetProgress()
    {
        return IsCompleted ? "Completed" : "Not completed";
    }
}
