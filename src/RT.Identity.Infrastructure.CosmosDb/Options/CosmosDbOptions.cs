namespace RT.Identity.Infrastructure.CosmosDb.Options;

public class CosmosDbOptions
{
    public const string Section = "CosmosDb";

    public string ConnectionString { get; set; } = String.Empty;
    public string DatabaseName { get; set; } = String.Empty;
}
