using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSampleCore.Application.Common.Factories;
using ProjectSampleCore.Core.Domain.Queries;
using ProjectSampleCore.Features.Basket.Models;

namespace ProjectSampleCore.Features.Basket.Controllers
{
    [Area("Basket")]
    public class HomeController : Controller
    {
        private readonly DbContext _context;
        private readonly ICustomerIdentityFactory _customerIdentityFactory;

        public HomeController(DbContext context, ICustomerIdentityFactory customerIdentityFactory)
        {
            _context = context;
            _customerIdentityFactory = customerIdentityFactory;
        }

        public async Task<IActionResult> Index()
        {
            var model =
                await
                    new FindBasketItemsForCustomerQuery(_customerIdentityFactory.Identifier())
                        .Execute(_context)
                        .ProjectTo<BasketListItem>()
                        .ToListAsync();
            return View(model);
        }
    }
}