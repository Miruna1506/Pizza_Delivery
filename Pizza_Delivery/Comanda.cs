using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Delivery
{
    public class Comanda
    {
        public Guid IdComanda { get; set; }
        public Guid IdClient { get; set; }
        public Guid IdAdresa { get; set; }
        public DateTime DataComenzii { get; set; }
        public string Observatii { get; set; }

        public Comanda()
        {
            IdComanda = Guid.NewGuid();
            DataComenzii = DateTime.Now;
        }

        public Comanda(Guid idComanda, Guid idClient, Guid idAdresa, DateTime dataComenzii, string observatii)
        {
            IdComanda = idComanda;
            IdClient = idClient;
            IdAdresa = idAdresa;
            DataComenzii = dataComenzii;
            Observatii = observatii;
        }

        public override string ToString()
        {
            return $"{DataComenzii:dd.MM.yyyy HH:mm}";
        }
    }
}