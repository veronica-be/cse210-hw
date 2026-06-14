public class IntTryLoop
{
    private string _question;
    private int _response;
    private string _exceptionString;
    private List<int> _listOptions;
    private string _conditionExceptionString;

    public IntTryLoop(string question, string exceptionString = "Sorry incorrect input it must be a whole number. Please try again.")
    {
        _question = question;
        _exceptionString = exceptionString;
    }

    public IntTryLoop(string question, List<int> listOptions, string conditionExceptionString, string exceptionString = "Sorry incorrect input it must be a whole number. Please try again.")
    {
        _question = question;
        _exceptionString = exceptionString;
        _listOptions = listOptions;
        _conditionExceptionString = conditionExceptionString;
    }

    public void Start()
    {
        while (true)
        {
            try
            {
                Console.Write(_question.Trim() + " ");
                _response = int.Parse(Console.ReadLine().Trim());

                if (_listOptions == null)
                {
                    break;
                }
                else
                {
                    if (_listOptions.Any())
                    {
                        if (_listOptions.Contains(_response))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine(_conditionExceptionString);
                        }
                    }
                    else
                    {
                        break;
                    }
                }

            }
            catch (System.Exception)
            {
                Console.WriteLine(_exceptionString);
            }
        }
    }

    public int GetIntResponse()
    {
        return _response;
    }

}