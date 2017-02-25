using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using KantaverkkoApp.DatabaseInitializer;
using KantaverkkoApp.DataModel;

namespace KantaverkkoApp.DatabaseInitializer.Migrations
{
    [DbContext(typeof(KantaverkkoAppContext))]
    partial class KantaverkkoAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("KantaverkkoApp.DataModel.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.Property<decimal>("Value");

                    b.Property<int>("VariableType");

                    b.HasKey("Id");

                    b.HasIndex("VariableType");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("KantaverkkoApp.DataModel.Variable", b =>
                {
                    b.Property<int>("Type");

                    b.Property<string>("DescriptionEn");

                    b.Property<string>("DescriptionFin");

                    b.Property<string>("Unit");

                    b.HasKey("Type");

                    b.ToTable("Variables");
                });

            modelBuilder.Entity("KantaverkkoApp.DataModel.Event", b =>
                {
                    b.HasOne("KantaverkkoApp.DataModel.Variable")
                        .WithMany("Events")
                        .HasForeignKey("VariableType")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
