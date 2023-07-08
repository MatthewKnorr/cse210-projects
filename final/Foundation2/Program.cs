using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create products
        Product product1 = new Product
        {
            Name = RandomGenerator.GetRandomItem(new List<string> { "TP-4567: Fluoride Toothpaste", "SK-1234: Cotton Socks (Pack of 3)", "NC-7890: Stainless Steel Nail Clippers" }),
            ProductId = RandomGenerator.GenerateRandomId(),
            Price = RandomGenerator.GenerateRandomPrice(),
            Quantity = RandomGenerator.GenerateRandomQuantity()
        };

        Product product2 = new Product
        {
            Name = RandomGenerator.GetRandomItem(new List<string> { "WT-6789: Slim Cardholder Wallet", "KC-7890: Keychain with LED Light", "HP-1234: Over-ear Bluetooth Headphones" }),
            ProductId = RandomGenerator.GenerateRandomId(),
            Price = RandomGenerator.GenerateRandomPrice(),
            Quantity = RandomGenerator.GenerateRandomQuantity()
        };

        // Create customers
        Address address1 = new Address
        {
            StreetAddress = RandomGenerator.GetRandomItem(RandomGenerator.StreetNames),
            City = RandomGenerator.GetRandomItem(RandomGenerator.Cities),
            State = RandomGenerator.GetRandomItem(RandomGenerator.States),
            Country = RandomGenerator.GetRandomItem(RandomGenerator.Countries)
        };

        Customer customer1 = new Customer
        {
            Name = RandomGenerator.GetRandomItem(RandomGenerator.CustomerNames),
            Address = address1
        };

        Address address2 = new Address
        {
            StreetAddress = RandomGenerator.GetRandomItem(RandomGenerator.StreetNames),
            City = RandomGenerator.GetRandomItem(RandomGenerator.Cities),
            State = RandomGenerator.GetRandomItem(RandomGenerator.States),
            Country = RandomGenerator.GetRandomItem(RandomGenerator.Countries)
        };

        Customer customer2 = new Customer
        {
            Name = RandomGenerator.GetRandomItem(RandomGenerator.CustomerNames),
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
