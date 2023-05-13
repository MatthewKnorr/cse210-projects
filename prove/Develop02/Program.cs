using System;

class Program
{
    static void Main(string[] args)
    {
        // Displays Greeting and List of options
        Console.WriteLine("\n\nWelcome new user to Journalling Pro+");     
        string[] optionList = {"Write a new entry","Display all unsaved entries","Load a files data","Display all loaded entries","Save written entries","Quit Journalling Pro+"};
        Files listLocalFiles = new Files();
        bool runAppCheck = true;

        while(runAppCheck)
        {
            int x = 0;
            Console.WriteLine("\nPlease select of one of the following options:");
            foreach(string item in optionList)
            {
                x++;
                Console.WriteLine($"{x}. {item}");
            }
            Console.Write("\nWhat is your selected option? ");
            int usersChoice = int.Parse(Console.ReadLine());
            switch (usersChoice)
            {
                case 1:
                    Entry newEntry = new Entry();
                    listLocalFiles._addEntry.Add(newEntry);
                    break;
                case 2:
                    // listLocalFiles.ShowAllEntries();
                    listLocalFiles.ShowEntries();
                    break;
                case 3:
                    listLocalFiles.LoadFileNames();
                    Console.WriteLine("Please type the name of the file to load: ");
                    string selection = Console.ReadLine();
                    listLocalFiles.LoadFile(selection);
                    break;
                case 4:
                    listLocalFiles.ShowLoadedEntries();
                    break;
                case 5:
                    Console.WriteLine("Use one of the following existing files or type the name for the a new file");
                    listLocalFiles.LoadFileNames();
                    listLocalFiles._saveFileName = Console.ReadLine();
                    listLocalFiles.WriteEntries();
                    break;
                case 6:
                    runAppCheck = false;
                    break;
                
                default:
                Console.Write($"\nSorry {usersChoice} is not a valid entry. Please try again with a valid number.");
                continue;
                
        }
        }
    }
} 

