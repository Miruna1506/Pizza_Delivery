using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Delivery
{
    public class RandComandaAfisare
    {
        public Guid IdRandComanda { get; set; }
        public Guid IdComanda { get; set; }
        public Guid IdPizza { get; set; }
        public string Pizza { get; set; }
        public string Dimensiune { get; set; }
        public int Cantitate { get; set; }

        public decimal Pret { get; set; }
        public override string ToString()
        {
            return $"{Pizza} - {Dimensiune} x {Cantitate}";
        }
    }
}