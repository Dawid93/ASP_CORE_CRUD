using Crud.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.DataAccess
{
    public interface IBeerRespository
    {
        IEnumerable<Beer> GetBeers();
        Beer GetBeer(Guid beerId);
        void AddBeer(Beer beer);
        void UpdateBeer(Beer beer);
        void DeleteBeer(Beer beer);
        bool Commit();
    }
}
