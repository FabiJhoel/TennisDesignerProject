﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TennisLibrary
{
    public class MoveablePoint
    {
        private double AxisX;
        private double AxisY;
        private string name;
        Ellipse pointEllipse;

        public MoveablePoint(int pAxisX, int pAxisY, string pName)
        {
            pointEllipse = new Ellipse();
            setAxisX(pAxisX);
            setAxisY(pAxisY);
            setName(pName);
        }

        public void setAxisX(int pAxisX)
        {
            this.AxisX = pAxisX;
        }

        public void setAxisY(int pAxisY)
        {
            this.AxisY = pAxisY;
        }

        public void setName(string pName)
        {
            this.name = pName;
        }

        public double getAxisX()
        {
            return this.AxisX;
        }

        public double getAxisY()
        {
            return this.AxisY;
        }

        public string getName()
        {
            return this.name;
        }

        public Ellipse getPointEllipse()
        {
            return pointEllipse;
        }

        public void drawPoint()
        {
            //Brush to fill the ellipse
            SolidColorBrush colorBrush = new SolidColorBrush();
            colorBrush.Color = Color.FromArgb(255, 177, 219, 255);

            //Set ellipse properties
            pointEllipse.Fill = colorBrush;
            pointEllipse.StrokeThickness = 3;
            pointEllipse.Stroke = Brushes.Navy;
            pointEllipse.Width = 24;
            pointEllipse.Height = 26;
        }
    }
}
