using System;

public abstract class Goal
{
    public string Name { get; set; }
    public bool IsCompleted { get; protected set; }
    public int Points { get; protected set; }

    public abstract void MarkAsComplete();
    public abstract string GetProgress();

    public override string ToString()
    {
        string completionStatus = IsCompleted ? "[X]" : "[ ]";
        return $"{completionStatus} {Name}: {GetProgress()}";
    }
}
