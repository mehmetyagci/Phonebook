using Phonebook.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Dto
{
    public class CreateCommunicationInfoRequest
    {
        public Guid PersonId { get; set; }

        /// <summary>
        /// CommunicationType Enum
        /// </summary>
        public int CommunicationType { get; set; }

        public string Info { get; set; }
    }
}
