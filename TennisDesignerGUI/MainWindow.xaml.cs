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
