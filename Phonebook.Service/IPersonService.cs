using Phonebook.Domain;
using Phonebook.Dto;
using System;
using System.Threading.Tasks;

namespace Phonebook.Service
{
    public interface IPersonService : IBaseService<Person>
    {
        Task DeleteWithDetails(Guid id);
        Task<Person> GetDetails(Guid id);
    }
}
