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
        private static void drawPolygon(PointCollection pPointCollection, Canvas pCanvas)
        {
            Polygon polygon = new Polygon();
            polygon.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            polygon.StrokeThickness = 0;
            polygon.HorizontalAlignment = HorizontalAlignment.Left;
            polygon.VerticalAlignment = VerticalAlignment.Center;

            polygon.Points = pPointCollection;
            pCanvas.Children.Add(polygon);
        }

        private static void drawEllipse(Canvas pCanvas, Brush pColor, double pWidth, double pHeight, double pAxisX, double pAxisY,
            int pThickness, SolidColorBrush pStroke)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = pColor;
            ellipse.Stroke = pStroke;
            ellipse.StrokeThickness = pThickness;
            ellipse.Width = pWidth;
            ellipse.Height = pHeight;
            Canvas.SetLeft(ellipse, pAxisX);
            Canvas.SetTop(ellipse, pAxisY);
            pCanvas.Children.Add(ellipse);
        }
        
        public static void loadDesign(Design pDesign, Canvas pCanvas)
        {
            //Load basic form
            PointCollection points = new PointCollection();
            points.Add(new Point(pDesign.getBasePoints()[0].getAxisX() + 8, pDesign.getBasePoints()[0].getAxisY() + 15));
            points.Add(new Point(pDesign.getBasePoints()[1].getAxisX(), pDesign.getBasePoints()[1].getAxisY() + 15));
            points.Add(new Point(pDesign.getBasePoints()[2].getAxisX() + 15, pDesign.getBasePoints()[2].getAxisY() + 15));
            points.Add(new Point(pDesign.getBasePoints()[3].getAxisX() + 15, pDesign.getBasePoints()[3].getAxisY() + 15));
            points.Add(new Point(pDesign.getBasePoints()[4].getAxisX() + 8, pDesign.getBasePoints()[4].getAxisY() + 15));
            drawPolygon(points, pCanvas);

            //Load Internal Arc
            drawEllipse(pCanvas, Brushes.LightSeaGreen, pDesign.getSegmentA().getSegmentContainerWidth() * 2,
                pDesign.getBasePoints()[4].getAxisY() - pDesign.getBasePoints()[0].getAxisY(),
                pDesign.getSegmentA().getAxisX(), pDesign.getSegmentA().getAxisY() + 10, 0, null);

            //Load External Arc
            drawEllipse(pCanvas, Brushes.White, pDesign.getBasePoints()[1].getAxisX() - pDesign.getBasePoints()[0].getAxisX(),
                pDesign.getSegmentB().getSegmentContainerHeight() * 2, pDesign.getSegmentB().getAxisX(),
                pDesign.getSegmentB().getAxisY() - pDesign.getSegmentB().getSegmentContainerHeight(), 0, null);

            //Load ShoeSole
            Line shoeSole = new Line();
            shoeSole.X1 = pDesign.getBasePoints()[3].getAxisX() + 15;
            shoeSole.Y1 = pDesign.getBasePoints()[3].getAxisY() + 15;
            shoeSole.X2 = pDesign.getBasePoints()[4].getAxisX() + 8;
            shoeSole.Y2 = pDesign.getBasePoints()[4].getAxisY() + 15;
            shoeSole.Stroke = new SolidColorBrush(pDesign.getShoeSole().getColor());
            shoeSole.StrokeThickness = pDesign.getShoeSole().getThickness();
            pCanvas.Children.Add(shoeSole);

            //Load Circle Decorations
            foreach (Circle circleDecoration in pDesign.getCircleDecorations())
            {
                double width;
                double height;
                if (circleDecoration.getSize() == 0) /* Small */
                    width = height = 27;

                else if (circleDecoration.getSize() == 1) /* Medium */
                    width = height = 64;

                else /* Large */
                    width = height = 110;

                SolidColorBrush filling;
                if (circleDecoration.getFilled())
                    filling = new SolidColorBrush(circleDecoration.getColor());
                else
                    filling = Brushes.Transparent;

                drawEllipse(pCanvas, filling, width, height, circleDecoration.getAxisX(), circleDecoration.getAxisY(),
                    circleDecoration.getThickness(), new SolidColorBrush(circleDecoration.getColor()));

                
            }
        }
    }
}
