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
        public static void loadBasePoints(Design pDesign, Canvas pCanvas)
        {
            // Asign BasePoints to the new design
            pDesign.addPoint(new BasePoint(156, 122, "pointA"));
            pDesign.addPoint(new BasePoint(352, 122, "pointB"));
            pDesign.addPoint(new BasePoint(457, 179, "pointC"));
            pDesign.addPoint(new BasePoint(516, 269, "pointD"));
            pDesign.addPoint(new BasePoint(156, 269, "pointE"));

            // Draw each Basepoint on screen
            foreach (BasePoint point in pDesign.getBasePoints())
            {
                point.drawPoint();
                Canvas.SetLeft(point.getPointEllipse(), point.getAxisX());
                Canvas.SetTop(point.getPointEllipse(), point.getAxisY());
                pCanvas.Children.Add(point.getPointEllipse());
            }
        }

        public static void removeBasePoints(Design pDesign, Canvas pCanvas)
        {
            foreach (BasePoint point in pDesign.getBasePoints())
            {
                pCanvas.Children.Remove(point.getPointEllipse());
            }
        }

        public static void loadTennisSilhouette(Design pDesign, Canvas pCanvas)
        {
            //Grid segmentAContainer;
            
            // SegmentA: arc
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(30, 40);
            myPathFigure.Segments.Add(new ArcSegment(new Point(30, 190), new Size(50, 55),
                                        0, true, SweepDirection.Counterclockwise, true));

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);

            pDesign.getSegmentA().Height = Double.NaN;
            pDesign.getSegmentA().Width = Double.NaN;
            pDesign.getSegmentA().Stretch = Stretch.Fill;
            pDesign.getSegmentA().Stroke = Brushes.Black;
            pDesign.getSegmentA().StrokeThickness = 3;
            pDesign.getSegmentA().Data = myPathGeometry;

            ////////////////////////////
            Canvas.SetLeft(pDesign.getSegmentAContainer(), 100);
            Canvas.SetTop(pDesign.getSegmentAContainer(), 132);
            pCanvas.Children.Add(pDesign.getSegmentAContainer());
            /////////////////////////////

            /*Canvas.SetLeft(pDesign.getSegmentA(), 100);
            Canvas.SetTop(pDesign.getSegmentA(), 132);
            pCanvas.Children.Add(pDesign.getSegmentA());*/

            // SegmentB: arc
            PathFigure myPathFigureB = new PathFigure();
            myPathFigureB.StartPoint = new Point(30, 40);
            myPathFigureB.Segments.Add(new ArcSegment(new Point(227, 40), new Size(70, 30),
                                       0, true, SweepDirection.Counterclockwise, true));

            PathGeometry myPathGeometryB = new PathGeometry();
            myPathGeometryB.Figures.Add(myPathFigureB);

            pDesign.getSegmentB().Height = Double.NaN;
            pDesign.getSegmentB().Width = Double.NaN;
            pDesign.getSegmentB().Stretch = Stretch.Fill;
            pDesign.getSegmentB().Stroke = Brushes.Black;
            pDesign.getSegmentB().StrokeThickness = 3;
            pDesign.getSegmentB().Data = myPathGeometryB;

            pDesign.getSegmentBContainer().Background = System.Windows.Media.Brushes.LightBlue;
            Canvas.SetLeft(pDesign.getSegmentBContainer(), 165);
            Canvas.SetTop(pDesign.getSegmentBContainer(), 132);
            pCanvas.Children.Add(pDesign.getSegmentBContainer());

           /* Canvas.SetLeft(pDesign.getSegmentB(), 165);
            Canvas.SetTop(pDesign.getSegmentB(), 132);
            pCanvas.Children.Add(pDesign.getSegmentB());*/

            // SegmentC: line
            pDesign.getSegmentC().X1 = 365;
            pDesign.getSegmentC().Y1 = 135;
            pDesign.getSegmentC().X2 = 470;
            pDesign.getSegmentC().Y2 = 193;
            pDesign.getSegmentC().Stroke = System.Windows.Media.Brushes.Black;
            pDesign.getSegmentC().StrokeThickness = 3;
            pCanvas.Children.Add(pDesign.getSegmentC());

            // SegmentD: line
            pDesign.getSegmentD().X1 = 470;
            pDesign.getSegmentD().Y1 = 193;
            pDesign.getSegmentD().X2 = 530;
            pDesign.getSegmentD().Y2 = 285;
            pDesign.getSegmentD().Stroke = System.Windows.Media.Brushes.Black;
            pDesign.getSegmentD().StrokeThickness = 3;
            pCanvas.Children.Add(pDesign.getSegmentD());

            // SegmentE: line
            pDesign.getSegmentE().X1 = 530;
            pDesign.getSegmentE().Y1 = 285;
            pDesign.getSegmentE().X2 = 165;
            pDesign.getSegmentE().Y2 = 285;
            pDesign.getSegmentE().Stroke = System.Windows.Media.Brushes.Black;
            pDesign.getSegmentE().StrokeThickness = 3;
            pCanvas.Children.Add(pDesign.getSegmentE());
        }

        
    }
}
