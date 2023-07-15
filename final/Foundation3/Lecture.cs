class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speakerName, int eventCapacity)
        : base(title, description, date, time, address)
    {
        speaker = speakerName;
        capacity = eventCapacity;
    }

    public override string GenerateFullDetails()
    {
        string details = base.GenerateFullDetails();
        details += $"\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
        return details;
    }
}
