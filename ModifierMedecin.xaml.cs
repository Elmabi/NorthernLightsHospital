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
    /// Interaction logic for ModifierMedecin.xaml
    /// </summary>
    public partial class ModifierMedecin : Window
    {
        public ModifierMedecin()
        {
            InitializeComponent();
            cbIdentifiant.DataContext = MainWindow.myBDD.Medecins.ToList();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            Medecin medecin = cbIdentifiant.SelectedItem as Medecin;
            string prenom = BonInput(txtPrenom, txtPrenom.Text, "Prénom"); if (prenom == null) return;
            string nom = BonInput(txtNom, txtNom.Text, "Nom"); if (nom == null) return;
            medecin.prenom = prenom;
            medecin.nom = nom;
            Sauvegarder(prenom, nom);
        }

        public String BonInput(TextBox textBox, string text, string textPardefaut)
        {
            if (String.IsNullOrEmpty(text) || text == textPardefaut)
            {
                string message = "Le " + textPardefaut + " saisie n'est pas valide.";
                string titre = "Attention";
                MessageBox.Show(message, titre, MessageBoxButton.OK, MessageBoxImage.Information);
                textBox.Focus();
                textBox.Clear();
                return null;
            }

            return text;
        }

        private void Sauvegarder(string prenom, string nom)
        {
            try
            {
                MainWindow.myBDD.SaveChanges();
                string message = $"Médécin {prenom.ToUpper()} {nom.ToUpper()} modifier avec Succèss";
                string titre = "Succès";
                MessageBox.Show(message, titre, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
