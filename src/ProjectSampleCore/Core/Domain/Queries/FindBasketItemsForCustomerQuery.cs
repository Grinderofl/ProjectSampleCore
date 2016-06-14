using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSampleCore.Infrastructure.Domain.Queries;

namespace ProjectSampleCore.Core.Domain.Queries
{
    public class FindBasketItemsForCustomerQuery : QueryObject<IQueryable<BasketItem>>
    {
        private readonly string _identifier;

        public FindBasketItemsForCustomerQuery(string identifier)
        {
            _identifier = identifier;
        }

        public FindBasketItemsForCustomerQuery(Customer customer)
        {
            _identifier = customer.Identifier;
        }

        public override IQueryable<BasketItem> Execute(DbContext context)
        {
            var items =
                context.Set<Customer>()
                    .Where(x => x.Identifier == _identifier)
                    .Include(x => x.Basket)
                    .ThenInclude(b => b.Items)
                    .SelectMany(x => x.Basket.Items);
            return items;
        }
    }
}
