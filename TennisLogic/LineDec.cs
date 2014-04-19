using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace TennisBusiness
{
    public class LineDec : Decoration
    {
        private double axisX1;
        private double axisY1;
        private double axisX2;
        private double axisY2;
        private Line line;
        private List<BasePoint> basePoints = new List<BasePoint>();

        public LineDec(int pThikness, Color pColor)
                        : base(0, pThikness, pColor)
        {
            line = new Line();
            addPoint(new BasePoint(200, 250, "axis1"));
            //addPoint(new BasePoint(200, 280, "axis2"));
            // Location in canvas
            setAxisX(100);
            setAxisY(100);
            // Line dimentions
            setAxisX1(100);
            setAxisY1(100);
            setAxisX2(200);
            setAxisY2(280);
        }

        public void setAxisX1(double pAxisX1)
        {
            axisX1 = pAxisX1;
        }

        public void setAxisY1(double pAxisY1)
        {
            axisY1 = pAxisY1;
        }

        public void setAxisX2(double pAxisX2)
        {
            axisX2 = pAxisX2;
        }

        public void setAxisY2(double pAxisY2)
        {
            axisY2 = pAxisY2;
        }

        public void setBasePoints(List<BasePoint> pBasePoints)
        {
            basePoints = pBasePoints;
        }

        public double getAxisX1()
        {
            return axisX1;
        }

        public double getAxisY1()
        {
            return axisY1;
        }

        public double getAxisX2()
        {
            return axisX2;
        }

        public double getAxisY2()
        {
            return axisY2;
        }

        public Line getLine()
        {
            return line;
        }

        public List<BasePoint> getBasePoints()
        {
            return this.basePoints;
        }

        public void addPoint(BasePoint pPoint)
        {
            basePoints.Add(pPoint);
        }

        public void drawLine(int pMode) /* 1= edit  2= arcade  3= fire */
        {
            if (pMode == 1)
                line.Stroke = Brushes.Black;
            else
                line.Stroke = new SolidColorBrush(getColor());

            line.StrokeThickness = getThickness();
            line.X1 = axisX1;
            line.Y1 =axisY1;
            line.X2 = axisX2;
            line.Y2 = axisY2;
        }
    }
}
