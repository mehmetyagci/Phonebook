using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Phonebook.Service
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        private readonly PhonebookDbContext _dbContext;
        public PersonService(PhonebookDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteWithDetails(Guid id)
        {
            var person = await _dbContext.Persons.FindAsync(id).ConfigureAwait(false);
            _dbContext.Persons.Remove(person);

            var communicationInfos = await _dbContext.CommunicationInfos.Where(x => x.PersonId == id && !x.IsDeleted).ToListAsync().ConfigureAwait(false);
            _dbContext.CommunicationInfos.RemoveRange(communicationInfos);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<Person> GetDetails(Guid id)
        {
            var personWithCommunicationInfos = await _dbContext.Persons.AsQueryable()
                            .IncludeFilter(c => c.CommunicationInfos.Where(y => !y.IsDeleted))
                            .Where(x => x.Id == id && !x.IsDeleted)
                            .FirstOrDefaultAsync().ConfigureAwait(false);

            return personWithCommunicationInfos;
        }
    }
}
