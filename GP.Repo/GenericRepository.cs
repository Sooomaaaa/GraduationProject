using GP.Core.IRepository;
using API.DL.Entities.idintity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GP.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {
        private readonly IdentityDbContext _context;

        public GenericRepository(IdentityDbContext context)
        {
            _context = context;
        }
        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

        }
        public async Task<IEnumerable<T>> GetAll()
        => await _context.Set<T>().ToListAsync();

        public async Task<T> GetById(int id)
        => await _context.Set<T>().FindAsync(id);

        public void Update(T entity)
        => _context.Set<T>().Update(entity);
    }

}
