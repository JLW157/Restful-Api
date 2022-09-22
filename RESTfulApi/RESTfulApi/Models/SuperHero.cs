using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace RESTfulApi.Models
{
    public class SuperHero
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Min(1)]
        [Max(99)]
        public int Age { get; set; }
    }
}
