public class Running : Activity
{
    private double _distance;

    public Running(double distance, double minutes) : base(minutes, "Running")
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return 60 / GetPace();
    }

    public override double GetPace()
    {
        return _minutes / GetDistance();
    }
}