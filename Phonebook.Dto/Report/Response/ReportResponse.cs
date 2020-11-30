using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Dto
{
    public class ReportResponse : BaseResponse
    {
        public string Name { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        ///     Preparing = 0,
        ///     Completed = 1
        /// </summary>
        public int ReportStatus { get; set; }
    }
}
