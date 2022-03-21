using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcFechaCumples.Models
{
    public class Cumple
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        public string Nombre { get; set; }
        
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime FechaCumple { get; set; }
    }
}
