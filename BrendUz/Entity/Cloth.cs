using System.ComponentModel.DataAnnotations;

namespace BrendUz.Entity
{
    public class Cloth
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(50), MinLength(3)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Brend { get; set; }
        [Required]
       public double Price { get; set; }
        [Required]
        public string Size { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public string Made { get; set; }
    }
}
