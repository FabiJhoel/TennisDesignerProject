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
using DataAccess;


namespace TennisDesignerGUI
{
    public partial class MainWindow : Window
    {
        // Global Variables
        Design designInstance;
        Path segmentA;
        Grid segmentAContainer;
        Line segmentC;
        DataAdministrator dataAdmin;
        

        //Shapes
        Path silhouette;

        public MainWindow()
        {
            InitializeComponent();
            dataAdmin = new DataAdministrator();
           
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
            //canvasEdit.Children.Add(silhouette);
            //////////////////////Create a figure. //////////////////////////////
                
        }

        /* Move points around 
           the workspace */

        private void MouseMovePointA(object sender, MouseEventArgs e)
         {
             Ellipse pointA = designInstance.getBasePoints()[0].getPointEllipse();

             if (pointA != null && e.LeftButton == MouseButtonState.Pressed)
             {
                 // Move ellipse
                 (pointA).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                 (pointA).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
          
                 // Move line
                 lineaIzq.X1 = Canvas.GetLeft(pointA) + 5;
                 lineaIzq.Y1 = Canvas.GetTop(pointA) + 5;
             }
         }

        private void MouseMovePointE(object sender, MouseEventArgs e)
        {
            string strGeom = "";

            Ellipse pointE = designInstance.getBasePoints()[4].getPointEllipse();

            if (pointE != null && e.LeftButton == MouseButtonState.Pressed)
            {
                

                (pointE).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                (pointE).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);

                //Move segment AE
                //segmentAContainer.Width = Math.Abs(Canvas.GetLeft(pointE) - 80);//segmentAContainer.ActualWidth + 100; 
                PathGeometry g = segmentA.Data.GetFlattenedPathGeometry();
                
                foreach (var f in g.Figures)
                {
                    Point pt1 = f.StartPoint;
                    pt1.X = pt1.X * 10;
                    pt1.Y = pt1.Y * 5;
                    strGeom += "M" + pt1.ToString() + "A 50,55 0 1 0";
                    foreach (var s in f.Segments)
                        if (s is ArcSegment)
                        {
                            var pt = ((ArcSegment)s).Point;
                           
                            Point pts = new Point(pt.X * 10, pt.Y * 5);
                            strGeom += " " + pts.ToString();
                                
                              
                            }
                        }
                }
                segmentA = new Path();
                segmentA.Data = Geometry.Parse(strGeom);
                segmentA.Stroke = Brushes.Red;
                canvasEdit.Children.Add(segmentA);
 

            
        }
        
        private void addNewDesignButton(object sender, RoutedEventArgs e)
        {
            string designName = "";
            designInstance = new Design(designName);

            DesignNameWindow getNameWindow = new DesignNameWindow(ListBoxDesigns, designInstance);
            getNameWindow.Show();
            loadBasePoints();
            loadTennisSilhouette();
            dataAdmin.getDesignList();

        }

        private void saveDesignButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(designInstance.getName());
            dataAdmin.saveDesign(designInstance);
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
            designInstance.getBasePoints()[4].getPointEllipse().MouseMove += MouseMovePointE;
        }

        private void loadTennisSilhouette()
        {
            // SegmentA: arc
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(30, 40);
            myPathFigure.Segments.Add(new ArcSegment(new Point(30, 190), new Size(50, 55),
                                        0, true, SweepDirection.Counterclockwise, true));

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(myPathFigure);
 
            segmentA = new Path();
            segmentA.Height = Double.NaN;
            segmentA.Width = Double.NaN;
            segmentA.Stretch = Stretch.Fill;
            segmentA.Stroke = Brushes.Black;
            segmentA.StrokeThickness = 2;
            segmentA.Data = myPathGeometry;
           
            segmentAContainer = new Grid();
            segmentAContainer.Background = System.Windows.Media.Brushes.LightBlue; 
            //segmentAContainer.Children.Add(segmentA);

            /*Canvas.SetLeft(segmentAContainer, 100);
            Canvas.SetTop(segmentAContainer, 132);
            canvasEdit.Children.Add(segmentAContainer);
            */
           

            Canvas.SetLeft(segmentA, 100);
            Canvas.SetTop(segmentA, 132);
            canvasEdit.Children.Add(segmentA);

        }
    }

    
}
