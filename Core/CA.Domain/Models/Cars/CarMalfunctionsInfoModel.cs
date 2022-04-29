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
        [Range(0, short.MaxValue, ErrorMessage = ModelViolationMsg.IncorrectRange)]
        public short SmallScratchesAmount { get; set; }

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [Range(0, short.MaxValue, ErrorMessage = ModelViolationMsg.IncorrectRange)]
        public short StrongScratchesAmount { get; set; }

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [Range(0, short.MaxValue, ErrorMessage = ModelViolationMsg.IncorrectRange)]
        public short FaultedElectronicsAmount { get; set; }

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        public bool HasSuspensionMalfunctions { get; set; }
    }
}
