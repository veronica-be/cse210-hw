//this one accepts a list to find
public class Reference
{
    private string _book;
    private int _bookIndex;
    private int _chapter;
    private int _chapterIndex;
    private int _verseIndex;
    private int _verse;
    private int _endVerse;
    private List<int> _verses;
    private int _textOfVerseIndex;

    private string _scriptureCode;

    private List<List<string>> _listOfLists;

    public Reference(string book, int bookIndex, int chapter, int chapterIndex, int verseIndex, int verse, int textOfVerseIndex, List<List<string>> list)
    {
        _book = book.ToLower();
        _bookIndex = bookIndex;
        _chapter = chapter;
        _chapterIndex = chapterIndex;
        _verse = verse;
        _listOfLists = list;
        _verseIndex = verseIndex;
        _verses = new List<int>();
        _verses.Add(_verse);
        _textOfVerseIndex = textOfVerseIndex;
        _scriptureCode = $"{_book} {_chapter}:{_verse}";
    }
    public Reference(string book, int bookIndex, int chapter, int chapterIndex, int verseIndex, int verse, int endVerse, int textOfVerseIndex, List<List<string>> list)
    {
        _book = book.ToLower();
        _bookIndex = bookIndex;
        _chapter = chapter;
        _chapterIndex = chapterIndex;
        _verseIndex = verseIndex;
        _verse = verse;
        _endVerse = endVerse;
        _listOfLists = list;
        int count = _endVerse - _verse + 1;
        _verses = Enumerable.Range(_verse, count).ToList();
        _textOfVerseIndex = textOfVerseIndex;
        _scriptureCode = $"{_book} {_chapter}:{_verse} — {_endVerse}";

    }

    public string GetCodeOfReference()
    {
        return _scriptureCode;
    }
    public string GetDisplayText()
    {
        // the csv file I got it from: https://scriptures.nephi.org
        string scripture;
        List<List<string>> scriptureVerses = new List<List<string>>();


        foreach (var list in _listOfLists)
        {
            if (list[_bookIndex].ToLower() == _book && list[_chapterIndex] == $"{_chapter}" && int.TryParse(list[_verseIndex], out int currentVerseFromCsv) && _verses.Contains(currentVerseFromCsv))
            {
                scriptureVerses.Add(list);
            }
        }

        // learn from: https://learn.microsoft.com/es-es/dotnet/api/system.environment.newline?view=netframework-4.8.1&viewFallbackFrom=net-10.0
        List<string> stringVersesList = new List<string>();

        foreach (var list in scriptureVerses)
        {
            stringVersesList.Add(list[_textOfVerseIndex]);
        }

        scripture = string.Join(Environment.NewLine, stringVersesList);
        return scripture;
    }


}