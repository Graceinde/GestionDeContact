using System.Collections.Generic;
using System.Data.SqlClient;
using Entites;

namespace Services
{
    public class GestionServicesAdresse
    {
        //Connecter a la base de donnee
        const string configbd = @"Data Source=DESKTOP-QSUGK9L\SQLEXPRESS; Initial Catalog =contactV2;Integrated Security = True; Connect Timeout = 35";

        public static List<Adresse> TouteslesAdresses()
        {
            List<Adresse> ladresse = new List<Adresse>();
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"select * from adresse";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Adresse adr = new Adresse();
                            adr.id = reader.GetInt32(0);
                            adr.numeroappartement= reader.GetString(1);
                            adr.numerorue= reader.GetString(2);
                            adr.nomrue= reader.GetString(3);
                            adr.ville= reader.GetString(4);
                            ladresse.Add(adr);
                        }
                    }
                }
            }
            return ladresse;
        }

        public static void AjouterAdresse(Adresse adr)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    
                    cmd.CommandText = @"insert into adresse(numeroappartement,numerorue,nomrue,ville) values(@numeroappartement,@numerorue,@nomrue,@ville)";
                    cmd.Parameters.AddWithValue("@numeroappartement", adr.numeroappartement);
                    cmd.Parameters.AddWithValue("@numerorue", adr.numerorue);
                    cmd.Parameters.AddWithValue("@nomrue", adr.nomrue);
                    cmd.Parameters.AddWithValue("@ville", adr.ville);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ModifierAdresse(Adresse adr)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"update adresse SET numeroappartement =@numeroappartement, numerorue=@numerorue, nomrue=@nomrue, ville=@ville where id = @id";
                    cmd.Parameters.AddWithValue("@numeroappartement", adr.numeroappartement);
                    cmd.Parameters.AddWithValue("@numerorue", adr.numerorue);
                    cmd.Parameters.AddWithValue("@nomrue", adr.nomrue);
                    cmd.Parameters.AddWithValue("@ville", adr.ville);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /*public static void SupprimerAdresse(int id)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"delete from adresse where id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }*/

        public static void SupprimerAdresse2(Personne pers)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"delete from adresse where id = @id";
                    cmd.Parameters.AddWithValue("@id", pers.adresse.id);
                    cmd.ExecuteNonQuery();
                }
          }
        }
    }
}
