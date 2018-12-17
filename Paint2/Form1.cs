using SimpleDrawingKit.Interface;
using SimpleDrawingKit.Object;
using SimpleDrawingKit.Tool;
using SimpleDrawingKit.ColorDecorator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private bool SetState = false;
        private int sliderOpacity = 0;
        public Color shapeColor;
        private AObject objectSelected;
        private int clickPosition = -1;
        private ATool toolSelected;
        private LineTool lineTool = new LineTool();
        private CircleTool circleTool = new CircleTool();
        private RectangleTool rectangleTool = new RectangleTool();
        private SelectTool selectTool = new SelectTool();

        //private fillColor fillColor = new fillColor();

        List<AObject> listObject = new List<AObject>();
        private LinkedList<AObject> drawables = new LinkedList<AObject>();

        void buttonColor()
        {
            lineButton.BackColor = Color.Snow;
            circleButton.BackColor = Color.Snow;
            rectangButton.BackColor = Color.Snow;
            //undoToolStripMenuItem.BackColor = Color.Snow;
            //cursorToolStripMenuItem.BackColor = Color.Snow;
        }

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

            foreach (AObject Object in drawables)
            {
                //Object.Deselect();
                Object.Draw();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            if (lineTool.isActive == false && SetState == true)
            {
                    reset();
                    Opacity = opacityTrackBar.Value;
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
            if (rectangleTool.isActive == false && SetState == true)
            {
                    reset();
                    rectangleTool.rectangleOpacity = opacityTrackBar.Value;
                    rectangleTool.isActive = true;
                    rectangleTool.rectangleColor = shapeColor;
                    toolSelected = rectangleTool;
                    buttonColor();
                    rectangleTool.BackColor = Color.Blue;
            }
            else
            {
                reset();
                toolSelected = null;
                rectangleTool.isActive = false;
                buttonColor();
            }
        }
        private void circleButton_Click(object sender, EventArgs e)
        {
            this.Refresh();
            if (circleTool.isActive == false && SetState == true)
            {
                    reset();
                    circleTool.circleOpacity = opacityTrackBar.Value;
                    circleTool.circleColor = shapeColor;
                    circleTool.isActive = true;
                    toolSelected = circleTool;
                    buttonColor();
                    circleTool.BackColor = Color.Blue;
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
                //  SetTransparency(opacityTrackBar.value);
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
        //public void SetTransparency()
        //{

        //}
        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.Refresh();
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
            SetState = false;
        }

        private void opacityTrackBar_Scroll(object sender, EventArgs e)
        {
            this.Refresh();
            //if (SetState = false)
            {
                //opacityText.Text = "Opacity : " + value();
                opacityText.Text = "Opacity : " + opacityTrackBar.Value.ToString();
                //rectangleOpacity = circleOpacity = opacityTrackBar.Value;
                //Refresh();
            }

        }
        private void setButton_Click(object sender, EventArgs e)
        {
            this.Refresh();
            if (SetState == false)
            {
                //Refresh();
                sliderOpacity = opacityTrackBar.Value;
                SetState = true;
            }
            else
            {
                reset();
            }
        }

        public void Remove_Object(AObject Object)
        {
            drawables.Remove(Object);
        }
        public void Add_Object(AObject Object)
        {
            drawables.AddLast(Object);
        }

        private void rebColorButton_Click(object sender, EventArgs e)
        {
            fillColor.redColorShape();
        }
        private void orangeColorButton_Click(object sender, EventArgs e)
        {
            fillColor.orangeColorShape();
        }
        private void yellowColorButton_Click(object sender, EventArgs e)
        {
            fillColor.yellowColorShape();
        }
        private void lightblueColorButton_Click(object sender, EventArgs e)
        {
            fillColor.lightblueColorShape();
        }
        private void blueColorButton_Click(object sender, EventArgs e)
        {
            fillColor.blueColorShape();
        }
        private void greenColorButton_Click(object sender, EventArgs e)
        {
            fillColor.greenColorShape();
        }
        private void whiteColorButton_Click(object sender, EventArgs e)
        {
            fillColor.whiteColorShape();
        }
    }
}