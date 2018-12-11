using SimpleDrawingKit.Interface;
using SimpleDrawingKit.Object;
using SimpleDrawingKit.Tool;
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

namespace SimpleDrawingKit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonColor();
            this.DoubleBuffered = true;
        }
        private bool shouldPaint = false;
        Boolean select;
        Point initial;
        private AObject objectSelected;
        private int clickPosition = -1;
        private ATool toolSelected;
        private LineTool lineTool = new LineTool();
        private CircleTool circleTool = new CircleTool();
        private RectangleTool rectangleTool = new RectangleTool();
        private SelectTool selectTool = new SelectTool();

        List<AObject> listObject = new List<AObject>();
        private LinkedList<AObject> drawables = new LinkedList<AObject>();

        /*Pen pen;
        private Graphics Gambar;
        private Point preCor, newCor;
        private bool MyPic = false;
        private int curX, curY, x, y, showX, showY;
        int cirW, cirL;
        private double length;
        private int bentuk = 0, ee = 0;
        private const double EPSILON = 3.0;
        //private Color warna;*/

        void buttonColor()
        {
            lineButton.BackColor = Color.Snow;
            circleButton.BackColor = Color.Snow;
            rectangButton.BackColor = Color.Snow;
            //undoToolStripMenuItem.BackColor = Color.Snow;
            //cursorToolStripMenuItem.BackColor = Color.Snow;
        }
        /*class Line
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
        }*/

        /*class Circle
        {
            public int xFrom, yFrom;
            public Point to;
        }*/

        /*class Rectang
        {
            public int xFrom, yFrom;
            public Point to;
        }*/

        List<Line> listLine = new List<Line>();
        List<Circle> listCircle = new List<Circle>();
        List<Object.Rectangle> listRectang = new List<Object.Rectangle>();
        List<Stack> listUndo = new List<Stack>();

        class Stack
        {
            public String bentuk;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Gambar = panel1.CreateGraphics();

            foreach (AObject Object in drawables)
            {
                //Object.Deselect();
                Object.Draw();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            /*foreach (Line line in listLine)
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
            }*/
        }
        private void panel1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (toolSelected == null && select == false)
            {
                DialogResult box2;
                box2 = MessageBox.Show("Please, Select Shape", "Error", MessageBoxButtons.RetryCancel);
                if (box2 == DialogResult.Cancel)
                {
                    this.Dispose();
                }
            }
            else if (selectTool.isActive == true)

            {
                if (toolSelected.MouseClick(sender, e, drawables) == true)
                {
                    System.Diagnostics.Debug.WriteLine("Bisa");
                    shouldPaint = true;
                }
            }
            /*if (MyPic == true)
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
            }*/
        }
        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            panel1.Cursor = Cursors.Cross;
            if (e.Button == MouseButtons.Left && toolSelected != null)
            {
                shouldPaint = true;
                //toolSelected.MouseDown(sender, e, panel1, listObject);
                toolSelected.MouseDown(sender, e, panel1, drawables);
            }
            /*if (e.Button == MouseButtons.Left)
            {
                MyPic = true;
                ee++;
            }

            curX = e.X;
            curY = e.Y;*/
        }
        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (toolSelected != null && shouldPaint == true)
            {
                this.Refresh();
                //toolSelected.MouseMove(sender, e, panel1, listObject);
                toolSelected.MouseMove(sender, e, panel1, drawables);
                this.Invalidate();
            }
            /*length = Math.Sqrt((showX * showX) + (showY * showY));
            //TextBox1.Text = Convert.ToString(showX);
            //TextBox2.Text = Convert.ToString(showY);
            //TextBox3.Text = Convert.ToString(length);*/
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            panel1.Cursor = Cursors.Default;
            if (shouldPaint == true && selectTool.isActive == true)
            {
                shouldPaint = false;
            }
            else if (toolSelected != null && shouldPaint == true)
            {
                //listObject.Add(toolSelected.MouseUp(sender, e, panel1, listObject));
                AObject objectPaint = toolSelected.MouseUp(sender, e, panel1, drawables);
                if (objectPaint != null)
                {
                    drawables.AddLast(toolSelected.MouseUp(sender, e, panel1, drawables));
                }
                shouldPaint = false;
            }
            this.Invalidate();
            //MyPic = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(e.KeyCode.ToString() + " pressed.");
            if (toolSelected != null && selectTool.isActive)
            {
                toolSelected.KeyDown(sender, e, panel1);
            }
            //System.Diagnostics.Debug.WriteLine(e.KeyCode.ToString() + " pressed.");
            this.Refresh();
            /*this.Invalidate();*/
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            this.Refresh();
            if (lineTool.isActive == false)
            {
                reset();
                lineTool.isActive = true;
                toolSelected = lineTool;
                buttonColor();
                lineTool.BackColor = Color.Blue;
            }
            else
            {
                reset();
                toolSelected = null;
                lineTool.isActive = false;
                buttonColor();
            }
        }
        private void rectangButton_Click(object sender, EventArgs e)
        {
            this.Refresh();
            if (rectangleTool.isActive == false)
            {
                reset();
                rectangleTool.isActive = true;
                toolSelected = rectangleTool;
                buttonColor();
                rectangleTool.BackColor = Color.Red;
            }
            else
            {
                reset();
                toolSelected = null;
                rectangleTool.isActive = false;
                buttonColor();
            }
            /*bentuk = 2;
            rectang.BackColor = Color.Red;
            circle.BackColor = Color.White;
            line.BackColor = Color.White;*/
        }
        private void circleButton_Click(object sender, EventArgs e)
        {
            this.Refresh();
            if (circleTool.isActive == false)
            {
                reset();
                circleTool.isActive = true;
                toolSelected = circleTool;
                buttonColor();
                circleTool.BackColor = Color.Red;
            }
            else
            {
                reset();
                toolSelected = null;
                circleTool.isActive = false;
                buttonColor();
            }
            /*bentuk = 3;
            circle.BackColor = Color.Red;
            line.BackColor = Color.White;
            rectang.BackColor = Color.White;*/
        }
        private void undoButton_Click(object sender, EventArgs e)
        {
            reset();
            this.Refresh();
            if (!drawables.Any())
            {
                DialogResult box2;
                box2 = MessageBox.Show("Belum Ada Tindakan", "Error", MessageBoxButtons.RetryCancel);
                if (box2 == DialogResult.Cancel)
                {
                    this.Dispose();
                }
            }
            else
            {
                //listObject.RemoveAt(listObject.Count - 1);
                drawables.RemoveLast();
                this.Refresh();
            }
        }
        private void selectButton_Click(object sender, EventArgs e)
        {
            this.Refresh();
            if (select == false)
            {
                reset();
                selectTool.isActive = true;
                selectTool.ParentForm = this;
                toolSelected = selectTool;
                buttonColor();
               selectTool.BackColor = Color.Red;
            }
            else
            {
                reset();
                toolSelected = null;
                selectTool.isActive = false;
                buttonColor();
            }
        }
        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.Refresh();
            //textBox1.Text = " ";
            //textBox2.Text = " ";
            //textBox3.Text = " ";
        }

        private void deselectObject()
        {
            clickPosition = -1;
            /*foreach (AObject Object in listObject)
            {
                Object.Deselect();
                //Object.DrawStatic();
            }*/
            foreach (AObject Object in drawables)
            {
                Object.Deselect();
                Object.Draw();
            }
            this.Refresh();
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

        /*void buttonColor()
        {
            lineToolStripMenuItem.BackColor = Color.Snow;
            circleToolStripMenuItem.BackColor = Color.Snow;
            connectorToolStripMenuItem.BackColor = Color.Snow;
            rectangleToolStripMenuItem.BackColor = Color.Snow;
            undoToolStripMenuItem.BackColor = Color.Snow;
            cursorToolStripMenuItem.BackColor = Color.Snow;
        }*/

        void reset()
        {
            deselectObject();
            circleTool.isActive = false;
            lineTool.isActive = false;
            rectangleTool.isActive = false;
            selectTool.isActive = false;
            toolSelected = null;
            objectSelected = null;
            clickPosition = -1;
            select = false;
        }

        public void Remove_Object(AObject Object)
        {
            drawables.Remove(Object);
        }

        public void Add_Object(AObject Object)
        {
            drawables.AddLast(Object);
        }






    }
}