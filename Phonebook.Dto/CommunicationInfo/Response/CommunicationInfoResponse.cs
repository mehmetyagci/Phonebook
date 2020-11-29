using Phonebook.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Dto
{
    public class CommunicationInfoResponse : BaseResponse
    {
        public Guid PersonId { get; set; }
        public CommunicationType CommunicationType { get; set; }
        public string Info { get; set; }
    }
}
