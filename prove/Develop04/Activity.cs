public class Activity
{
    private bool _timesUp = false; // Tells cycle if its time to end
    private int _howLong; // User input for cycle run time
    private int _delay;
    private string _activity;
    private string _mainMessage;


    public Activity() { }

    protected void Begin(string message, string activity)
    {
        _mainMessage = message;
        _activity = activity;
        StartMessage();
    }

    protected void Finish()
    {
        Console.WriteLine("Well Done\n");
        Spinner();
        EndMessage();
        Spinner();
    }

    private void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activity} Activity\n");
        Console.WriteLine(_mainMessage + '\n');
    }

    private void EndMessage()
    {
        Console.WriteLine($"You have completed another {_howLong - _delay} seconds of the {_activity} Activity.");
    }

    protected DateTime SetTimer(int delay)
    {
        _delay = delay;
        Console.WriteLine("How long, in seconds would you like you session to be?");
        _howLong = int.Parse(Console.ReadLine());
        _howLong += _delay;
        DateTime startTime = DateTime.Now;
        return startTime;
    }

    protected bool TimeUp(DateTime start)
    {
        DateTime endTime = start.AddSeconds(_howLong);
        DateTime testTime = DateTime.Now;
        if (testTime > endTime)
        {
            _timesUp = true;
        }
        return _timesUp;
    }

    protected void Countdown()
    {
        for (int i = 5; i > 0; i--)
        {
            Console.Write($"get Ready: {i}");
            Thread.Sleep(1000);
            Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
        }
    }

    protected void Spinner()
    {
        for (int i = 3; i > 0; i--)
        {
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    protected int Generator(int range)
    {
        Random randomNumber = new Random();
        int randomNum = randomNumber.Next(0, range);
        return randomNum;
    }
}