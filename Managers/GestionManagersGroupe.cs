using Entites;
using Services;
using System.Collections.Generic;

namespace Managers
{
    public class GestionManagersGroupe
    {
        public static List<Groupe> Allgroupe()
        {
            return GestionServicesGroupe.Touslesgroupes();
        }
        public static void Editergroupe(Groupe gpe)
        {
            GestionServicesGroupe.ModifierGroupe(gpe);
        }
        /*public static void DeleteGroupe(int id)
        {
            GestionServicesGroupe.Supprimergroupe(id);
        }*/

        public static void DeleteGroupe2(Personne pers)
        {
            GestionServicesGroupe.SupprimerGroupe2(pers);
        }

        public static void AddGroupe(Groupe gpe)
        {
            GestionServicesGroupe.AjouterGroupe(gpe);
        }
    }
}
