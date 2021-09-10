using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthernLightsHospital
{
    public class FacturePatient
    {
        public FacturePatient()
        {
        }


        public string NSS { get; set; }
        public string PrenomPatient { get; set; }
        public string NomPatient { get; set; }
        public decimal NumeroLit { get; set; }
        public string PrenomMedecin { get; set; }
        public string NomMedecin { get; set; }
        public string Televiseur { get; set; }
        public string Telephone { get; set; }
        public double NetAPayer { get; set; }

    }
}
