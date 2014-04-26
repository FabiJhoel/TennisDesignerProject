using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace TennisBusiness
{
    public static class Arcade
    {
        public static void paintEllipse(Canvas pCanvas, Circle circleDeco)
        {
            Ellipse concentricEllipse;
            double concentricWidth = circleDeco.getEllipse().Width;
            double concentricHeight = circleDeco.getEllipse().Height;
            double newAxisX = circleDeco.getAxisX();
            double newAxisY = circleDeco.getAxisY();

            while (concentricWidth > 0 && concentricHeight > 0)
            {
                concentricEllipse = new Ellipse();

                if (circleDeco.getFilled())
                    concentricEllipse.Stroke = new SolidColorBrush(circleDeco.getColor());
                else
                    concentricEllipse.Stroke = Brushes.Transparent;

                concentricEllipse.StrokeThickness = 1;
                concentricEllipse.Width = concentricWidth;
                concentricEllipse.Height = concentricHeight;

                Canvas.SetLeft(concentricEllipse, newAxisX);
                Canvas.SetTop(concentricEllipse, newAxisY);
                pCanvas.Children.Add(concentricEllipse);

                concentricWidth --;
                concentricHeight --;
                newAxisX += 0.5;
                newAxisY += 0.5;
            }

            if (!circleDeco.getFilled())
            {
                Ellipse topEllipse = new Ellipse();
                topEllipse.Width = circleDeco.getEllipse().Width;
                topEllipse.Height = circleDeco.getEllipse().Height;
                topEllipse.Stroke = new SolidColorBrush(circleDeco.getColor());
                topEllipse.StrokeThickness = circleDeco.getThickness();

                Canvas.SetLeft(topEllipse, circleDeco.getAxisX());
                Canvas.SetTop(topEllipse, circleDeco.getAxisY());
                pCanvas.Children.Add(topEllipse);
            }
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

            foreach (BasePoint[] pLine in lines)
            {
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
                                intersections.Add(new BasePoint(Math.Round(IntX, 5), Math.Round(IntY, 5), ""));
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
                    else if (Math.Abs(intersections[index].getAxisX() - intersections[index2].getAxisX()) < 1 &&
                        Math.Abs(intersections[index].getAxisY() - intersections[index2].getAxisY()) < 1)
                    {
                        intersections.RemoveAt(index2);
                    }
                    else
                        index2++;
                }
                index++;
            }

            return intersections;
        }

        //http://stackoverflow.com/questions/3153861/get-angle-of-a-line-from-horizon
        public static double calculateAngle(double x1, double y1, Point pPoint2)
        {
            double x2 = pPoint2.X;
            double y2 = pPoint2.Y;

            double degrees;

            // Avoid divide by zero run values.
            if (x2 - x1 == 0)
            {
                if (y2 > y1)
                    degrees = 90;
                else
                    degrees = 270;
            }
            else
            {
                // Calculate angle from offset.
                double riseoverrun = (double)(y2 - y1) / (double)(x2 - x1);
                double radians = Math.Atan(riseoverrun);
                degrees = radians * ((double)180 / Math.PI);

                // Handle quadrant specific transformations.       
                if ((x2 - x1) < 0 || (y2 - y1) < 0)
                    degrees += 180;
                if ((x2 - x1) > 0 && (y2 - y1) < 0)
                    degrees -= 180;
                if (degrees < 0)
                    degrees += 360;
            }
            return Math.Round(degrees, 4);
        }

        public static List<BasePoint[]> getLinesFromDesign(Design pDesign)
        {
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

            return lines;
        }
    }
}
