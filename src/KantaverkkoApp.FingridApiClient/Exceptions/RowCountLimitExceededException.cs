using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantaverkkoApp.FingridApiClient.Exceptions
{
    public class RowCountLimitExceededException : Exception
    {
        public RowCountLimitExceededException()
        {
        }

        public RowCountLimitExceededException(string message) : base(message)
        {
        }
    }
}
