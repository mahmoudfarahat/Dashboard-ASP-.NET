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
    public class EmpolyeeRepository : IEmployeeRepository
    {
        private MVCAppDbContext _context;

        public EmpolyeeRepository(MVCAppDbContext context)
        {
            _context = context;
        }
        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
           => _context.Employees.ToList();
        

        public int Add(Employee Employee)
        {
            _context.Employees.Add(Employee);
            return _context.SaveChanges();
        }

        public int Update(Employee Employee)
        {
            _context.Employees.Update(Employee);
            return _context.SaveChanges();
        }

        public int Remove(Employee Employee)
        {
            _context.Employees.Remove(Employee);
            return _context.SaveChanges();
        }
    }
}
