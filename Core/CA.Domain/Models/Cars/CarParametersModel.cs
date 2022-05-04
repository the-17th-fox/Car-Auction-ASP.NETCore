using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Cars
{
    public class CarParametersModel
    {
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = ModelViolationMsg.IncorrectStringLength)]
        public string InternalColor { get; set; } = String.Empty;

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = ModelViolationMsg.IncorrectStringLength)]
        public string ExternalColor { get; set; } = String.Empty;

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = ModelViolationMsg.IncorrectRange)]
        public int OdometerValue { get; set; }
    }
}
