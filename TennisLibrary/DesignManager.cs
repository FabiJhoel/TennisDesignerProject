﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using TennisBusiness;

namespace TennisLibrary
{
    public static class DesignManager
    {
        public static void addDecoration(Canvas pCanvas, Design pDesign, int typeDeco, int pSize, Color pColor, int pThickness)
        {
            switch (typeDeco)
            {
                case 0:
                        LineDec line = new LineDec(pThickness, pColor);
                        pDesign.addLineDecoration(line);
                        PaintManager.PaintLineDecoration(pCanvas, line, 1);
                        MessageBox.Show("linea agregada");
                        break;

                case 1:
                        Circle circle = new Circle(pThickness, pColor, pSize, false, 300, 180);
                        pDesign.addCircleDecoration(circle);
                        PaintManager.PaintCircleDecoration(pCanvas, circle, 1);
                        MessageBox.Show("circulo agregado");
                        break;

                case 2:
                        Circle fCircle = new Circle(pThickness, pColor, pSize, true, 300, 180);
                        pDesign.addCircleDecoration(fCircle);
                        PaintManager.PaintCircleDecoration(pCanvas, fCircle, 1);
                        MessageBox.Show("circulo relleno agregado");
                        break;

                case 3:
                        pDesign.getOutline().setColor(pColor);
                        pDesign.getOutline().setThickness(pThickness);
                        //PaintManager.paintOutline(pDesign, pColor, pThickness);
                        MessageBox.Show("contorno cambiado");
                        break;

                case 4:
                        pDesign.getShoeSole().setColor(pColor);
                        pDesign.getShoeSole().setThickness(pThickness);
                        //PaintManager.paintShoeSole(pDesign, pColor, pThickness);
                        MessageBox.Show("suela cambiada");
                        break;
            }
        }

        public static void saveCirclesDecoPosition(Design pDesign)
        {
            foreach (Circle circle in pDesign.getCircleDecorations())
            {
                circle.setAxisX(Canvas.GetLeft(circle.getEllipse()));
                circle.setAxisY(Canvas.GetTop(circle.getEllipse()));
            }
        }

        public static void saveLinesDecoPosition(Design pDesign)
        {
            foreach (LineDec line in pDesign.getLineDecorations())
            {
                foreach (BasePoint point in line.getBasePoints())
                {
                    point.setAxisX(Canvas.GetLeft(point.getPointEllipse()));
                    point.setAxisY(Canvas.GetTop(point.getPointEllipse()));
                }
            }
        }

        public static void addDecorationRemarks(/*Canvas pCanvas, Design pDesign, int typeDeco, int pSize, Color pColor, int pThickness*/)
        {
            Label remarks = new Label();
            MessageBox.Show("sirviooooooo");
        }
    }
}
