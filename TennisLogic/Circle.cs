using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TennisBusiness
{
    public class Circle : Decoration
    {
        private int size;
        private bool filled;
        private Ellipse ellipse;

        public Circle(int pThikness, Color pColor, int pSize, bool pFilled, double pAxisX, double pAxisY)
                       : base(1, pThikness, pColor)
        {
            ellipse = new Ellipse();
            setSize(pSize);
            setFilled(pFilled);
            setAxisX(300);
            setAxisY(180);
        }

        public void setSize(int pSize)
        {
            this.size = pSize;
            
            if (pSize == 0) /* Small */ 
            {
                ellipse.Width = 27;
                ellipse.Height = 27;
            }

            else if (pSize == 1) /* Medium */
            {
                ellipse.Width = 64;
                ellipse.Height = 64;
            }

            else /* Large */
            {
                ellipse.Width = 110;
                ellipse.Height = 110;
            }
        }

        public void setFilled(bool pFilled)
        {
            this.filled = pFilled;
        }

        public string getSize()
        {
            string stringSize = "";

            if (size == 0)
                stringSize = "Small";
            if (size == 1)
                stringSize = "Medium";
            if (size == 2)
                stringSize = "Large";

            return stringSize;
        }

        public int getSizeNumber()
        {
            return size;
        }

        public bool getFilled()
        {
            return this.filled;
        }

        public Ellipse getEllipse()
        {
            return ellipse;
        }

        public void drawCircle()
        {
            ellipse.StrokeThickness = getThickness();
            ellipse.Stroke = new SolidColorBrush(getColor());

            if (filled)
                ellipse.Fill = new SolidColorBrush(getColor());
            else
                ellipse.Fill = Brushes.Transparent;
        }

    }
}
