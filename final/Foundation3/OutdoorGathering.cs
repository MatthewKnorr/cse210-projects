class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string forecast)
        : base(title, description, date, time, address)
    {
        weatherForecast = forecast;
    }

    public override string GenerateFullDetails()
    {
        string details = base.GenerateFullDetails();
        details += $"\nType: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
        return details;
    }
}
