using System;
public class Program
{
    static void Main() // Declares & initializes two arrays:
    {
        string[] verseReferences = new string[] // verseReferences containing verse references
        {
            "John 3:16",
            "Matthew 5:16",
            "Psalm 23:1"
        };

        string[] verseTexts = new string[] // verseTexts containing texts verses
        {
            "For God so loved the world that He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life.",
            "Let your light so shine before men, that they may see your good works and glorify your Father in heaven.",
            "The Lord is my shepherd; I shall not want."
        };

        Scripture scripture = new Scripture(verseReferences, verseTexts); // Initializes scripture obj  passing verseRefr and verseTxt to constructer as arrgs
        int wordsToHide = 2; // The value of how many words are hidden each action

        // Scripture Obj loop condtion check by using AllWordsHidden until all are hidden
        while (!scripture.AllWordsHidden()) // Loop continuing until all words in verse are hidden
        {
            scripture.Display(); // Displays the scripture verse
            Console.WriteLine("Press enter to continue or type 'quit' to exit."); // Promtpts user to enter or type quit
            string input = Console.ReadLine(); // Stores it in input variable

            if (input.ToLower() == "quit") // Case insentive check to break loop
            {
                break;
            }
            
            scripture.HideRandomWords(wordsToHide); // If action = enter run below line
        }
    }
}