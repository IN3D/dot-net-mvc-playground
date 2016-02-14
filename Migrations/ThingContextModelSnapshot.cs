using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using WebAPIApplication.Tables;

namespace WebAPIApplication.Migrations
{
    [DbContext(typeof(ThingContext))]
    partial class ThingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("WebAPIApplication.Models.Thing", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("category");

                    b.Property<string>("name");

                    b.HasKey("id");
                });
        }
    }
}
