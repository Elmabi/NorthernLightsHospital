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
    /// Interaction logic for AjouterMedecin.xaml
    /// </summary>
    public partial class AjouterMedecin : Window
    {
        public AjouterMedecin()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            Medecin newMedecin = new Medecin();
            string prenom = BonInput(txtPrenom, txtPrenom.Text, "Prénom"); if (prenom == null) return;
            string nom = BonInput(txtNom, txtNom.Text, "Nom"); if (nom == null) return;
            newMedecin.prenom = prenom;
            newMedecin.nom = nom;
            MainWindow.myBDD.Medecins.Add(newMedecin);
            Sauvegarder(prenom, nom);
        }

        private void Sauvegarder(string prenom, string nom)
        {
            try
            {
                MainWindow.myBDD.SaveChanges();
                string message = $"Nouveau Médécin {prenom.ToUpper()} {nom.ToUpper()} ajouté avec Succèss";
                string titre = "Succès";
                MessageBox.Show(message, titre, MessageBoxButton.OK, MessageBoxImage.Information);
                txtNom.Text = "Nom";
                txtPrenom.Text = "Prénom";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    }
}
