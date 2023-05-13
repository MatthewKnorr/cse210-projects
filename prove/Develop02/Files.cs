using System.IO;
public class Files
{
    public List<Entry> _addEntry = new List<Entry>();
    public List<Entry> _loadedEntry = new List<Entry>();
    public string _saveFileName;

    public void ShowEntries()
    {   
        foreach (Entry i in _addEntry)
        {
            i.Display();
        }
    }

    public void ShowLoadedEntries()
    {   
        foreach (Entry i in _loadedEntry)
        {
            i.Display();
        }
    }

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
    
    public void LoadFileNames(){
        string[] lines = System.IO.File.ReadAllLines("filenames.txt");
        Console.WriteLine("Available Files");
        foreach(string line in lines){
            Console.WriteLine($"{line}");
        }
    }

    public void WriteEntries(){
        bool filesExists = false;
        string fileName = _saveFileName;

        string[] lines = System.IO.File.ReadAllLines("filenames.txt");
        foreach (string line in lines)
        {
            if (line == _saveFileName)
            {
                filesExists = true;
                break;
            }
        }

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
        
        string[] savedEntries = System.IO.File.ReadAllLines(_saveFileName);
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
        _addEntry.Clear();
    }       
}