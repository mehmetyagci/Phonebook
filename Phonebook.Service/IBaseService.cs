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
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(Guid id);

        Task<T> SaveAsync(T input);

        Task DeleteAsync(Guid id);

        Task<bool> ExistsAsync(Guid id);
    }
}
