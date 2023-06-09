using DAL.DBContext;
using DAL.GenericInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GenericRepo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly DBContextClass _context;

        public GenericRepo(DBContextClass context) 
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var getbyId = await _context.Set<T>().FindAsync(id);
            return getbyId;
        }
        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public Task AddAsync(T entity)
        {
          _context.Set<T>().Add(entity);
          return  _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

}
