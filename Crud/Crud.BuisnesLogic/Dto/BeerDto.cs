using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crud.BuisnesLogic.Dto
{
    public class BeerDto
    {
        public Guid BeerId { get; set; }
        [Required]
        public string BeerName { get; set; }
        public string BeerDescription { get; set; }
        public string BeerLabelImg { get; set; }
    }
}
