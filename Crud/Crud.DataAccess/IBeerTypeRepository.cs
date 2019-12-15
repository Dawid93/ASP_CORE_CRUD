using Crud.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace Crud.DataAccess
{
    public interface IBeerTypeRepository
    {
        IEnumerable<BeerType> GetBeerTypes();
        BeerType GetBeerType(Guid beerId);
        void AddBeerType(BeerType beerType);
        void UpdateBeerType(BeerType beerType);
        void DeleteBeerType(BeerType beerType);
        bool SaveBeerType();
    }
}
