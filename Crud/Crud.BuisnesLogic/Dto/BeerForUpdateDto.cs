using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crud.BuisnesLogic.Dto
{
    public class BeerForUpdateDto
    {
        [Required]
        public string BeerName { get; set; }
        [MaxLength(1500)]
        public string BeerDescription { get; set; }
        public Guid? BeerTypeFK { get; set; }
        public IFormFile BeerImgFile { get; set; }
    }
}
