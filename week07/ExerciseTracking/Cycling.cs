public class Cycling : Activity
{
    private double _speed;

    public Cycling(double speed, double minutes) : base(minutes, "Cycling")
    {
        _speed = speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetDistance()
    {
        double x = _speed / 60;
        return x * _minutes;
    }
}