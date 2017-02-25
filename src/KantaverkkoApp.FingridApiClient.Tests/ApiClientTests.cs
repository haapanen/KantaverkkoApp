using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KantaverkkoApp.DataModel;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace KantaverkkoApp.FingridApiClient.Tests
{
    public class ApiClientTests
    {
        private IConfiguration _configuration = new Configuration().GetConfiguration();

        [Fact]
        public void GetEvents_ReturnsValidData_WhenSearchingForHourlyWindPower()
        {
            var apiClient = new ApiClient("https://api.fingrid.fi", _configuration["API_KEY"]);

            Assert.True(apiClient.GetEvents(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow, VariableType.WindPowerHourly).Result.Count > 0);
        }
    }
}
