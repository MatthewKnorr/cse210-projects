public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points)
    {
    }

    public override void MarkComplete()
    {
        // Eternal goals are never marked complete
    }
}
