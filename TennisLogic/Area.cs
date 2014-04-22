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
        Rectangle rect = new Rectangle();
        public Area(Color pColor, double pAxisX, double pAxisY)
            : base(5, -1, pColor)
        {
            setAxisX(pAxisX);
            setAxisY(pAxisY);
        }

        public Rectangle getRectangle()
        {
            return rect;
        }

        public void drawArea()
        {
            rect.Width = 15;
            rect.Height = 15;
            rect.Fill = new SolidColorBrush(this.getColor());
        }  
    }
}
