using System;
public class Listing : Activity
{
    private string[] _prompts = {
            "Who are people that you appreciate?", "What are personal strengths of yours?","Who are people that you have helped this week?","When have you felt the Holy Ghost this month?","Who are some of your personal heroes?"};
    private DateTime _start;
    private int _iterations = 0;
    private string _activity = "Listing";
    private string _message = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
   public Listing()
   {
    base.Start(_message, _activity);
    MakeListing();
    base.Finish();
   }
   private void MakeListing()
   {
    _start = base.SetTimer(10);
    Console.WriteLine("Brace Ye Self");
    base.SpinningWheel();
    Console.WriteLine("\nList as many responses as you can to the following prompt: ");
    base.Countdown();
    int number = base.Generator(_prompts.Length);// call random number generator to select an index position
    Console.WriteLine($"--- {_prompts[number]} ---\n");// Print the pormpt
    bool test = false;
    while(!test)
    {
        Console.Write("> ");
        Console.ReadLine();// Get user input
        _iterations ++;// Count the input
        test = base.TimeUp(_start);// Checks to see if time is up
    } 
    Console.WriteLine($"You listed {_iterations} items!\n\n");
   }
}