using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment.BLL.Interfaces
{
    public interface IunitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }

        public IDepartmentRepository  DepartmentRepository { get; set; }

    }
}
