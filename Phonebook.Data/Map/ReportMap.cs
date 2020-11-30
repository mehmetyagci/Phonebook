using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phonebook.Domain;
using Phonebook.Domain.Base;

namespace Phonebook.Data.Map
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);
            modelBuilder.Property(t => t.Name).IsRequired(required: true);
            modelBuilder.Property(t => t.Name).HasMaxLength(250);
            modelBuilder.ToTable(nameof(Report));
        }
    }
}
