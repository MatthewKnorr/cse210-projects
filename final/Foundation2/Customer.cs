class Customer
{
    private string name;
    private Address address;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Address Address
    {
        get { return address; }
        set { address = value; }
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }
}
