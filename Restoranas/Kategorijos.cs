using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Restoranas
{
    class Kategorijos
    {
        public int katID;
        public string katPav;
        public List<Patiekalai> patiekaluSarasas;


        public Kategorijos(int katID, string katPav)
        {
            this.katID = katID;
            this.katPav = katPav;
            patiekaluSarasas = new List<Patiekalai>();
        }

        
    }
}
