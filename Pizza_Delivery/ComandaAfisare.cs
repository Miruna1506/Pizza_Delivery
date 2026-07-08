using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Delivery
{
    public class ComandaAfisare
    {
        public Guid IdComanda { get; set; }
        public string Client { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Produse { get; set; }
        public DateTime DataComenzii { get; set; }
        public string Observatii { get; set; }
        public string Adresa { get; set; }

        public decimal Total { get; set; }
    }
}