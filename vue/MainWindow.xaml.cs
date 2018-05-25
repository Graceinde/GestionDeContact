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
using Entites;
using Managers;
using Services;

namespace vue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Enregistrer(object sender, RoutedEventArgs e)
        {
            Personne p = new Personne();
            p.nom = text_nom.Text.Trim();
            p.prenom = text_prenom.Text.Trim();
            p.email = text_email.Text.Trim();
            p.mobile = text_mobile.Text.Trim();

            Adresse a = new Adresse();
            a.numeroappartement = text_numeroappart.Text.Trim();
            a.numerorue = text_numerorue.Text.Trim();
            a.nomrue = text_nomrue.Text.Trim();
            a.ville = text_ville.Text.Trim();

            Genre g = new Genre();
            g.type = text_type.Text.Trim();

            Groupe gr = new Groupe();
            gr.groupe = text_groupe.Text.Trim();

            GestionManagersPersonne.AddPersonne(p);
            GestionManagersAdresse.AddAdresse(a);
            GestionManagersGenre.AddGenre(g);
            GestionManagersGroupe.AddGroupe(gr);

            UpdateList();
        }

        public void UpdateList()
        {
            listContact.Items.Clear();

            List<Personne> list = GestionManagersPersonne.AllPersonne();

            foreach (Personne personne in list)
            {
                listContact.Items.Add(personne);
            }
        }

        private void Button_NvContact(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.Show();
            Close();
        }

        private void Button_Supprimer(object sender, RoutedEventArgs e)
        {
            /*if (listContact.SelectedItems != null)
            {
                foreach (Personne personne in listContact.SelectedItems)
                    GestionManagersPersonne.DeletePersonne(personne);
                UpdateList();
            }*/
        }

        private void Button_GO(object sender, RoutedEventArgs e)
        {

        }
    }
}
