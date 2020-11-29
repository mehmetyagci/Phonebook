using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Dto
{
    public class BaseResponse
    {
        #region Base Fields
        public Guid Id { get; set; }
        bool IsDeleted { get; set; }
        long CreatedDate { get; set; }
        long? ModifiedDate { get; set; }
        #endregion Base Fields
    }
}
