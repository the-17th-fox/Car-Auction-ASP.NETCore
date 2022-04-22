using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Cars
{
    public class CarManufacturingInfoModel
    {
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        public string Model { get; set; } = String.Empty;

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        public string Manufacturer { get; set; } = String.Empty;

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [Range(minimum: 1750, maximum: 9999, ErrorMessage = ModelViolationMsg.IncorrectData)]
        public short ManufacturingYear { get; set; }

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [StringLength(maximumLength: 17, MinimumLength = 17, ErrorMessage = ModelViolationMsg.IncorrectData)]
        public string VIN { get; set; } = String.Empty;

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        public decimal MSRP { get; set; }
    }
}
