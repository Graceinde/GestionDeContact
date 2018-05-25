using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entites;

namespace Services
{
    public class GestionServicesPersonne
    {
        //Connecter a la base de donnee
        const string configbd = @"Data Source=DESKTOP-QSUGK9L\SQLEXPRESS; Initial Catalog =contactV2 ;Integrated Security = True; Connect Timeout = 35";

        public static List<Personne> TouteslesPersonnes()
        {
            List<Personne> lpersonne = new List<Personne>();
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"select pr.id, pr.nom, pr.prenom,pr.email,pr.mobile,ad.numeroappartement,ad.numerorue,ad.nomrue,ad.ville,gr.type,gp.groupe from personne pr join adresse ad on pr.adresseid = ad.id join genre gr on gr.id = pr.genreid join groupe gp on gp.id = pr.groupeid;";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Personne pers = new Personne();
                            pers.id = reader.GetInt32(0);
                            pers.nom= reader.GetString(1);
                            pers.prenom= reader.GetString(2);
                            pers.email = reader.GetString(3);
                            pers.mobile= reader.GetString(4);
                            pers.adresse= new Adresse(pers.id,reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));
                            pers.genre= new Genre(pers.id, reader.GetString(9));
                           // pers.identification= new Identification(pers.id, reader.GetString(11), reader.GetString(12)) ;
                            pers.groupe=new Groupe(pers.id, reader.GetString(10));
                            lpersonne.Add(pers);
                        }
                    }
                }
            }
            return lpersonne;
        }

        public static List<Personne> TouteslesPersonnesParNom(String nom)
        {
            List<Personne> lpersonne = new List<Personne>();
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"select pr.id, pr.nom, pr.prenom,pr.email,pr.mobile,ad.numeroappartement,ad.numerorue,ad.nomrue,ad.ville,gr.type,gp.groupe 
                    from personne pr 
                                    join adresse ad on pr.adresseid = ad.id 
                                    join genre gr on gr.id = pr.genreid 
                                    join groupe gp on gp.id = pr.groupeid where pr.nom = @nom;";
                    cmd.Parameters.AddWithValue("@nom", nom);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Personne pers = new Personne();
                            pers.id = reader.GetInt32(0);
                            pers.nom = reader.GetString(1);
                            pers.prenom = reader.GetString(2);
                            pers.email = reader.GetString(3);
                            pers.mobile = reader.GetString(4);
                            pers.adresse = new Adresse(pers.id, reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));
                            pers.genre = new Genre(pers.id, reader.GetString(9));
                            // pers.identification= new Identification(pers.id, reader.GetString(11), reader.GetString(12)) ;
                            pers.groupe = new Groupe(pers.id, reader.GetString(10));
                            lpersonne.Add(pers);
                        }
                    }
                }
            }
            return lpersonne;
        }

        public static void AjouterPersonne(Personne pers)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"insert into personne(nom,prenom,email,mobile,adresseid,genreid,identificationid,groupeid) values(@nom,@prenom,@email,@mobile,@adresseid,@genreid,@identificationid,@groupeid)";
                    cmd.Parameters.AddWithValue("@nom", pers.nom);
                    cmd.Parameters.AddWithValue("@prenom", pers.prenom);
                    cmd.Parameters.AddWithValue("@email", pers.email);
                    cmd.Parameters.AddWithValue("@mobile", pers.mobile);
                    cmd.Parameters.AddWithValue("@adresseid", pers.id);
                    cmd.Parameters.AddWithValue("@genreid", pers.id);
                    cmd.Parameters.AddWithValue("@identificationid", pers.id);
                    cmd.Parameters.AddWithValue("@groupeid", pers.id);
                   

                    GestionServicesAdresse.AjouterAdresse(pers.adresse);
                    GestionServicesGenre.Ajoutergenre(pers.genre);
                    GestionServicesIdentification.AjouterIdentification(pers.identification);
                    GestionServicesGroupe.AjouterGroupe(pers.groupe);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("personne ajoutée");

                }
                
            }
            
        }

        public static void ModifierPersonne(Personne pers)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"update personne SET nom =@nom, prenom=@prenom, email=@email, mobile=@mobile, adresseid=@adresseid, genreid=@genreid, identificationid= @identificationid, groupeid=@groupeid where id = @id";
                    cmd.Parameters.AddWithValue("@nom", pers.nom);
                    cmd.Parameters.AddWithValue("@premnom", pers.prenom);
                    cmd.Parameters.AddWithValue("@email", pers.email);
                    cmd.Parameters.AddWithValue("@mobile", pers.mobile);
                    GestionServicesAdresse.ModifierAdresse(pers.adresse);
                    GestionServicesGenre.Modifiergenre(pers.genre);
                    GestionServicesIdentification.ModifierIdentification(pers.identification);
                    GestionServicesGroupe.ModifierGroupe(pers.groupe);


                    cmd.ExecuteNonQuery();
                }
            }
        }

       /* public static void SupprimerPersonne(int id)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"delete from personne where id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    

                    GestionServicesAdresse.SupprimerAdresse(id);
                    GestionServicesGenre.Supprimergenres(id);
                    GestionServicesGroupe.Supprimergroupe(id);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("personne supprimee");
                }
            }
        }*/

        public static void SupprimerPersonne2(Personne pers)
        {
            using (SqlConnection connection = new SqlConnection(configbd))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"delete from personne where id = @id";
                    cmd.Parameters.AddWithValue("@id", pers.id);


                    GestionServicesAdresse.SupprimerAdresse2(pers);
                    GestionServicesGenre.SupprimerGenre2(pers);
                    GestionServicesGroupe.SupprimerGroupe2(pers);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("personne supprimee");
                }
            }
        }
    }
}
