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
    /// Interaction logic for SupprimerMedecin.xaml
    /// </summary>
    public partial class SupprimerMedecin : Window
    {
        public SupprimerMedecin()
        {
            InitializeComponent();
            cbIdentifiant.DataContext = MainWindow.myBDD.Medecins.ToList();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Medecin medecin = cbIdentifiant.SelectedItem as Medecin;
            Supprimer(medecin);
        }

        private void SauvegarderSuppression(Medecin medecin)
        {
            try
            {
                MainWindow.myBDD.SaveChanges();
                string message = $"Médécin {medecin.prenom.ToUpper()} {medecin.nom.ToUpper()} supprimé avec Succèss";
                string titre = "Succès";
                MessageBox.Show(message, titre, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Supprimer(Medecin medecin)
        {
            string message = "Désirez-vous réellement supprimer " + medecin.prenom + " " + medecin.nom + " ? ";
            string titre = "Attention";
            MessageBoxResult reponse = MessageBox.Show(message, titre, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (reponse == MessageBoxResult.Yes)
            {
                MainWindow.myBDD.Medecins.Remove(medecin);
                SauvegarderSuppression(medecin);
                cbIdentifiant.DataContext = MainWindow.myBDD.Medecins.ToList();

            }
        }
    }
}
