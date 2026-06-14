public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string name, string description, int point) : base(name, description, point)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        //type/name/description/completed?/points
        return "SimpleGoal--|--" + base.GetStringRepresentation() + $"--|--{_isComplete}";
    }
}