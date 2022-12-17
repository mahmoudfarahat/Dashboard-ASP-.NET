using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assingment.PL.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Name { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        [Range(4000,8000, ErrorMessage ="Salary Must be between 4000 and 8000")]
        public decimal Salary { get; set; }
        public String Email { get; set; }

        public bool IsActive { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        public int DepartmentId { get; set; }
         
    }
}
