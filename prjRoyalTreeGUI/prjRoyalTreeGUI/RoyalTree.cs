using prjRoyalTreeGUI.Data;

namespace prjRoyalTreeGUI
{
    public partial class RoyalTree : Form
    {
        public RoyalTree()
        {
            InitializeComponent();
            this.Load += RoyalTree_Load;
        }

        private FamilyTree<string> royalFamily;

        private void RoyalTree_Load(object sender, EventArgs e)
        {
            //1. variable to create the royal tree
            royalFamily = new FamilyTree<string>();

            //2. setting up the root of the tree
            var charles = new FamilyMember<string> { name = "King Charles III", birthday = "14/11/1948", alive = true };
            royalFamily.Root = charles;

            //3. setting up the first row of children (king charles' children)
            var william = new FamilyMember<string> { name = "Prince William", birthday = "06/21/1982", alive = true, Parent = charles };
            var harry = new FamilyMember<string> { name = "Duke Harry", birthday = "09-15/1984", alive = true, Parent = charles };
            charles.Children.AddRange(new[] { william, harry });

            //4. setting up the second row of childrem to their parents
            var george = new FamilyMember<string> { name = "Prince George", birthday = "07/22/2013", alive = true, Parent = william };
            var charlotte = new FamilyMember<string> { name = "Princess Charlotte", birthday = "05/02/2015", alive = true, Parent = william }; 
            var louis = new FamilyMember<string> { name = "Prince Louis", birthday = "04/23/2018", alive = true, Parent = william };
            william.Children.AddRange(new[] {george, charlotte, louis });

            var archie = new FamilyMember<string> { name = "Prince Archie", birthday = "06/05/2019", alive = true, Parent = harry };
            var lilibet = new FamilyMember<string> { name = "Princess Lilibet", birthday = "04/06/2021", alive = true, Parent = harry };

            harry.Children.AddRange(new[] {archie, lilibet});

            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (royalFamily?.Root != null)
            {
                drawTree(e.Graphics, royalFamily.Root, 20, 100, this.ClientSize.Width / 2);
            }
        }

        private void drawTree(Graphics g, FamilyMember<string> node, int y, int verticalSpacing, int x)
        {
            if (node == null)
            {
                return;
            }

            //visual displays of each node
            int boxWidth = 160;
            int boxHeight = 70;
            Font font = this.Font;
            Brush brush = Brushes.White;
            Pen pen = Pens.Black;

            //draw the node on the UI
            Rectangle rect = new Rectangle(x - boxWidth / 2, y, boxWidth, boxHeight);
            Brush fillBrush = node.alive ? Brushes.LightGreen : Brushes.LightGray;
            g.FillRectangle(fillBrush, rect);
            g.DrawRectangle(pen, rect);

            //add memebr details inside the box
            StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            string displayText = $"{node.name}\n{node.birthday}\n{(node.alive ? "Alive" : "Deceased")}";
            g.DrawString(displayText, font, Brushes.Black, rect, format);


            //if there are children, divide them horizontally
            if (node.Children != null && node.Children.Count > 0)
            {
                int hSpacing = 40;
                int totalWidth = spacingHelper(node, boxWidth, hSpacing) - hSpacing;

                int startX = x - totalWidth / 2;

                foreach (var child in node.Children)
                {
                    int childWidth = spacingHelper(child, boxWidth, hSpacing);
                    int childX = startX + childWidth / 2;

                    //draw line from parent to child
                    g.DrawLine(pen, x, y + boxHeight, childX, y + verticalSpacing);

                    //recurse
                    drawTree(g, child, y + verticalSpacing, verticalSpacing, childX);

                    startX += childWidth + hSpacing;
                }
            }
        }

        private int spacingHelper(FamilyMember<string> node, int boxWidth, int hSpacing)
        {
            if (node.Children == null || node.Children.Count == 0)
                return boxWidth;

            int totalWidth = 0;
            foreach (var child in node.Children)
            {
                totalWidth += spacingHelper(child, boxWidth, hSpacing);
            }

            return totalWidth + (node.Children.Count - 1) * hSpacing;
        }
    }
}
