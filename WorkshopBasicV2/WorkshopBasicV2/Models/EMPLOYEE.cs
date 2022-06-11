using System.ComponentModel.DataAnnotations;
namespace WorkshopBasicV2.Models
{
    public class EMPLOYEE
    {
        [Key]
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string EmployeeName { get; set; }
        [Required]
        [StringLength(100)]
        public string EmployeeAddress { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [StringLength(10)]
        public string Tel { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}
