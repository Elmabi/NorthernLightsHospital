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
    /// Interaction logic for ListePatients.xaml
    /// </summary>
    public partial class ListePatients : Window
    {
        public ListePatients()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = (from patient in MainWindow.myBDD.Patients
                         select new
                         {
                             NSS = patient.NSS,
                             prenom = patient.prenom,
                             nom = patient.nom,
                             telephone = patient.telephone,
                             ville = patient.ville,
                             date = patient.dateNaissance,
                             code = patient.codePostal.ToUpper(),
                             adresse = patient.adresse
                         }).ToList().Select(x => new
                         {
                             NSS = x.NSS,
                             prenom = x.prenom,
                             nom = x.nom,
                             telephone = x.telephone,
                             ville = x.ville,
                             date = string.Format("{0:yyyy-MM-dd}", x.date),
                             code = x.code,
                             adresse = x.adresse

                         });

            dgListePatient.DataContext = query.ToList();
        }
    }
}
