using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using TennisBusiness;

namespace TennisLibrary
{
    public static class PaintManager
    {
        public static void createBasePoints(Design pDesign)
        {
            // Asign BasePoints to the new design
            if (pDesign.getBasePoints().Count == 0)
            {
                pDesign.addPoint(new BasePoint(156, 122, "pointA"));
                pDesign.addPoint(new BasePoint(352, 122, "pointB"));
                pDesign.addPoint(new BasePoint(457, 179, "pointC"));
                pDesign.addPoint(new BasePoint(516, 269, "pointD"));
                pDesign.addPoint(new BasePoint(156, 269, "pointE"));
            }
        }

        public static void loadBasePoints(Design pDesign, Canvas pCanvas)
        {
            // Draw each Basepoint on screen
            foreach (BasePoint point in pDesign.getBasePoints())
            {
                point.drawPoint();
                Canvas.SetLeft(point.getPointEllipse(), point.getAxisX());
                Canvas.SetTop(point.getPointEllipse(), point.getAxisY());
                pCanvas.Children.Add(point.getPointEllipse());
            }
        }

        public static void loadTennisSilhouette(Design pDesign, Canvas pCanvas)
        {
            // SegmentA: arc
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(30, 40);
            myPathFigure.Segments.Add(new ArcSegment(new Point(30, 190), new Size(50, 55),
                                        0, true, SweepDirection.Counterclockwise, true));

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);
                    
            pDesign.getSegmentA().getSegment().Stretch = Stretch.Fill;
            pDesign.getSegmentA().getSegment().Stroke = Brushes.Black;
            pDesign.getSegmentA().getSegment().StrokeThickness = 3;
            pDesign.getSegmentA().getSegment().Data = myPathGeometry;

            pDesign.getSegmentA().getSegmentContainer().Background = System.Windows.Media.Brushes.LightBlue;
            Canvas.SetLeft(pDesign.getSegmentA().getSegmentContainer(), pDesign.getSegmentA().getAxisX());
            Canvas.SetTop(pDesign.getSegmentA().getSegmentContainer(), pDesign.getSegmentA().getAxisY());
            pCanvas.Children.Add(pDesign.getSegmentA().getSegmentContainer());

            // SegmentB: arc
            PathFigure myPathFigureB = new PathFigure();
            myPathFigureB.StartPoint = new Point(30, 40);
            myPathFigureB.Segments.Add(new ArcSegment(new Point(227, 40), new Size(70, 30),
                                       0, true, SweepDirection.Counterclockwise, true));

            PathGeometry myPathGeometryB = new PathGeometry();
            myPathGeometryB.Figures.Add(myPathFigureB);

            pDesign.getSegmentB().getSegment().Stretch = Stretch.Fill;
            pDesign.getSegmentB().getSegment().Stroke = Brushes.Black;
            pDesign.getSegmentB().getSegment().StrokeThickness = 3;
            pDesign.getSegmentB().getSegment().Data = myPathGeometryB;

            pDesign.getSegmentB().getSegmentContainer().Background = System.Windows.Media.Brushes.LightBlue;
            Canvas.SetLeft(pDesign.getSegmentB().getSegmentContainer(), pDesign.getSegmentB().getAxisX());
            Canvas.SetTop(pDesign.getSegmentB().getSegmentContainer(), pDesign.getSegmentB().getAxisY());
            pCanvas.Children.Add(pDesign.getSegmentB().getSegmentContainer());

            // SegmentC: line
            pDesign.getSegmentC().X1 = pDesign.getBasePoints()[1].getAxisX() + 15;
            pDesign.getSegmentC().Y1 = pDesign.getBasePoints()[1].getAxisY() + 15;
            pDesign.getSegmentC().X2 = pDesign.getBasePoints()[2].getAxisX() + 15;
            pDesign.getSegmentC().Y2 = pDesign.getBasePoints()[2].getAxisY() + 15;
            pDesign.getSegmentC().Stroke = System.Windows.Media.Brushes.Black;
            pDesign.getSegmentC().StrokeThickness = 3;
            pCanvas.Children.Add(pDesign.getSegmentC());

            // SegmentD: line
            pDesign.getSegmentD().X1 = pDesign.getBasePoints()[2].getAxisX() + 15;
            pDesign.getSegmentD().Y1 = pDesign.getBasePoints()[2].getAxisY() + 15;
            pDesign.getSegmentD().X2 = pDesign.getBasePoints()[3].getAxisX() + 15;
            pDesign.getSegmentD().Y2 = pDesign.getBasePoints()[3].getAxisY() + 15;
            pDesign.getSegmentD().Stroke = System.Windows.Media.Brushes.Black;
            pDesign.getSegmentD().StrokeThickness = 3;
            pCanvas.Children.Add(pDesign.getSegmentD());

            // SegmentE: line
            pDesign.getSegmentE().X1 = pDesign.getBasePoints()[3].getAxisX() + 15;
            pDesign.getSegmentE().Y1 = pDesign.getBasePoints()[3].getAxisY() + 15;
            pDesign.getSegmentE().X2 = pDesign.getBasePoints()[4].getAxisX() + 15;
            pDesign.getSegmentE().Y2 = pDesign.getBasePoints()[4].getAxisY() + 15;
            pDesign.getSegmentE().Stroke = System.Windows.Media.Brushes.Black;
            pDesign.getSegmentE().StrokeThickness = 3;
            pCanvas.Children.Add(pDesign.getSegmentE());
        }
    }
}
