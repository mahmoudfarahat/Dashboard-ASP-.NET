using Assingment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment.BLL.Interfaces
{
   public  interface IEmployeeRepository :IGenericRepository<Employee>
    {
        IEnumerable<Employee> Search(string name);
    }
}
