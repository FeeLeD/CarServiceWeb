using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class Cars: Vechiles
    {
        public CarNames Name { get; set; }
    }

    public enum CarNames
    {
        LADA,
        Audi,
        BMW,
        Mercedes,
        Opel,
        Chevrolet,
        Ford,
        Renault,
        Citroen,
        Hyinday,
        Kia,
        Skoda,
        Volkswagen,
        Volvo,
        Nissan,
        Lexus,
        Mazda,
        Toyota,
        Subaru,
        Honda,
        Mitsubishi
    }
}
