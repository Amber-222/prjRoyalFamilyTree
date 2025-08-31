using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public List<FamilyMember<T>> BreadthFirstSearch(string name)
        {
            if (Root == null)
            {
                return new List<FamilyMember<T>>();
            }

            var visited = new List<FamilyMember<T>>(); //stores which nodes have been looked at 
            var queue = new Queue<FamilyMember<T>>(); //use a queue for bfs
            queue.Enqueue(Root);
            int order = 1;

            while (queue.Count > 0)
            {
                FamilyMember<T> currentNode = queue.Dequeue(); //get next node in the queue
                visited.Add(currentNode); //visit it, store that its been looked at
                currentNode.searchOrder = order++;

                //break the search once the name is found and show search order
                if (currentNode.name.Equals(name, StringComparison.OrdinalIgnoreCase))
                { 
                    break;
                }

                //add all its children at the back of the queue
                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return visited;
        }

        //DEPTH FIRST SEARCH
        public List<FamilyMember<T>> DepthFirstSearch(string name)
        {
            if (Root == null)
            {
                return new List<FamilyMember<T>>();
            }

            var visited = new List<FamilyMember<T>>();
            int order = 1;
            dfsHelper(name, Root, visited, order); //start recursive search from root node
            return visited;
        }

        //dfs helper method
        private void dfsHelper(string name, FamilyMember<T> node, List<FamilyMember<T>> visited, int order)
        {
            if (node == null) return;

            visited.Add(node); //viist current node
            node.searchOrder = order++;

            if (node.name.Equals(name, StringComparison.OrdinalIgnoreCase))
                return;
            //recursively visit each child to delve deeper into the tree
            foreach (var child in node.Children)
            {
                if (!visited.Contains(child))
                {
                    dfsHelper(name, child, visited, order++);
                }
            }
        }
    }
}
