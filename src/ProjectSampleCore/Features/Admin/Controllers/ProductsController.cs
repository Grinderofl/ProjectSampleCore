using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSampleCore.Core.Domain;
using ProjectSampleCore.Features.Admin.Models.Products;
using ProjectSampleCore.Infrastructure.CommandBus;
using ProjectSampleCore.Infrastructure.Mvc.Controllers.ProjectSample.Infrastructure.Mvc.Controllers;

namespace ProjectSampleCore.Features.Admin.Controllers
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
