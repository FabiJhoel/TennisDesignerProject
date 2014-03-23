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
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // private Brush _previousFill = null;
        public MainWindow()
        {
            InitializeComponent();
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");
            ListBoxDesigns.Items.Add("examp1");    
        }


        //Drag and Drop
     /*   //LO QUE PASA CUANDO SE SUELTA ALGO EN EL ELIPSE
        private void ellipse_Drop(object sender, DragEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null)
            {
                // If the DataObject contains string data, extract it. 
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    // If the string can be converted into a Brush,  
                    // convert it and apply it to the ellipse.
                    BrushConverter converter = new BrushConverter();
                    if (converter.IsValid(dataString))
                    {
                        Brush newFill = (Brush)converter.ConvertFromString(dataString);
                        ellipse.Fill = newFill;
                    }
                }
            }
        }

        //PERMITE ARRASTRAR EL ELIPSE
        private void ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(ellipse, ellipse.Fill.ToString(), DragDropEffects.Copy);
            }
        }*/

       /* private Point position;

        protected override void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Get the x and y coordinates of the mouse pointer.
                position = e.GetPosition(this);
                double pX = position.X;
                double pY = position.Y;
             
            }
        }
        */
       //private void canvas_MouseMove(object sender, MouseEventArgs e)
       // {
       //     Ellipse ellipse = sender as Ellipse; 
       //    //var draggableControl = sender as UserControl;

       //     if (isDragging && ellipse != null)
       //     {
       //         Point currentPosition = e.GetPosition(canvasEdit);

       //         var transform = ellipse.RenderTransform as TranslateTransform;
       //         if (transform == null)
       //         {
       //             transform = new TranslateTransform();
       //             ellipse.RenderTransform = transform;
       //         }

       //         transform.X = currentPosition.X - clickPosition.X;
       //         transform.Y = currentPosition.Y - clickPosition.Y;
       //     }
       //     /*// Get the x and y coordinates of the mouse pointer.
       //     Point position = e.GetPosition(this);
       //     double pX = position.X;
       //     double pY = position.Y;

       //     // Sets the position of the image to the mouse coordinates.
       //     punto.SetValue(Canvas.LeftProperty, pX);
       //     punto.SetValue(Canvas.LeftProperty, pY);*/
       // }

       //private Point clickPosition;
       //bool isDragging;
       //private void ellipse_MouseDown(object sender, MouseEventArgs e)
       //{

       //    isDragging = true;
       //    Ellipse ellipse = sender as Ellipse;
       //    //var draggableControl = sender as UserControl;
       //    clickPosition = e.GetPosition(canvasEdit);
       //    ellipse.CaptureMouse();
       //}

       //private void ellipse_MouseUp(object sender, MouseEventArgs e)
       //{
       //    isDragging = false;
       //    Ellipse ellipse = sender as Ellipse;
       //    //var draggable = sender as UserControl;
       //    ellipse.ReleaseMouseCapture();
       //}

      /*  double FirstXPos = 0.0;
        double FirstYPos = 0.0;//, FirstArrowXPos, FirstArrowYPos;
        
        object MovingObject;
        Point position;
        private void ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            Point position = e.GetPosition(ellipse);
            double pX = position.X;
            double pY = position.Y;

        }

        void ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MovingObject = null;
        }*/

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
