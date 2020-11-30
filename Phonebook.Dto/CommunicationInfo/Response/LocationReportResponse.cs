using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Dto
{
    public class LocationReportResponse
    {
        public string Location { get; set; }

        public int PersonCount { get; set; }

        public int PhoneCount { get; set; }
    }
}
