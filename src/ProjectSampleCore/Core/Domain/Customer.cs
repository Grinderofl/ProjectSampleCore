using ProjectSampleCore.Infrastructure.Domain.Base;

namespace ProjectSampleCore.Core.Domain
{
    public class Customer : Entity<long>
    {
        public virtual string Identifier { get; set; }
    }
}
