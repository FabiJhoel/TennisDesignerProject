﻿using System;
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
using TennisBusiness;


namespace TennisDesignerGUI
{

    public partial class DesignNameWindow : Window
    {
        private ListBox designNamesListBox;
        private Design design;

        public DesignNameWindow(ListBox pListBoxDesigns, Design pDesign)
        {
            InitializeComponent();
            designNamesListBox = pListBoxDesigns;
            design = pDesign;
        }

        private void confirmNameButton_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;

            foreach (string name in designNamesListBox.Items)
            {
                if (name == nameTextBox.Text)
                    valid = false;
            }

            if (nameTextBox.Text == "")
                MessageBox.Show("The design name must contain at least one character");
            else if (valid == false)
                MessageBox.Show("This design name already exists, please write a different one");
            else
            {
                designNamesListBox.Items.Add(nameTextBox.Text);
                design.setName(nameTextBox.Text);
                this.Hide();
            }
        }
    }
}
