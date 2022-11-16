namespace ElasticBlog.Persistence.Shared
{
    public static class RepositoryExtensions
    {
        public static async Task<PaginatedResponse<TEntity>> PaginateAsync<TEntity>(
            this IQueryable<TEntity> query,
            PaginationFilter paginationFilter)
        {
            var totalRecords = await query.CountAsync();

            List<TEntity> pagedData = null;

            if(paginationFilter.PageSize > -1)
            {
                pagedData = await query
                    .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                    .Take(paginationFilter.PageSize)
                    .ToListAsync();
            }
            else
            {
                pagedData = await query.ToListAsync();
            }

            var totalPages = ((double)totalRecords / (double)paginationFilter.PageSize);
            var roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            var paginatedResponse = new PaginatedResponse<TEntity>(pagedData, paginationFilter.PageNumber, paginationFilter.PageSize);
            paginatedResponse.TotalPages = roundedTotalPages;
            paginatedResponse.TotalRecords = totalRecords;

            return paginatedResponse;
        }

        public static IQueryable<TSource> WhereIf<TSource>(
            this IQueryable<TSource> source,
            bool condition,
            Expression<Func<TSource,bool>> predicate)
        {
            if(condition)
                return source.Where(predicate);
            return source;
        }
    }
}
