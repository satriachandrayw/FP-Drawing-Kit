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
    public abstract class Decorator
    {
        public int Opacity;
        public Form1 main;
        //public Color shapeColor;
        


        public Decorator()
        {
            //this.main = Form1;
        }
    }

    public class fillColor : Decorator
    {
        public fillColor()
        {
            
        }

        public void redColorShape()
        {
            //Refresh();
            main.shapeColor = Color.Red;
        }
        public void orangeColorShape()
        {
            //Refresh();
            main.shapeColor = Color.Orange;
        }
        public void yellowColorShape()
        {
            //Refresh();
            main.shapeColor = Color.Yellow;
        }
        public void lightblueColorShape()
        {
            //Refresh();
            main.shapeColor = Color.LightBlue;
        }
        public void blueColorShape()
        {
            //Refresh();
            main.shapeColor = Color.Blue;
        }
        public void greenColorShape()
        {
            //Refresh();
            main.shapeColor = Color.Green;
        }
        public void whiteColorShape()
        {
            //Refresh();
            main.shapeColor = Color.Transparent;
        }
    }
}
