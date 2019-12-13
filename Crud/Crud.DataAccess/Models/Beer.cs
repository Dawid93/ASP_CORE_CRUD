using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crud.DataAccess.Models
{
    public class Beer
    {
        [Key]
        public Guid BeerId { get; set; }
        [Required]
        public string BeerName { get; set; }
        [MaxLength(1500)]
        public string BeerDescription { get; set; }
        public string BeerLabelImg { get; set; }
    }
}
