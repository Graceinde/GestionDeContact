using System.Collections.Generic;
using Entites;
using Services;

namespace Managers
{
    public class GestionManagersGenre
    {
        public static List<Genre> AllGenre()
        {
            return GestionServicesGenre.Touslesgenres();
        }
        public static void EditerGenre(Genre gre)
        {
            GestionServicesGenre.Modifiergenre(gre);
        }
        /*public static void DeleteGenre(int id)
        {
            GestionServicesGenre.Supprimergenres(id);
        }*/

        public static void DeleteGenre2(Personne pers)
        {
            GestionServicesGenre.SupprimerGenre2(pers);
        }
        public static void AddGenre(Genre gre)
        {
            GestionServicesGenre.Ajoutergenre(gre);
        }
    }
}
