using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisLibrary
{
    class Figure
    {
        private int type;
        private int thikness;
        private ConsoleColor color;

        public Figure(int pType, int pThikness, ConsoleColor pColor)
        {
            setType(pType);
            setThikness(pThikness);
            setColor(pColor);
        }

        public Point[] plot(int pAxisX, int pAxisY)
        {
            Point[] points = new Point[1];
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
        public void setColor(ConsoleColor pColor)
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
        public ConsoleColor getColor()
        {
            return this.color;
        }
    }
}
