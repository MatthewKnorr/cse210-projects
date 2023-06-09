public class Reflection : Activity
{
    private string[] _prompts = { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." };
    private string[] _questions = { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" };

    private List<int> _used = new List<int>();
    private DateTime _start;
    private string _activity = "Reflection";

    private string _message = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    public Reflection()
    {
        base.Begin(_message,_activity);
        Prompt();
        base.Finish();
    }
    private void Prompt()
    {
        _start = base.SetTimer(10);
        Console.WriteLine("Consider the following prompt: ");
        int number = base.Generator(_prompts.Length);
        Console.WriteLine($"--- {_prompts[number]} ---\n");
        Console.WriteLine($"When you have somthing in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related tothis experience.\n");
        base.Countdown();
        bool test = false;
        while(!test)
        {
            int randomNum = base.Generator(_questions.Length);
            if (_used.Contains(randomNum))
            {
                continue;
            }
            else
            {
                Console.WriteLine($">{_questions[randomNum]}");
                base.Spinner();
                _used.Add(randomNum);
                test = base.TimeUp(_start);
            }
        }
    }
}