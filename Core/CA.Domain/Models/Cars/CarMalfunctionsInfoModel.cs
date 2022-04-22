using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Cars
{
    public class CarMalfunctionsInfoModel
    {
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        public short SmallScratchesAmount { get; set; }
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        public short StrongScratchesAmount { get; set; }
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        public short FaultedElectronicsAmount { get; set; }
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        public bool HasSuspensionMalfunctions { get; set; }
    }
}
