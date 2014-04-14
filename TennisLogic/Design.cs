﻿using System;
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
            segmentA = new Arc(100, 132, 71, 153);
            segmentB = new Arc(165, 132, 200, 45);
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
        
        public void addPoint(BasePoint pPoint)
        {
            basePoints.Add(pPoint);
        }
        public void addDecoration(Decoration pFigure)
        {
            decorations.Add(pFigure);
        }
    }
}
