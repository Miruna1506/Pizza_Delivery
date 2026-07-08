using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pizza_Delivery
{
    public class PizzaRepository
    {
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;" + @"AttachDbFilename=|DataDirectory|\PizzaDB.mdf;" + @"Integrated Security=True";

        // metoda care transforma un rand citit din baza de date intr-un obiect Pizza
        private Pizza CitestePizza(SqlDataReader reader)
        {
            Pizza pizza = new Pizza();

            pizza.IdPizza = (Guid)reader["IdPizza"];
            pizza.Denumire = reader["Denumire"].ToString();
            pizza.Dimensiune = reader["Dimensiune"].ToString();
            pizza.Pret = (decimal)reader["Pret"];
            pizza.Ingrediente = reader["Ingrediente"] == DBNull.Value ? "" : reader["Ingrediente"].ToString();

            return pizza;
        }
        //pentru a avea acces la toate pizzele din BD
        public List<Pizza> GetAll()
        {
            List<Pizza> pizzaList = new List<Pizza>();

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT IdPizza, Denumire, Dimensiune, Pret, Ingrediente
                      FROM Pizza
                      ORDER BY Denumire, Dimensiune", conn))
                //execut comanda SELECT si primesc rezultatele intr-un reader
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pizzaList.Add(CitestePizza(reader));
                    }
                }
            }

            return pizzaList;
        }

        public Pizza GetById(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT IdPizza, Denumire, Dimensiune, Pret, Ingrediente
                      FROM Pizza
                      WHERE IdPizza = @IdPizza", conn))
                {
                    cmd.Parameters.AddWithValue("@IdPizza", id);//dau valoare placeholder-ului din query

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return CitestePizza(reader);
                        }
                    }
                }
            }

            return null;
        }

        public void Add(Pizza pizza)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Pizza (IdPizza, Denumire, Dimensiune, Pret, Ingrediente)
                      VALUES (@IdPizza, @Denumire, @Dimensiune, @Pret, @Ingrediente)", conn))
                {
                    cmd.Parameters.AddWithValue("@IdPizza", pizza.IdPizza);
                    cmd.Parameters.AddWithValue("@Denumire", pizza.Denumire);
                    cmd.Parameters.AddWithValue("@Dimensiune", pizza.Dimensiune);
                    cmd.Parameters.AddWithValue("@Pret", pizza.Pret);
                    cmd.Parameters.AddWithValue("@Ingrediente",
                        string.IsNullOrWhiteSpace(pizza.Ingrediente)
                            ? (object)DBNull.Value
                            : pizza.Ingrediente);

                    cmd.ExecuteNonQuery(); 
                }
            }
        }

        public void Update(Pizza pizza)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE Pizza
                      SET Denumire = @Denumire,
                          Dimensiune = @Dimensiune,
                          Pret = @Pret,
                          Ingrediente = @Ingrediente
                      WHERE IdPizza = @IdPizza", conn))
                {
                    //pun valorile noi in parametrii din query
                    cmd.Parameters.AddWithValue("@IdPizza", pizza.IdPizza);
                    cmd.Parameters.AddWithValue("@Denumire", pizza.Denumire);
                    cmd.Parameters.AddWithValue("@Dimensiune", pizza.Dimensiune);
                    cmd.Parameters.AddWithValue("@Pret", pizza.Pret);
                    cmd.Parameters.AddWithValue("@Ingrediente",
                        string.IsNullOrWhiteSpace(pizza.Ingrediente)
                            ? (object)DBNull.Value
                            : pizza.Ingrediente);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Pizza WHERE IdPizza = @IdPizza", conn))
                {
                    cmd.Parameters.AddWithValue("@IdPizza", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}