using System;

namespace Entites
{
    public class Adresse
    {
        public int id { get; set; }
        public String numeroappartement { get; set; }
        public String numerorue { get; set; }
        public String nomrue{ get; set; }
        public String ville { get; set; }
        

        public Adresse()
        {
        }

        public Adresse(int id, string numeroappartement, string numerorue, string nomrue, string ville)
        {
            this.id = id;
            this.numeroappartement = numeroappartement;
            this.numerorue = numerorue;
            this.nomrue = nomrue;
            this.ville = ville;
        }
    }
}
