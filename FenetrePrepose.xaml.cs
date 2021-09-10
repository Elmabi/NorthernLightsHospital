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
    /// Interaction logic for FenetrePrepose.xaml
    /// </summary>
    public partial class FenetrePrepose : Window
    {
        public FenetrePrepose()
        {
            InitializeComponent();
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

        private void btnAjouterPatient_Click(object sender, RoutedEventArgs e)
        {
            _ = new AjouterPatient().ShowDialog();
        }

        private void btnModifierPatient_Click(object sender, RoutedEventArgs e)
        {
            _ = new ModifierPatient().ShowDialog();
        }

        private void btnSupprimerPatient_Click(object sender, RoutedEventArgs e)
        {
            _ = new SupprimerPatient().ShowDialog();
        }

        private void btnListePatients_Click(object sender, RoutedEventArgs e)
        {
            _ = new ListePatients().ShowDialog();
        }

        private void btnAjouterAdmission_Click(object sender, RoutedEventArgs e)
        {
            _ = new AjouterAdmission().ShowDialog();
        }
    }
}
