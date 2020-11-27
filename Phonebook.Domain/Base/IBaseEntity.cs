using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Domain.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        bool IsDeleted { get; set; }

        long CreatedDate { get; set; }

        long? ModifiedDate { get; set; }
    }
}
