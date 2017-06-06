using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Restoranas
{
    class Patiekalai
    {
        public int patiekaloID;
        public int kategorijosID;
        public string pavadinimas;
        public double kaina;
        public string aprasymas;

        

        public Patiekalai(int patiekaloID, int kategorijosID, string pavadinimas, double kaina, string aprasymas)
        {
            this.patiekaloID = patiekaloID;
            this.kategorijosID = kategorijosID;
            this.pavadinimas = pavadinimas;
            this.kaina = kaina;
            this.aprasymas = aprasymas;
        }



    }
}
