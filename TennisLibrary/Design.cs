using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisLibrary
{
    public class Design
    {
        private string name;
        private MoveablePoint[] shapePoints;
        private Figure[] decorations;

        public Design(string pName)
        {
            setName(pName);
        }

        public void setName(string pName)
        {
            name = pName;
        }
        public void addPoint(MoveablePoint pPoint)
        {
            shapePoints[shapePoints.Length - 1] = pPoint;
        }
        public void addDecoration(Figure pFigure)
        {
            decorations[decorations.Length - 1] = pFigure;
        }
    }
}
