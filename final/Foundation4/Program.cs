using System;
using System.Collections.Generic;

public abstract class Activity
{
    protected DateTime activityDate;
    protected int activityLength;

    protected Activity(int length)
    {
        activityDate = DateTime.Today;
        activityLength = length;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public abstract string GetSummary();

    protected double CalculatePace(double distance)
    {
        return activityLength / distance;
    }

    protected double CalculateSpeed(double distance)
    {
        return (distance / activityLength) * 60;
    }

    protected string FormatDistance(double distance)
    {
        return $"{distance:F2} km";
    }

    protected string FormatSpeed(double speed)
    {
        return $"{speed:F2} kph";
    }

    protected string FormatPace(double pace)
    {
        TimeSpan paceTime = TimeSpan.FromMinutes(pace);
        return $"{paceTime.Minutes} min {paceTime.Seconds} sec per km";
    }
}

public class Running : Activity
{
    private readonly double distance;

    public Running(int length, double distance) : base(length)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return CalculateSpeed(distance);
    }

    public override double GetPace()
    {
        return CalculatePace(distance);
    }

    public override string GetSummary()
    {
        string formattedDistance = FormatDistance(distance);
        string formattedSpeed = FormatSpeed(GetSpeed());
        string formattedPace = FormatPace(GetPace());

        return $"{activityDate.ToString("dd MMM yyyy")} Running ({activityLength} min) - Distance {formattedDistance}, Speed {formattedSpeed}, Pace: {formattedPace}";
    }
}

public class StationaryBicycles : Activity
{
    private readonly double speed;

    public StationaryBicycles(int length, double speed) : base(length)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return CalculateDistance();
    }

    private double CalculateDistance()
    {
        return (speed / 60) * activityLength;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return CalculatePace(CalculateDistance());
    }

    public override string GetSummary()
    {
        string formattedDistance = FormatDistance(GetDistance());
        string formattedSpeed = FormatSpeed(speed);
        string formattedPace = FormatPace(GetPace());

        return $"{activityDate.ToString("dd MMM yyyy")} Stationary Bicycles ({activityLength} min) - Distance {formattedDistance}, Speed {formattedSpeed}, Pace: {formattedPace}";
    }
}

public class Swimming : Activity
{
    private readonly int laps;

    public Swimming(int length, int laps) : base(length)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return CalculateDistance();
    }

    private double CalculateDistance()
    {
        return laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return CalculateSpeed(CalculateDistance());
    }

    public override double GetPace()
    {
        return CalculatePace(CalculateDistance());
    }

    public override string GetSummary()
    {
        string formattedDistance = FormatDistance(GetDistance());
        string formattedSpeed = FormatSpeed(GetSpeed());
        string formattedPace = FormatPace(GetPace());

        return $"{activityDate.ToString("dd MMM yyyy")} Swimming ({activityLength} min) - Distance {formattedDistance}, Speed {formattedSpeed}, Pace: {formattedPace}";
    }
}

public class RandomGenerator
{
    private static Random random = new Random();

    public static double GenerateRandomDistance()
    {
        return random.NextDouble() * 10.0; // Generate random distance between 0 and 10 km
    }

    public static double GenerateRandomSpeed()
    {
        return random.NextDouble() * 20.0; // Generate random speed between 0 and 20 kph
    }

    public static int GenerateRandomTime()
    {
        return random.Next(30, 90); // Generate random time between 30 and 90 minutes
    }
}

public class Program
{
    static void Main()
    {
        Console.Clear(); // Clear the console

        Random random = new Random();
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(RandomGenerator.GenerateRandomTime(), RandomGenerator.GenerateRandomDistance()));
        activities.Add(new StationaryBicycles(RandomGenerator.GenerateRandomTime(), RandomGenerator.GenerateRandomSpeed()));
        activities.Add(new Swimming(RandomGenerator.GenerateRandomTime(), random.Next(10, 30)));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine(); // Add a line space between each activity summary
        }
    }
}
