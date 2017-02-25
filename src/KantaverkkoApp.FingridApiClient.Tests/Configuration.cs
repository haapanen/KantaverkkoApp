using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace KantaverkkoApp.FingridApiClient.Tests
{
    public class Configuration
    {
        private IConfiguration _configuration;

        public IConfiguration GetConfiguration()
        {
            if (_configuration == null)
            {
                var builder = new ConfigurationBuilder()
                    .AddEnvironmentVariables("KANTAVERKKOAPP_");

                _configuration = builder.Build();
            }

            
            return _configuration;
        }
    }
}
