public class SimpleGoal : Goal
{
    public SimpleGoal(string name) : base(name)
    {
    }

    public override void MarkAsComplete()
    {
        SetIsCompleted(true);
        SetPoints(GetPoints() + 1);
    }

    public override string ToString()
    {
        return $"Simple Goal - {Name} [Points: {GetPoints()}, Completed: {GetIsCompleted()}]";
    }
}
