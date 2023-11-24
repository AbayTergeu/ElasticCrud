namespace ElasticCrudExample;

public class ElasticSettings : IElasticSettings
{
    public ElasticSettings(IConfiguration configuration)
    {
        Uri = configuration["Elastic:Uri"];
    }

    public string? Uri { get; set; }
}