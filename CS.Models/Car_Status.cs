using System.ComponentModel.DataAnnotations;

namespace CS.Models
{
    public class Car_Status : Entity
    {
        [Key]
        public short Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
