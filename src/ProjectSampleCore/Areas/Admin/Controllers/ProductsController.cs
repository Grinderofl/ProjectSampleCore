using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSampleCore.Areas.Admin.Models.Products;
using ProjectSampleCore.Core.Domain;
using ProjectSampleCore.Infrastructure.CommandBus;
using ProjectSampleCore.Infrastructure.Mvc.Controllers.ProjectSample.Infrastructure.Mvc.Controllers;

namespace ProjectSampleCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : EntityController<Product, ProductViewModel, ProductFields, ProductListItemModel, long>
    {
        public ProductsController(IMapper mapper, DbContext context, ICommandBus commandBus) : base(mapper, context, commandBus)
        {
        }

        protected override IEnumerable<string> GetHeaders()
        {
            yield return "Id";
            yield return "Name";
        }
    }
}
