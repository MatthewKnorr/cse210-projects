class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public string StreetAddress
    {
        get { return streetAddress; }
        set { streetAddress = value; }
    }

    public string City
    {
        get { return city; }
        set { city = value; }
    }

    public string State
    {
        get { return state; }
        set { state = value; }
    }

    public string Country
    {
        get { return country; }
        set { country = value; }
    }

    public bool IsInUSA()
    {
        return country == "USA";
    }

    public string GetFormattedAddress()
    {
        string formattedAddress = $"Street Address: {streetAddress}\n";
        formattedAddress += $"City: {city}\n";
        formattedAddress += $"State/Province: {state}\n";
        formattedAddress += $"Country: {country}";

        return formattedAddress;
    }
}
