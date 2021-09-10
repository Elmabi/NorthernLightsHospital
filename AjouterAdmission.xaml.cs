using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NorthernLightsHospital
{
    /// <summary>
    /// Interaction logic for AjouterAdmission.xaml
    /// </summary>
    public partial class AjouterAdmission : Window
    {
        Gestion gestion;
        public AjouterAdmission()
        {
            InitializeComponent();
            gestion = new Gestion();
            cbNSS.DataContext = MainWindow.myBDD.Patients.ToList();
            cbIDMedecin.DataContext = MainWindow.myBDD.Medecins.ToList();
            cbChirugieProgramme.DataContext = gestion.ListeDepartement;
            dpDateAdmission.SelectedDate = DateTime.Today;
            dpDateChirugie.SelectedDate = DateTime.Now;
            ListeTelephoneHopital();
            ListeTeleviseurHopital();
        }

        public void ListeTelephoneHopital()
        {
            string[] listeTelephoneHopital = new string[] {"Pas de téléphone", "613-555-0131", "613-555-0127", "613-555-0152",
            "613-555-0117","613-555-0151","613-555-0123"};
            _ = cbTelephone.ItemsSource = listeTelephoneHopital;
            cbTelephone.SelectedIndex = 0;
        }

        public void ListeTeleviseurHopital()
        {
            string[] listeTeleviseurHopital = new string[] {"Pas de téléviseur", "Samsung-OK85", "LG", "Philips",
            "Motorola","Ben-Q","Condor 378", "Samsung-OIR74"};
            _ = cbTeleviseur.ItemsSource = listeTeleviseurHopital;
            cbTeleviseur.SelectedIndex = 0;
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = cbNSS.SelectedItem as Patient;
            if (!DejaAdmis(patient))
            {
                Admettre(patient);
            }
        }

        private void Admettre(Patient patient)
        {
            if (cbChirugieProgramme.Text == "Non")
            {
                AdmettreSansDateChirugie(patient);
                return;
            }

            AdmettreAvecDateChirugie(patient);
        }

        private void AdmettreSansDateChirugie(Patient patient)
        {
            Admission newAdmission = new Admission
            {
                chirugieProgramme = ObtenirChiffreChirugieProgramme(),
                dateAdmission = dpDateAdmission.SelectedDate,
                NSS = cbNSS.Text,
                idMedecin = decimal.Parse(cbIDMedecin.Text),
                telephone = cbTelephone.Text,
                televiseur = cbTeleviseur.Text,
                numeroLit = int.Parse(cbNumeroLit.Text)
            };
            lblResultat.Content = "Chirugie Programme: " + newAdmission.chirugieProgramme
            + "\nDate Admission: " + DateTime.Parse(newAdmission.dateAdmission.ToString()).ToShortDateString()
            + "\nNSS: " + newAdmission.NSS
            + "\nidMedecin: " + newAdmission.idMedecin
            + "\nTelephone: " + newAdmission.telephone
            + "\nTeleviseur: " + newAdmission.televiseur
            + "\nNuméro Lit: " + newAdmission.numeroLit;

            _ = MainWindow.myBDD.Admissions.Add(newAdmission);
            Sauvegarder(patient.prenom, patient.nom);
            OccupeLit();
        }

        private void AdmettreAvecDateChirugie(Patient patient)
        {
            Admission newAdmission = new Admission
            {
                chirugieProgramme = ObtenirChiffreChirugieProgramme(),
                dateAdmission = dpDateAdmission.SelectedDate,
                NSS = cbNSS.Text,
                idMedecin = decimal.Parse(cbIDMedecin.Text),
                telephone = cbTelephone.Text,
                televiseur = cbTeleviseur.Text,
                dateChirugie = dpDateChirugie.SelectedDate,
                numeroLit = int.Parse(cbNumeroLit.Text)
            };
            lblResultat.Content = "Chirugie Programme: " + newAdmission.chirugieProgramme
            + "\nDate Admission: " + DateTime.Parse(newAdmission.dateAdmission.ToString()).ToShortDateString()
            + "\nNSS: " + newAdmission.NSS
            + "\nidMedecin: " + newAdmission.idMedecin
            + "\nTelephone: " + newAdmission.telephone
            + "\nTeleviseur: " + newAdmission.televiseur
            + "\nDate Chirugie: " + DateTime.Parse(newAdmission.dateChirugie.ToString()).ToShortDateString()
            + "\nNuméro Lit: " + newAdmission.numeroLit;
            _ = MainWindow.myBDD.Admissions.Add(newAdmission);
            Sauvegarder(patient.prenom, patient.nom);
            OccupeLit();
        }

        private static bool DejaAdmis(Patient patient)
        {
            foreach (Admission maladeAdmis in MainWindow.myBDD.Admissions)
            {
                if (maladeAdmis.NSS == patient.NSS)
                {
                    string message = "Ce patient est déjà admis dans cette hôpital.";
                    string titre = "Attention";
                    MessageBox.Show(message, titre, MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }
            }

            return false;
        }

        private void Sauvegarder(string prenom, string nom)
        {
            try
            {
                MainWindow.myBDD.SaveChanges();
                string message = $"Patient {prenom.ToUpper()} {nom.ToUpper()} admis avec Succèss";
                string titre = "Succès";
                MessageBox.Show(message, titre, MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool ObtenirChiffreChirugieProgramme()
        {
            return cbChirugieProgramme.Text == "Oui";
        }

        private void cbNumeroLit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Lit lit = cbNumeroLit.SelectedItem as Lit;
            var queryTypeLit =
                from typeLit in MainWindow.myBDD.TypeLits
                where typeLit.idType == lit.idType
                select typeLit.description;

            txtTypeLit.Text = queryTypeLit.FirstOrDefault();
            List<Departement> departements = MainWindow.myBDD.Departements.Where(
                                        departement => departement.idDepartement == lit.idDepartement).ToList();
            txtDepartement.Text = departements[0].nomDepartement;
        }


        private void cbChirugieProgramme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string etatChirugie = cbChirugieProgramme.Text;
            cbNumeroLit.DataContext = ListeLitsParDepartement(etatChirugie);
        }

        public void OccupeLit()
        {
            Lit lit = cbNumeroLit.SelectedItem as Lit;
            lit.occupe = true;
            MainWindow.myBDD.SaveChanges();
        }

        private List<Lit> ListeLitsParDepartement(string etatChirugie)
        {
            foreach (DepartementHopital departement in gestion.ListeDepartement)
            {
                if (departement.Occupe == etatChirugie)
                {
                    return departement.ListeLits;

                }
            }

            return null;
        }

        public string ObtenirDateChirugie()
        {
            if (cbChirugieProgramme.Text != "Non")
            {
                return dpDateChirugie.SelectedDate.ToString();
            }
            return null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbNumeroLit.DataContext = ListeLitsParDepartement("Oui");

        }
    }
}
