﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Cars
{
    public class UserCarModel
    {
        public int Id { get; set; }
        public short? Grade { get; set; }
        public decimal? StartingPrice { get; set; }

        public int SellerId { get; set; }
        // Car parameters
        public string Model { get; set; } = String.Empty;
        public string Manufacturer { get; set; } = String.Empty;
        public short ManufacturingYear { get; set; }
        public string VIN { get; set; } = String.Empty;
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