using System;

class Program
{
    static void Main()
    {
        // Create addresses
        Address address1 = new Address("123 Main Street", "New York", "NY", "USA");
        Address address2 = new Address("456 Elm Street", "Los Angeles", "CA", "USA");
        Address address3 = new Address("789 Oak Avenue", "Chicago", "IL", "USA");

        // Create events
        Event event1 = new Event("Generic Event", "This is a generic event", DateTime.Now, new TimeSpan(12, 0, 0), address1);
        Lecture lecture1 = new Lecture("Tech Talk", "Learn about the latest technology trends", DateTime.Now.AddDays(1), new TimeSpan(14, 0, 0), address2, "John Doe", 100);
        Reception reception1 = new Reception("Networking Mixer", "Network with professionals in your industry", DateTime.Now.AddDays(2), new TimeSpan(18, 0, 0), address3, "info@example.com");
        OutdoorGathering gathering1 = new OutdoorGathering("Picnic in the Park", "Enjoy a day of outdoor activities", DateTime.Now.AddDays(3), new TimeSpan(10, 0, 0), address1, "Sunny skies");

        // Generate marketing messages
        string event1StandardDetails = event1.GenerateStandardDetails();
        string event1FullDetails = event1.GenerateFullDetails();
        string event1ShortDescription = event1.GenerateShortDescription();

        string lecture1StandardDetails = lecture1.GenerateStandardDetails();
        string lecture1FullDetails = lecture1.GenerateFullDetails();
        string lecture1ShortDescription = lecture1.GenerateShortDescription();

        string reception1StandardDetails = reception1.GenerateStandardDetails();
        string reception1FullDetails = reception1.GenerateFullDetails();
        string reception1ShortDescription = reception1.GenerateShortDescription();

        string gathering1StandardDetails = gathering1.GenerateStandardDetails();
        string gathering1FullDetails = gathering1.GenerateFullDetails();
        string gathering1ShortDescription = gathering1.GenerateShortDescription();

        // Display marketing messages
        Console.WriteLine("Event 1 Standard Details:");
        Console.WriteLine(event1StandardDetails);
        Console.WriteLine();

        Console.WriteLine("Event 1 Full Details:");
        Console.WriteLine(event1FullDetails);
        Console.WriteLine();

        Console.WriteLine("Event 1 Short Description:");
        Console.WriteLine(event1ShortDescription);
        Console.WriteLine();

        Console.WriteLine("Lecture 1 Standard Details:");
        Console.WriteLine(lecture1StandardDetails);
        Console.WriteLine();

        Console.WriteLine("Lecture 1 Full Details:");
        Console.WriteLine(lecture1FullDetails);
        Console.WriteLine();

        Console.WriteLine("Lecture 1 Short Description:");
        Console.WriteLine(lecture1ShortDescription);
        Console.WriteLine();

        Console.WriteLine("Reception 1 Standard Details:");
        Console.WriteLine(reception1StandardDetails);
        Console.WriteLine();

        Console.WriteLine("Reception 1 Full Details:");
        Console.WriteLine(reception1FullDetails);
        Console.WriteLine();

        Console.WriteLine("Reception 1 Short Description:");
        Console.WriteLine(reception1ShortDescription);
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering 1 Standard Details:");
        Console.WriteLine(gathering1StandardDetails);
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering 1 Full Details:");
        Console.WriteLine(gathering1FullDetails);
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering 1 Short Description:");
        Console.WriteLine(gathering1ShortDescription);
    }
}
