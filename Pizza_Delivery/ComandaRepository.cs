using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Delivery
{
    public class ComandaRepository
    {
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;" +@"AttachDbFilename=|DataDirectory|\PizzaDB.mdf;" + @"Integrated Security=True";

        public List<ComandaAfisare> GetAll()
        {
            List<ComandaAfisare> comenzi = new List<ComandaAfisare>();

            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT 
                    c.IdComanda,
                    cl.Nume + ' ' + cl.Prenume AS Client,
                    cl.Telefon,
                    cl.Email,
                    c.DataComenzii,
                    c.Observatii,
                    a.Strada + ', nr. ' + a.Numar + ', ' + a.Oras + ', ' + a.Judet AS Adresa
                  FROM Comanda c
                  INNER JOIN Client cl ON c.IdClient = cl.IdClient
                  INNER JOIN Adresa a ON c.IdAdresa = a.IdAdresa
                  ORDER BY c.DataComenzii DESC", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ComandaAfisare c = new ComandaAfisare();

                            c.IdComanda = (Guid)reader["IdComanda"];
                            c.Client = reader["Client"].ToString();
                            c.Telefon = reader["Telefon"] == DBNull.Value ? "" : reader["Telefon"].ToString();
                            c.Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();
                            c.DataComenzii = (DateTime)reader["DataComenzii"];
                            c.Observatii = reader["Observatii"] == DBNull.Value ? "" : reader["Observatii"].ToString();
                            c.Adresa = reader["Adresa"].ToString();

                            comenzi.Add(c);
                        }
                    }
                }

                RandComandaRepository randRepo = new RandComandaRepository();

                foreach (var comanda in comenzi)
                {
                    var randuri = randRepo.GetByComandaId(comanda.IdComanda);
                    List<string> produse = new List<string>();
                    decimal totalComanda = 0;

                    foreach (var r in randuri)
                    {
                        produse.Add($"{r.Pizza} ({r.Dimensiune}) x {r.Cantitate}");
                        totalComanda += r.Cantitate * r.Pret;
                    }

                    comanda.Produse = string.Join(", ", produse);
                    comanda.Total = totalComanda;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Eroare la încărcarea comenzilor: " + ex.Message, ex);
            }

            return comenzi;
        }

        public Comanda GetById(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT IdComanda, IdClient, IdAdresa, DataComenzii, Observatii
                      FROM Comanda
                      WHERE IdComanda = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Comanda c = new Comanda();

                            c.IdComanda = (Guid)reader["IdComanda"];
                            c.IdClient = (Guid)reader["IdClient"];
                            c.IdAdresa = (Guid)reader["IdAdresa"];
                            c.DataComenzii = (DateTime)reader["DataComenzii"];
                            c.Observatii = reader["Observatii"] == DBNull.Value ? "" : reader["Observatii"].ToString();

                            return c;
                        }
                    }
                }
            }

            return null;
        }

        public void Add(Comanda comanda)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Comanda
                      (IdComanda, IdClient, IdAdresa, DataComenzii, Observatii)
                      VALUES
                      (@IdComanda, @IdClient, @IdAdresa, @DataComenzii, @Observatii)", conn))
                {
                    cmd.Parameters.AddWithValue("@IdComanda", comanda.IdComanda);
                    cmd.Parameters.AddWithValue("@IdClient", comanda.IdClient);
                    cmd.Parameters.AddWithValue("@IdAdresa", comanda.IdAdresa);
                    cmd.Parameters.AddWithValue("@DataComenzii", comanda.DataComenzii);
                    cmd.Parameters.AddWithValue("@Observatii",
                        string.IsNullOrWhiteSpace(comanda.Observatii) ? (object)DBNull.Value : comanda.Observatii);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Comanda comanda)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE Comanda
                      SET IdClient = @IdClient,
                          IdAdresa = @IdAdresa,
                          DataComenzii = @DataComenzii,
                          Observatii = @Observatii
                      WHERE IdComanda = @IdComanda", conn))
                {
                    cmd.Parameters.AddWithValue("@IdComanda", comanda.IdComanda);
                    cmd.Parameters.AddWithValue("@IdClient", comanda.IdClient);
                    cmd.Parameters.AddWithValue("@IdAdresa", comanda.IdAdresa);
                    cmd.Parameters.AddWithValue("@DataComenzii", comanda.DataComenzii);
                    cmd.Parameters.AddWithValue("@Observatii",
                        string.IsNullOrWhiteSpace(comanda.Observatii) ? (object)DBNull.Value : comanda.Observatii);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                new RandComandaRepository().DeleteByComandaId(id);

                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Comanda WHERE IdComanda = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}