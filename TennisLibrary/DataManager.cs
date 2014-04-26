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
        static DataAdministrator dataAdmin = DataAdministrator.getInstance();

        public static void saveDesign(Design pDesign)
        {
            dataAdmin.saveDesign(pDesign);
            MessageBox.Show("Your design has been saved as: " + pDesign.getName());
        }

        public static async Task<List<Design>> loadDesignList()
        {
            List<Design> designs = await dataAdmin.getDesignList();
            return designs;
        }

        public static async void writeDesignList(ListBox pListBoxDesign)
        {
            List<Design> designs = await DataManager.loadDesignList();
            foreach (Design design in designs)
            {
                pListBoxDesign.Items.Add(design.getName());
            }
        }

        public static async Task<Design> loadDesign(string pName)
        {
            return await dataAdmin.getDesign(pName);
        }
    }
}
