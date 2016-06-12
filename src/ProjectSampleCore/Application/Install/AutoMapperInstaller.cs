using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller;
using ProjectSampleCore.Infrastructure.Install;

namespace ProjectSampleCore.Application.Install
{
    public class AutoMapperInstaller : AbstractServiceInstaller
    {
        public override void Install(IServiceCollection services, IInstallerContext context)
        {
            Mapper.Initialize(conf =>
            {
                var profileTypes = FindTypes(context.Assemblies, typeof(Profile));
                foreach (var profile in profileTypes)
                    conf.AddProfile(Activator.CreateInstance(profile) as Profile);

                var otherTypes = FindTypes(context.Assemblies,   typeof(IValueResolver), 
                                                            typeof(IMappingAction<,>),
                                                            typeof(ITypeConverter<,>));

                foreach (var otherType in otherTypes)
                    services.AddScoped(otherType);
                services.AddSingleton(Mapper.Instance);
                services.AddSingleton(Mapper.Engine);
            });
        }

        
    }
}
