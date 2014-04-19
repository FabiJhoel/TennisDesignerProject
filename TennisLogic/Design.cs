using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;

namespace TennisBusiness
{
    public class Design
    {
        private string name;
        private string creationDate;
        private List<BasePoint> basePoints = new List<BasePoint>();
        private List<Circle> circleDecorations = new List<Circle>();
        private List<LineDec> lineDecorations = new List<LineDec>();
        private Decoration outline;
        private Decoration shoeSole;
        private Arc segmentA, segmentB;
        private Line segmentC, segmentD, segmentE;

        public Design(string pName)
        {
            segmentA = new Arc(100, 132, 71, 153);
            segmentB = new Arc(165, 132, 200, 45);
            segmentC = new Line();
            segmentD = new Line();
            segmentE = new Line(); 
            outline = new Decoration(3, 3, Color.FromArgb(255, 0, 0, 0));
            shoeSole = new Decoration(4, 3, Color.FromArgb(255, 0, 0, 0));
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
        public void setBasePoints(List<BasePoint> pBasePoints)
        {
            basePoints = pBasePoints;
        }
        public void setSegmentA(Arc pSegmentA)
        {
            segmentA = pSegmentA;
        }
        public void setSegmentB(Arc pSegmentB)
        {
            segmentB = pSegmentB;
        }
        public void setShoeSole(Decoration pShoeSole)
        {
            shoeSole = pShoeSole;
        }
        public void setOutline(Decoration pOutline)
        {
            outline = pOutline;
        }
        public void setCircleDecoration(List<Circle> pCircles)
        {
            circleDecorations = pCircles;
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
        public List<Circle> getCircleDecorations()
        {
            return this.circleDecorations;
        }
        public List<LineDec> getLineDecorations()
        {
            return this.lineDecorations;
        }
        public Arc getSegmentA()
        {
            return segmentA;
        }
        public Arc getSegmentB()
        {
            return segmentB;
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
        public Decoration getOutline()
        {
            return outline;
        }
        public Decoration getShoeSole()
        {
            return shoeSole;
        }
        
        public void addPoint(BasePoint pPoint)
        {
            basePoints.Add(pPoint);
        }
        public void addCircleDecoration(Circle pCircle)
        {
            circleDecorations.Add(pCircle);
        }
        public void addLineDecoration(LineDec pLine)
        {
            lineDecorations.Add(pLine);
        }
    }
}
