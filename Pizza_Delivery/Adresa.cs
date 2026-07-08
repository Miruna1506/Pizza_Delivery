using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Delivery
{
    public class Adresa
    {
        public Guid IdAdresa { get; set; }
        public Guid IdClient { get; set; }
        public string Strada { get; set; }
        public string Numar { get; set; }
        public string Oras { get; set; }
        public string Judet { get; set; }

        public Adresa()
        {
            IdAdresa = Guid.NewGuid();
        }

        public Adresa(Guid idAdresa, Guid idClient, string strada, string numar, string oras, string judet)
        {
            IdAdresa = idAdresa;
            IdClient = idClient;
            Strada = strada;
            Numar = numar;
            Oras = oras;
            Judet = judet;
        }

        public override string ToString()
        {
            return $"{Strada}, nr. {Numar}, {Oras}, {Judet}";
        }
    }
}