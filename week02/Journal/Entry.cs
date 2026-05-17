public class Entry
{
    public string _date;
    public string _response;
    public string _prompt;
    public string _mood; //this is part of the excced requirements

    public Entry(string date, string prompt, string response, string mood)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }
    public void Display()
    {
        Console.WriteLine($"Date : {_date}");
        Console.WriteLine($"Mood : {_mood}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine("----------");
    }

    public string ToFileLine()
    {
        return $"{_date}|{_mood}|{_prompt}|{_response}";
    }

    // static help to set it:  https://www.geeksforgeeks.org/c-sharp/static-keyword-in-c-sharp/
    public static Entry FromFileLine(string line)
    {
        string[] parts = line.Split('|');

        string date = parts[0];
        string mood = parts[1].Replace("~|~", "|");
        string prompt = parts[2].Replace("~|~", "|");
        string response = parts[3].Replace("~|~", "|");
        return new Entry(date, prompt, response, mood);
    }
}