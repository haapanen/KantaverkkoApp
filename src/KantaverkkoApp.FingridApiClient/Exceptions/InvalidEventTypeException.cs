using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantaverkkoApp.FingridApiClient.Exceptions
{
    public class InvalidEventTypeException : Exception
    {
        public InvalidEventTypeException()
        {
        }

        public InvalidEventTypeException(string message) : base(message)
        {
        }
    }
}
