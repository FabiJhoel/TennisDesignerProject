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

    public partial class DesignNameWindow : Window
    {
        private ListBox designNamesListBox;

        public DesignNameWindow(ListBox pListBoxDesigns)
        {
            InitializeComponent();
            designNamesListBox = pListBoxDesigns;
        }

        private void confirmNameButton_Click(object sender, RoutedEventArgs e)
        {
            designNamesListBox.Items.Add(nameTextBox.Text);
            this.Hide();
        }
    }
}
