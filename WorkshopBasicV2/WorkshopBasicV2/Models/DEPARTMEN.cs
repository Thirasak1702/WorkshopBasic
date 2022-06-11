using System.ComponentModel.DataAnnotations;
namespace WorkshopBasicV2.Models
{
    public class DEPARTMEN
    {
        [Key]
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }
        [StringLength(10)]
        public string Tel { get; set; }
    }
}
