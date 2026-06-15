public abstract class Activity
{
    private string _date;
    protected double _minutes;
    private string _nameOfActivity;

    public Activity(double minutes, string nameOfActivity)
    {
        _minutes = minutes;
        _nameOfActivity = nameOfActivity;

        DateTime currentDate = DateTime.Now;
        _date = currentDate.ToString("dd MMM yyyy");
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{_date} {_nameOfActivity} ({_minutes} min)- Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}