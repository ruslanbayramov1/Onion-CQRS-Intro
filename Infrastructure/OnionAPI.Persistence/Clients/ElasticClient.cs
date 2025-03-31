using Elastic.Clients.Elasticsearch;
using OnionAPI.Domain.Enums;
using OnionAPI.Persistence.Helpers;

namespace OnionAPI.Persistence.Clients;

/// <summary>
/// Custom elastic client class
/// </summary>
public class ElasticClient
{
    public static ElasticsearchClient GetClient(ElasticIndexes index)
    {
        string connStr = ConfigurationHelper.GetConnectionString("ElasticSearch")!;

        ElasticsearchClientSettings settings = new ElasticsearchClientSettings(new Uri(connStr));
        settings.DefaultIndex(index.ToString().ToLower());
        ElasticsearchClient client = new ElasticsearchClient(settings);
        client.IndexAsync(index.ToString());

        return client;
    }
}
