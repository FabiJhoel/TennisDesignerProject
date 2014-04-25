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

        /*public static void paintLine(Canvas pCanvas, LineDec lineDeco)
        { 
        }*/
    }
}
