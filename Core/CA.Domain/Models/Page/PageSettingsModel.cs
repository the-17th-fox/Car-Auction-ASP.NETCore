using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models.Pages
{
    public class PageSettingsModel
    {
        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [Range(minimum: 1, maximum: 100, ErrorMessage = "Invalid page size.")]
        public byte PageSize { get; set; }

        [Required(ErrorMessage = ModelViolationMsg.RequiredViolation)]
        [Range(minimum: 1, maximum: short.MaxValue, ErrorMessage = "Invalid page number.")]
        public short SelectedPage { get; set; } = 1;
    }
}
