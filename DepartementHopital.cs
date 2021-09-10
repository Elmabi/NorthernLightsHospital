using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthernLightsHospital
{
    public class DepartementHopital
    {
        public DepartementHopital(string nom, string occupe, List<Lit> listeLits)
        {
            Nom = nom;
            Occupe = occupe;
            ListeLits = listeLits;
        }

        public string Occupe { get; set; }
        public string Nom { get; set; }
        public List<Lit> ListeLits { get; set; }
    }
}
