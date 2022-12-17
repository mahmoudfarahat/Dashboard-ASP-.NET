using Assingment.BLL.Interfaces;
using Assingment.DAL.Contexts;
using Assingment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment.BLL.Repositories
{
    public class EmpolyeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {
        private MVCAppDbContext _context;

        public EmpolyeeRepository(MVCAppDbContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> Search(string name)
        {
            return _context.Employees.Where(e => e.Name.Contains(name)).ToList();
        }
       
    }
}
