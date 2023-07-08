using System;
using System.Collections.Generic;

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (Product product in products)
        {
            totalCost += product.Price * product.Quantity;
        }

        // Add shipping cost based on customer location
        if (customer.IsInUSA())
        {
            totalCost += 5;
        }
        else
        {
            totalCost += 35;
        }

        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (Product product in products)
        {
            packingLabel += $"Product ID: {product.ProductId}, Name: {product.Name}\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = "Shipping Label:\n";
        shippingLabel += $"Name: {customer.Name}\n";
        shippingLabel += customer.Address.GetFormattedAddress();

        return shippingLabel;
    }
}

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

class Program
{
    static void Main()
    {
        // Create products
        Product product1 = new Product
        {
            Name = "Product 1",
            ProductId = "P1",
            Price = 10,
            Quantity = 2
        };

        Product product2 = new Product
        {
            Name = "Product 2",
            ProductId = "P2",
           Price = 15,
            Quantity = 3
        };

        // Create customers
        Address address1 = new Address
        {
            StreetAddress = "123 Main Street",
            City = "New York",
            State = "NY",
            Country = "USA"
        };

        Customer customer1 = new Customer
        {
            Name = "Customer 1",
            Address = address1
        };

        Address address2 = new Address
        {
            StreetAddress = "456 Elm Street",
            City = "Los Angeles",
            State = "CA",
            Country = "USA"
        };

        Customer customer2 = new Customer
        {
            Name = "Customer 2",
            Address = address2
        };

        // Create orders
        Order order1 = new Order(new List<Product> { product1, product2 }, customer1);
        Order order2 = new Order(new List<Product> { product2 }, customer2);

        // Display order details
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order1.CalculateTotalCost());
        Console.WriteLine();

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order2.CalculateTotalCost());
    }
}
