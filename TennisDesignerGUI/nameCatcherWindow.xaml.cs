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
using System.Windows.Shapes;

namespace TennisDesignerGUI
{
    /// <summary>
    /// Interaction logic for nameCatcherWindow.xaml
    /// </summary>
    public partial class nameCatcherWindow : Window
    {
        private string nameCaught;
        public nameCatcherWindow()
        {
            InitializeComponent();
        }

        private void catchName(object sender, RoutedEventArgs e)
        {
            this.nameCaught = this.nameTextBox.GetLineText(0);
            this.Hide();
        }
        public string getNameCaught()
        {
            return this.nameCaught;
        }
    }
}
