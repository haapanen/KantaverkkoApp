using System;
using KantaverkkoApp.DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace KantaverkkoApp.DatabaseInitializer
{
    public partial class KantaverkkoAppContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public KantaverkkoAppContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Variable> Variables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("postgres"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Variable>()
                .HasKey(x => x.Type);
            modelBuilder.Entity<Variable>()
                .HasMany(x => x.Events)
                .WithOne();
        }

        public static void Seed(KantaverkkoAppContext context)
        {
            if (!context.Variables.Any())
            {
                SeedVariables(context);
            }
        }

        private static void SeedVariables(KantaverkkoAppContext context)
        {
            context.Variables.Add(new Variable
            {
                Type = VariableType.WindPowerHourly,
                Unit = "MWh/h",
                DescriptionFin = "Tuulivoiman tuotantolukema kertoo yhteislukeman niiltä laitoksilta, jotka toimittavat Fingridille reaaliaikamittaustietoa, täydennettynä arviolla muusta tuulivoimatuotannosta. Mittaukset kattavat valtaosan Suomen tuulivoimatuotannosta ja niiden osuus kokonaisarvosta kasvaa koko ajan.",
                DescriptionEn = ""
            });
            context.SaveChanges();
        }
    }
}