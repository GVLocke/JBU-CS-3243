namespace AVLTree
{
    internal static class App
    {
        public static void Main()
        {
            var avl = new AVLTree<int>();
            var keys = new List<int> { 50, 25, 75, 15, 35, 60, 120, 10, 68, 90, 125, 83, 100 };
            foreach (var variable in keys)
            {
                avl.Insert(variable);
            }
            
            avl.PrintTree();
        }
    }
}