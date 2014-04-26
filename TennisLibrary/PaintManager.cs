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
using System.Diagnostics;
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
                point.drawPoint(1);
                Canvas.SetLeft(point.getPointEllipse(), point.getAxisX());
                Canvas.SetTop(point.getPointEllipse(), point.getAxisY());
                pCanvas.Children.Add(point.getPointEllipse());
            }
        }

        public static void loadTennisSilhouette(Design pDesign, Canvas pCanvas, int pMode)
        {
            SolidColorBrush outlineColor = new SolidColorBrush();
            SolidColorBrush shoeSoleColor = new SolidColorBrush();

            if (pMode == 1)
            {
                outlineColor.Color = Color.FromArgb(255, 0, 0, 0);
                shoeSoleColor.Color = Color.FromArgb(255, 0, 0, 0);
            }

            else
            {
                outlineColor.Color = pDesign.getOutline().getColor();
                shoeSoleColor.Color = pDesign.getShoeSole().getColor();
            }

            // SegmentA: arc
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(30, 40);
            myPathFigure.Segments.Add(new ArcSegment(new Point(30, 190), new Size(50, 55),
                                        0, true, SweepDirection.Counterclockwise, true));

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);
            pDesign.getSegmentA().getSegment().Stroke = outlineColor;
            pDesign.getSegmentA().getSegment().Stretch = Stretch.Fill;
            pDesign.getSegmentA().getSegment().StrokeThickness = pDesign.getOutline().getThickness();
            pDesign.getSegmentA().getSegment().Data = myPathGeometry;

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
            pDesign.getSegmentB().getSegment().Stroke = outlineColor;
            pDesign.getSegmentB().getSegment().StrokeThickness = pDesign.getOutline().getThickness();
            pDesign.getSegmentB().getSegment().Data = myPathGeometryB;
            
            Canvas.SetLeft(pDesign.getSegmentB().getSegmentContainer(), pDesign.getSegmentB().getAxisX());
            Canvas.SetTop(pDesign.getSegmentB().getSegmentContainer(), pDesign.getSegmentB().getAxisY());
            pCanvas.Children.Add(pDesign.getSegmentB().getSegmentContainer());

            // SegmentC: line
            pDesign.getSegmentC().X1 = pDesign.getBasePoints()[1].getAxisX() + 13;
            pDesign.getSegmentC().Y1 = pDesign.getBasePoints()[1].getAxisY() + 12;
            pDesign.getSegmentC().X2 = pDesign.getBasePoints()[2].getAxisX() + 15;
            pDesign.getSegmentC().Y2 = pDesign.getBasePoints()[2].getAxisY() + 15;
            pDesign.getSegmentC().Stroke = outlineColor;
            pDesign.getSegmentC().StrokeThickness = pDesign.getOutline().getThickness();
            pCanvas.Children.Add(pDesign.getSegmentC());

            // SegmentD: line
            pDesign.getSegmentD().X1 = pDesign.getBasePoints()[2].getAxisX() + 15;
            pDesign.getSegmentD().Y1 = pDesign.getBasePoints()[2].getAxisY() + 15;
            pDesign.getSegmentD().X2 = pDesign.getBasePoints()[3].getAxisX() + 15;
            pDesign.getSegmentD().Y2 = pDesign.getBasePoints()[3].getAxisY() + 15;
            pDesign.getSegmentD().Stroke = outlineColor;
            pDesign.getSegmentD().StrokeThickness = pDesign.getOutline().getThickness();
            pCanvas.Children.Add(pDesign.getSegmentD());

            // SegmentE: line
            pDesign.getSegmentE().X1 = pDesign.getBasePoints()[3].getAxisX() + 15;
            pDesign.getSegmentE().Y1 = pDesign.getBasePoints()[3].getAxisY() + 14;
            pDesign.getSegmentE().X2 = pDesign.getBasePoints()[4].getAxisX() + 13;
            pDesign.getSegmentE().Y2 = pDesign.getBasePoints()[4].getAxisY() + 15;
            pDesign.getSegmentE().Stroke = shoeSoleColor;
            pDesign.getSegmentE().StrokeThickness = pDesign.getShoeSole().getThickness();
            pCanvas.Children.Add(pDesign.getSegmentE());

            //Remarks
            Canvas.SetLeft(pDesign.getShoeSole().getRemarks(), 15);
            Canvas.SetTop(pDesign.getShoeSole().getRemarks(), 405);
            pCanvas.Children.Add(pDesign.getShoeSole().getRemarks());

            Canvas.SetLeft(pDesign.getOutline().getRemarks(), 115);
            Canvas.SetTop(pDesign.getOutline().getRemarks(), 405);
            pCanvas.Children.Add(pDesign.getOutline().getRemarks());

            Canvas.SetLeft(pDesign.getBaseColor().getRemarks(), 215);
            Canvas.SetTop(pDesign.getBaseColor().getRemarks(), 405);
            pCanvas.Children.Add(pDesign.getBaseColor().getRemarks());

            //http://msdn.microsoft.com/en-us/library/vstudio/ms751808(v=vs.100).aspx
        }

        public static void paintOutline(Design pDesign, Canvas pCanvas, int pMode)
        {
            if (pMode != 1)
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

            pDesign.getSegmentA().getSegment().StrokeThickness = pDesign.getOutline().getThickness();
            pDesign.getSegmentB().getSegment().StrokeThickness = pDesign.getOutline().getThickness();
            pDesign.getSegmentC().StrokeThickness = pDesign.getOutline().getThickness();
            pDesign.getSegmentD().StrokeThickness = pDesign.getOutline().getThickness();           
        }

        public static void paintShoeSole(Design pDesign, int pMode)
        {
            /*//CONVERT STRING TO COLOR
            Color newColor = (Color)ColorConverter.ConvertFromString(pColor.ToString());
            pColor = newColor;*/
            if (pMode != 1)
                pDesign.getSegmentE().Stroke = new SolidColorBrush (pDesign.getShoeSole().getColor());

            pDesign.getSegmentE().StrokeThickness = pDesign.getShoeSole().getThickness();   
        }

        public static void paintArea(Canvas pCanvas, Area pArea)
        {
            pArea.drawArea();
            Canvas.SetLeft(pArea.getRectangle(), pArea.getAxisX());
            Canvas.SetTop(pArea.getRectangle(), pArea.getAxisY());
            pCanvas.Children.Add(pArea.getRectangle());
        }

        public static void loadCircleDecorations(Design pDesign, Canvas pCanvas, int pModo)
        {
            foreach (Circle circle in pDesign.getCircleDecorations())
            {
                paintCircleDecoration(pCanvas, circle, pModo);
            }
        }

        public static void loadAreaDecorations(Design pDesign, Canvas pCanvas)
        {
            foreach (Area area in pDesign.getFillingAreas())
            {
                paintArea(pCanvas, area);
            }
        }

        public static void paintCircleDecoration(Canvas pCanvas, Circle circleDeco, int pMode) 
        {
            circleDeco.drawCircle(pMode);
            Canvas.SetLeft(circleDeco.getEllipse(), circleDeco.getAxisX());
            Canvas.SetTop(circleDeco.getEllipse(), circleDeco.getAxisY());
            pCanvas.Children.Add(circleDeco.getEllipse());

            Canvas.SetLeft(circleDeco.getRemarks(), circleDeco.getAxisX() + circleDeco.getEllipse().Width / 2);
            Canvas.SetTop(circleDeco.getRemarks(), circleDeco.getAxisY() + circleDeco.getEllipse().Height / 2);

            if (pMode == 1)
                pCanvas.Children.Add(circleDeco.getRemarks());
        }

        public static void loadLineDecorations(Design pDesign, Canvas pCanvas, int pModo)
        {
            foreach (LineDec line in pDesign.getLineDecorations())
            {
                paintLineDecoration(pCanvas, line, pModo);
            }
        }

        public static void paintLineDecoration(Canvas pCanvas, LineDec lineDeco, int pMode)
        {
            lineDeco.drawLine(pMode);
            lineDeco.getLine().X1 = lineDeco.getBasePoints()[0].getAxisX() + 5;
            lineDeco.getLine().Y1 = lineDeco.getBasePoints()[0].getAxisY() + 5;
            lineDeco.getLine().X2 = lineDeco.getBasePoints()[1].getAxisX() + 5;
            lineDeco.getLine().Y2 = lineDeco.getBasePoints()[1].getAxisY() + 5;
            pCanvas.Children.Add(lineDeco.getLine());

            if (pMode == 1)
            {
                foreach (BasePoint point in lineDeco.getBasePoints())
                {
                    point.drawPoint(2);
                    Canvas.SetLeft(point.getPointEllipse(), point.getAxisX());
                    Canvas.SetTop(point.getPointEllipse(), point.getAxisY());
                    pCanvas.Children.Add(point.getPointEllipse());
                }
            }

            Canvas.SetLeft(lineDeco.getRemarks(), lineDeco.getBasePoints()[0].getAxisX() + 15);
            Canvas.SetTop(lineDeco.getRemarks(), lineDeco.getBasePoints()[0].getAxisY() + 15);
            pCanvas.Children.Add(lineDeco.getRemarks());
        }

        //------------------------------------------------------------------------------
        public static void fireMode(Design pDesign, Canvas pCanvas)
        {           
            Stopwatch timer = new Stopwatch();

            timer.Start();
  
            Fire.paintBackground(pDesign, pCanvas);

            //------------------------------------------------------
            //Calculate All Intersections

            List<BasePoint[]> lines = Fire.getLinesFromDesign(pDesign);

            //calculate All intersections
            List<BasePoint> intersections = Fire.calculateIntersections(lines, pCanvas, 0);
            Rectangle rect;

            /*foreach (BasePoint bpoint in intersections)
            {
                rect = new Rectangle();
                rect.Width = 5;
                rect.Height = 5;
                rect.Fill = Brushes.Red;
                Canvas.SetLeft(rect, bpoint.getAxisX());
                Canvas.SetTop(rect, bpoint.getAxisY());
                pCanvas.Children.Add(rect);
            }*/

            //Calculate Polygons of Areas
            List<BasePoint> polygonInt = new List<BasePoint>();
            BasePoint areaPoint;
            BasePoint[] testLine = new BasePoint[2];
            List<Point> polygonPoints;

            foreach (Area cArea in pDesign.getFillingAreas())
            {
                polygonPoints = new List<Point>();
                areaPoint = new BasePoint(cArea.getAxisX(), cArea.getAxisY(), "");
                foreach (BasePoint iPoint in intersections)
                {
                    testLine[0] = areaPoint;
                    testLine[1] = iPoint;
                    lines.Insert(0, testLine);
                    /*rect = new Rectangle();
                    rect.Width = 5;
                    rect.Height = 5;
                    rect.Fill = Brushes.LightBlue;
                    Canvas.SetLeft(rect, testLine[1].getAxisX());
                    Canvas.SetTop(rect, testLine[1].getAxisY());
                    pCanvas.Children.Add(rect);*/


                    polygonInt = Fire.calculateIntersections(lines, pCanvas, 1);
                    if (polygonInt.Count == 1 || polygonInt.Count == 0) //si es valido
                    {
                        polygonPoints.Add(new Point(iPoint.getAxisX(), iPoint.getAxisY()));
                        /*rect = new Rectangle();
                        rect.Width = 5;
                        rect.Height = 5;
                        rect.Fill = Brushes.Yellow;
                        Canvas.SetLeft(rect, iPoint.getAxisX());
                        Canvas.SetTop(rect, iPoint.getAxisY());
                        pCanvas.Children.Add(rect);*/
                    }
                    lines.RemoveAt(0);
                }

                //order polygon points
                Point temporal;
                for (int index = 0; index < polygonPoints.Count; index++)
                {
                    for (int index2 = 0; index2 < polygonPoints.Count - 1; index2++)
                    {
                        if (Fire.calculateAngle(cArea.getAxisX(), cArea.getAxisY(), polygonPoints[index2]) >
                            Fire.calculateAngle(cArea.getAxisX(), cArea.getAxisY(), polygonPoints[index2 + 1]))
                        {
                            temporal = polygonPoints[index2 + 1];
                            polygonPoints[index2 + 1] = polygonPoints[index2];
                            polygonPoints[index2] = temporal;
                        }
                    }
                }

                PointCollection correctPolygonPoints = new PointCollection();
                foreach (Point pPoint in polygonPoints)
                {
                    correctPolygonPoints.Add(new Point(pPoint.X + 8, pPoint.Y + 8));
                }

                Fire.paintArea(correctPolygonPoints, pCanvas, new SolidColorBrush(cArea.getColor()));
            }

            //Add the other parts
            Fire.paintWhiteArc(pDesign, pCanvas);
            paintOutline(pDesign, pCanvas, 3);

            foreach(Circle circle in pDesign.getCircleDecorations())
            {
                Circle newCircle = new Circle(circle.getThickness(), circle.getColor(), circle.getSize(), 
                                              circle.getFilled(), circle.getAxisX(), circle.getAxisY());
                paintCircleDecoration(pCanvas, newCircle, 3);
            }

            foreach(LineDec lineDec in pDesign.getLineDecorations())
            {
                LineDec newLine = new LineDec(lineDec.getThickness(), lineDec.getColor());
                newLine.setBasePoints(lineDec.getBasePoints());
                paintLineDecoration(pCanvas, newLine, 3);
            }

            timer.Stop();

            if (pDesign.getFireTime().ToString() == "00:00:00")
                pDesign.setFireTime(timer.Elapsed);

            else 
            {
                int result = TimeSpan.Compare(timer.Elapsed, pDesign.getFireTime());
                if (result == -1)
                    pDesign.setFireTime(timer.Elapsed);

            }

            MessageBox.Show(pDesign.getFireTime().ToString());
            

        }
       
        public static void arcadeMode(Design pDesign, Canvas pCanvas)
        {
            paintOutline(pDesign, pCanvas, 2);

            foreach (Circle circle in pDesign.getCircleDecorations())
            {
                Arcade.paintEllipse(pCanvas, circle);
            }

            foreach (LineDec line in pDesign.getLineDecorations())
            {
                LineDec newLine = new LineDec(line.getThickness(), line.getColor());
                newLine.setBasePoints(line.getBasePoints());
                paintLineDecoration(pCanvas, newLine, 3);
            }
        }
    }
}
