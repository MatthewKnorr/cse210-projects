class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string cityName, string stateName, string countryName)
    {
        street = streetAddress;
        city = cityName;
        state = stateName;
        country = countryName;
    }

    public string GetFormattedAddress()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}
