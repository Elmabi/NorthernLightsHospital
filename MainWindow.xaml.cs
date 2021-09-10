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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NorthernLightsHospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static NorthernLightsHospitalEntities myBDD;
        public MainWindow()
        {
            InitializeComponent();
            myBDD = new NorthernLightsHospitalEntities();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Password == "admin")
            {
                Hide();
                _ = new FenetreAdmin().ShowDialog();
            }

            if (txtUsername.Text == "prepose" && txtPassword.Password == "admin")
            {
                Hide();
                _ = new FenetrePrepose().ShowDialog();
            }

            if (txtUsername.Text == "medecin" && txtPassword.Password == "admin")
            {
                Hide();
                _ = new FenetreMedecin().ShowDialog();
            }
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            string message = "Désirez-vous réellement quitter ? ";
            string titre = "Attention";
            MessageBoxResult reponse = MessageBox.Show(message, titre, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (reponse == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public new void MouseLeave(string textParDefaut, string textVide, TextBox textBox)
        {
            if (textBox.Text == textVide)
            {
                textBox.Text = textParDefaut;
                textBox.Foreground = Brushes.Gray;
            }
        }

        private new void MouseEnter(string textParDefaut, string textVide, TextBox textBox)
        {
            if (textBox.Text == textParDefaut)
            {
                textBox.Text = textVide;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void txtUsername_MouseLeave(object sender, MouseEventArgs e)
        {
            MouseLeave("admin", string.Empty, txtUsername);
        }

        private void txtUsername_MouseEnter(object sender, MouseEventArgs e)
        {
            MouseEnter("admin", string.Empty, txtUsername);
        }

        private void txtPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txtPassword.Password.ToString() == "admin")
            {
                txtPassword.Password = string.Empty;
                txtPassword.Foreground = Brushes.Black;
            }
        }

        private void txtPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            if (txtPassword.Password == string.Empty)
            {
                txtPassword.Password = "admin";
                txtPassword.Foreground = Brushes.Gray;
            }
        }
    }
}
