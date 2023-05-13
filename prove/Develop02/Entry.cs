public class Entry
{
    // Sets up objects
    public string _entryText;
    public string _prompt = setPrompt();
    public string _date= SetDate();


    // Collects _entryText from user after prompt
    public Entry()
    {
        Console.Write(_prompt);
        _entryText = Console.ReadLine();
    }
    

    // Loading a file's terminal output
    public Entry(string simple)
    {
        Console.WriteLine("Loading.....");
    }

    // Gathers current date from .sys
    static string SetDate()
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        return dateText;
    }
    
    // Randomly returns 1 of 16 prompts to display 
    static string setPrompt()
    {
        string[] prompts = {           
            "Who was the most interesting person I interacted with today? ",
            "What was the best part of my day? ",
            "What was the strongest emotion I felt today? ",
            "If I had one thing I could do over today, what would it be? ",
            "What is your goal for the next day? ",
            "How did I see the hand of the Lord in my life today? ",
            "What was your favorite activity you did today? ",
            "Who were some people you spent time with today? ",
            "How have you felt the sprit today? ",
            "In what ways did you show Chirst like love today? ",
            "How do you show compassion to others? ",
            "What are three things that could be better? ",
            "How can you better support and appreciate your loved ones? ",
            "What are three things you would like to tell a friend, family member, or partner? ",
            "What three ordinary things bring you the most joy? ",
            "What is your favorite thing to do when feeling low? "
            };
        Random randomInt = new Random();
        int randomNumber = randomInt.Next(0,16);
        string singlePrompt = prompts[randomNumber];
        return singlePrompt;
    }

    // Thanks to my classmate I got his working with his example!
    // But it formats how the entry is saved and displayed
    public void Display()
    {
        Console.WriteLine($"Date: {_date}, Prompt: {_prompt}, Entry: {_entryText}");
    }

}
