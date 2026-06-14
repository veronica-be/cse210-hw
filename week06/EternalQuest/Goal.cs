public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString() // for showing to user
    {
        return $"{_shortName} ({_description})";
    }

    public virtual string GetStringRepresentation() // for saving to txt file
    {
        return $"{_shortName.Trim()}--|--{_description.Trim()}--|--{_points}";
    }

    public virtual int GetPoints()
    {
        return _points;
    }

    public string GetName()
    {
        return _shortName;
    }
}