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
        private string creationDate;
        private BasePoint[] shapePoints;
        private Decoration[] decorations;

        public Design(string pName)
        {
            setName(pName);
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
            shapePoints[shapePoints.Length - 1] = pPoint;
        }
        public void addDecoration(Decoration pFigure)
        {
            decorations[decorations.Length - 1] = pFigure;
        }
        public string getName()
        {
            return this.name;
        }
        public string getCreationDate()
        {
            return this.creationDate;
        }
    }
}
