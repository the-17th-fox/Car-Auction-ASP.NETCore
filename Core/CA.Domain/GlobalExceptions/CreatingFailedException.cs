using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.GlobalExceptions
{
    public class CreatingFailedException : Exception
    {
        public CreatingFailedException(string message = "An error occured during the creating.") : base(message) { }
    }
}
