using Phonebook.Constants;
using Phonebook.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Domain
{
    public class Report : BaseEntity
    {
        public string Name { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        public ReportStatus ReportStatus { get; set; }
    }
}
