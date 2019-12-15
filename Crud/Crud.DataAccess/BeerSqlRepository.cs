using Crud.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crud.DataAccess
{
    public class BeerSqlRepository : IBeerRepository, IBeerTypeRepository
    {
        private readonly BeerDbContext context;

        public BeerSqlRepository(BeerDbContext context)
        {
            this.context = context;
        }

        #region BeerRepository
        public void AddBeer(Beer beer)
        {
            if (beer == null)
                throw new ArgumentNullException(nameof(beer));
            context.Beers.Add(beer);
        }

        public bool SaveBeer()
        {
            return (context.SaveChanges() >= 0);
        }

        public void DeleteBeer(Beer beer)
        {
            if(beer != null)
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
        #endregion

        #region BeerTypeRepository
        public IEnumerable<BeerType> GetBeerTypes()
        {
            return context.BeerTypes.ToList();
        }

        public BeerType GetBeerType(Guid beerTypeId)
        {
            if (beerTypeId == Guid.Empty)
                throw new ArgumentNullException();
            return context.BeerTypes.Where(x => x.BeerTypeId == beerTypeId).FirstOrDefault();
        }

        public void AddBeerType(BeerType beerType)
        {
            if (beerType == null)
                throw new ArgumentNullException(nameof(beerType));
            context.BeerTypes.Add(beerType);
        }

        public void UpdateBeerType(BeerType beerType)
        {
        }

        public void DeleteBeerType(BeerType beerType)
        {
            if (beerType != null)
                context.BeerTypes.Remove(beerType);
        }

        public bool SaveBeerType()
        {
            return (context.SaveChanges() >= 0);
        }
        #endregion
    }
}
