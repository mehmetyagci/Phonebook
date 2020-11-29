using Phonebook.Data;
using Phonebook.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Service
{
    public class CommunicationInfoService : BaseService<CommunicationInfo>, ICommunicationInfoService
    {
        private readonly PhonebookDbContext _dbContext;
        public CommunicationInfoService(PhonebookDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
