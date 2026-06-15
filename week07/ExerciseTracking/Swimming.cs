public class Swimming : Activity
{
    private double _numberOfLaps;

    public Swimming(double numberOfLaps, double minutes) : base(minutes, "Swimming")
    {
        _numberOfLaps = numberOfLaps;
    }

    public override double GetDistance()
    {
        return _numberOfLaps * 50 / 1000;
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