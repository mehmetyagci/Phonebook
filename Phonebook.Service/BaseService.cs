using Phonebook.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Phonebook.Data;
using System.Threading.Tasks;

namespace Phonebook.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly PhonebookDbContext _dbContext;
        internal DbSet<T> dbSet;

        public BaseService(
            PhonebookDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = dbSet.Where(x => !x.IsDeleted);
            var result = await query.ToListAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<T> GetAsync(Guid id)
        {
            var result = await dbSet.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted).ConfigureAwait(false);
            return result;
        }

        public async Task<T> SaveAsync(T input)
        {
            if (input.Id == Guid.Empty)
            {
                dbSet.Add(input);
            }
            else
            {
                dbSet.Update(input);
            }
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return input;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await dbSet.FindAsync(id).ConfigureAwait(false);
            dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var result = await dbSet.AnyAsync(e => e.Id == id && !e.IsDeleted).ConfigureAwait(false);
            return result;
        }
    }
}
