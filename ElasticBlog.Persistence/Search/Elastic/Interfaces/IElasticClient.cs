using Nest;

namespace ElasticBlog.Persistence.Search.Elastic.Interfaces
{
    public interface IElasticClient<TEntity>
        where TEntity : class
    {
        Task<ExistsResponse> ExistsIndex(string indexName);
        Task<CreateIndexResponse> CreateIndex(string indexName);
        Task<CreateIndexResponse> CreateIndex(string indexName, Func<CreateIndexDescriptor, ICreateIndexRequest> indexPredicate);
        Task<IndexResponse> Index(TEntity entity, string indexName);
        Task<ISearchResponse<TEntity>> Search(Func<SearchDescriptor<TEntity>, ISearchRequest> searchPredicate);
        Task<DeleteByQueryResponse> Delete(Func<DeleteByQueryDescriptor<TEntity>, IDeleteByQueryRequest> deletePredicate);
    }
}

