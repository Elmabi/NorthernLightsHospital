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
    /// Interaction logic for ListeAssurances.xaml
    /// </summary>
    public partial class ListeAssurances : Window
    {
        public ListeAssurances()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from assurance in MainWindow.myBDD.Assurances
                        select new
                        {
                            ID = assurance.idAssurance,
                            nom = assurance.nomCompagnie,
                        };

            dgListeAssurance.DataContext = query.ToList();
        }
    }
}
