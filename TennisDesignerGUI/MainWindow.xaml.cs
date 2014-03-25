using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace TennisDesignerGUI
{
    public partial class MainWindow : Window
    {
        Path silhouette;
        public MainWindow()
        {
            InitializeComponent();
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");

            //path examp
            // //Create a figure.
            //PathFigure myPathFigure = new PathFigure();
            //myPathFigure.StartPoint = new Point(30, 40);
            //myPathFigure.Segments.Add(
            //    new ArcSegment(new Point(50, 190),new Size(50, 55),0,true,
            //    SweepDirection.Counterclockwise,true ));
            //myPathFigure.Segments.Add(
            //    new LineSegment(new Point(390, 190),true));
            //myPathFigure.Segments.Add(
            //    new LineSegment(new Point(325, 95), true));
            //myPathFigure.Segments.Add(
            //    new LineSegment(new Point(220, 40), true));
            //myPathFigure.Segments.Add(
            //    new LineSegment(new Point(27, 40), true));
            

            ///// Create a PathGeometry to contain the figure.
            //PathGeometry myPathGeometry = new PathGeometry();
            //myPathGeometry.Figures.Add(myPathFigure);

            //// Display the PathGeometry. 
            //silhouette = new Path();
            //silhouette.Stroke = Brushes.Black;
            //silhouette.StrokeThickness = 1;
            //silhouette.Data = myPathGeometry;
            //Canvas.SetLeft(silhouette, 65);
            //Canvas.SetTop(silhouette,65);
            //canvasEdit.Children.Add(silhouette);
        }

        /* Draws a point in the workspace */
        private void drawPoint()
        {

        }

        /* Move points around 
           the workspace */
        private void MouseMoveEllipse(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
            {
                (ellipse).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                (ellipse).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);

            }
        }

        private void MouseMovePointA(object sender, MouseEventArgs e)
        {
            if (pointA != null && e.LeftButton == MouseButtonState.Pressed)
            {
                (pointA).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                (pointA).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
                silhouette.StrokeThickness = 20;

            }
        }

    }

    
}
