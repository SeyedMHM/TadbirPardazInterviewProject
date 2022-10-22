using AutoMapper;
using TadbirPardazProject.Domain.Common;
using TadbirPardazProject.Shared.Common.ApiResults;

namespace TadbirPardazProject.Application.Common.Exceptions
{
    public static class DataPagerExtension
    {
        public static PagedList<TResult> ToPagedResult<TEntity, TResult>(
             this EntitiesWithCount<TEntity> entitiesWithCount, IMapper _mapper,
             int pageId, int pageSize)
             where TEntity : IEntity
        {
            var productsPagedList = new PagedList<TResult>()
            {
                CurrentPage = pageId,
                PageSize = pageSize,
                Items = _mapper.Map<List<TResult>>(entitiesWithCount.Entities),
                TotalCount = entitiesWithCount.Count
            };

            return productsPagedList;
        }
    }
}

