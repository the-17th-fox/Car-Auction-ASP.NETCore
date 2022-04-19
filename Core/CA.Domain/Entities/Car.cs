using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Entities
{
    public class Car : BasicEntity
    {
        public short Grade { get; set; }
        public decimal? Price { get; set; }

        public int SellerId { get; set; }
        [ForeignKey("SellerId")]
        public User Seller { get; set; }

        public int? LotId { get; set; }
        public Lot? Lot { get; set; }
        

        // Car parameters
        public string Model { get; set; } = String.Empty;
        public string Manufacturer { get; set; } = String.Empty;
        public short ManufacturingYear { get; set; }
        public string VIN { get; set; } = String.Empty;
        public decimal MSRP { get; set; }
        public string InternalColor { get; set; } = String.Empty;
        public string ExternalColor { get; set; } = String.Empty;
        public short OdometerValue { get; set; }

        // Malfunctions
        public int SmallScratchesAmount { get; set; }
        public int StrongScratchesAmount { get; set; }
        public int FaultedElectronicsAmount { get; set; }
        public bool HasSuspensionMalfunctions { get; set; }

    }
}
