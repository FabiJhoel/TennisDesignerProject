using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TennisBusiness
{
    public class BasePoint
    {
        private double axisX;
        private double axisY;
        private string name;
        private Ellipse pointEllipse;

        public BasePoint(double pAxisX, double pAxisY, string pName)
        {
            pointEllipse = new Ellipse();
            setAxisX(pAxisX);
            setAxisY(pAxisY);
            setName(pName);
        }

        public void setAxisX(double pAxisX)
        {
            this.axisX = pAxisX;
        }

        public void setAxisY(double pAxisY)
        {
            this.axisY = pAxisY;
        }

        public void setName(string pName)
        {
            this.name = pName;
        }

        public double getAxisX()
        {
            return this.axisX;
        }

        public double getAxisY()
        {
            return this.axisY;
        }

        public string getName()
        {
            return this.name;
        }

        public Ellipse getPointEllipse()
        {
            return pointEllipse;
        }

        public void drawPoint(int pType)
        {
            if (pType == 1)
            {
                pointEllipse.Fill = new SolidColorBrush(Color.FromArgb(255, 177, 219, 255));
                pointEllipse.StrokeThickness = 3;
                pointEllipse.Stroke = Brushes.Navy;
                pointEllipse.Width = 24;
                pointEllipse.Height = 26;
            }
            
            else
            {
                pointEllipse.Fill = new SolidColorBrush(Color.FromArgb(255, 238, 221, 56));
                pointEllipse.StrokeThickness = 4;
                pointEllipse.Stroke = new SolidColorBrush(Color.FromArgb(255, 245, 172, 16));
                pointEllipse.Width = 15;
                pointEllipse.Height = 15;
            }
        }
    }
}
