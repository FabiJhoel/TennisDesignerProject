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
using DataAccess;
using TennisBusiness;
using TennisLibrary;


namespace TennisDesignerGUI
{
    public partial class MainWindow : Window
    {   
        // Global Variables
        Design designInstance;
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
            PaintManager.loadTennisSilhouette(designInstance, canvasEdit);
            PaintManager.loadBasePoints(designInstance, canvasEdit);

            // Asign events to each BasePoint
            designInstance.getBasePoints()[0].getPointEllipse().MouseMove += MouseMovePointA;
            designInstance.getBasePoints()[1].getPointEllipse().MouseMove += MouseMovePointB;
            designInstance.getBasePoints()[2].getPointEllipse().MouseMove += MouseMovePointC;
            designInstance.getBasePoints()[3].getPointEllipse().MouseMove += MouseMovePointD;
            designInstance.getBasePoints()[4].getPointEllipse().MouseMove += MouseMovePointE;
        }

        private void saveDesignButton(object sender, RoutedEventArgs e)
        {
            dataAdmin.saveDesign(designInstance);
            MessageBox.Show("Your design has been saved as: " + designInstance.getName());
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
            Line segmentC = designInstance.getSegmentC();

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
            Line segmentC = designInstance.getSegmentC();
            Line segmentD = designInstance.getSegmentD();

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
            Line segmentD = designInstance.getSegmentD();
            Line segmentE = designInstance.getSegmentE();

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
            Line segmentE = designInstance.getSegmentE();

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
