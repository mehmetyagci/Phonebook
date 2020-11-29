using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Dto
{
    public class UpdatePersonRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}
