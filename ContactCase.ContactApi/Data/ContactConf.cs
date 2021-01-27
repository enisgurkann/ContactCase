using ContactCase.ContactApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ContactApi.Data
{
    public class ContactConf : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.FirstName).HasMaxLength(100);
            builder.Property(entity => entity.LastName).HasMaxLength(100);
            builder.Property(entity => entity.CompanyName).HasMaxLength(250);


            builder.HasMany(entity => entity.Infos).WithOne(entity => entity.Contact);
        }
    }
}
