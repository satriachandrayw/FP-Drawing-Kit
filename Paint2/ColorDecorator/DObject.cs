using System;
using System.Collections.Generic;
using SimpleDrawingKit;
using SimpleDrawingKit.Interface;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDrawingKit.ColorDecorator
{
    public abstract class Decorator : Form1
    {
        public int Opacity;
        public Color shapeColor;
        protected Form1 main;

        public Decorator(Form1 main)
        {
            this.main = main;
        }
    }

    class fillColor : Decorator
    {
        public static void redColorShape()
        {
            //Refresh();
            main.shapeColor = Color.Red;
        }
        public static void orangeColorShape()
        {
            //Refresh();
            main.shapeColor = Color.Orange;
        }
        public static void yellowColorShape()
        {
            //Refresh();
            main.shapeColor = Color.Yellow;
        }
        public static void lightblueColorShape()
        {
            //Refresh();
            main.shapeColor = Color.LightBlue;
        }
        public static void blueColorShape()
        {
            //Refresh();
            main.shapeColor = Color.Blue;
        }
        public static void greenColorShape()
        {
            //Refresh();
            main.shapeColor = Color.Green;
        }
        public static void whiteColorShape()
        {
            //Refresh();
            main.shapeColor = Color.Transparent;
        }
    }
}
