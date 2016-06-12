using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSampleCore.Application.Common.Factories;
using ProjectSampleCore.Areas.Basket.Models;
using ProjectSampleCore.Core.Domain;
using ProjectSampleCore.Core.Domain.Queries;

namespace ProjectSampleCore.Areas.Basket.Components
{
    public class BasketWidget : ViewComponent
    {
        private readonly ICustomerIdentityFactory _customerIdentityFactory;
        private readonly DbContext _dbContext;
        private readonly IConfigurationProvider _configurationProvider;

        public BasketWidget(ICustomerIdentityFactory customerIdentityFactory, DbContext dbContext, IConfigurationProvider configurationProvider)
        {
            _customerIdentityFactory = customerIdentityFactory;
            _dbContext = dbContext;
            _configurationProvider = configurationProvider;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentCustomer = _customerIdentityFactory.Identifier();
            var items =
                await
                    new FindNumberOfItemsInBasketForCustomerIdentifierQuery(currentCustomer).Execute(_dbContext)
                        .ProjectTo<BasketListItem>(_configurationProvider)
                        .ToListAsync();
            var model = new WidgetModel()
            {
                Items = items
            };
            return View(model);
        }
    }
}
