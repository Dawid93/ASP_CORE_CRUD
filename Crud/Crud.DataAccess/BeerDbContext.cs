using Crud.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.DataAccess
{
    public class BeerDbContext : DbContext
    {
        public BeerDbContext(DbContextOptions<BeerDbContext> options) : base(options) { }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<BeerType> BeerTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>().HasData(
                new Beer()
                {
                    BeerId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    BeerName = "Żywiec",
                    BeerDescription = "Lorem ipsum 1",
                    BeerLabelImg = null
                },
                new Beer()
                {
                    BeerId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    BeerName = "Lech",
                    BeerDescription = "Lorem ipsum 1",
                    BeerLabelImg = null
                },
                new Beer()
                {
                    BeerId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    BeerName = "Okocim",
                    BeerDescription = "Lorem ipsum 1",
                    BeerLabelImg = null
                },
                new Beer()
                {
                    BeerId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    BeerName = "Specjal",
                    BeerDescription = "Lorem ipsum 1",
                    BeerLabelImg = null
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
