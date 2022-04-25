using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.GlobalExceptions
{
    public class DeletingFailedException : Exception
    {
        public DeletingFailedException(string message = "An error occured during the deleting.") : base(message) { }
    }
}
