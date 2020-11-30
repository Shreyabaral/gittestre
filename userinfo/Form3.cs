using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace userinfo
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Point pt1 = new Point(0, 0);
            Point pt2 = new Point(200, 200);
            Rectangle rct1 = new Rectangle(50, 80, 100, 130);
            Graphics g = e.Graphics;
            Pen myBlackPen = new Pen(Color.Black, 5);

            g.DrawLine(myBlackPen, pt1, pt2
                );
            g.DrawLine(myBlackPen, 0, 50, 200, 50);
            g.DrawEllipse(myBlackPen, 50, 50, 200, 100);

            g.DrawRectangle(myBlackPen, rct1
                );
            myBlackPen.Dispose();
        }
    }
}
