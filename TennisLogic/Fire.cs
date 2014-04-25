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

            //http://msdn.microsoft.com/en-us/library/vstudio/ms751808(v=vs.100).aspx
        }

        public static void paintOutline(Design pDesign, Canvas pCanvas)
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

            // Segments: C, D
            PathFigure pathFigOutline = new PathFigure();
            pathFigOutline.StartPoint = new Point(pointB.getAxisX() + 13, pointB.getAxisY() + 10);
            pathFigOutline.Segments.Add(new LineSegment(new Point(pointC.getAxisX() + 12, pointC.getAxisY() + 13), true));
            pathFigOutline.Segments.Add(new LineSegment(new Point(pointD.getAxisX() + 12, pointD.getAxisY() + 13), true));

            PathGeometry pathGeoOutline = new PathGeometry();
            pathGeoOutline.Figures.Add(pathFigOutline);

            Path outline = new Path();
            outline.Stroke = new SolidColorBrush(pDesign.getOutline().getColor());
            outline.StrokeThickness = pDesign.getOutline().getThickness();
            outline.Data = pathGeoOutline;

            pCanvas.Children.Add(outline);

            //SegmentA
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(30, 40);
            myPathFigure.Segments.Add(new ArcSegment(new Point(30, 190), new Size(50, 55),
                                        0, true, SweepDirection.Counterclockwise, true));

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);
            segmentA.getSegment().Stroke = new SolidColorBrush(pDesign.getOutline().getColor());
            segmentA.getSegment().Stretch = Stretch.Fill;
            segmentA.getSegment().StrokeThickness = pDesign.getOutline().getThickness();
            segmentA.getSegment().Data = myPathGeometry;

            Canvas.SetLeft(segmentA.getSegmentContainer(), segmentA.getAxisX());
            Canvas.SetTop(segmentA.getSegmentContainer(), segmentA.getAxisY() - 1);
            pCanvas.Children.Add(segmentA.getSegmentContainer());

            //SegmentB
            PathFigure myPathFigureB = new PathFigure();
            myPathFigureB.StartPoint = new Point(30, 40);
            myPathFigureB.Segments.Add(new ArcSegment(new Point(227, 40), new Size(70, 30),
                                       0, true, SweepDirection.Counterclockwise, true));

            PathGeometry myPathGeometryB = new PathGeometry();
            myPathGeometryB.Figures.Add(myPathFigureB);
            segmentB.getSegment().Stroke = new SolidColorBrush(pDesign.getOutline().getColor());
            segmentB.getSegment().Stretch = Stretch.Fill;
            segmentB.getSegment().StrokeThickness = pDesign.getOutline().getThickness();
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
                segmentB.setSegmentContainerWidth(segmentB.getSegmentContainerWidth() + 2);
            }

            Canvas.SetLeft(segmentB.getSegmentContainer(), segmentB.getAxisX() - variantX);
            Canvas.SetTop(segmentB.getSegmentContainer(), segmentB.getAxisY() - variantY);
            pCanvas.Children.Add(segmentB.getSegmentContainer());

            // Shoe Sole
            Line shoeSole = new Line();

            shoeSole.X1 = pointE.getAxisX() + 11;
            shoeSole.Y1 = pointE.getAxisY() + 13;
            shoeSole.X2 = pointD.getAxisX() + 12;
            shoeSole.Y2 = pointD.getAxisY() + 13;
            shoeSole.Stroke = new SolidColorBrush(pDesign.getShoeSole().getColor());
            shoeSole.StrokeThickness = pDesign.getShoeSole().getThickness();

            pCanvas.Children.Add(shoeSole);
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
 

        //private static void drawPolygon(PointCollection pPointCollection, Canvas pCanvas)
        //{
        //    Polygon polygon = new Polygon();
        //    polygon.Fill = System.Windows.Media.Brushes.LightSeaGreen;
        //    polygon.StrokeThickness = 0;
        //    polygon.HorizontalAlignment = HorizontalAlignment.Left;
        //    polygon.VerticalAlignment = VerticalAlignment.Center;

        //    polygon.Points = pPointCollection;
        //    pCanvas.Children.Add(polygon);
        //}

        //private static void drawEllipse(Canvas pCanvas, Brush pColor, double pWidth, double pHeight, double pAxisX, double pAxisY,
        //    int pThickness, SolidColorBrush pStroke)
        //{
        //    Ellipse ellipse = new Ellipse();
        //    ellipse.Fill = pColor;
        //    ellipse.Stroke = pStroke;
        //    ellipse.StrokeThickness = pThickness;
        //    ellipse.Width = pWidth;
        //    ellipse.Height = pHeight;
        //    Canvas.SetLeft(ellipse, pAxisX);
        //    Canvas.SetTop(ellipse, pAxisY);
        //    pCanvas.Children.Add(ellipse);
        //}

        //public static void loadDesign(Design pDesign, Canvas pCanvas)
        //{
        //    //Load basic form
        //    PointCollection points = new PointCollection();
        //    points.Add(new Point(pDesign.getBasePoints()[0].getAxisX() + 8, pDesign.getBasePoints()[0].getAxisY() + 15));
        //    points.Add(new Point(pDesign.getBasePoints()[1].getAxisX(), pDesign.getBasePoints()[1].getAxisY() + 15));
        //    points.Add(new Point(pDesign.getBasePoints()[2].getAxisX() + 15, pDesign.getBasePoints()[2].getAxisY() + 15));
        //    points.Add(new Point(pDesign.getBasePoints()[3].getAxisX() + 15, pDesign.getBasePoints()[3].getAxisY() + 15));
        //    points.Add(new Point(pDesign.getBasePoints()[4].getAxisX() + 8, pDesign.getBasePoints()[4].getAxisY() + 15));
        //    drawPolygon(points, pCanvas);

        //    //Load Internal Arc
        //    drawEllipse(pCanvas, Brushes.LightSeaGreen, pDesign.getSegmentA().getSegmentContainerWidth() * 2,
        //        pDesign.getBasePoints()[4].getAxisY() - pDesign.getBasePoints()[0].getAxisY(),
        //        pDesign.getSegmentA().getAxisX(), pDesign.getSegmentA().getAxisY() + 10, 0, null);

        //    //Load External Arc
        //    drawEllipse(pCanvas, Brushes.White, pDesign.getBasePoints()[1].getAxisX() - pDesign.getBasePoints()[0].getAxisX(),
        //        pDesign.getSegmentB().getSegmentContainerHeight() * 2, pDesign.getSegmentB().getAxisX(),
        //        pDesign.getSegmentB().getAxisY() - pDesign.getSegmentB().getSegmentContainerHeight(), 0, null);

        //    //Load ShoeSole
        //    Line shoeSole = new Line();
        //    shoeSole.X1 = pDesign.getBasePoints()[3].getAxisX() + 15;
        //    shoeSole.Y1 = pDesign.getBasePoints()[3].getAxisY() + 15;
        //    shoeSole.X2 = pDesign.getBasePoints()[4].getAxisX() + 8;
        //    shoeSole.Y2 = pDesign.getBasePoints()[4].getAxisY() + 15;
        //    shoeSole.Stroke = new SolidColorBrush(pDesign.getShoeSole().getColor());
        //    shoeSole.StrokeThickness = pDesign.getShoeSole().getThickness();
        //    pCanvas.Children.Add(shoeSole);

        //    //Load Circle Decorations
        //    foreach (Circle circleDecoration in pDesign.getCircleDecorations())
        //    {
        //        double width;
        //        double height;
        //        if (circleDecoration.getSize() == 0) /* Small */
        //            width = height = 27;

        //        else if (circleDecoration.getSize() == 1) /* Medium */
        //            width = height = 64;

        //        else /* Large */
        //            width = height = 110;

        //        SolidColorBrush filling;
        //        if (circleDecoration.getFilled())
        //            filling = new SolidColorBrush(circleDecoration.getColor());
        //        else
        //            filling = Brushes.Transparent;

        //        drawEllipse(pCanvas, filling, width, height, circleDecoration.getAxisX(), circleDecoration.getAxisY(),
        //            circleDecoration.getThickness(), new SolidColorBrush(circleDecoration.getColor()));


        //    }
//        }
    }
}

