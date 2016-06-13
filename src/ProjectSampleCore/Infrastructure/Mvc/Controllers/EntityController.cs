using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSampleCore.Application.Common.Filters;
using ProjectSampleCore.Infrastructure.CommandBus;
using ProjectSampleCore.Infrastructure.Domain.Base;
using ProjectSampleCore.Infrastructure.Domain.Queries;
using ProjectSampleCore.Infrastructure.Mvc.Models;

namespace ProjectSampleCore.Infrastructure.Mvc.Controllers
{
    namespace ProjectSample.Infrastructure.Mvc.Controllers
    {
        [ServiceFilter(typeof(EntityFilter))]
        public abstract class EntityController<TEntity, TViewModel, TFieldModel, TIndexListItemModel, TKey> : Controller
            where TEntity : Entity<TKey>
            where TFieldModel : new()
            where TIndexListItemModel : class
        {
            protected readonly IMapper Mapper;
            protected readonly DbContext Context;
            protected readonly ICommandBus Bus;

            protected EntityController(IMapper mapper, DbContext context, ICommandBus commandBus)
            {
                if (mapper == null) throw new ArgumentNullException(nameof(mapper));
                if (context == null) throw new ArgumentNullException(nameof(context));
                if (commandBus == null) throw new ArgumentNullException(nameof(commandBus));

                Mapper = mapper;
                Context = context;
                Bus = commandBus;
            }

            protected virtual int ItemsPerPage => 10;

            protected void SetError(string message)
            {
                TempData["Error"] = message;
            }

            protected void SetSuccess(string message)
            {
                TempData["Success"] = message;
            }

            protected virtual IActionResult RedirectAfterAction(TEntity entity)
            {
                return RedirectToAction("Details", new { entity.Id });
            }

            #region Index

            protected abstract IEnumerable<string> GetHeaders();

            public virtual IActionResult Index(int? page)
            {
                page = page ?? 1;

                var entities = FindEntities(page.Value);
                var indexItems = MapToIndexItems(entities);
                var indexModel = CreateIndexModel(indexItems);
                return CreateIndexResult(indexModel);
            }

            private IActionResult CreateIndexResult(EntityIndexModel model) => View(model);

            protected virtual IEnumerable<TEntity> FindEntities(int page)
            {
                var query = CreateQuery(page);
                return query.Execute(Context);
            }

            protected virtual IEnumerable<TIndexListItemModel> MapToIndexItems(IEnumerable<TEntity> entities)
                => Mapper.Map<IEnumerable<TEntity>, IEnumerable<TIndexListItemModel>>(entities);

            protected virtual EntityIndexModel CreateIndexModel(IEnumerable<TIndexListItemModel> items)
                => new EntityIndexModel
                {
                    Headers = GetHeaders(),
                    Items = items
                };

            protected virtual QueryObject<IEnumerable<TEntity>> CreateQuery(int page)
                => new GenericEntityQueryObject<TEntity, TKey>(page, ItemsPerPage);

            #endregion

            #region Details

            public virtual IActionResult Details(TKey id)
            {
                var entity = FindEntity(id);
                var model = MapToViewModel(entity);
                return CreateDetailsResult(model);
            }

            protected virtual TEntity FindEntity(TKey id) => Context.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(id));
            protected virtual TViewModel MapToViewModel(TEntity entity) => Mapper.Map<TViewModel>(entity);
            protected virtual IActionResult CreateDetailsResult(TViewModel model) => View(model);

            #endregion

            #region Create

            public virtual IActionResult Create()
            {
                var model = CreateFieldModel();
                return CreateCreateResult(model);
            }

            public virtual TFieldModel CreateFieldModel()
            {
                return new TFieldModel();
            }

            public virtual ActionResult CreateCreateResult(TFieldModel model) => View(model);

            [HttpPost]
            [ValidateAntiForgeryToken]
            public virtual IActionResult Create(TFieldModel fields)
            {
                if (!ModelState.IsValid)
                {
                    SetError("There are some errors");
                    return CreateCreateResult(fields);
                }

                var result = CreateCore(fields);
                if (!result.IsValid)
                {
                    SetError(result.Message);
                    return CreateCreateResult(fields);
                }

                SetSuccess(result.Message);
                return RedirectAfterAction(result.Entity);
            }

            protected virtual Result<TEntity, TFieldModel> CreateCore(TFieldModel fields)
            {
                var entity = MapFromFields(fields);
                SaveEntity(entity);
                return Result.Valid(entity, fields, $"{typeof(TEntity).Name} created");
            }

            protected virtual TEntity MapFromFields(TFieldModel fields) => Mapper.Map<TEntity>(fields);

            protected virtual void SaveEntity(TEntity entity)
            {
                Context.Add(entity);
                Context.SaveChanges();
            }

            #endregion

            #region Delete

            [HttpPost]
            [ValidateAntiForgeryToken]
            public virtual IActionResult Delete(TKey id)
            {
                var entity = FindEntity(id);
                DeleteCore(entity);
                SetSuccess($"{typeof(TEntity).Name} deleted");
                return CreateDeleteResult();
            }

            protected virtual void DeleteCore(TEntity entity)
            {
                Context.Remove(entity);
                Context.SaveChanges();
            }

            protected virtual IActionResult CreateDeleteResult() => RedirectToAction("Index");

            #endregion

            #region Edit

            public virtual IActionResult Edit(TKey id)
            {
                var entity = FindEntity(id);
                var model = MapToFieldModel(entity);

                return CreateEditResult(model);
            }

            protected virtual TFieldModel MapToFieldModel(TEntity entity)
                => Mapper.Map<TFieldModel>(entity);

            protected virtual IActionResult CreateEditResult(TFieldModel model) => View(model);

            [HttpPost]
            [ValidateAntiForgeryToken]
            public virtual IActionResult Edit(TKey id, TFieldModel fields)
            {
                if (!ModelState.IsValid)
                {
                    SetError("There are some errors.");
                    return CreateEditResult(fields);
                }

                var entity = FindEntity(id);
                var result = EditCore(fields, entity);

                if (!result.IsValid)
                {
                    SetError(result.Message);
                    return CreateEditResult(fields);
                }

                SetSuccess(result.Message);
                return RedirectAfterAction(entity);
            }

            protected virtual Result EditCore(TFieldModel fields, TEntity entity)
            {
                MapFromFields(fields, entity);
                SaveEntity(entity);
                return Result.Valid(entity, fields, $"{typeof(TEntity).Name} saved");
            }

            protected virtual void MapFromFields(TFieldModel fields, TEntity entity)
                => Mapper.Map(fields, entity);

            #endregion
        }
    }
}
