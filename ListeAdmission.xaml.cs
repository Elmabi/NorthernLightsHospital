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
    /// Interaction logic for ListeAdmission.xaml
    /// </summary>
    public partial class ListeAdmission : Window
    {
        public ListeAdmission()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
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
    }
}
