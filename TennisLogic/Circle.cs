using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TennisBusiness
{
    public class Circle : Decoration
    {
        private int size;
        private bool filled;

        public Circle(int pThikness, Color pColor, int pSize, bool pFilled, double pAxisX, double pAxisY)
            : base(1, pThikness, pColor)
        {
            setRadio(pSize);
            setFilled(pFilled);
        }

        public void setRadio(int pRadio)
        {
            this.size = pRadio;
        }
        public void setFilled(bool pFilled)
        {
            this.filled = pFilled;
        }
        public int getRadio()
        {
            return this.size;
        }
        public bool getFilled()
        {
            return this.filled;
        }
    }
}
