using System.IO;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet here.");
            return;
        }

        Console.WriteLine();
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string _file)
    {
        using (StreamWriter outputFile = new StreamWriter(_file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileLine());
            }
        }
    }

    public void LoadFromFile(string _file)
    {

        if (!File.Exists(_file)) // help https://www.geeksforgeeks.org/c-sharp/file-exists-method-in-c-sharp-with-examples/
        {
            Console.WriteLine($"File '{_file}' has not been found.");
            return;
        }

        _entries.Clear();

        string[] lines = System.IO.File.ReadAllLines(_file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string date = parts[0];
            string mood = parts[1];
            string prompt = parts[2];
            string response = parts[3];

            Entry entry = new Entry(date, prompt, response, mood);
            _entries.Add(entry);
        }
        Console.WriteLine($"Journal has been loaded from '{_file}'.");
    }

}