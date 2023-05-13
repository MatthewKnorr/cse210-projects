using System;

class Program
{
    static void Main(string[] args)
    {
        string[] menu = {"Wrte New Entry","Display Unsaved Entries","Display Loaded Entries","Save Entries","Quit Program"};
        Console.WriteLine("Welcome TO The Program");
        bool runApp = true;
        Files listFiles = new Files();

        while(runApp)
        {
            Console.WriteLine("\nPlease Select One of the Following");
            int x = 1;
            foreach(string option in menu)
            {
                    Console.WriteLine($"{x}. {option}");
                    x++;
            }
            Console.Write("Your Selection? ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Entry newEntry = new Entry();
                    // Console.Write(newEntry._prompt);
                    // newEntry._entryText = Console.ReadLine();
                    listFiles._addEntry.Add(newEntry);
                    break;
                case 2:
                    listFiles.ShowEntries();
                    break;
                case 3:
                    listFiles.LoadFileNames();
                    Console.WriteLine("Please type the name of the file to load: ");
                    string selection = Console.ReadLine();
                    listFiles.LoadFile(selection);
                    break;

                    // string[] loadedEntries = System.IO.File.ReadAllLines(selection);

                    // foreach (string line in loadedEntries)
                    // {
                    //     string[] parts = line.Split(",");
                    //     Entry loadedEntry = new Entry();
                    //     loadedEntry._date = parts[0];
                    //     loadedEntry._prompt = parts[1];
                    //     loadedEntry._entryText = parts[2];
                    //     listFiles._loadedEntry.Add(loadedEntry);
                    // }
                    // break;
                case 4:
                    listFiles.ShowLoadedEntries();
                    break;
                case 5:
                    Console.WriteLine("Use one of the following existing files or type the name for the a new file");
                    listFiles.LoadFileNames();
                    listFiles._saveFileName = Console.ReadLine();
                    listFiles.WriteEntries();
                    break;
                case 6:
                    runApp = false;
                    break;
                
                default:
                Console.Write($"{choice} is not a valid entry.");
                continue;
                
        }
        }
    }
} 