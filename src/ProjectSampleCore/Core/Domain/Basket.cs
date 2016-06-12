using System.Collections.Generic;
using System.Linq;
using ProjectSampleCore.Infrastructure.Domain.Base;

namespace ProjectSampleCore.Core.Domain
{
    public class Basket : Entity<long>
    {
        public virtual ICollection<BasketItem> Items { get; set; } = new List<BasketItem>();

        public void AddItem(Product product)
        {
            if (Items.Any(i => i.Product.Id != product.Id))
            {
                Items.Add(new BasketItem(product));
            }
        }
    }
}