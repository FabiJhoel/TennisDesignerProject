using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisLibrary
{
    class Point
    {
        private double AxisX;
        private double AxisY;

        public Point(int pAxisX, int pAxisY)
        {
            setAxisX(pAxisX);
            setAxisY(pAxisY);
        }

        public void setAxisX(int pAxisX)
        {
            this.AxisX = pAxisX;
        }
        public void setAxisY(int pAxisY)
        {
            this.AxisY = pAxisY;
        }
        public double getAxisX()
        {
            return this.AxisX;
        }
        public double getAxisY()
        {
            return this.AxisY;
        }
    }
}
