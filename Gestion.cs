using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthernLightsHospital
{
    public class Gestion
    {
        private List<Admission> admissions;
        public Gestion()
        {
            admissions = new List<Admission>();
            admissions = MainWindow.myBDD.Admissions.ToList();
            ListeDepartement = new List<DepartementHopital>();
            ListeFacturePatients = new List<FacturePatient>();
            MesListeDepartement();
            MesListeFactures();
        }
        public void MesListeDepartement()
        {

            List<Lit> listeLitsPediatrie = MainWindow.myBDD.Lits.Where(lit => lit.idDepartement == 1 && lit.occupe == false).ToList();
            List<Lit> listeLitsChirugie = MainWindow.myBDD.Lits.Where(lit => lit.idDepartement == 2 && lit.occupe == false).ToList();

            ListeDepartement.Add(new DepartementHopital("Chirugie", "Oui", listeLitsChirugie));
            ListeDepartement.Add(new DepartementHopital("Pédiatrie", "Non", listeLitsPediatrie));
        }

        public void MesListeFactures()
        {
            List<Patient> listePatient = new List<Patient>();
            List<Medecin> listeMedecin = new List<Medecin>();
            List<Lit> listeLit = new List<Lit>();
            List<Admission> listeAdmission = new List<Admission>();
            foreach (Admission admission in admissions)
            {
                listePatient = MainWindow.myBDD.Patients.Where(patient => patient.NSS == admission.NSS).ToList();
                listeMedecin = MainWindow.myBDD.Medecins.Where(medecin => medecin.idMedecin == admission.idMedecin).ToList();
                listeLit = MainWindow.myBDD.Lits.Where(lit => lit.numeroLit == admission.numeroLit).ToList();
                listeAdmission = MainWindow.myBDD.Admissions.Where(admission1 => admission1.idAdmission == admission.idAdmission).ToList();
                for (int i = 0; i < listePatient.Count; i++)
                {
                    ListeFacturePatients.Add(new FacturePatient()
                    {
                        NSS = listePatient[i].NSS,
                        PrenomPatient = listePatient[i].prenom,
                        NomPatient = listePatient[i].nom,
                        NumeroLit = listeLit[i].numeroLit,
                        PrenomMedecin = listeMedecin[i].prenom,
                        NomMedecin = listeMedecin[i].nom,
                        Televiseur = listeAdmission[i].televiseur,
                        Telephone = listeAdmission[i].telephone,
                    });
                }
            }
            NetAPayer();
        }

        public void NetAPayer()
        {
            for (int i = 0; i < ListeFacturePatients.Count; i++)
            {
                if (ListeFacturePatients[i].Telephone != "Pas de téléphone")
                {
                    ListeFacturePatients[i].NetAPayer += 7.50;
                }
                if (ListeFacturePatients[i].Televiseur != "Pas de téléviseur")
                {
                    ListeFacturePatients[i].NetAPayer += 42.50;
                }
            }
           
        }
        public List<DepartementHopital> ListeDepartement { get; set; }
        public List<FacturePatient> ListeFacturePatients { get; set; }
    }
}
