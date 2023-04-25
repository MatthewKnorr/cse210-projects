using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int randomNumber = randomGenerator.Next(1, 101); 
        Console.WriteLine(randomNumber);
        int guess = -1;
        while (guess != randomNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (randomNumber > guess)
            {
                Console.WriteLine("Higher");
            }

            else if (randomNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            
            else
            {
                Console.WriteLine("You guessed it!");
            }


        }
    }
}