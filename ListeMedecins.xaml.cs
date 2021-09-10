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
    /// Interaction logic for ListeMedecins.xaml
    /// </summary>
    public partial class ListeMedecins : Window
    {
        public ListeMedecins()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from medecin in MainWindow.myBDD.Medecins
                        select new
                        {
                            ID = medecin.idMedecin,
                            prenom = medecin.prenom,
                            nom = medecin.nom
                        };

            dgListeMedecin.DataContext = query.ToList();
        }
    }
}
