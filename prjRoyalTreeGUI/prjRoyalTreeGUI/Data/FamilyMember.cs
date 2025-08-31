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
        public List<FamilyMember<T>> Children { get; set; } //represents who belongs to current node
    }
}
