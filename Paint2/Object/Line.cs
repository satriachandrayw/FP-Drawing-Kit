﻿using SimpleDrawingKit.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDrawingKit.Object
{
    public class Line : AObject
    {
        private const double EPSILON = 3.0;
        private Pen p;
        private int Opacity;
        public Color shapeColor;

        public Line()
        {
            this.p = new Pen(Color.Black);
            p.Width = 2;
           
        }

        public Line(Point awal, int lineOpacity, Color lineColor) : this()
        {
            this.from = awal;
            this.Opacity = lineOpacity;
            this.shapeColor = lineColor;


        }

        public override void DrawObject()
        {
            SolidBrush color = new SolidBrush(Color.FromArgb(Opacity, shapeColor.R, shapeColor.G, shapeColor.B));
            this.getGraphics().SmoothingMode = SmoothingMode.AntiAlias;
            this.getGraphics().DrawLine(p, from, to);
            //this.p.Color=shapeColor;
        }

        public override void DrawPreview()
        {
            this.p.Color = Color.Red;
            DrawObject();
        }

        public override void DrawEdit()
        {
            this.p.Color = Color.Blue;
            DrawObject();
        }

        public override void DrawStatic()
        {
            this.p.Color = Color.Black;
            DrawObject();
        }

        public override Boolean Select(Point posisi)
        {
            double m = GetSlope();
            double b = to.Y - m * to.X;
            double y_point = m * posisi.X + b;

            if (Math.Abs(posisi.Y - y_point) < EPSILON)
            {
                /*Debug.WriteLine("Object " + ID + " is selected.");*/
                //System.Diagnostics.Debug.WriteLine("Garis Terpilih");
                return true;
            }
            return false;
        }

        public double GetSlope()
        {
            double m = (double)(to.Y - from.Y) / (double)(to.X - from.X);
            return m;
        }


        public override void Translate(int difX, int difY)
        {
            this.from = new Point(this.from.X + difX, this.from.Y + difY);
            this.to = new Point(this.to.X + difX, this.to.Y + difY);
        }

        public override Point GetHandlePoint(int value)
        {
            Point result = Point.Empty;
            if (value == 1)//pojok kiri
                result = new Point(from.X, from.Y);
            else if (value == 2)//bawah kiri
                result = new Point(to.X, to.Y);
            return result;
            //else if (value == 2)//tengah kiri
            //  result = new Point((to.X + from.X) /2, (to.Y+from.Y)/2);
        }

        public override void DrawHandle()
        {
            for (int i = 1; i < 3; i++)
            {
                Point point = GetHandlePoint(i);
                point.Offset(-2, -2);
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(point.X, point.Y, 5, 5);
                this.getGraphics().SmoothingMode = SmoothingMode.AntiAlias;
                this.getGraphics().DrawRectangle(p, rect);
            }
        }

        public override int GetClickHandle(Point posisi)
        {
            for (int i = 1; i < 3; i++)
            {
                Point point = GetHandlePoint(i);
                point.Offset(-2, -2);
                if ((posisi.X >= point.X && posisi.X <= point.X + 5) && (posisi.Y >= point.Y && posisi.Y <= point.Y + 5))
                {
                    System.Diagnostics.Debug.WriteLine("Berubah" + i);
                    return i;
                }
            }
            return -1;
        }

        public override void Resize(int clickPosition, Point posisi)
        {
            if (clickPosition == 1)//pojok kiri
            {
                this.from = posisi;
            }
            else if (clickPosition == 2)//bawah kiri
            {
                this.to = posisi;
            }
        }
    }
}
