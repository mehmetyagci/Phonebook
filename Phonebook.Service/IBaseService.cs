using Phonebook.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Service
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(string includeProperties = null);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, string includeProperties = null);

        Task<T> GetAsync(Guid id);

        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null);

        Task<T> SaveAsync(T input);

        Task DeleteAsync(Guid id);

        Task<bool> ExistsAsync(Guid id);
    }
}
