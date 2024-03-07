using System.Text;

namespace Homework61
{
  public static class App
  {
    private const int ColumnWidth = 2;

    public static void Main(string[] args)
    {
      Console.OutputEncoding = Encoding.UTF8;
      var tree1 = new BinarySearchTree<int>();
      var tree2 = new BinarySearchTree<int>();

      tree1.Add(100);
      tree1.Add(90);
      tree1.Add(110);
      tree1.Add(80);
      tree1.Add(120);
      tree1.Add(105);
      tree1.Add(104);
      tree1.Add(95);
      tree1.Add(93);
      VisualizeTree(tree1, "Tree1");
      tree2.Add(101);
      tree2.Add(91);
      tree2.Add(111);
      tree2.Add(81);
      tree2.Add(121);
      tree2.Add(106);
      tree2.Add(107);
      tree2.Add(96);
      tree2.Add(97);
      VisualizeTree(tree2, "Tree2");
      System.Console.WriteLine(IsIsomorphic(tree1.Root, tree2.Root));
    }

    private static bool IsIsomorphic(BinaryTreeNode<int> a, BinaryTreeNode<int> b)
    {
      if (a == null && b == null) return true;
      if (a == null || b == null) return false;
      if (a.Left == null && b.Left == null) return true;
      return (IsIsomorphic(a.Left, b.Left) && IsIsomorphic(a.Right, b.Right) || IsIsomorphic(a.Left, b.Right) && IsIsomorphic(a.Right, b.Left));
    }



    private static void VisualizeTree(BinarySearchTree<int> tree, string caption)
    {
      Console.WriteLine(tree.Count);
      var console = InitializeVisualization(tree, out var width);
      VisualizeNode(tree.Root, 0, width / 2, console, width);
      Console.WriteLine(caption);
      foreach (var row in console)
      {
        Console.WriteLine(row);
      }
    }

    private static char[][] InitializeVisualization(BinarySearchTree<int> tree, out int width)
    {
      var height = tree.GetHeight();
      width = (int)Math.Pow(2, height) - 1;
      char[][] console = new char[height * 2][];
      for (var i = 0; i < height * 2; i++)
      {
        console[i] = new string(' ', ColumnWidth * width).ToCharArray();
      }
      return console;
    }

    private static void VisualizeNode(BinaryTreeNode<int> node, int row, int column, char[][] console, int width)
    {
      if (node == null) return;
      var chars = node.Data.ToString().ToCharArray();
      var margin = (ColumnWidth - chars.Length) / 2;
      for (var i = 0; i < chars.Length; i++)
      {
        console[row][ColumnWidth * column + i + margin] = chars[i];
      }

      var columnDelta = (width + 1) / (int)Math.Pow(2, node.GetHeight() + 1);
      VisualizeNode(node.Left, row + 2, column - columnDelta, console, width);
      VisualizeNode(node.Right, row + 2, column + columnDelta, console, width);
      if (node.Left != null) DrawLineLeft(node, row, column, console, columnDelta);
      if (node.Right != null) DrawLineRight(node, row, column, console, columnDelta);
    }

    private static void DrawLineRight(BinaryTreeNode<int> node, int row, int column, char[][] console, int columnDelta)
    {
      var startColumnIndex = ColumnWidth * column + 2;
      var endColumnIndex = ColumnWidth * (column + columnDelta) + 2;
      for (var x = startColumnIndex + 1; x < endColumnIndex; x++)
      {
        console[row + 1][x] = '-';
      }
      console[row + 1][startColumnIndex] = '+';
      console[row + 1][endColumnIndex] = '\u2510';
    }

    private static void DrawLineLeft(BinaryTreeNode<int> node, int row, int column, char[][] console, int columnDelta)
    {
      var startColumnIndex = ColumnWidth * (column - columnDelta) + 2;
      var endColumnIndex = ColumnWidth * column + 2;
      for (var x = startColumnIndex + 1; x < endColumnIndex; x++)
      {
        console[row + 1][x] = '-';
      }
      console[row + 1][startColumnIndex] = '\u250c';
      console[row + 1][endColumnIndex] = '+';
    }
  }
}
