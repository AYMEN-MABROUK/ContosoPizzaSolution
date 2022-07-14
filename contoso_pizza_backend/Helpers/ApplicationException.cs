using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contoso_pizza_backend.Helpers
{
    public abstract class ApplicationException : System.Exception
    {
        public ApplicationException(string message): base(message)
        {
        }
    }
    public class ApplicationNotFoundException : ApplicationException
    {
        public ApplicationNotFoundException(string message): base(message)
        {
        }
    }
    public class ApplicationValidationException : ApplicationException
    {
        public ApplicationValidationException(string message): base(message)
        {
        }
    }


}