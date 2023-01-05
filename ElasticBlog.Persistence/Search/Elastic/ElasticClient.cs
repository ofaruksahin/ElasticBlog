using ElasticBlog.Domain.ElasticModel;
using ElasticBlog.Persistence.Search.Elastic.Interfaces;
using ElasticBlog.Persistence.Search.Elastic.Models;
using Nest;

namespace ElasticBlog.Persistence.Search.Elastic
{
    public class ElasticClient<TEntity> : IElasticClient<TEntity>
        where TEntity : BaseElasticModel
    {
        private Nest.ElasticClient _client;

        public ElasticClient(ElasticOptions elasticOptions)
        {
            var settings = new ConnectionSettings(new Uri(elasticOptions.Url))
                .EnableApiVersioningHeader()
                .BasicAuthentication(elasticOptions.Username, elasticOptions.Password);
            _client = new Nest.ElasticClient(settings);
        }

        public async Task<ExistsResponse> ExistsIndex(string indexName)
        {
            return await _client.Indices.ExistsAsync(indexName);
        }

        public async Task<CreateIndexResponse> CreateIndex(string indexName)
        {
            return await _client.Indices.CreateAsync(
                indexName,
                f => f.Map<TEntity>(x => x.AutoMap()));
        }

        public async Task<CreateIndexResponse> CreateIndex(string indexName, Func<CreateIndexDescriptor, ICreateIndexRequest> indexPredicate)
        {
            return await _client.Indices.CreateAsync(indexName, indexPredicate);
        }

        public async Task<IndexResponse> Index(TEntity entity, string indexName)
        {
            object id = entity.Id;
            if (entity.Id < 1)
                id = string.Empty;
            return await _client.IndexAsync(entity, request => request.Index(indexName).Id(new Id(id)));
        }

        public async Task<ISearchResponse<TEntity>> Search(Func<SearchDescriptor<TEntity>, ISearchRequest> searchPredicate)
        {
            return await _client.SearchAsync<TEntity>(searchPredicate);
        }

        public async Task<DeleteByQueryResponse> Delete(Func<DeleteByQueryDescriptor<TEntity>, IDeleteByQueryRequest> deletePredicate)
        {
            return await _client.DeleteByQueryAsync<TEntity>(deletePredicate);
        }
    }
}

