using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crud.BuisnesLogic.Dto
{
    public class BeerForCreationDto
    {
        [Required]
        public string BeerName { get; set; }
        [MaxLength(1500)]
        public string BeerDescription { get; set; }
        public byte[] BeerLabelImg { get; set; }
    }
}
