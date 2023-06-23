public class EternalGoal : Goal
{
    public EternalGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override void MarkAsComplete()
    {
        // Eternal goals are never completed
    }

    public override string GetProgress()
    {
        return "In progress";
    }
}
