using ContactCase.ContactApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ContactApi.Data
{
    public class ContactInfoConf : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.InfoType).HasMaxLength(100);
            builder.Property(entity => entity.Value).HasMaxLength(150);
        }
    }
}
