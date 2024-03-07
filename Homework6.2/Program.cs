using System.Text;

namespace Homework6._2;

public static class Program
{
    private const int ColumnWidth = 2;
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var tree2 = new BinarySearchTree<int>();
        // make a simple modification to the Jamro BinarySearchTree.Add()
        // function that also returns a reference to the BinaryTreeNode
        // (of course you could also use the value itself, and search for
        // it instead of retaining a reference... that's a slower approach)
        var n90 = tree2.AddAndReturnReference(90);
        var n100 = tree2.AddAndReturnReference(100);
        var n110 = tree2.AddAndReturnReference(110);
        var n80 = tree2.AddAndReturnReference(80);
        tree2.Add(1290);
        tree2.Add(1);
        tree2.Add(234);
        tree2.Add(34);
        var n120 = tree2.AddAndReturnReference(120);
        var n105 = tree2.AddAndReturnReference(105);
        var n95 = tree2.AddAndReturnReference(95);
        var n93 = tree2.AddAndReturnReference(93);
        VisualizeTree(tree2, "tree2");
        Console.WriteLine(FindLCA(n120, n95).Data);
        Console.WriteLine(FindLCA(n80, n120).Data);
        Console.WriteLine(FindLCA(n93, n100).Data);
        Console.WriteLine(FindLCA(n120, n105).Data);
    }

    private static BinaryTreeNode<int> FindLCA(BinaryTreeNode<int> p, BinaryTreeNode<int> q)
    {
        var ancestors = new HashSet<BinaryTreeNode<int>>();
        while (p != null)
        {
            ancestors.Add(p);
            p = p.Parent;
        }

        while (q != null)
        {
          if (ancestors.Contains(q))
          {
            break;
          }
          q = q.Parent;
        }
        return q;
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
