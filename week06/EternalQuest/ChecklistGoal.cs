public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int point, int target, int bonus) : base(name, description, point)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        _amountCompleted += 1;
    }

    public override int GetPoints()
    {
        if (_amountCompleted == _target)
        {
            return base.GetPoints() + _bonus;
        }
        else
        {
            return base.GetPoints();
        }
    }

    public override bool IsComplete()
    {
        if (_amountCompleted < _target)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public override string GetDetailsString() // for user
    {
        string nameAndDescription = base.GetDetailsString();
        return $"{nameAndDescription} -- Currently completed: {_amountCompleted} / {_target}";
    }

    public override string GetStringRepresentation() // for txt file
    {
        //type/name/description/completed/target/bonus/points
        return "ChecklistGoal--|--" + base.GetStringRepresentation() + $"--|--{_amountCompleted}--|--{_target}--|--{_bonus}";
    }

}