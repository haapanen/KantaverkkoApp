using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantaverkkoApp.FingridApiClient.Exceptions
{
    public class MaintenanceException : Exception
    {
        public MaintenanceException()
        {
        }

        public MaintenanceException(string message) : base(message)
        {
        }
    }
}
