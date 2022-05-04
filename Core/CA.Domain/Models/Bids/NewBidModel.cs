using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Bids
{
    public class NewBidModel
    {
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = ModelViolationMsg.IncorrectRange)]
        public int LotId { get; set; }

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = ModelViolationMsg.IncorrectRange)]
        public decimal BidAmount { get; set; }
    }
}
