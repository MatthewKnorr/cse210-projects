using System;
// Creates type safe collections
using System.Collections.Generic;
// Used to quiery and manipulate data
using System.Linq;

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