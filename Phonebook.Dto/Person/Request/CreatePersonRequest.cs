using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Dto
{
    public class CreatePersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

    }
}
