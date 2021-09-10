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
    /// Interaction logic for Facture.xaml
    /// </summary>
    public partial class Facture : Window
    {
        Gestion gestion;
        public Facture()
        {
            InitializeComponent();
            gestion = new Gestion();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgFacturePatientAdmis.DataContext = gestion.ListeFacturePatients;
        }
    }
}
