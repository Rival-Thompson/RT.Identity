using Duende.IdentityServer.Models;

namespace RT.Identity.Core.Infrastructure.Data;

public interface IClientRepository
{
    ValueTask<Client?> GetClientByIdAsync(string id, CancellationToken cancellationToken = default);
}
