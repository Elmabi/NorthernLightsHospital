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
    /// Interaction logic for AjouterPatient.xaml
    /// </summary>
    public partial class AjouterPatient : Window
    {
        public AjouterPatient()
        {
            InitializeComponent();
            cbAssurance.DataContext = MainWindow.myBDD.Assurances.ToList();
            dpDateNaissance.SelectedDate = DateTime.Now;
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            Patient newPatient = new Patient();
            string nom = BonInput(txtNom, txtNom.Text, "Nom"); if (nom == null) return;
            string ville = BonInput(txtVille, txtVille.Text, "Ville"); if (ville == null) return;
            string prenom = BonInput(txtPrenom, txtPrenom.Text, "Prénom"); if (prenom == null) return;
            string codePostal = BonInput(txtCodePostal, txtCodePostal.Text, "Code Postal"); if (codePostal == null) return;
            string NSS = prenom.Substring(0, 2) + nom.Substring(0, 2);
            string telephone = BonInput(txtTelephone, txtTelephone.Text, "Téléphone"); if (telephone == null) return;
            string adresse = BonInput(txtAdresse, txtAdresse.Text, "Téléphone"); if (adresse == null) return;
            string province = cbProvince.Text;
            int idAssurance = int.Parse(cbAssurance.Text);

            newPatient.NSS = NSS.ToUpper();
            newPatient.prenom = prenom;
            newPatient.nom = nom;
            newPatient.dateNaissance = (DateTime)dpDateNaissance.SelectedDate;
            newPatient.adresse = adresse;
            newPatient.ville = ville;
            newPatient.province = province;
            newPatient.codePostal = codePostal;
            newPatient.telephone = telephone;
            newPatient.idAssurance = idAssurance;
            MainWindow.myBDD.Patients.Add(newPatient);
            Sauvegarder(prenom, nom);
        }
        private void Sauvegarder(string prenom, string nom)
        {
            try
            {
                MainWindow.myBDD.SaveChanges();
                string message = $"Nouveau Patient {prenom.ToUpper()} {nom.ToUpper()} ajouté avec Succèss";
                string titre = "Succès";
                MessageBox.Show(message, titre, MessageBoxButton.OK, MessageBoxImage.Information);
                txtNom.Text = "Nom";
                txtPrenom.Text = "Prénom";
                txtAdresse.Text = "Adresse";
                txtCodePostal.Text = "Code Postal";
                txtTelephone.Text = "Téléphone";
                txtVille.Text = "Ville";

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
