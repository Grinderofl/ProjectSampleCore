using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProjectSampleCore.Infrastructure.Domain.Base;

namespace ProjectSampleCore.Infrastructure.Domain.Queries
{
    public abstract class QueryObject<TResult>
    {
        public abstract TResult Execute(DbContext context);
    }

    public class GenericEntityQueryObject<TEntity, TPk> : QueryObject<IEnumerable<TEntity>>
        where TEntity : Entity<TPk>
    {
        private readonly int _itemsPerPage;
        private readonly int _page;

        public GenericEntityQueryObject(int page, int itemsPerPage)
        {
            _page = page;
            _itemsPerPage = itemsPerPage;
        }

        public override IEnumerable<TEntity> Execute(DbContext context)
        {
            return context.Set<TEntity>().OrderBy(x => x.Id).Skip((_page - 1)*_itemsPerPage).Take(_itemsPerPage);
        }
    }
}
