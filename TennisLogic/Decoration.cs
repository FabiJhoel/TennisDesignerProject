using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisBusiness
{
    public class Decoration
    {
        private int type;
        private int thikness;
        private string color;

        public Decoration(int pType, int pThikness, string pColor)
        {
            setType(pType);
            setThikness(pThikness);
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
            this.thikness = pThikness;
        }
        public void setColor(string pColor)
        {
            this.color = pColor;
        }
        public int getType()
        {
            return this.type;
        }
        public int getThikness()
        {
            return this.thikness;
        }
        public string getColor()
        {
            return this.color;
        }
    }
}
