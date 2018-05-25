using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;
using Managers;
using Services;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Tests");
            List<Personne> lpers = new List<Personne>();
            lpers = GestionManagersPersonne.AllPersonne();
            foreach(Personne p in lpers)
            {
               
                    Console.WriteLine("Id:" + p.id);
                    Console.WriteLine("Nom:" + p.nom);
                    Console.WriteLine("Prenom:" + p.prenom);
                    Console.WriteLine("Email:" + p.email);
                    Console.WriteLine("Mobile:" + p.mobile);
                    //Console.WriteLine("adresseid:" + p.adresse.id);
                    Console.WriteLine("numeroappartement:" + p.adresse.numeroappartement);
                    Console.WriteLine("numerorue:" + p.adresse.numerorue);
                    Console.WriteLine("nomrue:" + p.adresse.nomrue);
                    Console.WriteLine("ville:" + p.adresse.ville);
                    Console.WriteLine("type:" + p.genre.type);
                    Console.WriteLine("groupe:" + p.groupe.groupe);
               
                    
                    Console.WriteLine("---------------------------------------");
                
            }

           /* List<Adresse> ladresse = new List<Adresse>();
            ladresse = GestionManagersAdresse.AllAdresse();
            
            foreach (Adresse ap in ladresse)
            {

                Console.WriteLine("Id:" + ap.id);
                Console.WriteLine("appart:" + ap.numeroappartement);
                Console.WriteLine("numrue:" + ap.numerorue);
                Console.WriteLine("nomrue:" + ap.nomrue);
                Console.WriteLine("ville:" + ap.ville);
                

                Console.WriteLine("---------------------------------------");

            }*/


            List<Personne> listePersonne = new List<Personne>();
            listePersonne = GestionManagersPersonne.AllPersonne();
            Personne dernier = listePersonne.Last();
            Console.WriteLine("last person name " + dernier.nom);
            Console.WriteLine("last person id " + dernier.id);
            int id_personne = dernier.id + 1;
            Console.WriteLine("id personne " + id_personne);
            // test supprimer 
            //  PersonneManager.Delete(8);
            // test add contact
              Personne newPersonne = new Personne(id_personne, "etienne", "Delarue","Test2@yahou.fr","2514568798",
                  new Adresse(id_personne, "25", "12","Tessier","marseil"),
                  new Genre(id_personne,"M"), 
                  new Identification(id_personne, "Hello","abc"),
                  new Groupe(id_personne,"tester"));

    // AJOUT
            GestionManagersPersonne.AddPersonne(newPersonne);
            
        }
    }
}
