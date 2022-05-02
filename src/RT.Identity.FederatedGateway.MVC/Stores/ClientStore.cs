using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;
using RT.Identity.Core.Infrastructure.Data;

namespace RT.Identity.FederatedGateway.MVC.Stores;

public class ClientStore : IClientStore
{
    private readonly IClientRepository _repository;

    public ClientStore(IClientRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Client> FindClientByIdAsync(string clientId)
    {
        return (await _repository.GetClientByIdAsync(clientId)) ??
            throw new NullReferenceException($"No client found with id {clientId}");
    }
}
