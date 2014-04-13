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
        // Global variables
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
            canvasEdit.Children.Clear();
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
            DataManager.saveDesign(designInstance);
        }

        /* BasePoint Events */
        private void MouseMovePointA(object sender, MouseEventArgs e)
        {
            Ellipse pointA = designInstance.getBasePoints()[0].getPointEllipse();
            Ellipse pointB = designInstance.getBasePoints()[1].getPointEllipse();
            Ellipse pointE = designInstance.getBasePoints()[4].getPointEllipse();
            Grid segmentA = designInstance.getSegmentAContainer();
            Grid segmentB = designInstance.getSegmentBContainer();
            Line segmentC = designInstance.getSegmentC();
            Line segmentE = designInstance.getSegmentE();          

            if (pointA != null && e.LeftButton == MouseButtonState.Pressed)
            {
                // Move ellipse
                if (Canvas.GetLeft(segmentA) > 1 && Canvas.GetLeft(pointB) < 645 && Canvas.GetLeft(pointE) < 645)
                    pointA.SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                else
                {
                    if (Canvas.GetLeft(segmentA) <= 1)
                        pointA.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointA) + 1);

                    else
                        pointA.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointA) - 1);
                }

                designInstance.getBasePoints()[0].setAxisX(Canvas.GetLeft(pointA));

                if (Canvas.GetTop(pointE) < 435 && Canvas.GetTop(pointA) > 5)
                    pointA.SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
                else
                {
                    if (Canvas.GetTop(pointE) >= 435)
                        pointA.SetValue(Canvas.TopProperty, Canvas.GetTop(pointA) - 1);

                    if (Canvas.GetTop(pointA) <= 5)
                        pointA.SetValue(Canvas.TopProperty, Canvas.GetTop(pointA) + 1);
                }

                designInstance.getBasePoints()[0].setAxisY(Canvas.GetTop(pointA));

                // Move auxiliar ellipse
                pointB.SetValue(Canvas.TopProperty, Canvas.GetTop(pointA));
                pointB.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointA) + segmentB.ActualWidth);
                pointE.SetValue(Canvas.TopProperty, Canvas.GetTop(pointA) + segmentA.ActualHeight - 5);
                pointE.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointA));              

                // Move arc
                segmentB.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointA) + 10);
                segmentB.SetValue(Canvas.TopProperty, Canvas.GetTop(pointA) + 10);

                // Move auxiliar arc
                segmentA.SetValue(Canvas.TopProperty, Canvas.GetTop(pointA) + 5);
                segmentA.SetValue(Canvas.LeftProperty, (Canvas.GetLeft(pointA) + 5) - segmentA.ActualWidth);

                //Move auxiliar line
                segmentC.X1 = Canvas.GetLeft(pointB) + 5;
                segmentC.Y1 = Canvas.GetTop(pointB) + 5;
                segmentE.X2 = Canvas.GetLeft(pointE) + 5;
                segmentE.Y2 = Canvas.GetTop(pointE) + 5;
            }
        }

        private void MouseMovePointB(object sender, MouseEventArgs e)
        {
            Ellipse pointA = designInstance.getBasePoints()[0].getPointEllipse();
            Ellipse pointB = designInstance.getBasePoints()[1].getPointEllipse();
            Ellipse pointE = designInstance.getBasePoints()[4].getPointEllipse();
            Grid segmentA = designInstance.getSegmentAContainer();
            Grid segmentB = designInstance.getSegmentBContainer();
            Line segmentC = designInstance.getSegmentC();
            Line segmentE = designInstance.getSegmentE();

            if (pointB != null && e.LeftButton == MouseButtonState.Pressed)
            {
                // Move ellipse
                if (Canvas.GetLeft(pointB) < 645 && Canvas.GetLeft(pointB) > Canvas.GetLeft(pointA))      
                    pointB.SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                else
                    pointB.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointB) - 1);

                designInstance.getBasePoints()[1].setAxisX(Canvas.GetLeft(pointB));

                if (Canvas.GetTop(pointE) < 435 && Canvas.GetTop(pointB) > 5) 
                    pointB.SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
                else
                {
                    if (Canvas.GetTop(pointE) >= 435)
                        pointB.SetValue(Canvas.TopProperty, Canvas.GetTop(pointB) - 1);

                    else if (Canvas.GetTop(pointB) <= 5)
                        pointB.SetValue(Canvas.TopProperty, Canvas.GetTop(pointB) + 1);
                }

                designInstance.getBasePoints()[1].setAxisY(Canvas.GetTop(pointB));

                // Move auxiliar ellipse
                pointA.SetValue(Canvas.TopProperty, Canvas.GetTop(pointB));
                pointE.SetValue(Canvas.TopProperty, Canvas.GetTop(pointA) + segmentA.ActualHeight - 5);

                // Move arc
                segmentB.Width = Math.Abs((Canvas.GetLeft(pointB) - Canvas.GetLeft(pointA)) + 5);
                segmentB.SetValue(Canvas.TopProperty, Canvas.GetTop(pointB) + 5);
                //segmentB.Height = Math.Abs(segmentB.ActualHeight - Canvas.GetTop(pointB));
                
                // Move auxiliar arc
                segmentA.SetValue(Canvas.TopProperty, Canvas.GetTop(pointA) + 5);
                segmentA.SetValue(Canvas.LeftProperty, (Canvas.GetLeft(pointA) + 5) - segmentA.ActualWidth);

                // Move line
                segmentC.X1 = Canvas.GetLeft(pointB) + 5;
                segmentC.Y1 = Canvas.GetTop(pointB) + 5;

                //Move auxiliar line
                segmentE.X2 = Canvas.GetLeft(pointE) + 5;
                segmentE.Y2 = Canvas.GetTop(pointE) + 5;               
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
                if (Canvas.GetLeft(pointC) < 645)
                    pointC.SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                else
                    pointC.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointC) - 1);

                designInstance.getBasePoints()[2].setAxisX(Canvas.GetLeft(pointC));

                if (Canvas.GetTop(pointC) < 435 && Canvas.GetTop(pointC) > 5)
                    pointC.SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
                else
                {
                    if (Canvas.GetTop(pointC) >= 435)
                        pointC.SetValue(Canvas.TopProperty, Canvas.GetTop(pointC) - 1);

                    else if (Canvas.GetTop(pointC) <= 5)
                        pointC.SetValue(Canvas.TopProperty, Canvas.GetTop(pointC) + 1);
                }

                designInstance.getBasePoints()[2].setAxisY(Canvas.GetTop(pointC));

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
                if (Canvas.GetLeft(pointD) < 645)
                    pointD.SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                else
                    pointD.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointD) - 1);

                designInstance.getBasePoints()[3].setAxisX(Canvas.GetLeft(pointD));

                if (Canvas.GetTop(pointD) < 435 && Canvas.GetTop(pointD) > 5)
                    pointD.SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
                else
                {
                    if (Canvas.GetTop(pointD) >= 435)
                        pointD.SetValue(Canvas.TopProperty, Canvas.GetTop(pointD) - 1);

                    else if (Canvas.GetTop(pointD) <= 5)
                        pointD.SetValue(Canvas.TopProperty, Canvas.GetTop(pointD) + 1);
                }

                designInstance.getBasePoints()[3].setAxisY(Canvas.GetTop(pointD));

                // Move line
                segmentD.X2 = Canvas.GetLeft(pointD) + 5;
                segmentD.Y2 = Canvas.GetTop(pointD) + 5;
                segmentE.X1 = Canvas.GetLeft(pointD) + 7;
                segmentE.Y1 = Canvas.GetTop(pointD) + 7;
            }
        }

        private void MouseMovePointE(object sender, MouseEventArgs e)
        {
            Ellipse pointA = designInstance.getBasePoints()[0].getPointEllipse();
            Ellipse pointB = designInstance.getBasePoints()[1].getPointEllipse();
            Ellipse pointD = designInstance.getBasePoints()[3].getPointEllipse();
            Ellipse pointE = designInstance.getBasePoints()[4].getPointEllipse();
            Grid segmentA = designInstance.getSegmentAContainer();
            Grid segmentB = designInstance.getSegmentBContainer();
            Line segmentC = designInstance.getSegmentC();
            Line segmentE = designInstance.getSegmentE();

            if (pointE != null && e.LeftButton == MouseButtonState.Pressed)
            {
                // Move ellipse
                if (segmentA.Width > 2 && Canvas.GetLeft(segmentA) < Canvas.GetLeft(pointE) &&
                    Canvas.GetLeft(pointE) < Canvas.GetLeft(pointD) && Canvas.GetLeft(pointB) < 645)
                    pointE.SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                else
                {
                    if (Canvas.GetLeft(pointE) >= Canvas.GetLeft(pointD) || Canvas.GetLeft(pointB) >= 645)
                        pointE.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointE) - 1);

                    else
                    pointE.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointE) + 1);
                }

                designInstance.getBasePoints()[4].setAxisX(Canvas.GetLeft(pointE));

                if (Canvas.GetTop(pointE) < 435 && Canvas.GetTop(pointE) > Canvas.GetTop(pointA))
                    pointE.SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
                else
                {
                    if (Canvas.GetTop(pointE) >= 435)
                        pointE.SetValue(Canvas.TopProperty, Canvas.GetTop(pointE) - 1);

                    else if (Canvas.GetTop(pointE) <= Canvas.GetTop(pointA))
                        pointE.SetValue(Canvas.TopProperty, Canvas.GetTop(pointE) + 1);
                }

                designInstance.getBasePoints()[4].setAxisY(Canvas.GetTop(pointE));

                // Move auxiliar ellipse
                Canvas.SetLeft(pointA, Canvas.GetLeft(pointE));
                pointB.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointA) + segmentB.ActualWidth);

                // Move arcs
                segmentA.Width = Math.Abs((Canvas.GetLeft(pointE) - Canvas.GetLeft(segmentA)) + 5);
                segmentA.Height = Math.Abs(Canvas.GetTop(pointE) - Canvas.GetTop(pointA));

                // Move auxiliar arc
                segmentB.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointA) + 5);

                // Move line
                segmentE.X2 = Canvas.GetLeft(pointE) + 5;
                segmentE.Y2 = Canvas.GetTop(pointE) + 5;

                // Move auxiliar line
                segmentC.X1 = Canvas.GetLeft(pointB) + 5;
                segmentC.Y1 = Canvas.GetTop(pointB) + 5;
            }
        }

        private async void ListBoxDesigns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //http://shrinandvyas.blogspot.com/2011/07/wpf-get-listboxitem-from.html
            ListBoxItem rowSelected = ListBoxDesigns.ItemContainerGenerator.ContainerFromItem(ListBoxDesigns.SelectedItem) as ListBoxItem;
            Design design = await DataManager.loadDesign(rowSelected.Content.ToString());
            canvasEdit.Children.Clear();
            PaintManager.loadTennisSilhouetteee(design, canvasEdit);
            PaintManager.loadBasePoints(design, canvasEdit);
        }
    }
}
