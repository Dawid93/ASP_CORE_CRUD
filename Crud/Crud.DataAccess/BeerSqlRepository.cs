using Crud.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crud.DataAccess
{
    public class BeerSqlRepository : IBeerRepository
    {
        private readonly BeerDbContext context;

        public BeerSqlRepository(BeerDbContext context)
        {
            this.context = context;
        }

        public void AddBeer(Beer beer)
        {
            if (beer == null)
                throw new ArgumentNullException(nameof(beer));
            context.Add(beer);
        }

        public bool Commit()
        {
            return (context.SaveChanges() >= 0);
        }

        public void DeleteBeer(Beer beer)
        {
            context.Beers.Remove(beer);
        }

        public Beer GetBeer(Guid beerId)
        {
            if (beerId == Guid.Empty)
                throw new ArgumentNullException();
            return context.Beers.Where(x => x.BeerId == beerId).FirstOrDefault();
        }

        public IEnumerable<Beer> GetBeers()
        {
            return context.Beers.ToList();
        }

        public void UpdateBeer(Beer beer)
        {
        }
    }
}
