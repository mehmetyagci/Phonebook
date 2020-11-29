using Phonebook.Domain.Base;
using System;
using System.Collections.Generic;

namespace Phonebook.Domain
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public List<CommunicationInfo> CommunicationInfos { get; set; } = new List<CommunicationInfo>();
    }
}
