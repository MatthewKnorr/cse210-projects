class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string email)
        : base(title, description, date, time, address)
    {
        rsvpEmail = email;
    }

    public override string GenerateFullDetails()
    {
        string details = base.GenerateFullDetails();
        details += $"\nType: Reception\nRSVP Email: {rsvpEmail}";
        return details;
    }
}
