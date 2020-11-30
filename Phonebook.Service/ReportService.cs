using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Domain;
using Phonebook.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Service
{
    public class ReportService : BaseService<Report>, IReportService
    {
        private readonly PhonebookDbContext _dbContext;
        public ReportService(PhonebookDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       
    }
}
