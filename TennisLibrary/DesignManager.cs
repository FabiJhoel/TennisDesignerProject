using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using TennisBusiness;

namespace TennisLibrary
{
    public static class DesignManager
    {
        public static void addDecoration(Design pDesign, int typeDeco, int pSize, Color pColor, int pThickness)
        {
            switch (typeDeco)
            {
                case 0:
                        Decoration line = new Decoration (typeDeco, pThickness, pColor);
                        pDesign.addDecoration(line);
                        MessageBox.Show("linea agregada");
                        break;

                case 1:
                        Circle circle = new Circle(pThickness, pColor, pSize, false, 0, 0);
                        pDesign.addDecoration(circle);
                        MessageBox.Show("circulo agregado");
                        break;

                case 2:
                        Circle fCircle = new Circle(pThickness, pColor, pSize, true, 0, 0);
                        pDesign.addDecoration(fCircle);
                        MessageBox.Show("circulo relleno agregado");
                        break;

                case 3:
                        Decoration outline = new Decoration(typeDeco, pThickness, pColor);
                        pDesign.addDecoration(outline);             
                        PaintManager.paintSilhouette(pDesign, pColor, pThickness);
                        MessageBox.Show("contorno cambiado");
                        break;

            }
        }
    }
}
