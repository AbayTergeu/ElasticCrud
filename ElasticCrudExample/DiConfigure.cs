using Nest;

namespace ElasticCrudExample;

public static class DiConfigure
{
    public static IServiceCollection AddElasticConfig(this IServiceCollection serviceCollection)
    {
        serviceCollection.ConfigureElastic();
        return serviceCollection;
    }
    
    private static void ConfigureElastic(this IServiceCollection services)
    {
        services.AddSingleton(ConfigureElasticClient);
    }

    private static IElasticClient ConfigureElasticClient(IServiceProvider serviceProvider)
    {
        var elasticSettings = serviceProvider.GetRequiredService<IElasticSettings>();
        return new ElasticClient(
            new ConnectionSettings(new Uri(elasticSettings.Uri)));
    }
}