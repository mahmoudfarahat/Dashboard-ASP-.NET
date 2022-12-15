using Assingment.BLL.Interfaces;
using Assingment.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private MVCAppDbContext _context;

        public GenericRepository(MVCAppDbContext context)
        {
            _context = context;
        }

        public int Add(T obj)
        {
            _context.Set<T>().Add(obj);
            return _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
     => _context.Set<T>().ToList();

        public T GetById(int id)
         => _context.Set<T>().Find(id);

        public int Remove(T obj)
        {
            _context.Set<T>().Remove(obj);
            return _context.SaveChanges();
        }

        public int Update(T obj)
        {
            _context.Set<T>().Update(obj);
            return _context.SaveChanges();
        }
    }
}
