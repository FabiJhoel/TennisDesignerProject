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
        
        public MainWindow()
        {
            InitializeComponent();
            DataManager.loadDesignList(ListBoxDesigns); 
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

           /* Path segmentA = designInstance.getSegmentA();
            PathGeometry g = segmentA.Data.GetFlattenedPathGeometry();

            foreach (var f in g.Figures)
            {
                Point pt1 = f.StartPoint;
                MessageBox.Show(pt1.ToString());
            }*/
        }

        private void saveDesignButton(object sender, RoutedEventArgs e)
        {
            DataManager.saveDesign(designInstance);
        }

        // BasePoint Events
        private void MouseMovePointA(object sender, MouseEventArgs e)
        {
            Ellipse pointA = designInstance.getBasePoints()[0].getPointEllipse();
            Ellipse pointE = designInstance.getBasePoints()[4].getPointEllipse();
            Grid segmentB = designInstance.getSegmentBContainer();
            Grid segmentA = designInstance.getSegmentAContainer();

            if (pointA != null && e.LeftButton == MouseButtonState.Pressed)
            {
                // Move ellipse
                (pointA).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                (pointA).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);

                // Move auxiliar ellipse
                (pointE).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y + 130);

                // Move arc
                segmentB.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointA) + 5);

                // Move auxiliar arc
                segmentA.SetValue(Canvas.TopProperty, Canvas.GetTop(pointA) + 5);
                //segmentA.Height = Math.Abs(Canvas.GetTop(pointA) + 50);
                segmentA.Height = Math.Abs(Canvas.GetTop(pointE) - 120);
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
            Ellipse pointE = designInstance.getBasePoints()[4].getPointEllipse();
            Ellipse pointA = designInstance.getBasePoints()[0].getPointEllipse();
            Line segmentE = designInstance.getSegmentE();
            Grid segmentA = designInstance.getSegmentAContainer();
            Grid segmentB = designInstance.getSegmentBContainer();

            if (pointE != null && e.LeftButton == MouseButtonState.Pressed)
            {
                // Move ellipse
                (pointE).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                (pointE).SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);

                // Move auxiliar ellipse
                (pointA).SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);

                // Move line
                segmentE.X2 = Canvas.GetLeft(pointE) + 5;
                segmentE.Y2 = Canvas.GetTop(pointE) + 5;

                // Move arcs
                segmentA.Width = Math.Abs(Canvas.GetLeft(pointE) - 80);
                segmentA.Height = Math.Abs(Canvas.GetTop(pointE) - 120);

                // Move auxiliar arc
                //segmentB.Width = Math.Abs(Canvas.GetLeft(pointA) - 20);
                segmentB.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointA) + 5);
                //segmentB.Height = Math.Abs(Canvas.GetTop(pointA) - 120);

                

               /* canvasEdit.Children.Remove(segmentA);
               
                PathGeometry pathGeo = segmentA.Data.GetFlattenedPathGeometry();

                foreach (var figs in pathGeo.Figures)
                {
                    Point start = figs.StartPoint;
                    //MessageBox.Show(start.ToString());
                }*/

            }
      

        }

        private void ListBoxDesigns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //http://shrinandvyas.blogspot.com/2011/07/wpf-get-listboxitem-from.html
            ListBoxItem rowSelected = ListBoxDesigns.ItemContainerGenerator.ContainerFromItem(ListBoxDesigns.SelectedItem) as ListBoxItem;
            DataManager.loadDesign(rowSelected.Content.ToString());
        }

    }
}
