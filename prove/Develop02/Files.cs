using System.IO;
public class Files
{   
    // Sets up objects
    public List<Entry> _addEntry = new List<Entry>();
    public List<Entry> _loadedEntry = new List<Entry>();
    public string _saveFileName;


    // Loops through _addEntry and displays each entry
    public void ShowAllEntries()
    {   
        foreach (Entry i in _addEntry)
        {
            i.Display();
        }
    }

    // Loops through _loadedEntry and displays each loaded entry
    public void ShowAllLoadedEntries()
    {   
        foreach (Entry i in _loadedEntry)
        {
            i.Display();
        }   
    }

    // Displays local file names 
    public void LoadFileName(){
        string[] lines = System.IO.File.ReadAllLines("filenames.txt");
        Console.WriteLine("Select one of the Available Files");
        foreach(string line in lines){
            Console.WriteLine($"{line}");
        }
    }

    // Handles the loaded file and data within
    public void LoadFile(string selection)
    {
        string[] loadedEntries = System.IO.File.ReadAllLines(selection);
        foreach (string line in loadedEntries)
        {
            string[] parts =line.Split(",");
            string simple = "";
            Entry loadedEntry = new Entry(simple);
            loadedEntry._date = parts[0];
            loadedEntry._prompt = parts[1];
            loadedEntry._entryText = parts[2];
            _loadedEntry.Add(loadedEntry);
        }
    }
    
    // Checks to see if it can write to the file and _saveFileName saves it to file
    public void WriteEntries(){
        bool filesExists = false;
        string fileName = _saveFileName;

        string[] lines = System.IO.File.ReadAllLines("filenames.txt");
        string[] savedEntries = System.IO.File.ReadAllLines(_saveFileName);
        foreach (string line in lines)
        {
            if (line == _saveFileName)
            {
                filesExists = true;
                break;
            }
        }
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (string i in savedEntries)
            {
                outputFile.WriteLine($"{i}");
            }
            
            foreach (Entry i in _addEntry)
            {
                outputFile.WriteLine($"{i._date}, {i._prompt}, {i._entryText}");
            }
        }
        
        // File existance check
        if (!filesExists)
        {
            using (StreamWriter outputFile = new StreamWriter("filenames.txt"))
            {
                foreach (string line in lines)
                {
                    outputFile.WriteLine($"{line}");
                }
                outputFile.WriteLine($"{_saveFileName}");
            }
        }

        _addEntry.Clear();
    }       
}

