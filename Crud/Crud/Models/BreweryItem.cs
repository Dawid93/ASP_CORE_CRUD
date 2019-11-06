using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class BreweryItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<BeerItem> Beers { get; set; }
    }
}
