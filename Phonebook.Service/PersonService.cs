using Phonebook.Data;
using Phonebook.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Service
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        private readonly PhonebookDbContext _dbContext;
        public PersonService(PhonebookDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
