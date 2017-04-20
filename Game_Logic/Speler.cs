using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic
{
    public class Speler
    {
        public String Naam { get; set; }
        public Double Gezondheid { get; set; }

        public Speler(string naam) {
            Naam = naam;
            Gezondheid = 100;
        }

        public Move Aanvallen(Speler speler, double damage)
        {
            speler.Gezondheid -= damage;
            return new Move(speler, damage);
        }

        public override string ToString()
        {
            return "Speler: " + Naam + " Gezondheid: " + Gezondheid;
        }
    }
}
