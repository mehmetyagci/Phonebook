using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Phonebook.Domain.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        /// <summary>
        /// identity number for the entity
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DefaultValue(false)]
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// long unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        /// </summary>
        public long CreatedDate { get; set; }
      
        public long? ModifiedDate { get; set; }

        public BaseEntity()
        {
            CreatedDate = long.Parse("0");
            IsDeleted = false;
        }
    }
}
