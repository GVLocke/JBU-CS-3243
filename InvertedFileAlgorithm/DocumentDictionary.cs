namespace InvertedFileAlgorithm;

public class DocumentDictionary
{
    private Dictionary<string, LinkedList<int>> _dictionary = new();

    public DocumentDictionary(string path)
    {
        var reader = new StreamReader(path);
        string?[] wordsArray;
        using (reader)
        {
            if (reader.Peek() >= 0)
            {
                var line = reader.ReadLine();
                wordsArray = line?.Split(" ") ?? Array.Empty<string>();
            }
            else
            {
                throw new Exception("File is empty!");
            }
        }
        for (var i = 0; i < wordsArray.Length; i++)
        {
            if (_dictionary.TryGetValue(wordsArray[i], out LinkedList<int>? value))
            {
                value.AddLast(i);
            }
            else
            {
                _dictionary[wordsArray[i]] = new LinkedList<int>();
                _dictionary[wordsArray[i]].AddLast(i);
            }
        }
    }

    public void WriteOutputFile(string path)
    {
        var writer = new StreamWriter(path);
        using (writer)
        {
            var sortedKeys = _dictionary.Keys.ToList();
            sortedKeys.Sort();
            foreach (var key in sortedKeys)
            {
                writer.WriteLine($"{key} {WordIndices(key)}");
            }
        }
    }

    private string WordIndices(string key)
    {
        var returnString = "";
        foreach (var index in _dictionary[key])
        {
            returnString += index + " ";
        }
        return returnString;
    }
}