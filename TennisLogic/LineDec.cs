using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace TennisBusiness
{
    public class LineDec : Decoration
    {
        private Line line;
        private List<BasePoint> basePoints = new List<BasePoint>();

        public LineDec(int pThikness, Color pColor)
                        : base(0, pThikness, pColor)
        {
            line = new Line();
            addPoint(new BasePoint(215, 145, "axis1"));
            addPoint(new BasePoint(315, 245, "axis2"));
        }

        public void setBasePoints(List<BasePoint> pBasePoints)
        {
            basePoints = pBasePoints;
        }

        public Line getLine()
        {
            return line;
        }

        public List<BasePoint> getBasePoints()
        {
            return this.basePoints;
        }

        public void addPoint(BasePoint pPoint)
        {
            basePoints.Add(pPoint);
        }

        public void drawLine(int pMode) /* 1= edit  2= arcade  3= fire */
        {
            if (pMode == 1)
                line.Stroke = Brushes.Black;
            else
                line.Stroke = new SolidColorBrush(getColor());

            line.StrokeThickness = getThickness();
        }
    }
}
