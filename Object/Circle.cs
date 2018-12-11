﻿using simple-drawing-kit.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple-drawing-kit.Object
{
    class Circle : AObject
    {
        //public Point from { get; set; }
        //public Point to { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        private Pen p;

        public Circle()
        {
            this.p = new Pen(Color.Black);
            p.Width = 2;
        }

        public Circle(Point awal) : this()
        {
            this.from = awal;
            this.Height = 0;
            this.Width = 0;
        }

        public override void DrawObject()
        {
            int cirW = Math.Abs(to.X - from.X);
            int cirL = Math.Abs(to.Y - from.Y);
            System.Drawing.Rectangle rec = new System.Drawing.Rectangle(Math.Min(to.X, from.X),
                                                Math.Min(to.Y, from.Y),
                                                Math.Abs(to.X - from.X),
                                                Math.Abs(to.Y - from.Y));
            this.getGraphics().SmoothingMode = SmoothingMode.AntiAlias;
            this.getGraphics().DrawEllipse(p, rec);
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
            if ((posisi.X >= from.X && posisi.X <= from.X + Width) && (posisi.Y >= from.Y && posisi.Y <= from.Y + Height))
            {
                //System.Diagnostics.Debug.WriteLine("Circle Terpilih");
                return true;
            }
            return false;
        }

        public override void Translate(int difX, int difY)
        {
            this.from = new Point(this.from.X + difX, this.from.Y + difY);
            this.to = new Point(this.to.X + difX, this.to.Y + difY);
            notify();
        }

        public override Point GetHandlePoint(int value)
        {
            Point result = Point.Empty;
            if (value == 1)//pojok kiri
                result = new Point(from.X, from.Y);
            else if (value == 2)//tengah kiri
                result = new Point(from.X, from.Y + (Height / 2));
            else if (value == 3)//bawah kiri
                result = new Point(from.X, to.Y);
            else if (value == 4)
                result = new Point(from.X + (Width / 2), from.Y);
            else if (value == 5)
                result = new Point(from.X + (Width / 2), to.Y);
            else if (value == 6)
                result = new Point(to.X, from.Y);
            else if (value == 7)
                result = new Point(to.X, from.Y + (Height / 2));
            else if (value == 8)
                result = new Point(to.X, to.Y);
            return result;
        }

        public override void DrawHandle()
        {
            for (int i = 1; i < 9; i++)
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
            for (int i = 1; i < 9; i++)
            {
                Point point = GetHandlePoint(i);
                point.Offset(-2, -2);
                if ((posisi.X >= point.X && posisi.X <= point.X + 5) && (posisi.Y >= point.Y && posisi.Y <= point.Y + 5))
                {
                    // System.Diagnostics.Debug.WriteLine("Berubah"+i);
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
            else if (clickPosition == 2)//tengah kiri
            {
                this.from = new Point(posisi.X, from.Y);
            }
            else if (clickPosition == 3)//bawah kiri
            {
                this.from = new Point(posisi.X, from.Y);
                this.to = new Point(to.X, posisi.Y);
            }
            else if (clickPosition == 4)
            {
                this.from = new Point(from.X, posisi.Y);
            }
            else if (clickPosition == 5)
            {
                this.to = new Point(to.X, posisi.Y);
            }
            else if (clickPosition == 6)
            {
                this.from = new Point(from.X, posisi.Y);
                this.to = new Point(posisi.X, to.Y);
            }
            else if (clickPosition == 7)
            {
                this.to = new Point(posisi.X, to.Y);
            }
            else if (clickPosition == 8)
            {
                this.to = posisi;
            }
            this.Width = Math.Abs(from.X - to.X);
            this.Height = Math.Abs(from.Y - to.Y);
        }

        public override void FlipVertical(int midY)
        {
            Point pojokKiriAtas = new Point(Math.Min(this.to.X, this.from.X), Math.Min(this.to.Y, this.from.Y));
            Point pojokKananBawah = new Point(Math.Max(this.to.X, this.from.X), Math.Max(this.to.Y, this.from.Y));
            Point pojokKananAtas;
            Point pojokKiriBawah;
            if (pojokKiriAtas.X < midY)
            {
                pojokKananAtas = new Point(pojokKiriAtas.X + 2 * Math.Abs(pojokKiriAtas.X - midY), pojokKiriAtas.Y);
            }
            else
            {
                pojokKananAtas = new Point(pojokKiriAtas.X - 2 * Math.Abs(pojokKiriAtas.X - midY), pojokKiriAtas.Y);
            }

            if (pojokKananBawah.X < midY)
            {
                pojokKiriBawah = new Point(pojokKananBawah.X + 2 * Math.Abs(pojokKananBawah.X - midY), pojokKananBawah.Y);
            }
            else
            {
                pojokKiriBawah = new Point(pojokKananBawah.X - 2 * Math.Abs(pojokKananBawah.X - midY), pojokKananBawah.Y);
            }
            this.from = new Point(pojokKiriBawah.X, pojokKananAtas.Y);
            this.to = new Point(pojokKananAtas.X, pojokKiriBawah.Y);
            this.Width = Math.Abs(from.X - to.X);
            this.Height = Math.Abs(from.Y - to.Y);
            notify();
        }

        public override void FlipHorizontal(int midX)
        {
            Point pojokKiriAtas = new Point(Math.Min(this.to.X, this.from.X), Math.Min(this.to.Y, this.from.Y));
            Point pojokKananBawah = new Point(Math.Max(this.to.X, this.from.X), Math.Max(this.to.Y, this.from.Y));
            Point pojokKananAtas;
            Point pojokKiriBawah;
            if (pojokKiriAtas.Y < midX)
            {
                pojokKiriBawah = new Point(pojokKiriAtas.X, pojokKiriAtas.Y + 2 * Math.Abs(pojokKiriAtas.Y - midX));
            }
            else
            {
                pojokKiriBawah = new Point(pojokKiriAtas.X, pojokKiriAtas.Y - 2 * Math.Abs(pojokKiriAtas.Y - midX));
            }
            if (pojokKananBawah.Y < midX)
            {
                pojokKananAtas = new Point(pojokKananBawah.X, pojokKananBawah.Y + 2 * Math.Abs(pojokKananBawah.Y - midX));
            }
            else
            {
                pojokKananAtas = new Point(pojokKananBawah.X, pojokKananBawah.Y - 2 * Math.Abs(pojokKananBawah.Y - midX));
            }

            this.from = new Point(pojokKiriBawah.X, pojokKananAtas.Y);
            this.to = new Point(pojokKananAtas.X, pojokKiriBawah.Y);

            this.Width = Math.Abs(from.X - to.X);
            this.Height = Math.Abs(from.Y - to.Y);
            notify();
        }

        public override void RotateRight()
        {
            throw new NotImplementedException();
        }

        public override void RotateLeft()
        {
            throw new NotImplementedException();
        }
    }
}
