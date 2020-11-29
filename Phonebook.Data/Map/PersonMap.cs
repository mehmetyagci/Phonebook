using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phonebook.Domain;
using Phonebook.Domain.Base;

namespace Phonebook.Data.Map
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);
            modelBuilder.Property(t => t.FirstName).IsRequired(required: true);
            modelBuilder.Property(t => t.FirstName).HasMaxLength(250);
            modelBuilder.Property(t => t.LastName).IsRequired(required: true);
            modelBuilder.Property(t => t.LastName).HasMaxLength(250);
            modelBuilder.Property(t => t.Company).HasMaxLength(500);
            modelBuilder.HasMany(e => e.CommunicationInfos)
                     .WithOne();
            modelBuilder.ToTable(nameof(Person));
        }
    }
}
