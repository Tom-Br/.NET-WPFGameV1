using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Logic
{
    public class Controller
    {        
        private static Controller instance;
        private Controller(){}
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }
        public Spel Spel { get; set; }
        public void StartGame(string naamSpeler) {
            Spel = new Spel(naamSpeler);
        }


    }
}
