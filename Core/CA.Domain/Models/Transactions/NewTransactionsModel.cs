using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Transactions
{
    public class NewTransactionsModel
    {
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = ModelViolationMsg.IncorrectRange)]
        public int IncomeTargetId { get; set; } // UserId

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = ModelViolationMsg.IncorrectRange)]
        public int ExpeditureTargetId { get; set; } // UserId

        [StringLength(maximumLength: 50, ErrorMessage = ModelViolationMsg.IncorrectStringLength)]
        public string Message { get; set; } = string.Empty;

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = ModelViolationMsg.IncorrectRange)]
        public decimal Amount { get; set; }
    }
}
