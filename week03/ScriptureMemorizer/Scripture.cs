public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference)
    {
        _reference = reference;
        string text = _reference.GetDisplayText();

        List<string> listOfStrings = text.Trim('\n').Split(' ').ToList();

        foreach (var word in listOfStrings)
        {
            Word wordObject = new Word(word);
            _words.Add(wordObject);
        }
    }

    public Scripture(string text) //if the user decides to put the input by hand
    {
        List<string> listOfStrings = text.Trim('\n').Split(' ').ToList();

        foreach (var word in listOfStrings)
        {
            Word wordObject = new Word(word);
            _words.Add(wordObject);
        }
    }
    public void HideRandomWords(int numberToHide)
    {//Ask : https://www.geeksforgeeks.org/c-sharp/c-sharp-count-the-total-number-of-elements-in-the-list/

        Random random = new Random();

        List<int> visibleIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (_words[i].IsHidden() == false)
            {
                visibleIndices.Add(i);
            }
        }

        if (visibleIndices.Count < numberToHide)
        {
            numberToHide = visibleIndices.Count;
        }

        int wordsHiddenTotal = 0;

        while (wordsHiddenTotal < numberToHide)
        {
            int randomPosition = random.Next(0, visibleIndices.Count);
            int actualWordIndex = visibleIndices[randomPosition];

            _words[actualWordIndex].Hide();
            wordsHiddenTotal++;

            visibleIndices.RemoveAt(randomPosition);
        }
    }




    public string GetDisplayText()
    {
        List<string> displayText = new List<string>();

        foreach (var word in _words)
        {
            displayText.Add(word.GetDisplayText());
        }

        return string.Join(" ", displayText);
    }

    public bool IsCompletelyHidden()
    {
        int counterOfHiddenWords = 0;

        foreach (var word in _words)
        {
            if (word.IsHidden() == true)
            {
                counterOfHiddenWords++;
            }
        }
        if (_words.Count() == counterOfHiddenWords)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}