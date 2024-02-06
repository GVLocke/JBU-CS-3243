namespace LinkedListRotate;

public class Book(string title, string author)
{
    private string Title { get; set; } = title;
    private string Author { get; set; } = author;
    public override string ToString()
    {
        return $"{title} by {author}";
    }
}