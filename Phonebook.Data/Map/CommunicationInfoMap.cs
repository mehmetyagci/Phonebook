using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phonebook.Domain;
using Phonebook.Domain.Base;

namespace Phonebook.Data.Map
{
    public class CommunicationInfoMap : IEntityTypeConfiguration<CommunicationInfo>
    {
        public void Configure(EntityTypeBuilder<CommunicationInfo> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);
            modelBuilder.Property(t => t.Info).HasMaxLength(500);
            modelBuilder.ToTable(nameof(CommunicationInfo));
        }
    }
}
