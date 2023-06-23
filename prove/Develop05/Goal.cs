public abstract class Goal
{
    public string Name { get; }
    private int Points { get; set; }
    private bool IsCompleted { get; set; }

    public Goal(string name)
    {
        Name = name;
        Points = 0;
        IsCompleted = false;
    }

    public abstract void MarkAsComplete();

    public int GetPoints()
    {
        return Points;
    }

    public bool GetIsCompleted()
    {
        return IsCompleted;
    }

    public void SetPoints(int points)
    {
        Points = points;
    }

    public void SetIsCompleted(bool isCompleted)
    {
        IsCompleted = isCompleted;
    }

    public abstract override string ToString();
}
