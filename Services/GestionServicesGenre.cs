using System.Collections.Generic;
using Entites;
using System.Data.SqlClient;

namespace Services
{

    public class GestionServicesGenre
    {
        //Connecter a la base de donnee
        const string configbd = @"Data Source=DESKTOP-QSUGK9L\SQLEXPRESS; Initial Catalog =contactV2 ;Integrated Security = True; Connect Timeout = 35";

        public static List<Genre> Touslesgenres()
        {
            List<Genre> lgenre = new List<Genre>();
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"select * from genre";
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Genre gr = new Genre();
                            gr.id = reader.GetInt32(0);
                            gr.type = reader.GetString(1);
                            lgenre.Add(gr);
                        }
                    }
                }
            }
                return lgenre;
        }

        public static void Ajoutergenre(Genre gre)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"insert into genre(type) values(@type)";
                    cmd.Parameters.AddWithValue("@type", gre.type);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Modifiergenre(Genre gre)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"update genre SET type =@type where id = @id";
                    cmd.Parameters.AddWithValue("@type", gre.type);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /*public static void Supprimergenres(int id)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"delete from genre where id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }*/

        public static void SupprimerGenre2(Personne pers)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"delete from genre where id =@id";
                    cmd.Parameters.AddWithValue("@id", pers.genre.id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
