using Microsoft.EntityFrameworkCore;
using Phonebook.Data.Map;
using Phonebook.Domain;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Phonebook.Domain.Base;

namespace Phonebook.Data
{
    public class PhonebookDbContext : DbContext
    {
        public static readonly Microsoft.Extensions.Logging.LoggerFactory _consoleLoggerFactory =
           new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() });

        public PhonebookDbContext(DbContextOptions<PhonebookDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null)
                throw new ArgumentException("Options Builder is null!");

            optionsBuilder.EnableSensitiveDataLogging();
            //optionsBuilder.UseLazyLoadingProxies(false);

            optionsBuilder.UseLoggerFactory(_consoleLoggerFactory);
        }


        public DbSet<Person> Persons { get; set; }

         public DbSet<CommunicationInfo> CommunicationInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentException("Model Builder is null!");

            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new CommunicationInfoMap());

            base.OnModelCreating(modelBuilder);
        }

        #region OnBeforeSaving
        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is IBaseEntity);
            foreach (var entiry in entries)
            {
                var unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                switch (entiry.State)
                {
                    case EntityState.Added:
                        entiry.CurrentValues[nameof(IBaseEntity.CreatedDate)] = unixTime;
                        
                        break;
                    case EntityState.Modified:
                        entiry.CurrentValues[nameof(IBaseEntity.ModifiedDate)] = unixTime;
                        entiry.Property(nameof(IBaseEntity.CreatedDate)).IsModified = false;
                        break;
                    case EntityState.Deleted:
                        entiry.Property(nameof(IBaseEntity.CreatedDate)).IsModified = false;
                        entiry.State = EntityState.Modified;
                        entiry.CurrentValues[nameof(IBaseEntity.ModifiedDate)] = unixTime;
                        entiry.CurrentValues[nameof(IBaseEntity.IsDeleted)] = true;
                        break;
                }
            }
        }
        #endregion OnBeforeSaving
    }
}
