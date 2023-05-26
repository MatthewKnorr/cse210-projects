using System;
//  creates type-safe collections
using System.Collections.Generic;
// used to quiere and manipulate data
using System.Linq;


// Single word in scripture tracking if hidden
class Word
{ 
    // Defines properties Text and Hidden with specific modifers to access get/set behavior
    public string Text { get; private set; }
    public bool Hidden { get; private set; }

    // Sets defualt word
    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }
    // Sets Hidden word
    public void Hide()
    {
        Hidden = true;
    }

    // Sets revealed word
    public void Reveal()
    {
        Hidden = false;
    }
}

// Constructor holds the scripture reference value
class Reference
{
    // Getters and Setters 
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
        // create reference obj assinged to Reference
        Reference = new Reference(reference);
        // Split the tect into an array of words using ' '
        // Using LINQ select method to transform each word intto a new Word Obj by calling Word constructer for each word in the array
        words = text.Split(' ').Select(word => new Word(word)).ToList();
        random = new Random();
    }

    // Displays and updates the scripture
    public void Display()
    {
        // clear the screen for clean display 
        Console.Clear();
        Console.WriteLine($"{Reference.Value}\n");

        // Loops through to check if hidden or not if so it blanks the word if not it keeps it
        foreach (Word word in words)
        {
            Console.Write(word.Hidden ? "____ " : $"{word.Text} ");
        }
        
        Console.WriteLine("\n");
    }

    // Responsible for hiding a specified number of random words in the scripture
    public void HideRandomWords(int count)
    {
        // create list that filters out the words that are already hidden
        List<Word> visibleWords = words.Where(word => !word.Hidden).ToList();
        //  Determines the number of words to hide.
        int wordsToHide = Math.Min(count, visibleWords.Count);

        // Iterates through to hide
        for (int i = 0; i < wordsToHide; i++)
        {
            // Generates random index within the range of visiblewords
            int index = random.Next(visibleWords.Count);
            // Hides the word at the randomly generated index by calling the Hide method on the corresponding Word object
            visibleWords[index].Hide();
            // Removes the hidden word from the visibleWords list to ensure it won't be selected again in subsequent iterations
            visibleWords.RemoveAt(index);
        }
    }
    
    // Using .all from linq it monitors the status of all words in the scripture and determine when to stop hiding words
    public bool AllWordsHidden()
    {  
        // checks if hidden = true or false
        return words.All(word => word.Hidden);
    }
}


// Handles program execution, prompting user and controlling the flow by input, is user entry point
class Program
{
    static void Main()
    {
        // Creats a scripture object,This scripture object will be used to display and manipulate the scripture.
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life.");
        // Specifies the number of words to hide each time.
        int wordsToHide = 2;

        // Enters a loop that continues until all the words in the scripture are hidden. It checks the condition by calling the AllWordsHidden 
        while (!scripture.AllWordsHidden())
        {
            // Calls the Display method of the scripture object to show the current state of the scripture
            scripture.Display();
            //  Displays a message to prompt the user for input.
            Console.WriteLine("Press enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            // Checks if the user entered case insensitive. If true breaks the loop ending the program
            if (input.ToLower() == "quit")
            {
                break;
            }

            // Calls the HideRandomWords method of the scripture object to hide a specified number of random words.
            scripture.HideRandomWords(wordsToHide);
        }
    }
}