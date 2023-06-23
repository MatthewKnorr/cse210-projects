public class EternalGoal : Goal
{
    public EternalGoal(string name) : base(name)
    {
    }

    public override void MarkAsComplete()
    {
        // The completion of an eternal goal doesn't change its completion status or points
    }

    public override string ToString()
    {
        return $"Eternal Goal - {Name} [Points: {GetPoints()}, Completed: {GetIsCompleted()}]";
    }
}
