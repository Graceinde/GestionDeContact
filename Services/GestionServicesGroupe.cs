using System.Collections.Generic;
using System.Data.SqlClient;
using Entites;

namespace Services
{
    public class GestionServicesGroupe
    {
        //Connecter a la base de donnee
        const string configbd = @"Data Source=DESKTOP-QSUGK9L\SQLEXPRESS; Initial Catalog =contactV2 ;Integrated Security = True; Connect Timeout = 35";

        public static List<Groupe> Touslesgroupes()
        {
            List<Groupe> lgroupe = new List<Groupe>();
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"select * from groupe";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Groupe gre = new Groupe();
                            gre.id= reader.GetInt32(0);
                            gre.groupe = reader.GetString(1);
                            lgroupe.Add(gre);
                        }
                    }
                }
            }
            return lgroupe;
        }

        public static void AjouterGroupe(Groupe gre)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"insert into groupe(groupe) values(@groupe)";
                    cmd.Parameters.AddWithValue("@groupe", gre.groupe);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ModifierGroupe(Groupe gre)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"update groupe SET groupe =@groupe where id = @id";
                    cmd.Parameters.AddWithValue("@groupe", gre.groupe);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /*public static void Supprimergroupe(int id)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"delete from groupe where id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }*/

        public static void SupprimerGroupe2(Personne pers)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"delete from groupe where id = @id";
                    cmd.Parameters.AddWithValue("@id", pers.groupe.id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
