namespace HopSkipJump;

public class App
{
  private static readonly int ArraySize = 100;

  public static void Main()
  {
    int[] game = new int[ArraySize];
    Random random = new Random();
    for (int i = 0; i < ArraySize; i++)
    {
      game[i] = random.Next() % 14;
    }

    //print array
    foreach (var item in game)
    {
      Console.Write(item + " ");
    }

    Console.WriteLine();
    int[] memo = new int[game.Length];
    List<int> path = new List<int>();
    Console.WriteLine($"Best path through the array costs: {Hsj(game, memo)}");
  }

  private static int Hsj(int[] array, int[] memo, int cost = 0, int index = 0)
  {
    if ((index + 1) == array.Length)
    {
      return cost + array[index];
    }
    if (memo[index] != 0)
    {
      return cost + memo[index];
    }
    if ((index + 1) + 1 == array.Length)
    {
      return cost + array[index] + array[index + 1];
    }
    int costFromA = Hsj(array, memo, cost, index + 1);
    memo[index + 1] = costFromA;
    int costFromB = Hsj(array, memo, cost, index + 2);
    memo[index + 2] = costFromB;
    return costFromA > costFromB ? array[index] + costFromB : array[index] + costFromA;
  }
}
