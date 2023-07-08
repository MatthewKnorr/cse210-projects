using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class RandomNumberGenerator
{
    private Random random;

    public RandomNumberGenerator()
    {
        random = new Random();
    }

    public int GenerateNumber(int minValue, int maxValue)
    {
        return random.Next(minValue, maxValue + 1);
    }
}

class RandomNameSelector
{
    private Random random;
    private List<string> names;

    public RandomNameSelector(List<string> nameList)
    {
        random = new Random();
        names = nameList;
    }

    public string SelectRandomName()
    {
        int index = random.Next(names.Count);
        return names[index];
    }
}

class Program
{
    static void Main()
    {
        // Create videos
        List<Video> videos = new List<Video>();

        RandomNumberGenerator rng = new RandomNumberGenerator();
        int randomNumberOne = rng.GenerateNumber(800, 2500);

        List<string> names = new List<string> { "ShadowSlayer", "RapidFire", "NinjaGamer", "SavageQueen", "CyberWolf", "PhantomStrike", "EpicGamer", "PixelMaster", "StealthSniper", "LunarKnight", "Frostbite", "XenoBlade", "ThunderStrike", "SpectralSorcerer", "VenomousViper" };
        RandomNameSelector nameSelector = new RandomNameSelector(names);
        string randomNameOne = nameSelector.SelectRandomName();

        Video video1 = new Video("How to Parse a File Python 3", randomNameOne, randomNumberOne);
        video1.Comments.Add(new Comment(nameSelector.SelectRandomName(), "Comment 1 for video 1"));
        video1.Comments.Add(new Comment(nameSelector.SelectRandomName(), "Comment 2 for video 1"));
        video1.Comments.Add(new Comment(nameSelector.SelectRandomName(), "Comment 3 for video 1"));
        videos.Add(video1);

        int randomNumberTwo = rng.GenerateNumber(125, 500);
        string randomNameTwo = nameSelector.SelectRandomName();

        Video video2 = new Video("Video 2", randomNameTwo, randomNumberTwo);
        video2.Comments.Add(new Comment(nameSelector.SelectRandomName(), "Comment 1 for video 2"));
        video2.Comments.Add(new Comment(nameSelector.SelectRandomName(), "Comment 2 for video 2"));
        videos.Add(video2);

        int randomNumberThree = rng.GenerateNumber(400, 1300);
        string randomNameThree = nameSelector.SelectRandomName();

        Video video3 = new Video("Video 3", randomNameThree, randomNumberThree);
        video3.Comments.Add(new Comment(nameSelector.SelectRandomName(), "Comment 1 for video 3"));
        videos.Add(video3);

        // Display video information
        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length: " + video.Length + " seconds");
            Console.WriteLine("Number of comments: " + video.GetNumberOfComments());

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine(" - " + comment.Name + ": " + comment.Text);
            }

            Console.WriteLine();
        }
    }
}
