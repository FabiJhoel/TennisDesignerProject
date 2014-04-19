using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace TennisBusiness
{
    public class Decoration
    {
        private int type; /* 0= Line  1= Circle  2= Filled Circle  3= Outline  4= Shoe Sole */
        private int thickness;
        private double axisX;
        private double axisY;
        private Color color;
        private Label remarks;

        public Decoration(int pType, int pThickness, Color pColor)
        {
            setType(pType);
            setThickness(pThickness);
            setColor(pColor);
        }

        public void setAxisX(double pAxisX)
        {
            this.axisX = pAxisX;
        }

        public void setAxisY(double pAxisY)
        {
            this.axisY = pAxisY;
        }

        public void setType(int pType)
        {
            this.type = pType;
        }

        public void setThickness(int pThikness)
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

        public int getThickness()
        {
            return this.thickness;
        }

        public Color getColor()
        {
            return this.color;
        }

        public double getAxisX()
        {
            return this.axisX;
        }

        public double getAxisY()
        {
            return this.axisY;
        }
    }
}
