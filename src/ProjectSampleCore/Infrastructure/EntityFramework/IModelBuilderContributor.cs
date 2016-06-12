using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectSampleCore.Infrastructure.EntityFramework
{
    public interface IModelBuilderContributor
    {
        void Contribute(ModelBuilder modelBuilder);
    }
}
