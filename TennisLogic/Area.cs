using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
