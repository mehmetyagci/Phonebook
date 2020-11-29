using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Dto
{
    public class PersonDetailResponse : BaseResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public List<CommunicationInfoResponse> CommunicationInfos { get; set; } = new List<CommunicationInfoResponse>();
    }
}
