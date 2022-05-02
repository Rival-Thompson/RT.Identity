using Duende.IdentityServer.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using RT.Identity.Core.Infrastructure.Data;
using RT.Identity.Infrastructure.CosmosDb.Databases;
using RT.Identity.Infrastructure.CosmosDb.Extensions;

namespace RT.Identity.Infrastructure.CosmosDb.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IdentityDatabase _db;
    
    public ClientRepository(IdentityDatabase db)
    {
        _db = db;
    }

    public ValueTask<Client?> GetClientByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return _db.Clients
            .GetItemLinqQueryable<Client>()
            .Where(c => c.ClientId == id)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
