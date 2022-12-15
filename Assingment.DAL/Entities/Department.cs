using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment.DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Code Field is Required")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
    }
}
