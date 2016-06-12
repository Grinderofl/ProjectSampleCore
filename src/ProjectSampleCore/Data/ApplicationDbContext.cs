using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectSampleCore.Infrastructure.Domain.Base;
using ProjectSampleCore.Infrastructure.EntityFramework.Extensions;
using ProjectSampleCore.Models;

namespace ProjectSampleCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Contribute().FromAssemblyOf<ApplicationDbContext>().WithEntityBase<Entity>();
        }
    }
}
