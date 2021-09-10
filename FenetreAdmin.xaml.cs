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
    /// Interaction logic for FenetreAdmin.xaml
    /// </summary>
    public partial class FenetreAdmin : Window
    {
        
        public FenetreAdmin()
        {
            InitializeComponent();
            
        }

        private void btnAjouterMedecin_Click(object sender, RoutedEventArgs e)
        {
            _ = new AjouterMedecin().ShowDialog();
        }

        private void btnModifierMedecin_Click(object sender, RoutedEventArgs e)
        {
            _ = new ModifierMedecin().ShowDialog();
        }

        private void btnSupprimerMedecin_Click(object sender, RoutedEventArgs e)
        {
            _ = new SupprimerMedecin().ShowDialog();
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnListeMedecin_Click(object sender, RoutedEventArgs e)
        {
            _ = new ListeMedecins().ShowDialog();
        }

        private void btnListePatients_Click(object sender, RoutedEventArgs e)
        {
            _ = new ListePatients().ShowDialog();
        }

        private void btnListeAssurance_Click(object sender, RoutedEventArgs e)
        {
            _ = new ListeAssurances().ShowDialog();
        }

        private void btnListePatientAdmis_Click(object sender, RoutedEventArgs e)
        {
            _ = new ListeAdmission().ShowDialog();
        }

        private void btnFacturePatient_Click(object sender, RoutedEventArgs e)
        {
            _ = new Facture().ShowDialog();
        }
    }
}
