using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Paint_sederhana
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Pen pen;
        private Graphics Gambar;
        private Point preCor, newCor;
        private bool MyPic = false;
        private int curX, curY, x, y, showX, showY;
        int cirW, cirL;
        private double length;
        private int bentuk = 0, ee = 0;
        private const double EPSILON = 3.0;
        //private Color warna;

        class Line
        {
            public Point from, to;

            public bool Intersect(int xTest, int yTest)
            {
                double m = GetSlope();
                double b = to.Y - m * to.X;
                double y_point = m * xTest + b;

                if (Math.Abs(yTest - y_point) < EPSILON)
                {
                    System.Diagnostics.Debug.WriteLine("Terpilih");
                    return true;
                }
                return false;
            }

            public double GetSlope()
            {
                double m = (double)(to.Y - from.Y) / (double)(to.X - from.X);
                return m;
            }
        }

        class Circle
        {
            public int xFrom, yFrom;
            public Point to;
        }

        class Rectang
        {
            public int xFrom, yFrom;
            public Point to;
        }

        List<Line> listLine = new List<Line>();
        List<Circle> listCircle = new List<Circle>();
        List<Rectang> listRectang = new List<Rectang>();
        List<Stack> listUndo = new List<Stack>();

        class Stack
        {
            public String bentuk;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Gambar = panel1.CreateGraphics();

            foreach (Line line in listLine)
            {
                Gambar.DrawLine(pen, line.from, line.to);
            }

            foreach (Circle circle in listCircle)
            {
                p.Width = 2;
                cirW = Math.Abs(circle.to.X - circle.xFrom);
                cirL = Math.Abs(circle.to.Y - circle.yFrom);
                Rectangle rec = new Rectangle(Math.Min(circle.to.X, circle.xFrom),
                Math.Min(circle.to.Y, circle.yFrom),
                Math.Abs(circle.to.X - circle.xFrom),
                Math.Abs(circle.to.Y - circle.yFrom));
                Gambar.DrawEllipse(pen, rec);
            }

            foreach (Rectang rectang in listRectang)
            {
                p.Width = 2;
                int width = rectang.to.X - rectang.xFrom;
                int height = rectang.to.Y - rectang.yFrom;
                Rectangle rect = new Rectangle(Math.Min(rectang.to.X, rectang.xFrom),
                Math.Min(rectang.to.Y, rectang.yFrom),
                Math.Abs(rectang.to.X - rectang.xFrom),
                Math.Abs(rectang.to.Y - rectang.yFrom));
                newCoor = new Point(rectang.to.X, rectang.to.Y);
                Gambar.DrawRectangle(pen, rect);
            }
        }

        private void line_Click(object sender, EventArgs e)
        {
            bentuk = 1;
            line.BackColor = Color.Red;
            circle.BackColor = Color.White;
            rectang.BackColor = Color.White;
        }

        private void rectang_Click(object sender, EventArgs e)
        {
            bentuk = 2;
            rectang.BackColor = Color.Red;
            circle.BackColor = Color.White;
            line.BackColor = Color.White;
        }

        private void circle_Click(object sender, EventArgs e)
        {
            bentuk = 3;
            circle.BackColor = Color.Red;
            line.BackColor = Color.White;
            rectang.BackColor = Color.White;
        }

        /*private void pilih_warna_Click(object sender, EventArgs e)
        {
            ColorDialog col = new ColorDialog();
            if (col.ShowDialog() == DialogResult.OK)
            {
                pilih_warna.BackColor = col.Color;
                warna = col.Color;
            }
        }*/

        private void refresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
            //textBox1.Text = " ";
            //textBox2.Text = " ";
            //textBox3.Text = " ";
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MyPic = true;
                ee++;
            }

            curX = e.X;
            curY = e.Y;
        }

        private void panel1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (MyPic == true)
            x = e.X;
            y = e.Y;
            showX = e.X - curX;
            showY = curY - e.Y;

            if (bentuk == 1)
            {
                Gambar.DrawLine(new Pen(Color.Black), curX, curY, e.X, e.Y);
                Gambar.DrawLine(new Pen(Color.Red), curX, curY, e.X, e.Y);
            }
            if (bentuk == 2)
            {
                Gambar.DrawRectangle(new Pen(Color.Black), curX, curY, showX, -showY);
                Gambar.DrawRectangle(new Pen(Color.Green), curX, curY, showX, -showY);
            }
            if (bentuk == 3)
            {
                Gambar.DrawEllipse(new Pen(Color.Black), curX, curY, showX, -showY);
                Gambar.DrawEllipse(new Pen(Color.Blue), curX, curY, showX, -showY);
            }
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            length = Math.Sqrt((showX * showX) + (showY * showY));
            //TextBox1.Text = Convert.ToString(showX);
            //TextBox2.Text = Convert.ToString(showY);
            //TextBox3.Text = Convert.ToString(length);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            MyPic = false;
        }
    }
}