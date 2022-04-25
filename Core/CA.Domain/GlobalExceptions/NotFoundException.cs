using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.GlobalExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message = "Requested data was not found.") : base(message) { }
    }
}
