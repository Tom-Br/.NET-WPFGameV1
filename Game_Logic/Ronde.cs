using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic
{
    public class Ronde
    {
        private static int id = 0;
        public int RondeID { get; }
        public Move MoveSpeler { get; set; }
        public Move MoveComputer { get; set; }
        public Ronde() {
            id++;
            RondeID = id;
        }
    }
}
