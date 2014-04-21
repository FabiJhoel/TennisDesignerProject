using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace TennisBusiness
{
    public static class Arcade
    {
        /*using System.Diagnostics;
        // ...

        Stopwatch sw = new Stopwatch();

        sw.Start();

        // ...

        sw.Stop();

        MessageBox.Show(sw.Elapsed.ToString());*/

        private static void drawEllipse(Canvas pCanvas, Brush pColor, double pWidth, double pHeight, double pAxisX, double pAxisY,
            int pThickness, SolidColorBrush pStroke)
        {
            Ellipse ellipse;

            /*if (pColor.Equals(Brushes.Transparent))
            {
                ellipse = new Ellipse();
                ellipse.Fill = pColor;
                ellipse.Stroke = pStroke;
                ellipse.StrokeThickness = pThickness;
                ellipse.Width = pWidth;
                ellipse.Height = pHeight;
                Canvas.SetLeft(ellipse, pAxisX);
                Canvas.SetTop(ellipse, pAxisY);
                pCanvas.Children.Add(ellipse);
            }
            else
            {*/
            while (pWidth > 0 && pHeight > 0)
            {
                ellipse = new Ellipse();
                ellipse.Stroke = pColor;
                ellipse.StrokeThickness = pThickness;
                ellipse.Width = pWidth;
                ellipse.Height = pHeight;
                Canvas.SetLeft(ellipse, pAxisX);
                Canvas.SetTop(ellipse, pAxisY);
                pCanvas.Children.Add(ellipse);
                pWidth--;
                pHeight--;
                pAxisX += 0.5;
                pAxisY += 0.5;
            }
            //}
        }

        public static void loadDesign(Design pDesign, Canvas pCanvas)
        {
            //Load Internal Arc
            drawEllipse(pCanvas, Brushes.LightSeaGreen, pDesign.getSegmentA().getSegmentContainerWidth() * 2,
                pDesign.getBasePoints()[4].getAxisY() - pDesign.getBasePoints()[0].getAxisY(),
                pDesign.getSegmentA().getAxisX(), pDesign.getSegmentA().getAxisY() + 10, -1, Brushes.Transparent);

            //Load External Arc
            drawEllipse(pCanvas, Brushes.White, pDesign.getBasePoints()[1].getAxisX() - pDesign.getBasePoints()[0].getAxisX(),
                pDesign.getSegmentB().getSegmentContainerHeight() * 2, pDesign.getSegmentB().getAxisX(),
                pDesign.getSegmentB().getAxisY() - pDesign.getSegmentB().getSegmentContainerHeight(), -1, Brushes.Transparent);

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
