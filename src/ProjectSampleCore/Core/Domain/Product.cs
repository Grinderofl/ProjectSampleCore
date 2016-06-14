using System.Collections.Generic;
using ProjectSampleCore.Infrastructure.Domain.Base;

namespace ProjectSampleCore.Core.Domain
{
    public class Product : Entity<long>
    {
        public string Name { get; set; }
        public virtual int CurrentStock { get; set; }
        public ICollection<StockTake> StockTakes { get; set; } = new List<StockTake>();

        public virtual void IncreaseStock(int by)
        {
            StockTakes.Add(new StockTake(by));
            CurrentStock += by;
        }

        public virtual void DecreaseStock(int by)
        {
            CurrentStock -= by;
        }
    }
}