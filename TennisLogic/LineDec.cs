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
        private double axisX2;
        private double axisY2;
        private Line line;

        public LineDec(int pThikness, Color pColor)
                        : base(0, pThikness, pColor)
        {
            line = new Line();
            setAxisX(100);
            setAxisY(100);
            setAxisX2(200);
            setAxisY2(280);
        }

        public void setAxisX2(double pAxisX2)
        {
            axisX2 = pAxisX2;
        }

        public void setAxisY2(double pAxisY2)
        {
            axisY2 = pAxisY2;
        }

        public double getAxisX2()
        {
            return axisX2;
        }

        public double getAxisY2()
        {
            return this.axisY2;
        }

        public Line getLine()
        {
            return line;
        }

        public void drawLine()
        {
            line.Stroke = new SolidColorBrush(getColor());
            line.StrokeThickness = getThikness();
            line.X1 = getAxisX();
            line.Y1 = getAxisY();
            line.X2 = getAxisX2();
            line.Y2 = getAxisY2();
        }
    }
}
