using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your FIRST name? ");
        string firstName = Console.ReadLine();
        Console.WriteLine("What is your LAST name? ");
        string lastName = Console.ReadLine();

        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}");

    }
}