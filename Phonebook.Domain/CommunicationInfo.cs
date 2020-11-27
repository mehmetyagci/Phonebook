using Phonebook.Constants;
using Phonebook.Domain.Base;
using System;

namespace Phonebook.Domain
{
    public class CommunicationInfo : BaseEntity
    {
        public Person Person { get; set; }

        public CommunicationType CommunicationType { get; set; }

        public string Info { get; set; }
    }
}
