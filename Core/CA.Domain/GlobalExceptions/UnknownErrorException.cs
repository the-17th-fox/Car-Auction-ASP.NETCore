using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.GlobalExceptions
{
    public class UnknownErrorException : Exception
    {
        public UnknownErrorException(string message = "An unknown error has occured.") : base(message) { }
    }
}
