using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private List<Word> _words;
    private Random _random;

    public Reference Reference { get; private set; }

    public Scripture(string[] references, string[] texts)
    {
        if (references.Length != texts.Length)
        {
            throw new ArgumentException("The number of references must match the number of texts.");
        }

        _random = new Random();
        int index = _random.Next(references.Length);

        Reference = new Reference(references[index]);
        _words = texts[index].Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{Reference.Value}\n");

        foreach (Word word in _words)
        {
            Console.Write(word.Hidden ? "____ " : $"{word.Text} ");
        }

        Console.WriteLine("\n");
    }

    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = _words.Where(word => !word.Hidden).ToList();
        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.Hidden);
    }
}