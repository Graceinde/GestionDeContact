using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Entites;
using Managers;

namespace view
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateList();
        }

        private void Button_Enregistrer(object sender, RoutedEventArgs e)
        {
            List<Personne> listePersonne = new List<Personne>();
            listePersonne = GestionManagersPersonne.AllPersonne();
            Personne dernier = listePersonne.Last();
            Console.WriteLine("last person name " + dernier.nom);
            Console.WriteLine("last person id " + dernier.id);
            int id_personne = dernier.id + 1;


            Personne p = new Personne();
            p.id = id_personne;
            p.nom = text_nom.Text;
            p.prenom = text_prenom.Text;
            p.email = text_email.Text;
            p.mobile = text_mobile.Text;
            p.adresse = new Adresse(id_personne, text_numeroappart.Text, text_numerorue.Text, text_nomrue.Text, text_ville.Text);
            p.genre = new Genre(id_personne, text_type.Text);
            p.identification = new Identification(id_personne, text_nom.Text, text_prenom.Text);
            p.groupe = new Groupe(id_personne, text_groupe.Text);

            GestionManagersPersonne.AddPersonne(p);

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

        private void Button_Supprimer(object sender, RoutedEventArgs e)
        {

            if (listContact.SelectedItems != null)
            {
                foreach (Personne personne in listContact.SelectedItems)
                    GestionManagersPersonne.DeletePersonne2(personne);
                UpdateList();
            }
        }

        private void Button_GO(object sender, RoutedEventArgs e)
        {
            if (text_recherche.Text != null)
            {
                listContact.Items.Clear();
                List<Personne> list = GestionManagersPersonne.PersonneParNom(text_recherche.Text);

                foreach (Personne personne in list)
                {
                    listContact.Items.Add(personne);
                }

            }

        }
    }
}

