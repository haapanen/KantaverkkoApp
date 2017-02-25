using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace KantaverkkoApp.DatabaseInitializer
{
    public class KantaverkkoAppTestContextFactory : IDbContextFactory<KantaverkkoAppContext>
    {
        public KantaverkkoAppContext Create(DbContextFactoryOptions options)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("testsettings.json", optional: false, reloadOnChange: true)
                .Build();
            return new KantaverkkoAppContext(configuration);
        }
    }
}
