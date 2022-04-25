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
        public short? Grade { get; set; }
        [Column(TypeName = "decimal(9,2)")]
        public decimal? StartingPrice { get; set; }

        [ForeignKey("SellerId")]
        public User Seller { get; set; } = null!;
        public List<Lot> Lots { get; set; } = new();
        
        // Car parameters
        public string Model { get; set; } = String.Empty;
        public string Manufacturer { get; set; } = String.Empty;
        public short ManufacturingYear { get; set; }
        public string VIN { get; set; } = String.Empty;
        [Column(TypeName = "decimal(9,2)")]
        public decimal MSRP { get; set; }
        public string InternalColor { get; set; } = String.Empty;
        public string ExternalColor { get; set; } = String.Empty;
        public int OdometerValue { get; set; }

        // Malfunctions
        public short SmallScratchesAmount { get; set; }
        public short StrongScratchesAmount { get; set; }
        public short FaultedElectronicsAmount { get; set; }
        public bool HasSuspensionMalfunctions { get; set; }
    }
}
