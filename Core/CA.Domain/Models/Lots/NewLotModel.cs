using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Lots
{
    public class NewLotModel
    {
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = ModelViolationMsg.IncorrectRange)]
        public int CarId { get; set; }

        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = ModelViolationMsg.IncorrectRange)]
        public int? AuctionId { get; set; } = null;
    }
}
