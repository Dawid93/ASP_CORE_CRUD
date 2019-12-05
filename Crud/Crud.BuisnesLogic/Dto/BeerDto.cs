using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.BuisnesLogic.Dto
{
    public class BeerDto
    {
        public Guid BeerId { get; set; }
        public string BeerName { get; set; }
        public string BeerDescription { get; set; }
        public byte[] BeerLabelImg { get; set; }
    }
}
