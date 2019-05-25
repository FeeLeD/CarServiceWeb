using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class Vechiles
    {
        public string VIN { get; set; }
        public string Model { get; set; }
        public double EngineVolume { get; set; }
        public DateTime ManufactureYear { get; set; }

        public List<string> DefectsDescription;
    }
}
