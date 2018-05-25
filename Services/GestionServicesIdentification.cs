using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entites;

namespace Services
{
    public class GestionServicesIdentification
    {
        //Connecter a la base de donnee
        const string configbd = @"Data Source=DESKTOP-QSUGK9L\SQLEXPRESS; Initial Catalog =contactV2 ;Integrated Security = True; Connect Timeout = 35";

        //Methode d'authentification
        public static bool Authentification(string utilisateur, string motdepasse)
        {
            bool IsOk = false;

            SqlConnection conn = new SqlConnection(configbd);
            SqlDataAdapter ada = new SqlDataAdapter(@"select Count(*) from identification where utilisateur like'" + utilisateur + "' AND motdepasse like '" + motdepasse + "'", conn);
            DataTable Dt = new DataTable();

            ada.Fill(Dt);

            if (Dt.Rows[0][0].ToString() == "1")
            {
                IsOk = true;

            }
            else
            {
                IsOk = false;
            }

            return IsOk;
        }

        private static List<Identification> Touteslesidendifications()
        {
            List<Identification> lidentification = new List<Identification>();
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"select * from identification";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Identification id = new Identification();
                            id.id = reader.GetInt32(0);
                            id.utilisateur= reader.GetString(1);
                            id.motdepasse= reader.GetString(2);
                            lidentification.Add(id);
                        }
                    }
                }
            }
            return lidentification;
        }

        public static void AjouterIdentification(Identification ide)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"insert into identification(utilisateur,motdepasse) values(@utilisateur,@motdepasse)";
                    cmd.Parameters.AddWithValue("@utilisateur", ide.utilisateur);
                    cmd.Parameters.AddWithValue("@motdepasse", ide.motdepasse);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ModifierIdentification(Identification ide)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"update identification SET utilisateur =@utilisateur, motdepasse =@motdepasse where id = @id";
                    cmd.Parameters.AddWithValue("@utilisateur", ide.utilisateur);
                    cmd.Parameters.AddWithValue("@motdepasse", ide.motdepasse);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
