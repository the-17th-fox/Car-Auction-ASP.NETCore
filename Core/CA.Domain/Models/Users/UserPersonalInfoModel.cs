using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Users
{
    public class UserPersonalInfoModel
    {
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [RegularExpression("[A-Z]{1}[A-Za-z]+", ErrorMessage = ModelViolationMsg.IncorrectData)]
        public string FirstName { get; set; } = String.Empty;
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [RegularExpression("[A-Z]{1}[A-Za-z]+", ErrorMessage = ModelViolationMsg.IncorrectData)]
        public string LastName { get; set; } = String.Empty;
    }
}
