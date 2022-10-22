using Microsoft.EntityFrameworkCore;
using TadbirPardazProject.Domain.Common;

namespace TadbirPardazProject.Infrastructure.Common.Extensions
{
    public static class EntityWithCountExtension
    {
        public static async Task<EntitiesWithCount<TType>> ToEntityWithCount<TType>(this IQueryable<TType> query,
            int pageId, int pageSize, CancellationToken cancellationToken)
        {
            pageId = pageId < 0 ? 1 : pageId;
            var startRow = (pageId - 1) * pageSize;

            return new EntitiesWithCount<TType>()
            {
                Entities = await query.Skip(startRow).Take(pageSize).ToListAsync(cancellationToken),
                Count = await query.CountAsync(cancellationToken)
            };
        }
    }
}
