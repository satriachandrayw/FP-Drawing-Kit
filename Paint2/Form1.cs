using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Paint_sederhana
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics Gambar;
        private bool MyPic = false;
        private int curX, curY, x, y, showX, showY;
        private double length;
        private int bentuk = 0, ee = 0;
        //private Color warna;

        private void Form1_Load(object sender, EventArgs e)
        {
            Gambar = panel1.CreateGraphics();
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
            showY = e.Y - curY;

            if (bentuk == 1)
            {
                Gambar.DrawLine(new Pen(Color.Black), curX, curY, e.X, e.Y);
                Gambar.DrawLine(new Pen(Color.Red), curX, curY, e.X, e.Y);
            }
            if (bentuk == 2)
            {
                Gambar.DrawRectangle(new Pen(Color.Black), curX, curY, showX, -showY);
                Gambar.DrawRectangle(new Pen(Color.Red), curX, curY, showX, -showY);
            }
            if (bentuk == 3)
            {
                Gambar.DrawEllipse(new Pen(Color.Black), curX, curY, showX, -showY);
                Gambar.DrawEllipse(new Pen(Color.Red), curX, curY, showX, -showY);
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