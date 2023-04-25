using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLogic.DataModels
{
    public class PizzaModel
    {
        public int Id { get; set; }
        [Required]
        public  string? Name { get; set; }
        [Required]
        public  string? Image { get; set; }
        [Required]
        public  string? Description { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public double SmallPrice { get; set; } = 1.99;
        [DataType(DataType.Currency)]
        [Required]
        public double MediumPrice { get; set; } = 2.99;
        [DataType(DataType.Currency)]
        [Required]
        public double LargePrice { get; set; } = 3.99;
        [DataType(DataType.Currency)]
        [Required]
        public double ExtraLargePrice { get; set; } = 4.99;
    }
}
