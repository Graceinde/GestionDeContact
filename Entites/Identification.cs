using System;

namespace Entites
{
    public class Identification
    {
        public int id { get; set; }
        public String utilisateur { get; set; }
        public String motdepasse { get; set; }
 

        public Identification()
        {
        }

        public Identification(int id, string utilisateur, string motdepasse)
        {
            this.id = id;
            this.utilisateur = utilisateur;
            this.motdepasse = motdepasse;
        }
    }
}
