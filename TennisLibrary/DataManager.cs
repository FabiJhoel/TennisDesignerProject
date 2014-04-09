using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using TennisBusiness;
using DataAccess;

namespace TennisLibrary
{
    public static class DataManager
    {
        static DataAdministrator dataAdmin = new DataAdministrator();

        public static void saveDesign(Design pDesign)
        {
            dataAdmin.saveDesign(pDesign);
            MessageBox.Show("Your design has been saved as: " + pDesign.getName());
        }

        public static async void loadDesignList(ListBox pListBoxDesigns)
        {
            List<string> names = await dataAdmin.getDesignList();

            foreach (string name in names)
            {
                pListBoxDesigns.Items.Add(name);
            }
        }

        public static async void loadDesign(string pName)
        {
            Design design = await dataAdmin.getDesign(pName);
            MessageBox.Show(" " + design.getBasePoints()[0].getAxisX());
        }
    }
}
