public class TryParseInt
{
    // info get of: https://www-w3schools-com.translate.goog/cs/cs_exceptions.php?_x_tr_sl=en&_x_tr_tl=es&_x_tr_hl=es&_x_tr_pto=tc

    private bool _isInt = false;
    private string _value;
    private int _number;

    public TryParseInt(string value)
    {
        _value = value;
    }

    public bool TryParse()
    {
        try
        {
            _number = int.Parse(_value.Trim());
            _isInt = true;
            return _isInt;
        }
        catch (Exception)
        {
            _number = 0;
            _isInt = false;
            return _isInt;
        }
    }

    public int GetNumber()
    {
        return _number;
    }

}



