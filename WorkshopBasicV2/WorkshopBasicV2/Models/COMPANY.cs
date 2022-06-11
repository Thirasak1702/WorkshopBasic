using System.ComponentModel.DataAnnotations;
namespace WorkshopBasicV2.Models
{
    public class COMPANY
    {
        [Key]
        [Required]
        public int CompanyId { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyAddress { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
