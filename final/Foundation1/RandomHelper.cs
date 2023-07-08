using System;
using System.Collections.Generic;

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

    public RandomNameSelector()
    {
        random = new Random();
        names = new List<string> { "ShadowSlayer", "RapidFire", "NinjaGamer", "SavageQueen", "CyberWolf", "PhantomStrike", "EpicGamer", "PixelMaster", "StealthSniper", "LunarKnight", "Frostbite", "XenoBlade", "ThunderStrike", "SpectralSorcerer", "VenomousViper" };
    }

    public string SelectRandomName()
    {
        int index = random.Next(names.Count);
        return names[index];
    }
}

class RandomCommentGenerator
{
    private Random random;
    private List<string> comments;

    public RandomCommentGenerator()
    {
        random = new Random();
        comments = new List<string> { "Great video!", "I learned a lot.", "Awesome content!", "Very informative.", "Keep up the good work!", "This is amazing!", "Helped me a ton!", "Thanks for sharing!" };
    }

    public string GenerateRandomComment()
    {
        int index = random.Next(comments.Count);
        return comments[index];
    }
}

class RandomTitleGenerator
{
    private Random random;
    private List<string> titles;

    public RandomTitleGenerator()
    { 
        random = new Random();
        titles = new List<string> { "How to Parse a File Python 3", "Introduction to Machine Learning", "Web Development 101", "Mastering C# Programming", "Artificial Intelligence: A Beginner's Guide", "Game Development with Unity", "Creating Stunning Visual Effects", "Photography Tips and Techniques" };
    }

    public string GenerateRandomTitle()
    {
        int index = random.Next(titles.Count);
        return titles[index];
    }
}
