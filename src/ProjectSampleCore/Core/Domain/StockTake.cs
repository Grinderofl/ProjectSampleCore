using System;
using ProjectSampleCore.Infrastructure.Domain.Base;

namespace ProjectSampleCore.Core.Domain
{
    public class StockTake : Entity<long>
    {
        public virtual int StockTaken { get; set; }
        public virtual DateTime TakeOn { get; set; } = DateTime.Now;
    }
}