using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic
{
    public class Spel
    {
        public Speler Gebruiker { get; set; }
        public Speler Computer { get; set; }
        public List <Ronde> Ronde { get; set; }


        public Spel(string speler1Naam)
        {
            Gebruiker = new Speler(speler1Naam);
            Computer = new Speler("Computer");
            Ronde = new List<Ronde>();
        }
        public void NieuweRonde() {
            Ronde.Add(new Ronde());
        }
    }
}
