namespace HopSkipJump;

public class App
{
    // private static readonly int ArraySize = 5;

    public static void Main()
    {
        // int[] game = new int[ArraySize];
        // Random random = new Random();
        // for (int i = 0; i < ArraySize; i++)
        // {
        //     game[i] = random.Next() % 150;
        // }

        //print array
        // foreach (var item in game)
        // {
        //     Console.Write(item + " ");
        // }
        int[] game = new int[] {0, 23, 25, 63, 23, 24, 64, 51, 52, 59, 58, 38, 39, 41, 24, 25, 43, 50, 52, 54, 53, 55};

        Console.WriteLine();
        Console.WriteLine(Hsj(game, game[0]));
    }

    private static int Hsj(int[] array, int count = 0, int index = 0)
    {
        Console.WriteLine($"Current index: {index}, Value: {array[index]}"); // Debug statement

        if ((index + 1) == array.Length)
        {
            return count;
        }

        if ((index + 1) + 1 == array.Length)
        {
            return count + array[index + 1];
        }

        int costFromA = Hsj(array, count + array[index + 1], index + 1);
        int costFromB = Hsj(array, count + array[index + 2], index + 2);
        return costFromA > costFromB ? costFromB : costFromA;
    }
}