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
            string sSize = "";
            switch (typeDeco)
            {
                case 0:
                        LineDec line = new LineDec(pThickness, pColor);
                        pDesign.addLineDecoration(line);
                        line.setRemarks("Line\n" + "Color: " + pColor.ToString()
                        + "\n" + "Thickness: " + pThickness.ToString() + "px");
                        PaintManager.paintLineDecoration(pCanvas, line, 1);
                        break;

                case 1:
                        if (pSize == 0)
                             sSize= "Small";
                        if (pSize == 1)
                            sSize = "Medium";
                        if (pSize == 2)
                            sSize = "Large";
                        Circle circle = new Circle(pThickness, pColor, pSize, false, 300, 180);
                        pDesign.addCircleDecoration(circle);
                        circle.setRemarks("Circle\n" + "Size: " + sSize + "\n" + "Color: " 
                        + pColor.ToString()+ "\n" + "Thickness: " + pThickness.ToString() + "px");
                        PaintManager.paintCircleDecoration(pCanvas, circle, 1);
                        break;

                case 2:
                        if (pSize == 0)
                             sSize= "Small";
                        if (pSize == 1)
                            sSize = "Medium";
                        if (pSize == 2)
                            sSize = "Large";
                        Circle fCircle = new Circle(pThickness, pColor, pSize, true, 300, 180);
                        pDesign.addCircleDecoration(fCircle);
                        fCircle.setRemarks("Filled Circle\n" + "Color: " + pColor.ToString()
                        + "\n" + "Size: " + sSize);
                        PaintManager.paintCircleDecoration(pCanvas, fCircle, 1);
                        break;

                case 3:
                        pDesign.getOutline().setColor(pColor);
                        pDesign.getOutline().setThickness(pThickness);
                        pDesign.getOutline().setRemarks("Outline\n" + "Color: " + pColor.ToString()
                        + "\n" + "Thickness: " + pThickness.ToString() + "px");
                        PaintManager.paintOutline(pDesign, pCanvas, 1);
                        break;

                case 4:
                        pDesign.getShoeSole().setColor(pColor);
                        pDesign.getShoeSole().setThickness(pThickness);
                        pDesign.getShoeSole().setRemarks("Shoe Sole\n" + "Color: " + pColor.ToString() 
                        + "\n" + "Thickness: " + pThickness.ToString() + "px");
                        PaintManager.paintShoeSole(pDesign, 1);
                        break;

                case 5:
                        Area area = new Area(pColor, 300, 180);
                        area.setRemarks("Area\n" + "Color: " + pColor.ToString());
                        pDesign.addAreaDecoration(area);
                        PaintManager.paintArea(pCanvas, area);
                        break;

                case 6:
                        pDesign.getBaseColor().setColor(pColor);
                        pDesign.getBaseColor().setRemarks("Base Color\n" + "Color: " + pColor.ToString()
                        + "\n");
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

        public static void saveAreasPosition(Design pDesign)
        {
            foreach (Area area in pDesign.getFillingAreas())
            {
                area.setAxisX(Canvas.GetLeft(area.getRectangle()));
                area.setAxisY(Canvas.GetTop(area.getRectangle()));
            }
        }
    }
}
