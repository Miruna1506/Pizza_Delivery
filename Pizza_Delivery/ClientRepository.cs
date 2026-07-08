using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Delivery
{
    public class ClientRepository
    {
        private const string CONNECTION_STRING =@"Data Source=(LocalDB)\MSSQLLocalDB;" +@"AttachDbFilename=|DataDirectory|\PizzaDB.mdf;" + @"Integrated Security=True";

        public List<Client> GetAll()
        {
            List<Client> clienti = new List<Client>();

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT IdClient, Nume, Prenume, Telefon, Email
                      FROM Client
                      ORDER BY Nume, Prenume", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client client = new Client();
                        //iau valorile din randul curent si le pun in obiectul Client
                        client.IdClient = (Guid)reader["IdClient"];
                        client.Nume = reader["Nume"].ToString();
                        client.Prenume = reader["Prenume"].ToString();
                        client.Telefon = reader["Telefon"] == DBNull.Value ? "" : reader["Telefon"].ToString();
                        client.Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();

                        clienti.Add(client);
                    }
                }
            }

            return clienti;
        }

        public Client GetById(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT IdClient, Nume, Prenume, Telefon, Email
                      FROM Client
                      WHERE IdClient = @IdClient", conn))
                {
                    cmd.Parameters.AddWithValue("@IdClient", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Client client = new Client();
                            client.IdClient = (Guid)reader["IdClient"];
                            client.Nume = reader["Nume"].ToString();
                            client.Prenume = reader["Prenume"].ToString();
                            client.Telefon = reader["Telefon"] == DBNull.Value ? "" : reader["Telefon"].ToString();
                            client.Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();

                            return client;
                        }
                    }
                }
            }

            return null;
        }

        public void Insert(Client client)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Client (IdClient, Nume, Prenume, Telefon, Email)
                      VALUES (@IdClient, @Nume, @Prenume, @Telefon, @Email)", conn))
                {
                    cmd.Parameters.AddWithValue("@IdClient", client.IdClient);
                    cmd.Parameters.AddWithValue("@Nume", client.Nume);
                    cmd.Parameters.AddWithValue("@Prenume", client.Prenume);
                    cmd.Parameters.AddWithValue("@Telefon",
                        string.IsNullOrWhiteSpace(client.Telefon) ? (object)DBNull.Value : client.Telefon);
                    cmd.Parameters.AddWithValue("@Email",
                        string.IsNullOrWhiteSpace(client.Email) ? (object)DBNull.Value : client.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Client client)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE Client
                      SET Nume = @Nume,
                          Prenume = @Prenume,
                          Telefon = @Telefon,
                          Email = @Email
                      WHERE IdClient = @IdClient", conn))
                {
                    cmd.Parameters.AddWithValue("@IdClient", client.IdClient);
                    cmd.Parameters.AddWithValue("@Nume", client.Nume);
                    cmd.Parameters.AddWithValue("@Prenume", client.Prenume);
                    cmd.Parameters.AddWithValue("@Telefon",
                        string.IsNullOrWhiteSpace(client.Telefon) ? (object)DBNull.Value : client.Telefon);
                    cmd.Parameters.AddWithValue("@Email",
                        string.IsNullOrWhiteSpace(client.Email) ? (object)DBNull.Value : client.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}