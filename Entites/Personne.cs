using System;

namespace Entites
{
    public class Personne
    {
        public int id { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public String email { get; set; }
        public String mobile { get; set; }
        public Adresse adresse { get; set; }
        public Genre genre{ get; set; }
        public Identification identification{ get; set; }
        public Groupe groupe{ get; set; }


        public override string ToString()
        {
            return nom + " " + prenom + " " +  "Email:" + email + " Tél:" + mobile ;
        }


        public Personne()
        {
        }

        public Personne(int id, string nom, string prenom, string email, string mobile, Adresse adresse, Genre genre, Groupe groupe)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.mobile = mobile;
            this.adresse = adresse;
            this.genre = genre;
            this.groupe = groupe;
        }

        public Personne(int id, string nom, string prenom, string email, string mobile, Adresse adresse, Genre genre, Identification identification, Groupe groupe)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.mobile = mobile;
            this.adresse = adresse;
            this.genre = genre;
            this.identification = identification;
            this.groupe = groupe;
        }

        
    }
}
