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
    }
}
