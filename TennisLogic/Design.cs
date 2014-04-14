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
        private Arc segmentA, segmentB;
        private Line segmentC, segmentD, segmentE;

        public Design(string pName)
        {
            segmentA = new Arc(100, 132);
            segmentB = new Arc(165, 132);
            segmentC = new Line();
            segmentD = new Line();
            segmentE = new Line();
            setName(pName);
            setCreationDate(DateTime.Now.ToString("M/d/yyyy"));
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

        public Arc getSegmentA()
        {
            return segmentA;
        }

        public void setSegmentA(Arc pSegmentA)
        {
            segmentA = pSegmentA;
        }

       /* public Grid getSegmentAContainer()
        {
            return segmentAContainer;
        }*/

        public Arc getSegmentB()
        {
            return segmentB;
        }

        public void setSegmentB(Arc pSegmentB)
        {
            segmentA = pSegmentB;
        }

        /*public Grid getSegmentBContainer()
        {
            return segmentBContainer;
        }*/

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
