using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace userinfo
{
    public partial class Form4 : Form
    {
        Bitmap myBitmap;
        Graphics g;
        public Form4()
        {
            InitializeComponent();
             myBitmap = new Bitmap(640, 480);
             g = Graphics.FromImage(myBitmap);
            Pen p = new Pen(Color.Red, 2);
            g.DrawLine(p, 0, 0, 640, 480);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics windowG = e.Graphics;
            windowG.DrawImageUnscaled(myBitmap, 0, 0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myBitmap.Save("d:\\image1.jpg",ImageFormat.Jpeg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = new Bitmap("d:\\image1.jpg");
        }
    }
}
