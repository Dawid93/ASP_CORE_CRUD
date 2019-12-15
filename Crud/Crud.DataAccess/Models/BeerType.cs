using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crud.DataAccess.Models
{
    public class BeerType
    {
        [Key]
        public Guid BeerTypId { get; set; }
        [Required]
        public string BeerTypeName { get; set; }
    }
}
