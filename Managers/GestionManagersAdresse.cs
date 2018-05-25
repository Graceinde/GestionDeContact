using System;
using Entites;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class GestionManagersAdresse
    {
        
        public static List<Adresse> AllAdresse()
        {
            return GestionServicesAdresse.TouteslesAdresses();
        }
        public static void EditerAdresse(Adresse adr)
        {
            GestionServicesAdresse.ModifierAdresse(adr);
        }
        /*public static void DeleteAdresse(int id)
        {
            GestionServicesAdresse.SupprimerAdresse(id);
        }*/

        public static void DeleteAdresse2(Personne pers)
        {
            GestionServicesAdresse.SupprimerAdresse2(pers);
        }

        public static void AddAdresse(Adresse adr)
        {
            GestionServicesAdresse.AjouterAdresse(adr);
        }
    }
}
