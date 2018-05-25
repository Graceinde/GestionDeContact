using System;

namespace Entites
{
    public class Genre
    {
        public int id { get; set; }
        public String type { get; set; }
        

        public Genre()
        {
        }

        public Genre(int id, string type)
        {
            this.id = id;
            this.type = type;
        }
    }
}
