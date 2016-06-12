using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSampleCore.Core.Domain;

namespace ProjectSampleCore.Application.Common.Factories
{
    public interface ICustomerIdentityFactory
    {
        string Identifier();
    }
}
