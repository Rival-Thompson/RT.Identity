﻿using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;

namespace RT.Identity.FederatedGateway.MVC.Stores;

public class ResourceStore : IResourceStore
{
    public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
    {
        throw new NotImplementedException();
    }

    public Task<Resources> GetAllResourcesAsync()
    {
        throw new NotImplementedException();
    }
}
