using System;
using System.Collections.Generic;

public class RandomGenerator
{
    private static Random random = new Random();

    public static List<string> StreetNames = new List<string>
    {
        "Main Street",
        "Elm Street",
        "Oak Avenue",
        "Pine Street",
        "Maple Lane",
        "Cedar Road",
        "Birch Avenue",
        "Willow Lane"
    };

    public static List<string> Cities = new List<string>
    {
        "New York",
        "Los Angeles",
        "Chicago",
        "Houston",
        "Phoenix",
        "Philadelphia",
        "San Antonio",
        "San Diego"
    };

    public static List<string> States = new List<string>
    {
        "NY",
        "CA",
        "IL",
        "TX",
        "AZ",
        "PA",
        "TX",
        "CA"
    };

    public static List<string> Countries = new List<string>
    {
        "USA",
        "Canada",
        "Australia",
        "United Kingdom",
        "Germany",
        "France",
        "Japan",
        "China"
    };

    public static List<string> CustomerNames = new List<string>
    {
        "John Doe",
        "Jane Smith",
        "Michael Johnson",
        "Emily Davis",
        "Robert Wilson",
        "Olivia Brown",
        "David Taylor",
        "Sophia Lee"
    };

    public static string GetRandomItem(List<string> list)
    {
        int index = random.Next(list.Count);
        return list[index];
    }

    public static string GenerateRandomId()
    {
        int id = random.Next(1000, 10000);
        return "P" + id;
    }

    public static decimal GenerateRandomPrice()
    {
        return (decimal)random.Next(10, 100);
    }

    public static int GenerateRandomQuantity()
    {
        return random.Next(1, 5);
    }
}
