using System.Collections.Generic;
using Entites;
using Services;

namespace Managers
{
    public class GestionManagersPersonne
    {

        public static List<Personne> AllPersonne()
        {
            return GestionServicesPersonne.TouteslesPersonnes();
        }

        public static List<Personne> PersonneParNom(string nom)
        {
            return GestionServicesPersonne.TouteslesPersonnesParNom(nom);
        }

        public static void EditerPersonne(Personne pers)
        {
            GestionServicesPersonne.ModifierPersonne(pers);
        }

        /*public static void DeletePersonne(int id)
        {
            GestionServicesPersonne.SupprimerPersonne(id);
        }*/

        public static void DeletePersonne2(Personne  pers)
        {
            GestionServicesPersonne.SupprimerPersonne2(pers);
        }

        public static void AddPersonne(Personne pers)
        {
            GestionServicesPersonne.AjouterPersonne(pers);
        }

    }
}
