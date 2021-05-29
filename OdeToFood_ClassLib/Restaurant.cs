using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood_ClassLib
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public Cuisine Cuisine { get; set; }
    }
}
