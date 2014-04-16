using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TennisBusiness
{
    public class Decoration
    {
        private int type; /* 0= Line  1= Circle  2= Filled Circle  3= Outline  4= Shoe Sole */
        private int thickness;
        private Color color;

        public Decoration(int pType, int pThickness, Color pColor)
        {
            setType(pType);
            setThikness(pThickness);
            setColor(pColor);
        }

        public BasePoint[] plot(int pAxisX, int pAxisY)
        {
            BasePoint[] points = new BasePoint[1];
            return points;
        }

        public void setType(int pType)
        {
            this.type = pType;
        }

        public void setThikness(int pThikness)
        {
            this.thickness = pThikness;
        }

        public void setColor(Color pColor)
        {
            this.color = pColor;
        }

        public int getType()
        {
            return this.type;
        }

        public int getThikness()
        {
            return this.thickness;
        }

        public Color getColor()
        {
            return this.color;
        }
    }
}
