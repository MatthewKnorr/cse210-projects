using System;

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