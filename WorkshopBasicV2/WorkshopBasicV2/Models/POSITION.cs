using System.ComponentModel.DataAnnotations;

namespace WorkshopBasicV2.Models
{
    public class POSITION
    {
        [Key]
        [Required]
        public int PositionId { get; set; }
        [Required]
        [StringLength(50)]
        public string PositionName { get; set; }

    }
}
