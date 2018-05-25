using Entites;
using Services;

namespace Managers
{
    public class GestionManagersIdentification
    {
        //Se Logger 
        public static bool Login(string utilisateur, string motdepasse)
        {
            return GestionServicesIdentification.Authentification(utilisateur, motdepasse);
        }

        public static void EditerIdentification(Identification ide)
        {
            GestionServicesIdentification.ModifierIdentification(ide);
        }
      
        public static void AddIdentification(Identification ide)
        {
            GestionServicesIdentification.AjouterIdentification(ide);
        }
    }
}
