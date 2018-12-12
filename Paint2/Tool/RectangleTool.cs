﻿using SimpleDrawingKit.Interface;
using SimpleDrawingKit.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SimpleDrawingKit.Tool
{
    class RectangleTool : ATool
    {
        public bool isActive { set; get; }
        public int rectangleOpacity { set; get; }
        public Color rectangleColor { set; get; }
        private Object.Rectangle rectangleObject;
        public override bool MouseClick(object sender, MouseEventArgs e, LinkedList<AObject> listObject)
        {
            System.Diagnostics.Debug.WriteLine("Click");
            return true;
        }

        public override void MouseDown(object sender, MouseEventArgs e, Panel panel1, LinkedList<AObject> listObject)
        {
            rectangleObject = new Object.Rectangle(e.Location, rectangleOpacity, rectangleColor);
            rectangleObject.to = e.Location;
            rectangleObject.setGraphics(panel1.CreateGraphics());
            rectangleObject.Draw();
            panel1.Invalidate();
        }

        public override void MouseMove(object sender, MouseEventArgs e, Panel panel1, LinkedList<AObject> listObject)
        {
            rectangleObject.to = e.Location;
            rectangleObject.Width = Math.Abs(e.X - rectangleObject.from.X);
            rectangleObject.Height = Math.Abs(e.Y - rectangleObject.from.Y);
            rectangleObject.Draw();
        }

        public override AObject MouseUp(object sender, MouseEventArgs e, Panel panel1, LinkedList<AObject> listObject)
        {
            rectangleObject.to = e.Location;
            rectangleObject.Width = Math.Abs(e.X - rectangleObject.from.X);
            rectangleObject.Height = Math.Abs(e.Y - rectangleObject.from.Y);
            //rectangleObject.DrawEdit();
            //rectangleObject.Select();
            rectangleObject.centerPoint = new System.Drawing.Point(Math.Abs(rectangleObject.from.X - rectangleObject.to.X) / 2, Math.Abs(rectangleObject.from.Y - rectangleObject.to.Y) / 2);
            rectangleObject.Deselect();
            rectangleObject.Draw();
            return rectangleObject;
        }

        public override void KeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void KeyDown(object sender, KeyEventArgs e, Panel panel1)
        {
            throw new NotImplementedException();
        }

       /* internal static void FillObject(SolidBrush fill, object rect)
        {
            throw ne/w NotImplementedException();
        }*/
    }
}
