using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KantaverkkoApp.DatabaseInitializer;
using KantaverkkoApp.DataModel;
using KantaverkkoApp.FingridApiClient;
using KantaverkkoApp.Repositories;
using Microsoft.Extensions.Configuration;

namespace KantaverkkoApp.DataSynchronizationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables("KANTAVERKKOAPP_").Build();

            var apiUrl = string.IsNullOrEmpty(configuration["API_URL"]) ? "https://data.fingrid.fi" : configuration["API_URL"];
            if (string.IsNullOrEmpty(configuration["API_KEY"]))
            {
                throw new ArgumentException("API_KEY cannot be empty");
            }

            var apiClient = new ApiClient(configuration["API_URL"], configuration["API_KEY"]);
            var appContext = new KantaverkkoAppContext(configuration);
            var variableRepository = new VariableRepository(appContext);

            foreach (var type in Enum.GetValues(typeof(VariableType)).Cast<VariableType>())
            {
                const int initialYear = 2010;
                var startTime = new DateTime(initialYear, 1, 1);
                var latestEvent = variableRepository.GetLatestEvent(type);
                if (latestEvent != null)
                {
                    startTime = latestEvent.EndTime;
                }
                var endTime = DateTime.UtcNow.AddYears(1);
                var events = apiClient.GetEvents(startTime, endTime, type).Result;
                var variable = variableRepository.GetVariableForType(type);
                variable.Events = events;
                variableRepository.Save(variable);
            }
        }
    }
}
