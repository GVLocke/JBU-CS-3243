List<String> inputs = new List<string>();
string? line;
Console.WriteLine("Enter lines of text (type 'END' to finish): ");

while ((line = Console.ReadLine()) != "END")
{
    if (line != null) {
        inputs.Add(line);
    } 
}
Console.WriteLine("Here's your input backwards");
for (int i = inputs.Count - 1; i >= 0; i--) {
    Console.WriteLine(inputs[i]);
}