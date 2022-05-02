using System.Formats.Asn1;
using Microsoft.Azure.Cosmos;
using RT.Identity.Infrastructure.CosmosDb.Constants;

namespace RT.Identity.Infrastructure.CosmosDb.Databases;

public class IdentityDatabase
{
    private readonly Database _db;

    public IdentityDatabase(Database db)
    {
        _db = db;
    }

    public async Task InitialiseDatabaseAync()
    {
        await _db.CreateContainerIfNotExistsAsync(ContainerNames.Clients, "clientId");
    }

    public Container Clients => _db.GetContainer(ContainerNames.Clients);
}
