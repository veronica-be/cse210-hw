public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int top_number)
    {
        _numerator = top_number;
        _denominator = 1;
    }

    public Fraction(int top_number, int bottom_number)
    {
        _numerator = top_number;
        _denominator = bottom_number;
    }

    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)_numerator / (double)_denominator;
    }
}