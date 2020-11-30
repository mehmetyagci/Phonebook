using Phonebook.Domain;
using Phonebook.Domain;
using Phonebook.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phonebook.Service
{
    public interface ICommunicationInfoService : IBaseService<CommunicationInfo>
    {
        Task<List<LocationReportResponse>> GetLocationReport();
    }
}
