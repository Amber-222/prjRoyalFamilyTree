using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjRoyalTreeGUI.Data
{
    public class FamilyMember<T>
    {
        public string name { get; set; }
        public string birthday { get; set; }
        public bool alive { get; set; }
        public FamilyMember<T> Parent { get; set; } //represents where on tree the node belongs
        public List<FamilyMember<T>> Children { get; set; } = new List<FamilyMember<T>>(); //represents who belongs to current node
        public int searchOrder { get; set; } = -1; //stores order of BFS and DFS searches
    }
}
