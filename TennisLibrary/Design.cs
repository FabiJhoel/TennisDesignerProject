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
        private List<BasePoint> basePoints = new List<BasePoint>();
        private List<Decoration> decorations = new List<Decoration>();

        public Design(string pName)
        {
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
    }
}
