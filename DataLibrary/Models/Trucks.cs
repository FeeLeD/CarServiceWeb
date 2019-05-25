using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class Trucks: Vechiles
    {
        public TruckNames Name { get; set; }
    }

    public enum TruckNames
    {
        Scania,
        IVECO,
        Volvo,
        MAN,
        KaMAZ,
        MAZ,
        DAF,
        Isuzu
    }
}
