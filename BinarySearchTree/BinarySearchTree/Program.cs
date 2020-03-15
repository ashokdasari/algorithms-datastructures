using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {

            var tree = new BinarySearchTree<string>();
            string input = string.Empty;
            while(!input.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.Write(">");
                input = Console.ReadLine();
                var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(var word in words)
                {
                    tree.Add(word);
                }
                Console.WriteLine("{0} words", tree.Count);
                foreach(var word in tree)
                {
                    Console.Write("{0} ", word);
                }
                Console.WriteLine();
                tree.Clear();
            }
        }
    }
}
