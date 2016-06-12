using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace ProjectSampleCore.Application.Common.Factories.Impl
{
    public class CustomerIdentityFactory : ICustomerIdentityFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerIdentityFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Identifier()
        {
            return _httpContextAccessor.HttpContext.Session.Id;
        }
    }
}
