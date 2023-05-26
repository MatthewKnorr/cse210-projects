using System;
using System.Collections.Generic; // Used to define the generic List<Word> and the Random object
using System.Linq; // Used to perform filtering and checking operations on the _words list

public class Scripture
{   // Private attributs
    private List<Word> _words; // Stores word in scripture
    private Random _random; // Generates random Numbers
    
    public Reference Reference { get; private set; } // Provides read only access to Reference obj

    public Scripture(string[] references, string[] texts) // Constructor checks if the lengths of the two arrays are equal
    {
        if (references.Length != texts.Length) 
        {
            throw new ArgumentException("The number of references must match the number of texts.");
        }

        _random = new Random();
        int index = _random.Next(references.Length);  // Generates a random index within the valid range of the arrays
        Reference = new Reference(references[index]); // Using the index it creates new Reference obj assiging it to reference property
        _words = texts[index].Split(' ').Select(word => new Word(word)).ToList(); // Splitting text at index points and creating Word objects for each word
    }
    
    public void Display() // Clears the console screen and displays the scripture
    {
        Console.Clear();
        Console.WriteLine($"{Reference.Value}\n"); // Prints reference.value 
        foreach (Word word in _words) // Followed by each word in _word
        {   
            Console.Write(word.Hidden ? "____ " : $"{word.Text} "); // If the word is hidden it displays _____ instead otherwise the actual word
        }

        Console.WriteLine("\n");
    }

    public void HideRandomWords(int count) // Hides a specified number of random words in the scripture and words
    {
        List<Word> visibleWords = _words.Where(word => !word.Hidden).ToList(); // Contains all the words from a collection that arent hidden
        int wordsToHide = Math.Min(count, visibleWords.Count); // Selects visible words by number of hiden based on min cnt

        for (int i = 0; i < wordsToHide; i++) // Generates a random index
        {
            int index = _random.Next(visibleWords.Count); // Selects a random index within the range of the visibleWords list
            visibleWords[index].Hide(); // Retrieves a word to hide
            visibleWords.RemoveAt(index); // Removes word from visibleWords to prevent 2x dip
        }
    }

    public bool AllWordsHidden() // Checks if all the words in the scripture are hidden
    {
        return _words.All(word => word.Hidden); // Returns true if all words are hidden, and false otherwise
    }
}