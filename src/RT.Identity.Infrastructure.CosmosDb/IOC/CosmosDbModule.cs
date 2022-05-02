using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RT.Identity.Infrastructure.CosmosDb.Databases;
using RT.Identity.Infrastructure.CosmosDb.Options;

namespace RT.Identity.Infrastructure.CosmosDb.IOC;

public static class CosmosDbModule
{
    public static IServiceCollection AddCosmosDbModule(this IServiceCollection services,
        string configSection = CosmosDbOptions.Section)
    {
        return services
            .AddCosmosDbOptions(configSection)
            .AddSingleton<CosmosClient>((s) => CreateClient(s.GetRequiredService<IOptions<CosmosDbOptions>>())) 
            .AddSingleton<Database>((s) => GetDatabase(s.GetRequiredService<CosmosClient>(),s.GetRequiredService<IOptions<CosmosDbOptions>>()))
            .AddSingleton<IdentityDatabase>()
            ;
    }

    private static IServiceCollection AddCosmosDbOptions(this IServiceCollection services, string configSection = CosmosDbOptions.Section)
    {
        services.AddOptions<CosmosDbOptions>().BindConfiguration(configSection);
        return services;
    }

    private static CosmosClient CreateClient(IOptions<CosmosDbOptions> options)
    {
        return new CosmosClientBuilder(options.Value.ConnectionString)
            .WithSerializerOptions(new CosmosSerializationOptions
            {
                PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
            })
            .Build();
    }

    private static Database GetDatabase(CosmosClient client, IOptions<CosmosDbOptions> options) =>
        client.GetDatabase(options.Value.DatabaseName);
}
