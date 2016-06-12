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
        private readonly ISet<Type> _entityBaseTypes = new HashSet<Type>();

        public ModelBuilderContributor(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        // API methods

        public virtual ModelBuilderContributor FromAssembly(Assembly assembly) => Contribute(assembly);
        public virtual ModelBuilderContributor FromAssemblyOf<T>() => Contribute(typeof(T).GetTypeInfo().Assembly);
        public virtual ModelBuilderContributor FromAssemblies(params Assembly[] assemblies) => Contribute(assemblies);
        public virtual ModelBuilderContributor WithEntityBase(Type entityBase) => ContributeEntities(entityBase);
        public virtual ModelBuilderContributor WithEntityBase<T>() => ContributeEntities(typeof(T));

        /// <summary>
        /// Adds an entity base to search for, and immediately performs a search
        /// on already referenced assemblies
        /// </summary>
        /// <param name="entityBase"></param>
        /// <returns></returns>
        protected virtual ModelBuilderContributor ContributeEntities(Type entityBase)
        {
            if (!_entityBaseTypes.Contains(entityBase))
            {
                _entityBaseTypes.Add(entityBase);
                ContributeEntities(entityBase, _contributedAssemblies.ToArray());
            }
            return this;
        }

        /// <summary>
        /// Performs entity search on given assemblies for all base types
        /// </summary>
        /// <param name="assemblies"></param>
        protected virtual void ContributeEntities(params Assembly[] assemblies)
        {
            foreach (var entityBaseType in _entityBaseTypes)
            {
                ContributeEntities(entityBaseType, assemblies);
            }
        }

        /// <summary>
        /// Performs entity search for given base type on all given assemblies
        /// </summary>
        /// <param name="entityBase"></param>
        /// <param name="contributedAssemblies"></param>
        protected virtual void ContributeEntities(Type entityBase, params Assembly[] contributedAssemblies)
        {
            var entityTypes =
                contributedAssemblies.SelectMany(x => x.GetExportedTypes())
                    .Where(t => !t.GetTypeInfo().IsAbstract && t.GetTypeInfo().IsSubclassOf(entityBase));

            foreach (var type in entityTypes)
                _modelBuilder.Entity(type);
        }

        /// <summary>
        /// Contributes from all IModelBuilderContributor implementations in
        /// given assemblies
        /// </summary>
        /// <param name="assemblies"></param>
        protected virtual void ContributeToModelBuilder(params Assembly[] assemblies)
        {
            var contributorTypes =
                            assemblies.SelectMany(a => a.GetExportedTypes())
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
        }

        /// <summary>
        /// Contributes IModelBuilderContributors and adds entities from given assemblies
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        protected virtual ModelBuilderContributor Contribute(params Assembly[] assemblies)
        {
            if (assemblies == null)
                throw new ArgumentNullException($"{nameof(assemblies)} is null");
            
            var actualAssemblies = assemblies.Where(a => !_contributedAssemblies.Contains(a)).ToArray();
            
            foreach (var actualAssembly in actualAssemblies)
                _contributedAssemblies.Add(actualAssembly);
            ContributeToModelBuilder(actualAssemblies);
            ContributeEntities(actualAssemblies);
            return this;
        }

        
    }
}