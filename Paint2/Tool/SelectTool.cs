﻿using SimpleDrawingKit.Interface;
using SimpleDrawingKit.Object;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleDrawingKit.Tool
{
    class SelectTool : ATool
    {
        public bool isActive { set; get; }
        public int Opacity { set; get; }
        public Point initial;
        public AObject objectSelected;
        private int posisiClick = -1;
        private bool shouldPaint = false;
        protected Form1 formuse;
        public Form1 ParentForm { get; set; }
        public LinkedList<AObject> ObjectGroup;

        public bool controlClick = false;

        public SelectTool()
        {
            ObjectGroup = new LinkedList<AObject>();
        }

        public AObject GetObjectSelected()
        {
            return objectSelected;
        }

        public int banyakObject()
        {
            int j = 0;
            foreach (AObject Object in ObjectGroup)
            {
                j++;
            }
            System.Diagnostics.Debug.WriteLine(j);
            return j;
        }

        public bool checkchild(AObject aObject)
        {
            foreach (AObject Object in ObjectGroup)
            {
                if (aObject == Object)
                {
                    return false;
                }
            }
            return true;
        }

        public AObject getObject(LinkedList<AObject> listObject, MouseEventArgs e)
        {
            foreach (AObject Object in listObject)
            {
                if (Object.Select(e.Location) == true)
                {
                    return Object;
                }
            }
            return null;
        }

        public override bool MouseClick(object sender, MouseEventArgs e, LinkedList<AObject> listObject)
        {
            initial = e.Location;
            if (controlClick == true || ObjectGroup.Any())
            {
                AObject objectdipilih = getObject(listObject, e);
                if (objectdipilih == null)
                {
                    System.Diagnostics.Debug.WriteLine("Salah");
                    foreach (AObject Object in ObjectGroup)
                    {
                        Object.Deselect();
                        Object.Draw();
                    }
                    ObjectGroup = new LinkedList<AObject>();
                    controlClick = false;
                }
                else if (objectdipilih != null && checkchild(objectdipilih))
                {
                    //System.Diagnostics.Debug.WriteLine("Benar");
                    objectdipilih.Select();
                    objectdipilih.Draw();
                    ObjectGroup.AddLast(objectdipilih);
                    if (objectSelected != null && checkchild(objectSelected))
                    {
                        ObjectGroup.AddLast(objectSelected);
                        objectSelected.Select();
                        objectSelected.Draw();
                        objectSelected = null;
                    }
                    controlClick = false;
                    //banyakObject();
                }
                return true;
            }
            else
            {
                objectSelected = null;
                objectSelected = getObject(listObject, e);
                if (objectSelected != null)
                {
                    System.Diagnostics.Debug.WriteLine("Masuk");
                    objectSelected.DrawEdit();
                    objectSelected.DrawHandle();
                    return true;
                }
            }
            /*if (ObjectGroup!=null)
            {
                System.Diagnostics.Debug.WriteLine("salah");
                foreach (AObject Object in ObjectGroup)
                {
                    Object.Deselect();
                    Object.Draw();
                }
                ObjectGroup = new LinkedList<AObject>();
            }*/
            return false;
        }

        public override void MouseDown(object sender, MouseEventArgs e, Panel panel1, LinkedList<AObject> listObject)
        {
            initial = e.Location;
            if (ObjectGroup.Any())
            {

            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("Inini");
                if (objectSelected == null)
                {
                    //System.Diagnostics.Debug.WriteLine("Gak ada");
                    foreach (AObject Object in listObject)
                    {
                        if (Object.Select(e.Location) == true)
                        {
                            System.Diagnostics.Debug.WriteLine("Masuk");
                            shouldPaint = true;
                            objectSelected = Object;
                            Object.DrawEdit();
                            Object.DrawHandle();
                            break;
                        }
                    }
                }
                else
                {
                    posisiClick = objectSelected.GetClickHandle(e.Location);
                    //System.Diagnostics.Debug.WriteLine(posisiClick);
                }
            }
            panel1.Invalidate();
        }

        public override void MouseMove(object sender, MouseEventArgs e, Panel panel1, LinkedList<AObject> listObject)
        {
            if (ObjectGroup.Any())
            {
                foreach (AObject aObject in ObjectGroup)
                {
                    aObject.Translate(e.X - initial.X, e.Y - initial.Y);
                    aObject.Draw();
                }
                initial = e.Location;
            }
            else
            {
                if (objectSelected != null)
                {
                    if (posisiClick != -1)
                    {
                        objectSelected.Resize(posisiClick, e.Location);
                        objectSelected.Draw();
                        objectSelected.DrawEdit();
                        objectSelected.DrawHandle();
                    }
                    else
                    {
                        objectSelected.Translate(e.X - initial.X, e.Y - initial.Y);
                        //System.Diagnostics.Debug.WriteLine("objectSelected.from");
                        initial = e.Location;
                        objectSelected.DrawObject();
                        objectSelected.DrawHandle();
                    }
                }
            }
        }

        public override AObject MouseUp(object sender, MouseEventArgs e, Panel panel1, LinkedList<AObject> listObject)
        {
            return null;
        }

        public override void KeyUp(object sender, KeyEventArgs e)
        {

        }

        public override void KeyDown(object sender, KeyEventArgs e, Panel panel1)
        {
            //System.Diagnostics.Debug.WriteLine(e.KeyCode.ToString() + " Pencet.");
            if (e.KeyCode == Keys.Delete && objectSelected != null)
            {
                ParentForm.Remove_Object(objectSelected);
                objectSelected = null;
                //System.Diagnostics.Debug.WriteLine(e.KeyCode.ToString() + " Oke.");
            }
            else if (e.Control && e.KeyCode == Keys.G && ObjectGroup.Any() && banyakObject() > 1)
            {
                GroupObject groupObject = new GroupObject();
                groupObject.setGraphics(panel1.CreateGraphics());
                groupObject.AddChild(ObjectGroup);

                foreach (AObject aObject in ObjectGroup)
                {
                    aObject.Deselect();
                    ParentForm.Remove_Object(aObject);
                }
                groupObject.Deselect();
                ParentForm.Add_Object(groupObject);
                ObjectGroup = new LinkedList<AObject>();
                controlClick = false;
                //groupObject.Draw();
                //panel1.Invalidate();
                //panel1.Refresh();
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.G && objectSelected != null)
            {
                LinkedList<AObject> child = objectSelected.RemoveChild();
                ParentForm.Remove_Object(objectSelected);
                foreach (AObject aObject in child)
                {
                    ParentForm.Add_Object(aObject);
                }
                objectSelected = null;
                panel1.Refresh();
                panel1.Invalidate();
            }
            else if (e.Control)
            {
                //System.Diagnostics.Debug.WriteLine(e.KeyCode.ToString() + " Control Saja.");
                controlClick = true;
            }
        }
    }
}
