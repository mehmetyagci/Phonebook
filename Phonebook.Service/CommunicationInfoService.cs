using Phonebook.Data;
using Phonebook.Domain;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Domain;
using Phonebook.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Service
{
    public class CommunicationInfoService : BaseService<CommunicationInfo>, ICommunicationInfoService
    {
        private readonly PhonebookDbContext _dbContext;
        public CommunicationInfoService(PhonebookDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LocationReportResponse>> GetLocationReport()
        {
            return await _dbContext.CommunicationInfos
                   .AsQueryable()
                   .Where(w => w.CommunicationType == Constants.CommunicationType.Location)
                   .GroupBy(g => g.Info)
                   .Select(s => new LocationReportResponse
                   {
                       Location = s.Key,
                       PersonCount = s.Count(),
                       // PhoneCount = s.Where(y => y.Info == s.Key && y.CommunicationType == Constants.CommunicationType.Phone).Count()
                   })
                   .ToListAsync().ConfigureAwait(false);
        }
    }
}
