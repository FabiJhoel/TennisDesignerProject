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
using TennisLibrary;


namespace TennisDesignerGUI
{
    public partial class MainWindow : Window
    {
        //Shapes
        Path silhouette;
        MoveablePoint pointA, pointB, pointC, pointD, pointE;
        public MainWindow()
        {
            InitializeComponent();
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");

            //////////////////////Create a figure. //////////////////////////////
            Point line2Point = new Point (390,190);
            LineSegment line2 = new LineSegment(line2Point, true);

            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(30, 40);

            myPathFigure.Segments.Add(
                new ArcSegment(new Point(50, 190), new Size(50, 55), 0, true,
                SweepDirection.Counterclockwise, true));
/////////////////////////
            line2Point.X = 0;
            line2Point.Y = 0;
            myPathFigure.Segments.Add(line2);
            //myPathFigure.Segments.Add(new LineSegment(new Point(390, 190), true));
////////////////////////
            myPathFigure.Segments.Add(
                new LineSegment(new Point(325, 95), true));

            myPathFigure.Segments.Add(
                new LineSegment(new Point(220, 40), true));

            myPathFigure.Segments.Add(
                new ArcSegment(new Point(27, 40), new Size(70, 30), 0, true,
                SweepDirection.Clockwise, true));

           

            /// Create a PathGeometry to contain the figure.
            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);

            // Display the PathGeometry. 
            silhouette = new Path();
            silhouette.Stroke = Brushes.Black;
            silhouette.StrokeThickness = 1;
            silhouette.Data = myPathGeometry;
            Canvas.SetLeft(silhouette, 140);
            Canvas.SetTop(silhouette, 94);
            canvasEdit.Children.Add(silhouette);
            //////////////////////Create a figure. //////////////////////////////

            //Draw Points
            pointA = new MoveablePoint(1, 1, "pointA");
            pointA.drawPoint();
            Canvas.SetLeft(pointA.getPointEllipse(), 156);
            Canvas.SetTop(pointA.getPointEllipse(), 122);
            canvasEdit.Children.Add(pointA.getPointEllipse());

            pointB = new MoveablePoint(1, 1, "pointB");
            pointB.drawPoint();
            Canvas.SetLeft(pointB.getPointEllipse(), 352);
            Canvas.SetTop(pointB.getPointEllipse(), 122);
            canvasEdit.Children.Add(pointB.getPointEllipse());

            pointC = new MoveablePoint(1, 1, "pointC");
            pointC.drawPoint();
            Canvas.SetLeft(pointC.getPointEllipse(), 457);
            Canvas.SetTop(pointC.getPointEllipse(), 179);
            canvasEdit.Children.Add(pointC.getPointEllipse());

            pointD = new MoveablePoint(1, 1, "pointD");
            pointD.drawPoint();
            Canvas.SetLeft(pointD.getPointEllipse(), 516);
            Canvas.SetTop(pointD.getPointEllipse(), 269);
            canvasEdit.Children.Add(pointD.getPointEllipse());

            pointE = new MoveablePoint(1, 1, "pointE");
            pointE.drawPoint();
            Canvas.SetLeft(pointE.getPointEllipse(), 156);
            Canvas.SetTop(pointE.getPointEllipse(), 269);
            canvasEdit.Children.Add(pointE.getPointEllipse());

            //Asign event to Points
            pointA.getPointEllipse().MouseMove += MouseMovePointA;
            pointB.getPointEllipse().MouseMove += MouseMoveEllipse;
            pointC.getPointEllipse().MouseMove += MouseMoveEllipse;
            pointD.getPointEllipse().MouseMove += MouseMoveEllipse;
            pointE.getPointEllipse().MouseMove += MouseMoveEllipse;
                      
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
             if (pointA.getPointEllipse() != null && e.LeftButton == MouseButtonState.Pressed)
             {
                 (pointA.getPointEllipse()).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                 (pointA.getPointEllipse()).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
                 silhouette.StrokeThickness = 20;

             }
         }

    }

    
}
