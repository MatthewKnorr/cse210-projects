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

class Program
{
    static void Main()
    {
        // Create videos
        List<Video> videos = new List<Video>();

        RandomNumberGenerator rng = new RandomNumberGenerator();
        RandomNameSelector nameSelector = new RandomNameSelector();
        RandomCommentGenerator commentGenerator = new RandomCommentGenerator();
        RandomTitleGenerator titleGenerator = new RandomTitleGenerator();

        int randomNumberOne = rng.GenerateNumber(800, 2500);
        string randomNameOne = nameSelector.SelectRandomName();

        Video video1 = new Video(titleGenerator.GenerateRandomTitle(), randomNameOne, randomNumberOne);
        video1.Comments.Add(new Comment(nameSelector.SelectRandomName(), commentGenerator.GenerateRandomComment()));
        video1.Comments.Add(new Comment(nameSelector.SelectRandomName(), commentGenerator.GenerateRandomComment()));
        video1.Comments.Add(new Comment(nameSelector.SelectRandomName(), commentGenerator.GenerateRandomComment()));
        videos.Add(video1);

        int randomNumberTwo = rng.GenerateNumber(125, 500);
        string randomNameTwo = nameSelector.SelectRandomName(); 

        Video video2 = new Video(titleGenerator.GenerateRandomTitle(), randomNameTwo, randomNumberTwo);
        video2.Comments.Add(new Comment(nameSelector.SelectRandomName(), commentGenerator.GenerateRandomComment()));
        video2.Comments.Add(new Comment(nameSelector.SelectRandomName(), commentGenerator.GenerateRandomComment()));
        videos.Add(video2);

        int randomNumberThree = rng.GenerateNumber(400, 1300);
        string randomNameThree = nameSelector.SelectRandomName();

        Video video3 = new Video(titleGenerator.GenerateRandomTitle(), randomNameThree, randomNumberThree);
        video3.Comments.Add(new Comment(nameSelector.SelectRandomName(), commentGenerator.GenerateRandomComment()));
        video3.Comments.Add(new Comment(nameSelector.SelectRandomName(), commentGenerator.GenerateRandomComment()));
        video3.Comments.Add(new Comment(nameSelector.SelectRandomName(), commentGenerator.GenerateRandomComment()));
        video3.Comments.Add(new Comment(nameSelector.SelectRandomName(), commentGenerator.GenerateRandomComment()));
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
