public class Activity
{
    private bool _timeCheck = false; // Tells cycle if its time to end
    private int _timeLength; // User input for cycle run time
    private int _delay;
    private string _activity;
    private string _messages;


    public Activity() { }

    protected void Start(string message, string activity)
    {
        _messages = message;
        _activity = activity;
        StartDisplay();
    }

    protected void Finish()
    {
        Console.WriteLine("Well Done\n");
        SpinningWheel();
        EndDisplay();
        SpinningWheel();
    }

    private void StartDisplay()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activity} Activity\n");
        Console.WriteLine(_messages + '\n');
    }

    private void EndDisplay()
    {
        Console.WriteLine($"You have completed another {_timeLength - _delay} seconds of the {_activity} Activity.");
    }

    protected DateTime SetTimer(int delay)
    {
        _delay = delay;
        Console.WriteLine("How long, in seconds would you like you session to be?");
        _timeLength = int.Parse(Console.ReadLine());
        _timeLength += _delay;
        DateTime startTime = DateTime.Now;
        return startTime;
    }

    protected bool TimeUp(DateTime start)
    {
        DateTime endTime = start.AddSeconds(_timeLength);
        DateTime testTime = DateTime.Now;
        if (testTime > endTime)
        {
            _timeCheck = true;
        }
        return _timeCheck;
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

    protected void SpinningWheel()
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