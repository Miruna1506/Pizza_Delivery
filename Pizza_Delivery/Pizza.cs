using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Delivery
{
    public class Pizza
    {
        public Guid IdPizza { get; set; }
        public string Denumire { get; set; }
        public string Dimensiune { get; set; }
        public decimal Pret { get; set; }
        public string Ingrediente { get; set; }

        public Pizza()
        {
            IdPizza = Guid.NewGuid();
        }

        public Pizza(Guid idPizza, string denumire, string dimensiune, decimal pret, string ingrediente)
        {
            IdPizza = idPizza;
            Denumire = denumire;
            Dimensiune = dimensiune;
            Pret = pret;
            Ingrediente = ingrediente;
        }
        public string Afisare
        {
            get
            {
                return $"{Denumire} - {Dimensiune} - {Pret:0.00} lei";
            }
        }
    }
}