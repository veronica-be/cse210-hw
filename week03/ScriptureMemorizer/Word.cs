public class Word
{
    private string _text;
    private bool _isHidden = false; // true: yes it is hidden  --- false: it is showing 

    private List<string> _hiddenTxt = new List<string>();
    public Word(string text)
    {
        _text = text;
        _hiddenTxt = new List<string>();
    }

    public void Hide()
    {
        if (_isHidden == false)
        {
            foreach (var character in _text)
            {
                _hiddenTxt.Add("_");

            }
        }
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (IsHidden() == true)
        {
            return string.Join("", _hiddenTxt);
        }
        else // if false (is showing)
        {
            return _text;
        }
    }
}