using Crud.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace Crud.DataAccess
{
    public interface IBeerTypeRepository
    {
        IEnumerable<BeerType> GetBeers();
        BeerType GetBeer(Guid beerId);
        void AddBeer(BeerType beer);
        void UpdateBeer(BeerType beer);
        void DeleteBeer(BeerType beer);
        bool Commit();
    }
}
