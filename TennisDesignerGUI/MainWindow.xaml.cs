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

namespace TennisDesignerGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");    

            //path examp
            // Create a figure.
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(10, 50);
            myPathFigure.Segments.Add(
                new BezierSegment(
                    new Point(100, 0),
                    new Point(200, 200),
                    new Point(300, 100),
                    true /* IsStroked */  ));
            myPathFigure.Segments.Add(
                new LineSegment(
                    new Point(400, 100),
                    true /* IsStroked */ ));
            myPathFigure.Segments.Add(
                new ArcSegment(
                    new Point(200, 100),
                    new Size(50, 50),
                    45,
                    true, /* IsLargeArc */
                    SweepDirection.Clockwise,
                    true /* IsStroked */ ));

            /// Create a PathGeometry to contain the figure.
            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);

            // Display the PathGeometry. 
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;
            Canvas.SetLeft(myPath,12);
            Canvas.SetRight(myPath, 112);
            canvasEdit.Children.Add(myPath);
        }

        /*Move points around 
         the workspace*/
        private void MouseMoveEllipse(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
            {
                (ellipse).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                (ellipse).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
            }
        }
         
    }
}
