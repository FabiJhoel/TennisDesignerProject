using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace TennisBusiness
{
    public class Design
    {
        private string name;
        private string creationDate;
        private List<BasePoint> basePoints = new List<BasePoint>();
        private List<Decoration> decorations = new List<Decoration>();
        Path segmentA, segmentB;
        Grid segmentAContainer, segmentBContainer;
        Line segmentC, segmentD, segmentE;

        public Design(string pName)
        {
            setName(pName);
            setCreationDate(DateTime.Now.ToString("M/d/yyyy"));
            segmentA = new Path();
            segmentAContainer = new Grid();
            segmentAContainer.Children.Add(getSegmentA());
            segmentB = new Path();
            segmentBContainer = new Grid();
            segmentBContainer.Children.Add(getSegmentB());
            segmentC = new Line();
            segmentD = new Line();
            segmentE = new Line();
        }

        public void setName(string pName)
        {
            name = pName;
        }

        public void setCreationDate(string pDate)
        {
            creationDate = pDate;
        }

        public void addPoint(BasePoint pPoint)
        {
            basePoints.Add(pPoint);
        }

        public void addDecoration(Decoration pFigure)
        {
            decorations.Add(pFigure);
        }

        public string getName()
        {
            return this.name;
        }

        public string getCreationDate()
        {
            return this.creationDate;
        }

        public List<BasePoint> getBasePoints()
        {
            return this.basePoints;
        }

        public List<Decoration> getDecorations()
        {
            return this.decorations;
        }

        public Path getSegmentA()
        {
            return segmentA;
        }

        public Grid getSegmentAContainer()
        {
            return segmentAContainer;
        }

        public Path getSegmentB()
        {
            return segmentB;
        }

        public Grid getSegmentBContainer()
        {
            return segmentBContainer;
        }

        public Line getSegmentC()
        {
            return segmentC;
        }

        public Line getSegmentD()
        {
            return segmentD;
        }

        public Line getSegmentE()
        {
            return segmentE;
        }
    }
}
