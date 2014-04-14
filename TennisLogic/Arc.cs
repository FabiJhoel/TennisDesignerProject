using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace TennisBusiness
{
    public class Arc
    {
        private double AxisX;
        private double AxisY;
        Path segment;
        Grid segmentContainer;

        public Arc(double pAxisX, double pAxisY)
        {
            segment = new Path();
            segmentContainer = new Grid();
            segmentContainer.Children.Add(getSegment());
            setAxisX(pAxisX);
            setAxisY(pAxisY);
        }

        public void setAxisX(double pAxisX)
        {
            this.AxisX = pAxisX;
        }

        public double getAxisX()
        {
            return this.AxisX;
        }

        public void setAxisY(double pAxisY)
        {
            this.AxisY = pAxisY;
        }

        public double getAxisY()
        {
            return this.AxisY;
        }

        public void setSegmentContainerWidth(double pWidth)
        {
            segmentContainer.Width = pWidth;
        }

        public double getSegmentContainerWidth()
        {
            return segmentContainer.ActualWidth;
        }

        public void setSegmentContainerHeight(double pHeight)
        {
            segmentContainer.Height = pHeight;
        }

        public double getSegmentContainerHeight()
        {
            return segmentContainer.ActualHeight;
        }

        public Path getSegment()
        {
            return segment;
        }

        public Grid getSegmentContainer()
        {
            return segmentContainer;
        }

    }
}
