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
        private List<TimeSpan> arcadeTimes = new List<TimeSpan>();
        private List<TimeSpan> fireTimes = new List<TimeSpan>();
        private List<BasePoint> basePoints = new List<BasePoint>();
        private List<Circle> circleDecorations = new List<Circle>();
        private List<LineDec> lineDecorations = new List<LineDec>();
        private List<Area> fillingAreas = new List<Area>();
        private Decoration outline;
        private Decoration shoeSole;
        private Decoration baseColor;
        private Arc segmentA, segmentB;
        private Line segmentC, segmentD, segmentE;

        public Design(string pName)
        {
            segmentA = new Arc(100, 132, 71, 153);
            segmentB = new Arc(167, 132, 200, 45);
            segmentC = new Line();
            segmentD = new Line();
            segmentE = new Line(); 
            outline = new Decoration(3, 3, Color.FromArgb(255, 0, 0, 0));
            shoeSole = new Decoration(4, 3, Color.FromArgb(255, 0, 0, 0));
            baseColor = new Decoration(6, -1, Color.FromArgb(255, 255, 255, 255));
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

        public void setBaseColor(Decoration pBaseColor)
        {
            baseColor = pBaseColor;
        }

        public void setCircleDecoration(List<Circle> pCircles)
        {
            circleDecorations = pCircles;
        }

        public void setLineDecoration(List<LineDec> pLines)
        {
            lineDecorations = pLines;
        }

        public void setFillingAreas(List<Area> pAreas)
        {
            fillingAreas = pAreas;
        }

        public void setArcadeTimes(List<TimeSpan> pArcadeTimes)
        {
            arcadeTimes = pArcadeTimes;
        }

        public void setFireTimes(List<TimeSpan> pFireTimes)
        {
            fireTimes = pFireTimes;
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

        public List<Area> getFillingAreas()
        {
            return this.fillingAreas;
        }

        public List<TimeSpan> getArcadeTimes()
        {
            return arcadeTimes;
        }

        public List<TimeSpan> getFireTimes()
        {
            return fireTimes;
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

        public Decoration getBaseColor()
        {
            return baseColor;
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

        public void addAreaDecoration(Area pArea)
        {
            fillingAreas.Add(pArea);
        }

        public void addArcadeTime(TimeSpan pArcadeTime)
        {
            arcadeTimes.Add(pArcadeTime);
        }

        public void addFireTime(TimeSpan pFireTime)
        {
            fireTimes.Add(pFireTime);
        }
    }
}
