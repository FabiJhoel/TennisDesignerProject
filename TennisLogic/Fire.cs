using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace TennisBusiness
{
    public static class Fire
    {
        public static void paintBackground(Design pDesign, Canvas pCanvas)
        {
            int variantY = 0;
            int variantX = 0;
            Arc segmentA = new Arc(pDesign.getSegmentA().getAxisX(), 
                                   pDesign.getSegmentA().getAxisY(), 
                                   pDesign.getSegmentA().getSegmentContainerWidth(), 
                                   pDesign.getSegmentA().getSegmentContainerHeight());

            Arc segmentB = new Arc(pDesign.getSegmentB().getAxisX(),
                                   pDesign.getSegmentB().getAxisY(),
                                   pDesign.getSegmentB().getSegmentContainerWidth(),
                                   pDesign.getSegmentB().getSegmentContainerHeight());
            
            BasePoint pointA = pDesign.getBasePoints()[0];
            BasePoint pointB = pDesign.getBasePoints()[1];
            BasePoint pointC = pDesign.getBasePoints()[2];
            BasePoint pointD = pDesign.getBasePoints()[3];
            BasePoint pointE = pDesign.getBasePoints()[4];

            // Polygon: Segments C, D, E
            PathFigure myPathFigureD = new PathFigure();
            myPathFigureD.StartPoint = new Point(pointA.getAxisX() + 8, pointA.getAxisY() + 12);
            myPathFigureD.Segments.Add(new LineSegment(new Point(pointB.getAxisX() + 14, pointB.getAxisY() + 12), true));
            myPathFigureD.Segments.Add(new LineSegment(new Point(pointC.getAxisX() + 12, pointC.getAxisY() + 13), true));
            myPathFigureD.Segments.Add(new LineSegment(new Point(pointD.getAxisX() + 12, pointD.getAxisY() + 13), true));
            myPathFigureD.Segments.Add(new LineSegment(new Point(pointE.getAxisX() + 8, pointE.getAxisY() + 14), true));
            myPathFigureD.Segments.Add(new LineSegment(new Point(pointA.getAxisX() + 8, pointA.getAxisY() + 12), true));

            PathGeometry myPathGeometryD = new PathGeometry();
            myPathGeometryD.Figures.Add(myPathFigureD);

            Path polygon = new Path();
            polygon.Fill = new SolidColorBrush(pDesign.getBaseColor().getColor());
            polygon.Data = myPathGeometryD;

            pCanvas.Children.Add(polygon);

            // Arc SegmentA
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(30, 40);
            myPathFigure.Segments.Add(new ArcSegment(new Point(30, 190), new Size(50, 55),
                                        0, true, SweepDirection.Counterclockwise, true));

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);
            segmentA.getSegment().Stretch = Stretch.Fill;
            segmentA.getSegment().Fill = new SolidColorBrush(pDesign.getBaseColor().getColor());
            segmentA.getSegment().Data = myPathGeometry;

            Canvas.SetLeft(segmentA.getSegmentContainer(), segmentA.getAxisX());
            Canvas.SetTop(segmentA.getSegmentContainer(), segmentA.getAxisY() - 1);
            pCanvas.Children.Add(segmentA.getSegmentContainer());

            // Arc SegmentB
            PathFigure myPathFigureB = new PathFigure();
            myPathFigureB.StartPoint = new Point(30, 40);
            myPathFigureB.Segments.Add(new ArcSegment(new Point(227, 40), new Size(70, 30),
                                       0, true, SweepDirection.Counterclockwise, true));

            PathGeometry myPathGeometryB = new PathGeometry();
            myPathGeometryB.Figures.Add(myPathFigureB);
            segmentB.getSegment().Stretch = Stretch.Fill;
            segmentB.getSegment().Fill = Brushes.White;
            segmentB.getSegment().Data = myPathGeometryB;

            if (pDesign.getOutline().getThickness() == 8)
            {
                variantY = 5;
                variantX = 5;
                segmentB.setSegmentContainerWidth(segmentB.getSegmentContainerWidth() + 9);
            }

            else
            {
                variantY = 2;
                variantX = 0;
                segmentB.setSegmentContainerWidth(segmentB.getSegmentContainerWidth() + 1);
            }

            Canvas.SetLeft(segmentB.getSegmentContainer(), segmentB.getAxisX() - variantX);
            Canvas.SetTop(segmentB.getSegmentContainer(), segmentB.getAxisY() - variantY);
            pCanvas.Children.Add(segmentB.getSegmentContainer());                      
        }

        public static void paintLine(Line pLine, Color pColor)
        {
            pLine.Stroke = new SolidColorBrush(pColor);
        }

        public static void paintCircle(Ellipse pEllipse, Color pColor, bool pFilled)
        {
            if (pFilled)
                pEllipse.Fill = new SolidColorBrush(pColor);

            else
                pEllipse.Stroke = new SolidColorBrush(pColor);
        }

        public static void paintArea(PointCollection pPointCollection, Canvas pCanvas, SolidColorBrush pColor)
        {
            Polygon polygon = new Polygon();
            polygon.Fill = pColor;
            polygon.StrokeThickness = 0;
            polygon.HorizontalAlignment = HorizontalAlignment.Left;
            polygon.VerticalAlignment = VerticalAlignment.Center;

            polygon.Points = pPointCollection;
            pCanvas.Children.Add(polygon);
        }

        //http://www.navision-blog.de/blog/2008/12/02/calculate-the-intersection-of-two-lines-in-fsharp-2d/
        //http://stackoverflow.com/questions/4543506/algorithm-for-intersection-of-2-lines
        public static List<BasePoint> calculateIntersections(List<BasePoint[]> lines, Canvas pCanvas, int mode) //0 = all intersections
        {                                                                                                         //1 = intersections with a particular line
            List<BasePoint> intersections = new List<BasePoint>();

            //calculate intersections
            double delta;
            double r;
            double s;
            double IntX;
            double IntY;
            double aY, aX, bY, bX, cY, cX, dY, dX;
            Line test;

            foreach (BasePoint[] pLine in lines)
            {
                /*test = new Line();
                test.Stroke = Brushes.Black;
                test.StrokeThickness = 8;
                test.X1 = pLine[0].getAxisX() + 5;
                test.Y1 = pLine[0].getAxisY() + 5;
                test.X2 = pLine[1].getAxisX() + 5;
                test.Y2 = pLine[1].getAxisY() + 5;
                pCanvas.Children.Add(test);*/

                foreach (BasePoint[] qLine in lines)
                {
                    if (!pLine.Equals(qLine))
                    {
                        aX = pLine[0].getAxisX();
                        aY = pLine[0].getAxisY();
                        bX = pLine[1].getAxisX();
                        bY = pLine[1].getAxisY();
                        cX = qLine[0].getAxisX();
                        cY = qLine[0].getAxisY();
                        dX = qLine[1].getAxisX();
                        dY = qLine[1].getAxisY();

                        delta = (bX - aX) * (dY - cY) - (bY - aY) * (dX - cX); //A1*B2 - A2*B1

                        if (delta != 0)
                        {
                            r = ((aY - cY) * (dX - cX) - (aX - cX) * (dY - cY)) / delta;

                            s = ((aY - cY) * (bX - aX) - (aX - cX) * (bY - aY)) / delta;

                            if (r >= 0 && r <= 1 && s >= 0 && s <= 1)
                            {
                                IntX = aX + r * (bX - aX);
                                IntY = aY + r * (bY - aY);
                                intersections.Add(new BasePoint(Math.Round(IntX, 5), Math.Round(IntY, 5), "")); //+9 Ajuste de Intersecciones
                            }
                        }
                    }
                }

                if (mode == 1)
                    break;
            }

            //Delete repeated items
            int index = 0;
            int index2 = 0;
            while (index < intersections.Count)
            {
                index2 = index + 1;
                while (index2 < intersections.Count)
                {
                    if (intersections[index].getAxisX() == intersections[index2].getAxisX() &&
                        intersections[index].getAxisY() == intersections[index2].getAxisY())
                    {
                        intersections.RemoveAt(index2);
                    }
                    else
                    {
                        /*MessageBox.Show("Puntos: " + intersections[index].getAxisX() + " " + intersections[index].getAxisY() + "\n"+
                            intersections[index2].getAxisX() + " " + intersections[index2].getAxisY()+
                            "\nDiferencias " + (intersections[index].getAxisX() - intersections[index2].getAxisX()) +
                            "  "+(intersections[index].getAxisY() - intersections[index2].getAxisY()));*/
                        index2++;
                    }
                        
                }
                index++;
            }

            return intersections;
        }
    }
}

