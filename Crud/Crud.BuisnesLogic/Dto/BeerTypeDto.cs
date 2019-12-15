using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crud.BuisnesLogic.Dto
{
    public class BeerTypeDto
    {
        public Guid BeerTypeId;
        [Required]
        public string BeerTypeName;
    }
}
