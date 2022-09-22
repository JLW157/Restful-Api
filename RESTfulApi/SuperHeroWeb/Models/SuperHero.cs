using System.ComponentModel.DataAnnotations;

namespace SuperHeroWeb.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
