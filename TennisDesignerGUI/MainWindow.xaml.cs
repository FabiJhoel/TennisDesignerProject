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
        // Global Variables
        Design designInstance;
        Line segmentB;

        //Shapes
        Path silhouette;
        BasePoint pointB, pointC, pointD, pointE;
        public MainWindow()
        {
            InitializeComponent();
           
            //////////////////////Create a figure. //////////////////////////////
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(30, 40);

            myPathFigure.Segments.Add(
                new ArcSegment(new Point(40, 190), new Size(50, 55), 0, true,
                SweepDirection.Counterclockwise, true));

/*            myPathFigure.Segments.Add(new LineSegment(new Point(390, 190), true));

            myPathFigure.Segments.Add(
                new LineSegment(new Point(325, 95), true));

            myPathFigure.Segments.Add(
                new LineSegment(new Point(220, 40), true));

            myPathFigure.Segments.Add(
                new ArcSegment(new Point(27, 40), new Size(70, 30), 0, true,
                SweepDirection.Clockwise, true));

  */         

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
            pointB = new BasePoint(1, 1, "pointB");
            pointB.drawPoint();
            Canvas.SetLeft(pointB.getPointEllipse(), 352);
            Canvas.SetTop(pointB.getPointEllipse(), 122);
            canvasEdit.Children.Add(pointB.getPointEllipse());

            pointC = new BasePoint(1, 1, "pointC");
            pointC.drawPoint();
            Canvas.SetLeft(pointC.getPointEllipse(), 457);
            Canvas.SetTop(pointC.getPointEllipse(), 179);
            canvasEdit.Children.Add(pointC.getPointEllipse());

            pointD = new BasePoint(1, 1, "pointD");
            pointD.drawPoint();
            Canvas.SetLeft(pointD.getPointEllipse(), 516);
            Canvas.SetTop(pointD.getPointEllipse(), 269);
            canvasEdit.Children.Add(pointD.getPointEllipse());

            pointE = new BasePoint(1, 1, "pointE");
            pointE.drawPoint();
            Canvas.SetLeft(pointE.getPointEllipse(), 156);
            Canvas.SetTop(pointE.getPointEllipse(), 269);
            canvasEdit.Children.Add(pointE.getPointEllipse());

            //Asign event to Points

       /*   pointB.getPointEllipse().MouseMove += MouseMoveEllipseB;
           pointC.getPointEllipse().MouseMove += MouseMoveEllipse;
            pointD.getPointEllipse().MouseMove += MouseMoveEllipse;*/
            pointE.getPointEllipse().MouseMove += MouseMoveEllipseE;
                
        }

        /* Move points around 
           the workspace */
        private void MouseMoveEllipseE(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
            {
                (ellipse).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                (ellipse).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);

                //Move path
                silhouette.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointE.getPointEllipse()) + 5);

            }
        }

        private void MouseMovePointA(object sender, MouseEventArgs e)
         {
             Ellipse pointA = designInstance.getBasePoints()[0].getPointEllipse();

             if (designInstance.getBasePoints()[0].getPointEllipse() != null && e.LeftButton == MouseButtonState.Pressed)
             {
                 // Move ellipse
                 (pointA).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                 (pointA).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
          
                 // Move line
                 lineaIzq.X1 = Canvas.GetLeft(pointA) + 5;
                 lineaIzq.Y1 = Canvas.GetTop(pointA) + 5;
             }
         }
        
        private void addNewDesignButton(object sender, RoutedEventArgs e)
        {
            string designName = "";
            designInstance = new Design(designName);

            DesignNameWindow getNameWindow = new DesignNameWindow(ListBoxDesigns, designInstance);
            getNameWindow.Show();
            loadBasePoints();

        }

        private void saveDesignButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(designInstance.getName());
        }

        private void loadBasePoints()
        {
            // Asign BasePoints to the new design
            designInstance.addPoint(new BasePoint(156, 122, "pointA"));
            designInstance.addPoint(new BasePoint(352, 122, "pointB"));
            designInstance.addPoint(new BasePoint(457, 179, "pointC"));
            designInstance.addPoint(new BasePoint(516, 269, "pointD"));
            designInstance.addPoint(new BasePoint(156, 269, "pointE"));

            // Draw each Basepoint on screen
            foreach (BasePoint point in designInstance.getBasePoints())
            {
                point.drawPoint();
                Canvas.SetLeft(point.getPointEllipse(), point.getAxisX());
                Canvas.SetTop(point.getPointEllipse(), point.getAxisY());
                canvasEdit.Children.Add(point.getPointEllipse());
            }

            // Asign events to each BasePoint
            designInstance.getBasePoints()[0].getPointEllipse().MouseMove += MouseMovePointA; 
        }

        private void loadTenniSilhouette()
        {

        }
    }

    
}
