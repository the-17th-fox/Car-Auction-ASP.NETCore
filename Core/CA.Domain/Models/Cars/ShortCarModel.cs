using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Cars
{
    public class ShortCarModel
    {
        public int Id { get; set; }

        public int SellerId { get; set; }

        public string Model { get; set; } = String.Empty;
        public string Manufacturer { get; set; } = String.Empty;
        public short ManufacturingYear { get; set; }
    }
}
