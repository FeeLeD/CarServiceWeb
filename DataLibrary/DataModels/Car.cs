using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataModels
{
    public class Car
    {
        public string CarName { get; set; }
        public string VIN { get; set; }
        public float EngineVolume { get; set; }
        public DateTime ManufactureYear { get; set; }
        public string Defects { get; set; }
        public string ClientId { get; set; }
    }
}
