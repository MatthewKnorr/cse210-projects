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
        // Runs app until chosen to quit
        while(runAppCheck)
        {
            // Displays option list with a incrementor 
            int x = 0;
            Console.WriteLine("\nPlease select of one of the following options:");
            foreach(string item in optionList)
            {
                x++;
                Console.WriteLine($"{x}. {item}");
            }
            // Stores users repsonse
            Console.Write("\nWhat is your selected option? ");
            int usersChoice = int.Parse(Console.ReadLine());
            switch (usersChoice)
            {
                // Write a entry to save
                case 1:
                    Entry newEntry = new Entry();
                    listLocalFiles._addEntry.Add(newEntry);
                    break;
                
                // List unsaved/recent entries
                case 2:
                    listLocalFiles.ShowAllEntries();
                    break;
                
                // Load a specifc file to display and write to
                case 3:
                    listLocalFiles.LoadFileName();
                    Console.WriteLine("Please type the name of the file to load: ");
                    string selection = Console.ReadLine();
                    listLocalFiles.LoadFile(selection);
                    break;

                // Display entries loaded from the file
                case 4:
                    listLocalFiles.ShowAllLoadedEntries();
                    break;
                
                // Save all entries made to selected file
                case 5:
                    Console.WriteLine("Use one of the following existing files or type the name for the a new file");
                    listLocalFiles.LoadFileName();
                    listLocalFiles._saveFileName = Console.ReadLine();
                    listLocalFiles.WriteEntries();
                    break;
                
                // Ends While Loop
                case 6:
                    runAppCheck = false;
                    break;
                
                // Else: invalid choice contiues
                default:
                    Console.Write($"\nSorry {usersChoice} is not a valid entry. Please try again with a valid number.");
                    continue;
                
            }
        }
    }
} 

