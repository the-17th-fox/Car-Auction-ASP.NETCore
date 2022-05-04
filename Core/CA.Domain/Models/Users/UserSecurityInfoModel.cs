using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Users
{
    public class UserSecurityInfoModel
    {
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [Phone(ErrorMessage = ModelViolationMsg.IncorrectData)]
        public string PhoneNumber { get; set; } = String.Empty;

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [EmailAddress(ErrorMessage = ModelViolationMsg.IncorrectData)]
        public string Email { get; set; } = String.Empty;
    }
}
