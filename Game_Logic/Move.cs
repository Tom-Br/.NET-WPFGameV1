using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic
{
    public class Move
    {
        public Speler Speler { get; set; }
        public double Aanvalskracht { get; set; }

        public Move(Speler speler, double aanvalskracht)
        {
            Speler = speler;
            Aanvalskracht = aanvalskracht;
        }
    }
}
