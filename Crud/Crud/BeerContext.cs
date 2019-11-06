using Crud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud
{
    public class BeerContext : DbContext
    {
        public BeerContext(DbContextOptions<BeerContext> options) : base(options)
        {
        }

        public DbSet<BeerItem> BeerItems { get; set; }
    }
}
