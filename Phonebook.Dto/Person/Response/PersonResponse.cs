using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Dto
{
    public class PersonResponse : BaseResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}
