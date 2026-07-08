using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Delivery
{
    public class AdresaRepository
    {
        private const string CONNECTION_STRING =
            @"Data Source=(LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename=|DataDirectory|\PizzaDB.mdf;" +
            @"Integrated Security=True";

        public List<Adresa> GetAll()
        {
            List<Adresa> adrese = new List<Adresa>();

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT IdAdresa, IdClient, Strada, Numar, Oras, Judet
                      FROM Adresa
                      ORDER BY Strada, Numar", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Adresa adresa = new Adresa();
                        adresa.IdAdresa = (Guid)reader["IdAdresa"];
                        adresa.IdClient = (Guid)reader["IdClient"];
                        adresa.Strada = reader["Strada"].ToString();
                        adresa.Numar = reader["Numar"].ToString();
                        adresa.Oras = reader["Oras"].ToString();
                        adresa.Judet = reader["Judet"].ToString();

                        adrese.Add(adresa);
                    }
                }
            }

            return adrese;
        }

        public Adresa GetById(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT IdAdresa, IdClient, Strada, Numar, Oras, Judet
                      FROM Adresa
                      WHERE IdAdresa = @IdAdresa", conn))
                {
                    cmd.Parameters.AddWithValue("@IdAdresa", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Adresa adresa = new Adresa();
                            adresa.IdAdresa = (Guid)reader["IdAdresa"];
                            adresa.IdClient = (Guid)reader["IdClient"];
                            adresa.Strada = reader["Strada"].ToString();
                            adresa.Numar = reader["Numar"].ToString();
                            adresa.Oras = reader["Oras"].ToString();
                            adresa.Judet = reader["Judet"].ToString();

                            return adresa;
                        }
                    }
                }
            }

            return null;
        }

        public void Insert(Adresa adresa)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Adresa (IdAdresa, IdClient, Strada, Numar, Oras, Judet)
                      VALUES (@IdAdresa, @IdClient, @Strada, @Numar, @Oras, @Judet)", conn))
                {
                    cmd.Parameters.AddWithValue("@IdAdresa", adresa.IdAdresa);
                    cmd.Parameters.AddWithValue("@IdClient", adresa.IdClient);
                    cmd.Parameters.AddWithValue("@Strada", adresa.Strada);
                    cmd.Parameters.AddWithValue("@Numar", adresa.Numar);
                    cmd.Parameters.AddWithValue("@Oras", adresa.Oras);
                    cmd.Parameters.AddWithValue("@Judet", adresa.Judet);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Adresa adresa)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE Adresa
                      SET IdClient = @IdClient,
                          Strada = @Strada,
                          Numar = @Numar,
                          Oras = @Oras,
                          Judet = @Judet
                      WHERE IdAdresa = @IdAdresa", conn))
                {
                    cmd.Parameters.AddWithValue("@IdAdresa", adresa.IdAdresa);
                    cmd.Parameters.AddWithValue("@IdClient", adresa.IdClient);
                    cmd.Parameters.AddWithValue("@Strada", adresa.Strada);
                    cmd.Parameters.AddWithValue("@Numar", adresa.Numar);
                    cmd.Parameters.AddWithValue("@Oras", adresa.Oras);
                    cmd.Parameters.AddWithValue("@Judet", adresa.Judet);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}