using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.GlobalExceptions
{
    public class UpdatingFailedException : Exception
    {
        public UpdatingFailedException(string message = "An error occured during the updating.") : base(message) { }
    }
}
