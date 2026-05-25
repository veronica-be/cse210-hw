using System.Text.RegularExpressions;

public class ReadCSV
{
    private string _path;
    private List<List<string>> _linesList = new List<List<string>>();

    public ReadCSV(string path)
    {
        _path = path;
    }

    public List<List<string>> GetAllLines(int linesToPass = 0)
    { //learned from: https://youtu.be/mOEAoZFVknA?si=jDtfVC4BmJOaO7FG

        using (var reader = new StreamReader(_path))
        {
            for (int i = 0; i < linesToPass; i++)
            {
                if (!reader.EndOfStream)
                {
                    reader.ReadLine();
                }
            }

            while (reader.EndOfStream == false)
            {
                var content = reader.ReadLine();
                if (content == null) continue;
                var line = Regex.Split(content, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)").Select(x => x.Trim('"')).ToList();
                if (RowHasData(line))
                {
                    _linesList.Add(line);
                }
            }
        }
        return _linesList;
    }

    public List<List<string>> GetAllLines(List<int> indexesToSave, int linesToPass = 0) //Selecting by Indexes
    { //learned from: https://youtu.be/mOEAoZFVknA?si=jDtfVC4BmJOaO7FG
      //This is to only save the indexes we are really interested.

        using (var reader = new StreamReader(_path))
        {
            for (int i = 0; i < linesToPass; i++)
            {
                if (!reader.EndOfStream)
                {
                    reader.ReadLine();
                }
            }

            indexesToSave.Sort();


            while (reader.EndOfStream == false)
            {
                var content = reader.ReadLine();
                if (content == null) continue;
                var line = Regex.Split(content, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)").Select(x => x.Trim('"')).ToList();
                List<string> filteredLine = new List<string>();
                int index = 0;

                foreach (var item in line) // data of csv
                {

                    if (indexesToSave.Contains(index))
                    {
                        filteredLine.Add(item);
                    }
                    index++;
                }

                if (RowHasData(line))
                {
                    _linesList.Add(filteredLine);
                }
            }
        }
        return _linesList;
    }

    private bool RowHasData(List<string> data)
    {
        return data.Any(x => x.Length > 0);
    }

    public List<List<string>> GetFilterListByValue(int index, string valueToFind)
    {
        List<List<string>> listFilteredByValue = new List<List<string>>();

        foreach (var list in _linesList)
        {
            string realValue = list[index];
            if (realValue == valueToFind)
            {
                listFilteredByValue.Add(list);
            }
        }
        return listFilteredByValue;
    }
}