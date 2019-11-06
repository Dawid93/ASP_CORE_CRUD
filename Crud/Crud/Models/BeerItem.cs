using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class BeerItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Brewery { get; set; } // Create Bewery model later
        public byte[] LabelImage { get; set; }
    }
}
