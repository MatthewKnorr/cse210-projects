public class Entry
{
    public string _entryText;
    public string _prompt = setPrompt();
    public string _date= SetDate();

    public Entry()
    {
        Console.Write(_prompt);
        _entryText = Console.ReadLine();
        // listFiles._addEntry.Add(_entryText);
    }
    public Entry(string simple)
    {
        // skip the prompt and date because this is only sused when loading files.
    }
    
    static string SetDate()
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        return dateText;
    }

    static string setPrompt()
    {
        string[] prompts = {"Question 1","Question 2","Question 3","Question 4","Question 5","Question 6"};
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(0,3);
        string prompt = prompts[number];
        return prompt;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}, Prompt: {_prompt}, Entry: {_entryText}");
    }

}