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
            pDesign.getSegmentA().getSegment().Stroke = new SolidColorBrush(pDesign.getOutline().getColor());
            pDesign.getSegmentA().getSegment().StrokeThickness = pDesign.getOutline().getThikness();
            pDesign.getSegmentA().getSegment().Data = myPathGeometry;

            //pDesign.getSegmentA().getSegmentContainer().Background = System.Windows.Media.Brushes.LightBlue;
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
            pDesign.getSegmentB().getSegment().Stroke = new SolidColorBrush(pDesign.getOutline().getColor());
            pDesign.getSegmentB().getSegment().StrokeThickness = pDesign.getOutline().getThikness();
            pDesign.getSegmentB().getSegment().Data = myPathGeometryB;
            
            //pDesign.getSegmentB().getSegmentContainer().Background = System.Windows.Media.Brushes.LightBlue;
            Canvas.SetLeft(pDesign.getSegmentB().getSegmentContainer(), pDesign.getSegmentB().getAxisX());
            Canvas.SetTop(pDesign.getSegmentB().getSegmentContainer(), pDesign.getSegmentB().getAxisY());
            pCanvas.Children.Add(pDesign.getSegmentB().getSegmentContainer());

            // SegmentC: line
            pDesign.getSegmentC().X1 = pDesign.getBasePoints()[1].getAxisX() + 15;
            pDesign.getSegmentC().Y1 = pDesign.getBasePoints()[1].getAxisY() + 15;
            pDesign.getSegmentC().X2 = pDesign.getBasePoints()[2].getAxisX() + 15;
            pDesign.getSegmentC().Y2 = pDesign.getBasePoints()[2].getAxisY() + 15;
            pDesign.getSegmentC().Stroke = new SolidColorBrush(pDesign.getOutline().getColor());
            pDesign.getSegmentC().StrokeThickness = pDesign.getOutline().getThikness();
            pCanvas.Children.Add(pDesign.getSegmentC());

            // SegmentD: line
            pDesign.getSegmentD().X1 = pDesign.getBasePoints()[2].getAxisX() + 15;
            pDesign.getSegmentD().Y1 = pDesign.getBasePoints()[2].getAxisY() + 15;
            pDesign.getSegmentD().X2 = pDesign.getBasePoints()[3].getAxisX() + 15;
            pDesign.getSegmentD().Y2 = pDesign.getBasePoints()[3].getAxisY() + 15;
            pDesign.getSegmentD().Stroke = new SolidColorBrush(pDesign.getOutline().getColor());
            pDesign.getSegmentD().StrokeThickness = pDesign.getOutline().getThikness();
            pCanvas.Children.Add(pDesign.getSegmentD());

            // SegmentE: line
            pDesign.getSegmentE().X1 = pDesign.getBasePoints()[3].getAxisX() + 15;
            pDesign.getSegmentE().Y1 = pDesign.getBasePoints()[3].getAxisY() + 15;
            pDesign.getSegmentE().X2 = pDesign.getBasePoints()[4].getAxisX() + 15;
            pDesign.getSegmentE().Y2 = pDesign.getBasePoints()[4].getAxisY() + 15;
            pDesign.getSegmentE().Stroke = new SolidColorBrush(pDesign.getShoeSole().getColor());
            pDesign.getSegmentE().StrokeThickness = pDesign.getShoeSole().getThikness();
            pDesign.getSegmentE().MouseLeftButtonDown += PaintManager_MouseLeftButtonDown; 
            pDesign.getSegmentE().MouseRightButtonDown += PaintManager_MouseRightButtonDown;
            pCanvas.Children.Add(pDesign.getSegmentE());
        }

        static void PaintManager_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ocultar");
        }

        static void PaintManager_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("mostrar");
        }

        public static void paintOutline(Design pDesign, Color pColor, int pThickness)
        {
            pDesign.getSegmentA().getSegment().Stroke = new SolidColorBrush(pColor);
            pDesign.getSegmentB().getSegment().Stroke = new SolidColorBrush(pColor);
            pDesign.getSegmentC().Stroke = new SolidColorBrush(pColor);
            pDesign.getSegmentD().Stroke = new SolidColorBrush(pColor);

            pDesign.getSegmentA().getSegment().StrokeThickness = pThickness;
            pDesign.getSegmentB().getSegment().StrokeThickness = pThickness;
            pDesign.getSegmentC().StrokeThickness = pThickness;
            pDesign.getSegmentD().StrokeThickness = pThickness;           
        }

        public static void paintShoeSole(Design pDesign, Color pColor, int pThickness)
        {
            //CONVERT STRING TO COLOR
           /* Color newColor = (Color)ColorConverter.ConvertFromString(pColor.ToString());
            pColor = newColor;*/

            pDesign.getSegmentE().Stroke = new SolidColorBrush(pColor);
            pDesign.getSegmentE().StrokeThickness = pThickness;       
        }

        public static void loadCircleDecorations()
        {

        }

        public static void PaintCircleDecoration(Canvas pCanvas, Circle circleDeco) 
        {
            circleDeco.drawCircle();
            Canvas.SetLeft(circleDeco.getEllipse(), circleDeco.getAxisX());
            Canvas.SetTop(circleDeco.getEllipse(), circleDeco.getAxisY());
            pCanvas.Children.Add(circleDeco.getEllipse());
        }

        static void decoLine_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        public static void arcadeMode(Design pDesign, Canvas pCanvas)
        {
            //loadTennisSilhouette(pDesign, pCanvas);

            Polygon myPolygon = new Polygon();
            myPolygon.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            myPolygon.StrokeThickness = 0;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(pDesign.getBasePoints()[0].getAxisX() + 8, pDesign.getBasePoints()[0].getAxisY() + 15);
            System.Windows.Point Point2 = new System.Windows.Point(pDesign.getBasePoints()[1].getAxisX(), pDesign.getBasePoints()[1].getAxisY() + 15);
            System.Windows.Point Point3 = new System.Windows.Point(pDesign.getBasePoints()[2].getAxisX() + 15, pDesign.getBasePoints()[2].getAxisY() + 15);
            System.Windows.Point Point4 = new System.Windows.Point(pDesign.getBasePoints()[3].getAxisX() + 15, pDesign.getBasePoints()[3].getAxisY() + 15);
            System.Windows.Point Point5 = new System.Windows.Point(pDesign.getBasePoints()[4].getAxisX() + 8, pDesign.getBasePoints()[4].getAxisY() + 15);

            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPointCollection.Add(Point5);
            myPolygon.Points = myPointCollection;
            pCanvas.Children.Add(myPolygon);

            Ellipse test = new Ellipse();
            test.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            test.StrokeThickness = 0;
            test.Width = pDesign.getSegmentA().getSegmentContainerWidth() * 2;
            test.Height = pDesign.getBasePoints()[4].getAxisY() - pDesign.getBasePoints()[0].getAxisY();
            Canvas.SetLeft(test, pDesign.getSegmentA().getAxisX());
            Canvas.SetTop(test, pDesign.getSegmentA().getAxisY() + 10);
            pCanvas.Children.Add(test);

            Ellipse test2 = new Ellipse();
            test2.Fill = System.Windows.Media.Brushes.White;
            test2.StrokeThickness = 0;
            test2.Width = pDesign.getBasePoints()[1].getAxisX() - pDesign.getBasePoints()[0].getAxisX();
            test2.Height = pDesign.getSegmentB().getSegmentContainerHeight() * 2;
            Canvas.SetLeft(test2, pDesign.getSegmentB().getAxisX());
            Canvas.SetTop(test2, pDesign.getSegmentB().getAxisY() - pDesign.getSegmentB().getSegmentContainerHeight());
            pCanvas.Children.Add(test2);
        }
    }
}
