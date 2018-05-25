using System;

namespace Entites
{
    public class Groupe
    {
        public int id { get; set; }
        public String groupe { get; set; }
       

        public Groupe()
        {
        }

        public Groupe(int id, string groupe)
        {
            this.id = id;
            this.groupe = groupe;
        }
    }
}
