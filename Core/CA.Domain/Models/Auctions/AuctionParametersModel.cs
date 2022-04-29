using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Auctions
{
    public class AuctionParametersModel
    {
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [StringLength(maximumLength: 500, ErrorMessage = ModelViolationMsg.IncorrectStringLength)]
        public string Title { get; set; } = String.Empty;

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        public DateTime OpenedAt { get; set; }

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        public DateTime ClosedAt { get; set; }
    }
}
