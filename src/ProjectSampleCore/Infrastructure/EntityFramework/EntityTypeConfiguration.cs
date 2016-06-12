using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectSampleCore.Infrastructure.EntityFramework
{
    public abstract class EntityTypeConfiguration<T> : IModelBuilderContributor where T : class
    {
        public void Contribute(ModelBuilder modelBuilder)
        {
            Configure(modelBuilder.Entity<T>());
        }

        protected abstract void Configure(EntityTypeBuilder<T> entity);
    }
}