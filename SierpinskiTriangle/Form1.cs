using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SierpinskiTriangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;
        Graphics grp;
        Queue<PointF> x = new Queue<PointF>();
        Queue<PointF> y = new Queue<PointF>();
        Queue<PointF> z = new Queue<PointF>();

        PointF p1 = new PointF(170, 20);
        PointF p2 = new PointF(20, 210);
        PointF p3 = new PointF(320, 210);

        float distance(PointF a, PointF b)
        {
            return (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }


        public void solve(PointF a, PointF b, PointF c)
        {
            x.Enqueue(a);
            y.Enqueue(b);
            z.Enqueue(c);

            while (x.Count != 0 && y.Count != 0 && z.Count != 0)
            {
                a = x.Dequeue();
                b = y.Dequeue();
                c = z.Dequeue();

                if (distance(a, b) > 2)
                {
                    grp.DrawLine(Pens.Black, a, b);
                    grp.DrawLine(Pens.Black, a, c);
                    grp.DrawLine(Pens.Black, c, b);

                    PointF a_urmator = new PointF((c.X + b.X) / 2, (c.Y + b.Y) / 2);
                    PointF b_urmator = new PointF((c.X + a.X) / 2, (c.Y + a.Y) / 2);
                    PointF c_urmator = new PointF((a.X + b.X) / 2, (a.Y + b.Y) / 2);

                    x.Enqueue(a);
                    y.Enqueue(b_urmator);
                    z.Enqueue(c_urmator);
                    x.Enqueue(a_urmator);
                    y.Enqueue(b);
                    z.Enqueue(c_urmator);
                    x.Enqueue(a_urmator);
                    y.Enqueue(b_urmator);
                    z.Enqueue(c);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            solve(p1, p2, p3);
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
