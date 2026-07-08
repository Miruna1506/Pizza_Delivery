using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Delivery
{
    public class RandComanda
    {
        public Guid IdRandComanda { get; set; }
        public Guid IdComanda { get; set; }
        public Guid IdPizza { get; set; }
        public int Cantitate { get; set; }

        public RandComanda()
        {
            IdRandComanda = Guid.NewGuid();
        }
    }
}