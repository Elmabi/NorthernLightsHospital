using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for FenetreMedecin.xaml
    /// </summary>
    public partial class FenetreMedecin : Window
    {
        public static List<Admission> admissions;
        public FenetreMedecin()
        {
            InitializeComponent();
            admissions = new List<Admission>();
            admissions = MainWindow.myBDD.Admissions.ToList();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string message = "Désirez-vous revenir à la fenêtre de Login ? ";
            string titre = "Attention";
            MessageBoxResult reponse = MessageBox.Show(message, titre, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (reponse == MessageBoxResult.Yes)
            {
                new MainWindow().Show();
                Hide();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChargerListePatientsAdmis();
        }

        private void ChargerListePatientsAdmis()
        {
            var query = (from admission in MainWindow.myBDD.Admissions
                         select new
                         {
                             NSS = admission.NSS,
                             numeroLit = admission.numeroLit,
                             idMedecin = admission.idMedecin,
                             chirugieProgramme = admission.chirugieProgramme,
                             dateAdmission = admission.dateAdmission,
                             dateChirugie = admission.dateChirugie,
                             dateCongé = admission.dateConge,
                             televiseur = admission.televiseur,
                             telephone = admission.telephone
                         }).ToList().Select(x => new
                         {
                             NSS = x.NSS,
                             numeroLit = x.numeroLit,
                             idMedecin = x.idMedecin,
                             chirugieProgramme = x.chirugieProgramme,
                             dateAdmission = string.Format("{0:yyyy-MM-dd}", x.dateAdmission),
                             dateChirugie = string.Format("{0:yyyy-MM-dd}", x.dateChirugie),
                             dateCongé = string.Format("{0:yyyy-MM-dd}", x.dateCongé),
                             televiseur = x.televiseur,
                             telephone = x.telephone

                         });

            dgPatientAdmis.DataContext = query.ToList();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnDonneConge_Click(object sender, RoutedEventArgs e)
        {
            if (dgPatientAdmis.SelectedIndex ==-1)
            {
                string message = $"Vous avez oublié de selectionner le patient.";
                string titre = "Attention";
                MessageBox.Show(message, titre, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (dgPatientAdmis.SelectedItem != null)
            {
                int indexAdmission = dgPatientAdmis.SelectedIndex;
                Admission admission = admissions[indexAdmission];
                if (string.IsNullOrEmpty(admission.dateConge.ToString()))
                {
                    admission.dateConge = DateTime.Now;
                    string message = $"Patient {NomPrenomPatient(admission.NSS)[0]} {NomPrenomPatient(admission.NSS)[1]} a bien récu son congé.";
                    string titre = "Succès";
                    MessageBox.Show(message, titre, MessageBoxButton.OK, MessageBoxImage.Information);
                    LibererLit(admission.numeroLit);
                    MainWindow.myBDD.SaveChanges();
                    ChargerListePatientsAdmis();
                }
                else
                {
                    string message1 = $"Patient {NomPrenomPatient(admission.NSS)[0]} {NomPrenomPatient(admission.NSS)[1]} a déjà récu son congé. Vous ne pouvez plus lui donner de congé.";
                    string titre1 = "Attention";
                    MessageBox.Show(message1, titre1, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

        }

        public void LibererLit(decimal numeroLit)
        {
            Lit lit;
            foreach (Lit litOccupe in MainWindow.myBDD.Lits.ToList())
            {
                if (litOccupe.numeroLit == numeroLit )
                {
                    lit = litOccupe;
                    lit.occupe = false;
                }
            }
        }
        public string[] NomPrenomPatient( string nss)
        {
            string[] nomPrenom = { "0","1"};
            foreach (Patient patient in MainWindow.myBDD.Patients)
            {
                if (patient.NSS == nss)
                {
                    nomPrenom[0] = patient.prenom;
                    nomPrenom[1] = patient.nom;
                }
            }
            return nomPrenom;
        }

    }
   
}
