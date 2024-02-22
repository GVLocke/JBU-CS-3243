namespace InvertedFileAlgorithm;

public class DocumentDictionary
{
    private readonly Dictionary<string, LinkedList<int>> _dictionary = new();

    public DocumentDictionary(string path)
    {
        var reader = new StreamReader(path);
        var wordCount = 0;
        using (reader)
        {
            while (reader.ReadLine() is { } line)
            {
                var wordsArray = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < wordsArray.Length; i++)
                {
                    if (wordsArray[i].Length >= 3)
                    {
                        Add(wordsArray[i], i + wordCount);
                    }
                }
                wordCount += wordsArray.Length;
            }
        }
    }

    private void Add(string word, int index)
    {
        if (_dictionary.TryGetValue(word, out var value))
        {
            value.AddLast(index);
        }
        else
        {
            _dictionary[word] = [];
            _dictionary[word].AddLast(index);
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