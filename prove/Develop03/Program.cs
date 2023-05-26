using System;

public class Program
{
    static void Main()
    {
        // Declares & initializes two arrays: verseReferences and verseTexts containing references and texts of different verses
        string[] verseReferences = new string[]
        {
            "John 3:16",
            "Matthew 5:16",
            "Psalm 23:1"
        };

        string[] verseTexts = new string[]
        {
            "For God so loved the world that He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life.",
            "Let your light so shine before men, that they may see your good works and glorify your Father in heaven.",
            "The Lord is my shepherd; I shall not want."
        };
    
        // This initializes the scripture object by creating a instance of Scripture passing verseRefr and verseTxt to constructer as arrgs.
        Scripture scripture = new Scripture(verseReferences, verseTexts);
        // The value of how many words are hidden each action
        int wordsToHide = 2;


        // Enters while loop continuing until all words in verse are hidden
        // Checks loop condition by ussing ALlWordsHidden method of the Scripture Obj
        while (!scripture.AllWordsHidden())
        {
            // Displays the scripture verse
            scripture.Display();
            // Promtpts user to enter or type quit
            Console.WriteLine("Press enter to continue or type 'quit' to exit.");
            // Stores it input variable
            string input = Console.ReadLine();

            // Case insentive check to break loop
            if (input.ToLower() == "quit")
            {
                break;
            }
            // If action = enter run below line
            scripture.HideRandomWords(wordsToHide);
        }
    }
}