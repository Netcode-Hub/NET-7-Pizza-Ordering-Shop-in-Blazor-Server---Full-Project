
using System.ComponentModel.DataAnnotations;

namespace PizzaLogic.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public double SmallPrice { get; set; }
        public double MediumPrice { get; set; }
        public double LargePrice { get; set; }
        public double ExtraLargePrice { get; set; }

    }
}
