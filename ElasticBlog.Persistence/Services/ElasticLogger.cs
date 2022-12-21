using ElasticBlog.Domain.ValueObjects;
using ElasticBlog.Persistence.Search.Elastic.Interfaces;

namespace ElasticBlog.Persistence.Services
{
    public class ElasticLogger : IElasticLogger
    {
        private IElasticClient<LogModel> _elasticClient;
        private string IndexName = "error_log";

        public ElasticLogger(IElasticClient<LogModel> elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task LogCritical(LogModel logModel)
        {
            await CreateIndex();
            logModel.SetLogLevel(LogLevel.Critical);
            await Index(logModel);
        }

        public async Task LogException(LogModel logModel)
        {
            await CreateIndex();
            logModel.SetLogLevel(LogLevel.Exception);
            await Index(logModel);
        }

        public async Task LogInformation(LogModel logModel)
        {
            await CreateIndex();
            logModel.SetLogLevel(LogLevel.Information);
            await Index(logModel);
        }

        public async Task LogWarning(LogModel logModel)
        {
            await CreateIndex();
            logModel.SetLogLevel(LogLevel.Warning);
            await Index(logModel);
        }

        #region Private Methods
        private async Task CreateIndex()
        {
            var exists = await _elasticClient.ExistsIndex(IndexName);
            if (!exists.Exists)
            {
                var response = await _elasticClient.CreateIndex(IndexName);
                if (!response.IsValid)
                    throw new Exception("Index oluşturulamadı");
            }
        }

        private async Task Index(LogModel logModel)
        {
            var response = await _elasticClient.Index(logModel, IndexName);
            if (!response.IsValid || response.Result != Nest.Result.Created)
                throw new Exception("Indexlenemedi");
        }
        #endregion
    }
}
