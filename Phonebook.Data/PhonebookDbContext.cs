using Microsoft.EntityFrameworkCore;
using Phonebook.Data.Map;
using Phonebook.Domain;
using System;

namespace Phonebook.Data
{
    public class PhonebookDbContext : DbContext
    {
        public PhonebookDbContext(DbContextOptions<PhonebookDbContext> options) : base(options)
        {

        }

         public DbSet<Person> Persons { get; set; }

         public DbSet<CommunicationInfo> CommunicationInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new CommunicationInfoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
