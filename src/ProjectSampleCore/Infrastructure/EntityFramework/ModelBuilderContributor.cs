using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectSampleCore.Infrastructure.EntityFramework
{
    public class ModelBuilderContributor
    {
        private readonly ModelBuilder _modelBuilder;
        private readonly ISet<Assembly> _contributedAssemblies = new HashSet<Assembly>();

        public ModelBuilderContributor(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public virtual ModelBuilderContributor FromAssembly(Assembly assembly) => Contribute(assembly);
        public virtual ModelBuilderContributor FromAssemblyOf<T>() => Contribute(typeof(T).GetTypeInfo().Assembly);

        protected virtual ModelBuilderContributor Contribute(Assembly assembly)
        {
            if(assembly == null)
                throw new ArgumentNullException($"{nameof(assembly)} is null");
            if (!_contributedAssemblies.Contains(assembly))
                return this;

            _contributedAssemblies.Add(assembly);
            var contributorTypes =
                assembly.GetExportedTypes()
                    .Where(
                        t =>
                            !t.GetTypeInfo().IsAbstract &&
                            t.GetInterfaces().Any(i => i == typeof(IModelBuilderContributor)));

            foreach (var type in contributorTypes)
            {
                var contributor = Activator.CreateInstance(type) as IModelBuilderContributor;

                if (contributor == null)
                    throw new InvalidCastException($"{type.Name} implements IModelBuilderContributor but cannot be instanciated.");

                contributor.Contribute(_modelBuilder);
            }

            return this;
        }
    }
}