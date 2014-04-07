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
        Path segmentA, segmentB;
        Grid segmentAContainer;
        Line segmentC, segmentD, segmentE;
        DataAdministrator dataAdmin;
        
        public MainWindow()
        {
            InitializeComponent();
            dataAdmin = new DataAdministrator();
            loadDesignList(); 
        }
        
        private void addNewDesignButton(object sender, RoutedEventArgs e)
        {
            string designName = "";
            designInstance = new Design(designName);
            DesignNameWindow getNameWindow = new DesignNameWindow(ListBoxDesigns, designInstance);

            getNameWindow.Show();
            loadTennisSilhouette();
            loadBasePoints();            
        }

        private void saveDesignButton(object sender, RoutedEventArgs e)
        {
            dataAdmin.saveDesign(designInstance);
            MessageBox.Show("Your design has been saved as: " + designInstance.getName());
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
            designInstance.getBasePoints()[1].getPointEllipse().MouseMove += MouseMovePointB;
            designInstance.getBasePoints()[2].getPointEllipse().MouseMove += MouseMovePointC;
            designInstance.getBasePoints()[3].getPointEllipse().MouseMove += MouseMovePointD;
            designInstance.getBasePoints()[4].getPointEllipse().MouseMove += MouseMovePointE;
        }

        // BasePoint Events
        private void MouseMovePointA(object sender, MouseEventArgs e)
        {
            Ellipse pointA = designInstance.getBasePoints()[0].getPointEllipse();

            if (pointA != null && e.LeftButton == MouseButtonState.Pressed)
            {
                // Move ellipse
                (pointA).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                (pointA).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
            }
        }

        private void MouseMovePointB(object sender, MouseEventArgs e)
        {
            Ellipse pointB = designInstance.getBasePoints()[1].getPointEllipse();

            if (pointB != null && e.LeftButton == MouseButtonState.Pressed)
            {
                // Move ellipse
                (pointB).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                (pointB).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);

                // Move line
                segmentC.X1 = Canvas.GetLeft(pointB) + 5;
                segmentC.Y1 = Canvas.GetTop(pointB) + 5;
            }
        }

        private void MouseMovePointC(object sender, MouseEventArgs e)
        {
            Ellipse pointC = designInstance.getBasePoints()[2].getPointEllipse();

            if (pointC != null && e.LeftButton == MouseButtonState.Pressed)
            {
                // Move ellipse
                (pointC).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                (pointC).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);

                // Move line
                segmentC.X2 = Canvas.GetLeft(pointC) + 5;
                segmentC.Y2 = Canvas.GetTop(pointC) + 5;
                segmentD.X1 = Canvas.GetLeft(pointC) + 7;
                segmentD.Y1 = Canvas.GetTop(pointC) + 7;
            }
        }

        private void MouseMovePointD(object sender, MouseEventArgs e)
        {
            Ellipse pointD = designInstance.getBasePoints()[3].getPointEllipse();

            if (pointD != null && e.LeftButton == MouseButtonState.Pressed)
            {
                // Move ellipse
                (pointD).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                (pointD).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);

                // Move line
                segmentD.X2 = Canvas.GetLeft(pointD) + 5;
                segmentD.Y2 = Canvas.GetTop(pointD) + 5;
                segmentE.X1 = Canvas.GetLeft(pointD) + 7;
                segmentE.Y1 = Canvas.GetTop(pointD) + 7;
            }
        }

        private void MouseMovePointE(object sender, MouseEventArgs e)
        {
            string strGeom = "";
            Ellipse pointE = designInstance.getBasePoints()[4].getPointEllipse();

            if (pointE != null && e.LeftButton == MouseButtonState.Pressed)
            {
                // Move ellipse
                (pointE).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                (pointE).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);

                // Move line
                segmentE.X2 = Canvas.GetLeft(pointE) + 5;
                segmentE.Y2 = Canvas.GetTop(pointE) + 5;

                /********************************************/
                //Move segment ARC
                //segmentAContainer.Width = Math.Abs(Canvas.GetLeft(pointE) - 80);
                segmentAContainer.Background = System.Windows.Media.Brushes.Red; 
               
                /* PathGeometry g = segmentA.Data.GetFlattenedPathGeometry();

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
            */}
            /*   segmentA = new Path();
               segmentA.Data = Geometry.Parse(strGeom);
               segmentA.Stroke = Brushes.Red;
               canvasEdit.Children.Add(segmentA);*/

            /********************************************/
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
            segmentA.StrokeThickness = 3;
            segmentA.Data = myPathGeometry;
           
            /*segmentAContainer = new Grid();
            segmentAContainer.Background = System.Windows.Media.Brushes.LightBlue; 
            segmentAContainer.Children.Add(segmentA);

            Canvas.SetLeft(segmentAContainer, 100);
            Canvas.SetTop(segmentAContainer, 132);
            canvasEdit.Children.Add(segmentAContainer);*/
            
           
            Canvas.SetLeft(segmentA, 100);
            Canvas.SetTop(segmentA, 132);
            canvasEdit.Children.Add(segmentA);

            // SegmentB: arc
            PathFigure myPathFigureB = new PathFigure();
            myPathFigureB.StartPoint = new Point(30, 40);
            myPathFigureB.Segments.Add(new ArcSegment(new Point(227, 40), new Size(70, 30),
                                       0, true, SweepDirection.Counterclockwise, true));

            PathGeometry myPathGeometryB = new PathGeometry();
            myPathGeometryB.Figures.Add(myPathFigureB);

            segmentB = new Path();
            segmentB.Height = Double.NaN;
            segmentB.Width = Double.NaN;
            segmentB.Stretch = Stretch.Fill;
            segmentB.Stroke = Brushes.Black;
            segmentB.StrokeThickness = 3;
            segmentB.Data = myPathGeometryB;

            segmentAContainer = new Grid();
            segmentAContainer.Background = System.Windows.Media.Brushes.LightBlue;
            //segmentAContainer.Children.Add(segmentA);

            /*Canvas.SetLeft(segmentAContainer, 100);
            Canvas.SetTop(segmentAContainer, 132);
            canvasEdit.Children.Add(segmentAContainer);
            */

            Canvas.SetLeft(segmentB, 165);
            Canvas.SetTop(segmentB, 132);
            canvasEdit.Children.Add(segmentB);

            // SegmentC: line
            segmentC = new Line();
            segmentC.X1 = 365;
            segmentC.Y1 = 135;
            segmentC.X2 = 470;
            segmentC.Y2 = 193;
            segmentC.Stroke = System.Windows.Media.Brushes.Black;
            segmentC.StrokeThickness = 3;
            canvasEdit.Children.Add(segmentC);

            // SegmentD: line
            segmentD = new Line();
            segmentD.X1 = 470;
            segmentD.Y1 = 193;
            segmentD.X2 = 530;
            segmentD.Y2 = 285;
            segmentD.Stroke = System.Windows.Media.Brushes.Black;
            segmentD.StrokeThickness = 3;
            canvasEdit.Children.Add(segmentD);

            // SegmentE: line
            segmentE = new Line();
            segmentE.X1 = 530;
            segmentE.Y1 = 285;
            segmentE.X2 = 165;
            segmentE.Y2 = 285;
            segmentE.Stroke = System.Windows.Media.Brushes.Black;
            segmentE.StrokeThickness = 3;
            canvasEdit.Children.Add(segmentE);
        }

        public void loadDesignList()
        {
            List<string> names = dataAdmin.getDesignList();
            MessageBox.Show("" + names.Count());

            foreach (string name in names)
            {
                ListBoxDesigns.Items.Add(name);
            }
        }
    }
}
