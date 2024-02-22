namespace InvertedFileAlgorithm;

public static class App
{
    public static void Main(string[] args)
    {
        const string inPath = "/Users/Keys/Desktop/words.txt";
        const string outPath = "/Users/Keys/Desktop/out.txt";
        var dd = new DocumentDictionary(inPath);
        dd.WriteOutputFile(outPath);

        using var reader = new StreamReader(outPath);
        while (reader.ReadLine() is { } line)
        {
            Console.WriteLine(line);
        }
    }
}