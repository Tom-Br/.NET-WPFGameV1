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
        public double Power { get; set; }
        public bool Won { get; set; }

        public Speler(string naam) {
            Naam = naam;
            Gezondheid = 100;
            Power = 100;
        }

        public Move Aanvallen(Speler speler, double damage)
        {
            if(damage >= speler.Gezondheid)
            {
                Power = 0;
                speler.Gezondheid = 0;
                this.Won = true;
                speler.Won = false;
            }
            else
            {
                Power -= damage;
                speler.Gezondheid -= damage;
            }

            return new Move(speler, damage);
        }

        public override string ToString()
        {
            return "Speler: " + Naam + " Gezondheid: " + Gezondheid + " Power : " + Power ;
        }
    }
}
