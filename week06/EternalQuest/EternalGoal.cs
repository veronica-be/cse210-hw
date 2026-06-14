public class EternalGoal : Goal
{
    private int _timesDone;
    
    public EternalGoal(string name, string description, int point) : base(name, description, point)
    { }

    public override void RecordEvent()
    {
        _timesDone++;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        if (_timesDone > 0)
        {
            string nameAndDescription = base.GetDetailsString();
            return $"{nameAndDescription} -- times achived: {_timesDone} Keep going!";
        }
        else
        {
            string nameAndDescription = base.GetDetailsString();
            return $"{nameAndDescription}";
        }
    }

    public override string GetStringRepresentation()
    {
        //type/name/description/points
        return "EternalGoal--|--" + base.GetStringRepresentation() + $"--|--{_timesDone}";
    }
}