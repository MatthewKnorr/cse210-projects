using System;
//  creates type-safe collections
using System.Collections.Generic;
// used to quiere and manipulate data
using System.Linq;


// Single word in scripture tracking if hidden
class Word
{
    public string Text { get; private set; }
    public bool Hidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }

    public void Hide()
    {
        Hidden = true;
    }

    public void Reveal()
    {
        Hidden = false;
    }
}

// Constructor holds the scripture reference value
class Reference
{
    public string Value { get; private set; }

    public Reference(string reference)
    {
        Value = reference;
    }
}

// Main logic stores scriptures as text to collection of word objects, displaying the scripture, hiding random words, and checking all words of hidden
class Scripture
{
    private List<Word> words;
    private Random random;

    public Reference Reference { get; private set; }

    public Scripture(string reference, string text)
    {
        Reference = new Reference(reference);
        words = text.Split(' ').Select(word => new Word(word)).ToList();
        random = new Random();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{Reference.Value}\n");

        foreach (Word word in words)
        {
            Console.Write(word.Hidden ? "____ " : $"{word.Text} ");
        }

        Console.WriteLine("\n");
    }

    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = words.Where(word => !word.Hidden).ToList();
        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.Hidden);
    }
}


// Handles program execution, prompting user and controlling the flow by input, is user entry point
class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life.");
        int wordsToHide = 2;

        while (!scripture.AllWordsHidden())
        {
            scripture.Display();
            Console.WriteLine("Press enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(wordsToHide);
        }
    }
}