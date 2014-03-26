using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisLibrary
{
    public class Circle : Figure
    {
        private int radio;
        private bool filled;

        public Circle(int pThikness, ConsoleColor pColor, int pRadio, bool pFilled)
            : base(1, pThikness, pColor)
        {
            setRadio(pRadio);
            setFilled(pFilled);
        }

        public void setRadio(int pRadio)
        {
            this.radio = pRadio;
        }
        public void setFilled(bool pFilled)
        {
            this.filled = pFilled;
        }
        public int getRadio()
        {
            return this.radio;
        }
        public bool getFilled()
        {
            return this.filled;
        }
    }
}
