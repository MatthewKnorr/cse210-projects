using System;

class Event
{
    private string eventTitle;
    private string eventDescription;
    private DateTime eventDate;
    private TimeSpan eventTime;
    private Address eventAddress;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        eventTitle = title;
        eventDescription = description;
        eventDate = date;
        eventTime = time;
        eventAddress = address;
    }

    public string GenerateStandardDetails()
    {
        string details = $"Title: {eventTitle}\n";
        details += $"Description: {eventDescription}\n";
        details += $"Date: {eventDate.ToShortDateString()}\n";
        details += $"Time: {eventTime.ToString()}\n";
        details += $"Address: {eventAddress.GetFormattedAddress()}";
        return details;
    }

    public virtual string GenerateFullDetails()
    {
        return GenerateStandardDetails();
    }

    public virtual string GenerateShortDescription()
    {
        return $"Type: Event\nTitle: {eventTitle}\nDate: {eventDate.ToShortDateString()}";
    }
}
