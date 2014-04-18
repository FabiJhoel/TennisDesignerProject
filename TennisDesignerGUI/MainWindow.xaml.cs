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
using System.Reflection;
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
            cmbxColor.ItemsSource = typeof(Colors).GetProperties();
            DataManager.loadDesignList(ListBoxDesigns); 
        }
        
        private void addNewDesignButton(object sender, RoutedEventArgs e)
        {
            string designName = "";
            designInstance = new Design(designName);
            DesignNameWindow getNameWindow = new DesignNameWindow(ListBoxDesigns, designInstance);

            getNameWindow.Show();
            canvasEdit.Children.Clear();
            PaintManager.createBasePoints(designInstance);
            PaintManager.loadTennisSilhouette(designInstance, canvasEdit);           
            PaintManager.loadBasePoints(designInstance, canvasEdit);
            asignEventToBasePoint();
        }

        private void saveDesignButton(object sender, RoutedEventArgs e)
        {
            DataManager.saveDesign(designInstance);
        }

        private async void listBoxDesigns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Design design = await DataManager.loadDesign(ListBoxDesigns.SelectedItem.ToString());

            if (design != null)
            {
                designInstance = design;
                canvasEdit.Children.Clear();
                PaintManager.loadTennisSilhouette(designInstance, canvasEdit);
                PaintManager.loadBasePoints(designInstance, canvasEdit);
                asignEventToBasePoint();
            }

            else
                MessageBox.Show("The selected design was not saved");
        }

        private void cmbxDecorations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string statment = "System.Windows.Controls.ComboBoxItem: ";

            // Enable joint property
            cmbxColor.IsEnabled = true;
            cmbxColor.SelectedIndex = -1;

            // Disable disjoint properties
            cmbxSize.IsEnabled = false;
            cmbxSize.SelectedIndex = -1;
            cmbxThikness.IsEnabled = false;
            cmbxThikness.SelectedIndex = -1;

            if (cmbxDecorations.SelectedItem.ToString() == statment + "Circle" ||
                cmbxDecorations.SelectedItem.ToString() == statment + "Filled Circle")
            {
                cmbxSize.IsEnabled = true;
                if (cmbxDecorations.SelectedItem.ToString() == statment + "Circle")
                    cmbxThikness.IsEnabled = true;
            }

            else
                cmbxThikness.IsEnabled = true;
        }

        private void addDecorationButton(object sender, RoutedEventArgs e)
        {
            int selectedDeco = cmbxDecorations.SelectedIndex;
            Color selectedColor;
            int selectedThickness;
            int selectedSize;
            bool valid = false;

            try
            {
                selectedColor = (Color)(cmbxColor.SelectedItem as PropertyInfo).GetValue(null, null);
                selectedThickness = cmbxThikness.SelectedIndex;
                selectedSize = cmbxSize.SelectedIndex;

                if (selectedDeco == 0 || selectedDeco == 3 || selectedDeco == 4)
                {
                    if (selectedThickness != -1)
                        valid = true;
                }

                else if (selectedDeco == 1)
                {
                    if (selectedSize != -1 && selectedThickness != -1)
                        valid = true;
                }

                else if (selectedDeco == 2)
                {
                    if (selectedSize != -1)
                        valid = true;
                }

                switch (selectedThickness)
                {
                    case 0:
                            selectedThickness = 1;
                            break;
                    case 1:
                            selectedThickness = 3;
                            break;
                    case 2:
                            selectedThickness = 5;
                            break;
                    case 3:
                            selectedThickness = 8;
                            break; 
                }

                if (valid)
                {
                    DesignManager.addDecoration(canvasEdit, designInstance, selectedDeco, selectedSize,
                                                selectedColor, selectedThickness);
                    asignEventToDecoration(selectedDeco);
                    //PaintManager.PaintDecoration();
                }

                else
                    MessageBox.Show("Properties hasn't been set correctly");
            }
   
            catch
                {
                    MessageBox.Show("Properties hasn't been set correctly");
                }
        }

        /* Decoration Events */
        public void asignEventToDecoration(int typeDeco)
        {
            if (typeDeco == 0) /* Line */
            {
                /*foreach (Line decoration in designInstance.getDecorations())
                {

                }*/
            }

            else if (typeDeco == 1 || typeDeco == 2) /* Circle */
            {
                foreach (Circle circle in designInstance.getCircleDecorations())
                {
                    circle.getEllipse().MouseMove += circleDecorations_MouseMove;
                }

            }
        }

        void circleDecorations_MouseMove(object sender, MouseEventArgs e)
        {
            Ellipse circle = sender as Ellipse;
            int variance = 0;

            if (circle != null && e.LeftButton == MouseButtonState.Pressed)
            {
                if (circle.Width == 27)
                    variance = 10;
                else if (circle.Width == 64)
                    variance = 30;
                else
                    variance = 50;

                circle.SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - variance);
                circle.SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - variance);
                DesignManager.saveCirclesDecoPosition(designInstance);
            }            
        }

        /* BasePoint Events */
        private void asignEventToBasePoint()
        {
            designInstance.getBasePoints()[0].getPointEllipse().MouseMove += MouseMovePointA;
            designInstance.getBasePoints()[1].getPointEllipse().MouseMove += MouseMovePointB;
            designInstance.getBasePoints()[2].getPointEllipse().MouseMove += MouseMovePointC;
            designInstance.getBasePoints()[3].getPointEllipse().MouseMove += MouseMovePointD;
            designInstance.getBasePoints()[4].getPointEllipse().MouseMove += MouseMovePointE;
        }

        private void MouseMovePointA(object sender, MouseEventArgs e)
        {
            Ellipse pointA = designInstance.getBasePoints()[0].getPointEllipse();
            Ellipse pointB = designInstance.getBasePoints()[1].getPointEllipse();
            Ellipse pointE = designInstance.getBasePoints()[4].getPointEllipse();
            Grid segmentA = designInstance.getSegmentA().getSegmentContainer();
            Grid segmentB = designInstance.getSegmentB().getSegmentContainer();
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
               
                if (Canvas.GetTop(pointE) < 435 && Canvas.GetTop(pointA) > 5)
                    pointA.SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
                else
                {
                    if (Canvas.GetTop(pointE) >= 435)
                        pointA.SetValue(Canvas.TopProperty, Canvas.GetTop(pointA) - 1);

                    if (Canvas.GetTop(pointA) <= 5)
                        pointA.SetValue(Canvas.TopProperty, Canvas.GetTop(pointA) + 1);
                }
               
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

                // Set design values 
                designInstance.getBasePoints()[0].setAxisX(Canvas.GetLeft(pointA));
                designInstance.getBasePoints()[0].setAxisY(Canvas.GetTop(pointA));
                designInstance.getBasePoints()[1].setAxisX(Canvas.GetLeft(pointB));
                designInstance.getBasePoints()[1].setAxisY(Canvas.GetTop(pointB));
                designInstance.getBasePoints()[4].setAxisX(Canvas.GetLeft(pointE));
                designInstance.getBasePoints()[4].setAxisY(Canvas.GetTop(pointE));
                designInstance.getSegmentA().setAxisX(Canvas.GetLeft(segmentA));
                designInstance.getSegmentA().setAxisY(Canvas.GetTop(segmentA));
                designInstance.getSegmentB().setAxisX(Canvas.GetLeft(segmentB));
                designInstance.getSegmentB().setAxisY(Canvas.GetTop(segmentB));
            }
        }

        private void MouseMovePointB(object sender, MouseEventArgs e)
        {
            Ellipse pointA = designInstance.getBasePoints()[0].getPointEllipse();
            Ellipse pointB = designInstance.getBasePoints()[1].getPointEllipse();
            Ellipse pointE = designInstance.getBasePoints()[4].getPointEllipse();
            Grid segmentA = designInstance.getSegmentA().getSegmentContainer();
            Grid segmentB = designInstance.getSegmentB().getSegmentContainer();
            Line segmentC = designInstance.getSegmentC();
            Line segmentE = designInstance.getSegmentE();

            if (pointB != null && e.LeftButton == MouseButtonState.Pressed)
            {
                // Move ellipse
                if (Canvas.GetLeft(pointB) < 645 && Canvas.GetLeft(pointB) > Canvas.GetLeft(pointA))      
                    pointB.SetValue(Canvas.LeftProperty, e.GetPosition(canvasEdit).X - 10);
                else
                    pointB.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointB) - 1);
                
                if (Canvas.GetTop(pointE) < 435 && Canvas.GetTop(pointB) > 5) 
                    pointB.SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
                else
                {
                    if (Canvas.GetTop(pointE) >= 435)
                        pointB.SetValue(Canvas.TopProperty, Canvas.GetTop(pointB) - 1);

                    else if (Canvas.GetTop(pointB) <= 5)
                        pointB.SetValue(Canvas.TopProperty, Canvas.GetTop(pointB) + 1);
                }
               
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
            
                // Set design values
                designInstance.getBasePoints()[0].setAxisX(Canvas.GetLeft(pointA));
                designInstance.getBasePoints()[0].setAxisY(Canvas.GetTop(pointA));
                designInstance.getBasePoints()[1].setAxisX(Canvas.GetLeft(pointB));
                designInstance.getBasePoints()[1].setAxisY(Canvas.GetTop(pointB));
                designInstance.getBasePoints()[4].setAxisX(Canvas.GetLeft(pointE));
                designInstance.getBasePoints()[4].setAxisY(Canvas.GetTop(pointE));
                designInstance.getSegmentA().setAxisX(Canvas.GetLeft(segmentA));
                designInstance.getSegmentA().setAxisY(Canvas.GetTop(segmentA));
                designInstance.getSegmentB().setAxisX(Canvas.GetLeft(segmentB));
                designInstance.getSegmentB().setAxisY(Canvas.GetTop(segmentB));
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
               
                if (Canvas.GetTop(pointC) < 435 && Canvas.GetTop(pointC) > 5)
                    pointC.SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
                else
                {
                    if (Canvas.GetTop(pointC) >= 435)
                        pointC.SetValue(Canvas.TopProperty, Canvas.GetTop(pointC) - 1);

                    else if (Canvas.GetTop(pointC) <= 5)
                        pointC.SetValue(Canvas.TopProperty, Canvas.GetTop(pointC) + 1);
                }

                // Move line
                segmentC.X2 = Canvas.GetLeft(pointC) + 5;
                segmentC.Y2 = Canvas.GetTop(pointC) + 5;
                segmentD.X1 = Canvas.GetLeft(pointC) + 7;
                segmentD.Y1 = Canvas.GetTop(pointC) + 7;

                // Set design values
                designInstance.getBasePoints()[2].setAxisX(Canvas.GetLeft(pointC));
                designInstance.getBasePoints()[2].setAxisY(Canvas.GetTop(pointC));
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
                
                if (Canvas.GetTop(pointD) < 435 && Canvas.GetTop(pointD) > 5)
                    pointD.SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
                else
                {
                    if (Canvas.GetTop(pointD) >= 435)
                        pointD.SetValue(Canvas.TopProperty, Canvas.GetTop(pointD) - 1);

                    else if (Canvas.GetTop(pointD) <= 5)
                        pointD.SetValue(Canvas.TopProperty, Canvas.GetTop(pointD) + 1);
                }

                // Move line
                segmentD.X2 = Canvas.GetLeft(pointD) + 5;
                segmentD.Y2 = Canvas.GetTop(pointD) + 5;
                segmentE.X1 = Canvas.GetLeft(pointD) + 7;
                segmentE.Y1 = Canvas.GetTop(pointD) + 7;

                // Set design values
                designInstance.getBasePoints()[3].setAxisX(Canvas.GetLeft(pointD));
                designInstance.getBasePoints()[3].setAxisY(Canvas.GetTop(pointD));
            }
        }

        private void MouseMovePointE(object sender, MouseEventArgs e)
        {
            Ellipse pointA = designInstance.getBasePoints()[0].getPointEllipse();
            Ellipse pointB = designInstance.getBasePoints()[1].getPointEllipse();
            Ellipse pointD = designInstance.getBasePoints()[3].getPointEllipse();
            Ellipse pointE = designInstance.getBasePoints()[4].getPointEllipse();
            Grid segmentA = designInstance.getSegmentA().getSegmentContainer();
            Grid segmentB = designInstance.getSegmentB().getSegmentContainer();
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

                if (Canvas.GetTop(pointE) < 435 && Canvas.GetTop(pointE) > Canvas.GetTop(pointA))
                    pointE.SetValue(Canvas.TopProperty, e.GetPosition(canvasEdit).Y - 10);
                else
                {
                    if (Canvas.GetTop(pointE) >= 435)
                        pointE.SetValue(Canvas.TopProperty, Canvas.GetTop(pointE) - 1);

                    else if (Canvas.GetTop(pointE) <= Canvas.GetTop(pointA))
                        pointE.SetValue(Canvas.TopProperty, Canvas.GetTop(pointE) + 1);
                }

                // Move auxiliar ellipse
                Canvas.SetLeft(pointA, Canvas.GetLeft(pointE));
                pointB.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointA) + segmentB.ActualWidth);

                // Move arcs
                segmentA.Width = Math.Abs((Canvas.GetLeft(pointE) - Canvas.GetLeft(segmentA)) + 5);
                segmentA.Height = Math.Abs(Canvas.GetTop(pointE) - Canvas.GetTop(pointA));

                designInstance.getSegmentA().setSegmentContainerWidth(segmentA.Width);

                // Move auxiliar arc
                segmentB.SetValue(Canvas.LeftProperty, Canvas.GetLeft(pointA) + 5);

                // Move line
                segmentE.X2 = Canvas.GetLeft(pointE) + 5;
                segmentE.Y2 = Canvas.GetTop(pointE) + 5;

                // Move auxiliar line
                segmentC.X1 = Canvas.GetLeft(pointB) + 5;
                segmentC.Y1 = Canvas.GetTop(pointB) + 5;

                // Set design values
                designInstance.getBasePoints()[0].setAxisX(Canvas.GetLeft(pointA));
                designInstance.getBasePoints()[0].setAxisY(Canvas.GetTop(pointA));
                designInstance.getBasePoints()[1].setAxisX(Canvas.GetLeft(pointB));
                designInstance.getBasePoints()[1].setAxisY(Canvas.GetTop(pointB));
                designInstance.getBasePoints()[4].setAxisX(Canvas.GetLeft(pointE));
                designInstance.getBasePoints()[4].setAxisY(Canvas.GetTop(pointE));
                designInstance.getSegmentA().setAxisX(Canvas.GetLeft(segmentA));
                designInstance.getSegmentA().setAxisY(Canvas.GetTop(segmentA));
                designInstance.getSegmentB().setAxisX(Canvas.GetLeft(segmentB));
                designInstance.getSegmentB().setAxisY(Canvas.GetTop(segmentB));
            }
        }

        private void ArcadeMode_Selection(object sender, ContextMenuEventArgs e)
        {
            //canvasArcade.Children.Clear();
            PaintManager.arcadeMode(designInstance, canvasArcade);
        }

        /*private void ArcadeMode_Selection(object sender, RoutedEventArgs e)
        {
            canvasArcade.Children.Clear();
            PaintManager.arcadeMode(designInstance, canvasArcade);
        }*/

    }
}
