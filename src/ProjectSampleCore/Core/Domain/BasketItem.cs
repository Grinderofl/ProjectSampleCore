using ProjectSampleCore.Infrastructure.Domain.Base;

namespace ProjectSampleCore.Core.Domain
{
    public class BasketItem : Entity<long>
    {
        protected BasketItem()
        { }

        public BasketItem(Product product)
        {
            Product = product;
        }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }
    }
}