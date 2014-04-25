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

        }

        public static void paintOutline(Design pDesign, int pMode)
        {
            if (pMode != 1)
            {
                pDesign.getSegmentA().getSegment().Stroke = new SolidColorBrush(pDesign.getOutline().getColor());
                pDesign.getSegmentB().getSegment().Stroke = new SolidColorBrush(pDesign.getOutline().getColor());
                pDesign.getSegmentC().Stroke = new SolidColorBrush(pDesign.getOutline().getColor());
                pDesign.getSegmentD().Stroke = new SolidColorBrush(pDesign.getOutline().getColor());
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
            Fire.paintBackground(pDesign, pCanvas);
            Fire.paintOutline(pDesign, pCanvas);
            
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




            //------------------------------------------------------
            //Calculate All Intersections

            List<BasePoint[]> lines = new List<BasePoint[]>();

            //get lines from Design First Silouhette lines and then LinesDec
            BasePoint[] line = new BasePoint[2];
            line[0] = pDesign.getBasePoints()[0];
            line[1] = pDesign.getBasePoints()[1];
            lines.Add(line); //A-B

            line = new BasePoint[2];
            line[0] = pDesign.getBasePoints()[1];
            line[1] = pDesign.getBasePoints()[2];
            lines.Add(line); //B-C

            line = new BasePoint[2];
            line[0] = pDesign.getBasePoints()[2];
            line[1] = pDesign.getBasePoints()[3];
            lines.Add(line); //C-D

            line = new BasePoint[2];
            line[0] = pDesign.getBasePoints()[3];
            line[1] = pDesign.getBasePoints()[4];
            lines.Add(line); //D-E

            line = new BasePoint[2];
            line[0] = pDesign.getBasePoints()[4];
            line[1] = pDesign.getBasePoints()[0];
            lines.Add(line); //E-A

            foreach (LineDec tLine in pDesign.getLineDecorations())
            {
                line = new BasePoint[2];
                line[0] = tLine.getBasePoints()[0];
                line[1] = tLine.getBasePoints()[1];
                lines.Add(line); //E-A
            }

            //calculate All intersections
            List<BasePoint> intersections = Fire.calculateIntersections(lines, pCanvas, 0);
            Rectangle rect;
            //MessageBox.Show("" + intersections.Count);

            foreach (BasePoint bpoint in intersections)
            {
                rect = new Rectangle();
                rect.Width = 5;
                rect.Height = 5;
                rect.Fill = Brushes.Red;
                Canvas.SetLeft(rect, bpoint.getAxisX());
                Canvas.SetTop(rect, bpoint.getAxisY());
                pCanvas.Children.Add(rect);
                //MessageBox.Show("" + bpoint.getAxisX() + "  " + bpoint.getAxisY());
            }



            //Calculate Polygons of Areas
           List<BasePoint> polygonInt = new List<BasePoint>();
           BasePoint areaPoint;
           BasePoint[] testLine = new BasePoint[2];
           PointCollection polygonPoints;

           foreach (Area cArea in pDesign.getFillingAreas())
           {
               polygonPoints = new PointCollection();
               areaPoint = new BasePoint(cArea.getAxisX(), cArea.getAxisY(), "");
               foreach (BasePoint iPoint in intersections)
               {
                   testLine[0] = areaPoint;
                   testLine[1] = iPoint;
                   lines.Insert(0,testLine);
                   /*rect = new Rectangle();
                   rect.Width = 5;
                   rect.Height = 5;
                   rect.Fill = Brushes.LightBlue;
                   Canvas.SetLeft(rect, testLine[1].getAxisX());
                   Canvas.SetTop(rect, testLine[1].getAxisY());
                   pCanvas.Children.Add(rect);*/


                   polygonInt = Fire.calculateIntersections(lines, pCanvas, 1);
                   //MessageBox.Show("" + polygonInt.Count);
                   if (polygonInt.Count == 1) //si es valido
                   {
                       polygonPoints.Add(new Point(polygonInt[0].getAxisX(), polygonInt[0].getAxisY()));
                       rect = new Rectangle();
                       rect.Width = 5;
                       rect.Height = 5;
                       rect.Fill = Brushes.Yellow;
                       Canvas.SetLeft(rect, polygonInt[0].getAxisX());
                       Canvas.SetTop(rect, polygonInt[0].getAxisY());
                       pCanvas.Children.Add(rect);
                   }

                   lines.RemoveAt(0);
               }
               Fire.paintArea(polygonPoints, pCanvas,new SolidColorBrush(cArea.getColor()));
           }

        }

        public static void arcadeMode(Design pDesign, Canvas pCanvas)
        {
            Arcade.loadDesign(pDesign, pCanvas);
        }
    }
}
