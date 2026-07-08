using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Delivery
{
    public class Client
    {
        public Guid IdClient { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public Client()
        {
            IdClient = Guid.NewGuid();
        }

        public Client(Guid idClient, string nume, string prenume, string telefon, string email)
        {
            IdClient = idClient;
            Nume = nume;
            Prenume = prenume;
            Telefon = telefon;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Nume} {Prenume}";
        }
    }
}