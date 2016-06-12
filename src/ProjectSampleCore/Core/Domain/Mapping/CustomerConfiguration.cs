using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectSampleCore.Infrastructure.EntityFramework;

namespace ProjectSampleCore.Core.Domain.Mapping
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        protected override void Configure(EntityTypeBuilder<Customer> entity)
        {
        }
    }
}
