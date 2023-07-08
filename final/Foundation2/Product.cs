class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
}
