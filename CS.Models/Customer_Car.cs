using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.Models
{
    public class Customer_Car : Entity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(17)]
        [MaxLength(17)]
        public string Vin { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public string RegNr { get; set; }

        [Required]
        public short StatusId { get; set; }


        public DateTime? LastPing { get; set; }

        [Required]
        public int CustomerId { get; set; }

        #region virtual
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("StatusId")]
        public virtual Car_Status Car_Status { get; set; }
        #endregion
    }
}
