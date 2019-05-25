using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class Clients
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Cars> Cars;
        public List<Trucks> Trucks;
        public bool OrderDone { get; set; }
    }
}
