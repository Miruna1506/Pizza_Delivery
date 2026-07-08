using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Delivery
{
    public class RandComandaRepository
    {
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;" +@"AttachDbFilename=|DataDirectory|\PizzaDB.mdf;" +@"Integrated Security=True";

        public List<RandComandaAfisare> GetByComandaId(Guid idComanda)
        {
            List<RandComandaAfisare> lista = new List<RandComandaAfisare>();

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT 
                        rc.IdRandComanda,
                        rc.IdComanda,
                        rc.IdPizza,
                        p.Denumire AS Pizza,
                        p.Dimensiune,
                        p.Pret,
                        rc.Cantitate
                      FROM RandComanda rc
                      INNER JOIN Pizza p ON rc.IdPizza = p.IdPizza
                      WHERE rc.IdComanda = @IdComanda", conn))
                {
                    cmd.Parameters.AddWithValue("@IdComanda", idComanda);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RandComandaAfisare r = new RandComandaAfisare();
                            //iau valorile din linia curenta si le pun in randul de comanda
                            r.IdRandComanda = (Guid)reader["IdRandComanda"];
                            r.IdComanda = (Guid)reader["IdComanda"];
                            r.IdPizza = (Guid)reader["IdPizza"];
                            r.Pizza = reader["Pizza"].ToString();
                            r.Dimensiune = reader["Dimensiune"].ToString();
                            r.Cantitate = (int)reader["Cantitate"];
                            r.Pret = (decimal)reader["Pret"];
                            lista.Add(r);
                        }
                    }
                }
            }

            return lista;
        }

        public void Add(RandComanda rand)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO RandComanda (IdRandComanda, IdComanda, IdPizza, Cantitate)
                      VALUES (@IdRandComanda, @IdComanda, @IdPizza, @Cantitate)", conn))
                {
                    cmd.Parameters.AddWithValue("@IdRandComanda", rand.IdRandComanda);
                    cmd.Parameters.AddWithValue("@IdComanda", rand.IdComanda);
                    cmd.Parameters.AddWithValue("@IdPizza", rand.IdPizza);
                    cmd.Parameters.AddWithValue("@Cantitate", rand.Cantitate);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteByComandaId(Guid idComanda)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                //sterg toate produsele care apartin comenzii cu id-ul primit
                using (SqlCommand cmd = new SqlCommand(
                    @"DELETE FROM RandComanda WHERE IdComanda = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", idComanda);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}