using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSampleCore.Core.Domain;
using ProjectSampleCore.Features.Admin.Models.Products;
using ProjectSampleCore.Infrastructure.AutoMapper;

namespace ProjectSampleCore.Features.Admin.Mapping
{
    public class ProductsAdminProfile : EntityProfile<Product, ProductViewModel, ProductFields, ProductLineModel>
    {
    }
}
