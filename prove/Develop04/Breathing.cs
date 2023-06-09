public class Breathing: Activity
{
    private DateTime _start;
    private string _message = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    private string _activity = "Breathing";

    public Breathing()
    {
        base.Start(_message, _activity);
        Cycle();
        base.Finish();
    }

    public void Cycle()
    {
        _start = base.SetTimer(5); // Starts a timer/adds delay for animations and countdowns
        bool looper = false;
        while(!looper)
        {
            for (int i = 5; i > 0; i--)
            {
                Console.Write($"Breathe In... {i}");
                Thread.Sleep(1000);
                Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
            }
            Console.WriteLine("");
            for (int i = 6; i > 0; i--){
                Console.Write($"Breathe In... {i}");
                Thread.Sleep(1000);
                Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
            }
            Console.WriteLine("\n");
            looper = base.TimeUp(_start);
        }   
    }


}