using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectSampleCore.Infrastructure.EntityFramework.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilderContributor Contribute(this ModelBuilder modelBuilder)
        {
            return new ModelBuilderContributor(modelBuilder);
        }
    }
}
