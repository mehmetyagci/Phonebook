using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Dto
{
    public class BaseResponse
    {
        #region Base Fields
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedDate { get; set; }
        public long? ModifiedDate { get; set; }
        #endregion Base Fields
    }
}
