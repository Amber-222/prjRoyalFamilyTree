using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjRoyalTreeGUI.Data
{
    public class FamilyTree<T>
    {
        public FamilyMember<T> Root { get; set; }

        public void printTree(FamilyMember<T> node, string indent = "", bool last = true)
        {
            if (node == null)
            {
                return; //if no node is given
            }

            Console.WriteLine($"{indent}+-{node.name} ({node.birthday})");
            indent += last ? "  " : "| ";

            for (int i = 0; i < node.Children.Count; i++)
            {
                printTree(node.Children[i], indent, i == node.Children.Count - 1);
            }
        }

        //BREADTH FIRST SEARCH
        public List<string> BreadthFirstSearch()
        {
            if (Root == null)
            {
                return new List<string>();
            }

            var visited = new List<string>(); //stores which nodes have been looked at 
            var queue = new Queue<FamilyMember<T>>(); //use a queue for bfs
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                FamilyMember<T> currentNode = queue.Dequeue(); //get next node in the queue
                visited.Add(currentNode.name); //visit it, store that its been looked at

                //add all its children at the back of the queue
                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return visited;
        }

        //DEPTH FIRST SEARCH
        public List<string> DepthFirstSearch()
        {
            if (Root == null)
            {
                return new List<string>();
            }

            var visited = new List<string>();
            dfsHelper(Root, visited); //start recursive search from root node
            return visited;
        }

        //dfs helper method
        private void dfsHelper(FamilyMember<T> node, List<string> visited)
        {
            if (node == null) return;

            visited.Add(node.name); //viist current node

            //recursively visit each child to delve deeper into the tree
            foreach (var child in node.Children)
            {
                dfsHelper(child, visited);
            }
        }
    }
}
