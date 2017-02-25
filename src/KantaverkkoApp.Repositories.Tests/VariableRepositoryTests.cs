using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KantaverkkoApp.DatabaseInitializer;
using KantaverkkoApp.DataModel;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Xunit;

namespace KantaverkkoApp.Repositories.Tests
{
    public class VariableRepositoryTests
    {
        private static IConfiguration Configuration { get; set; }

        private static IConfiguration GetConfiguration()
        {
            return Configuration ?? (Configuration = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                       .AddEnvironmentVariables()
                       .Build());
        }

        private static KantaverkkoAppContext CreateContext()
        {
            return new KantaverkkoAppContext(GetConfiguration());
        }

        private static VariableRepository CreateVariableRepository()
        {
            return new VariableRepository(CreateContext());
        }

        private static void InitializeDatabase()
        {
            KantaverkkoAppContext.Seed(CreateContext());
        }

        [Fact]
        public void VariableRepository_ReturnsEmptyList_WhenNoMatchingEventsWasFound()
        {
            InitializeDatabase();
            var repository = CreateVariableRepository();

            Assert.Empty(repository.GetEventsForVariable(VariableType.WindPowerHourly, DateTime.UtcNow, DateTime.UtcNow.AddHours(1)));
        }
    }
}
