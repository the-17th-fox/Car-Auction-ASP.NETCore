using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Models
{
    internal class ModelViolationMsg
    {
        internal const string RequiredViolation = "This field is required.";
        internal const string IncorrectData = "Provided form is incorrect.";
        internal const string IncorrectStringLength = "Provided string violates length regulations.";
        internal const string IncorrectRange = "Provided number violates range regulations.";
    }
}
