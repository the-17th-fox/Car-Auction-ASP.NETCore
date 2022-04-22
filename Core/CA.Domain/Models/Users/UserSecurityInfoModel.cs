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
        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Phone number is incorrect.")]
        public string PhoneNumber { get; set; } = String.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email is invorrect.")]
        public string Email { get; set; } = String.Empty;
    }
}
