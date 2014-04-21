using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace TennisBusiness
{
    public class Area : Decoration
    {
        Polygon triangle;

        public Area(Color pColor, double pAxisX, double pAxisY)
            : base(5, -1, pColor)
        {
            triangle = new Polygon();
            setAxisX(pAxisX);
            setAxisY(pAxisY);
        }

        public void drawArea()
        {
            PointCollection points = new PointCollection();
            points.Add(new Point(getAxisX(), getAxisY()+10));
            points.Add(new Point(getAxisX() - 5, getAxisY()));
            points.Add(new Point(getAxisX() + 5, getAxisY()));

            triangle.Points = points;

            //triangle.StrokeThickness = 2;
            triangle.Stroke = Brushes.Black;
            triangle.Fill = new SolidColorBrush(this.getColor());
            /*triangle.HorizontalAlignment = HorizontalAlignment.Left;
            triangle.VerticalAlignment = VerticalAlignment.Center;*/
        }

        public Polygon getTriangle()
        {
            return triangle;
        }
    }
}
