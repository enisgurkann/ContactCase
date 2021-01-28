using ContactCase.ReportApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ReportApi.Data
{
    public class ReportConf : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Tag).HasMaxLength(100);
            builder.Property(entity => entity.Status);
        }
    }
}
