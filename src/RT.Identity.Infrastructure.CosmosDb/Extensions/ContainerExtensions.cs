using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace RT.Identity.Infrastructure.CosmosDb.Extensions;

public static class ContainerExtensions
{
    public static async IAsyncEnumerable<TModel> ToAsyncEnumerable<TModel>(this FeedIterator<TModel> setIterator,
        CancellationToken cancellationToken = default)
    {
        while (setIterator.HasMoreResults)
            foreach (var item in await setIterator.ReadNextAsync(cancellationToken))
            {
                yield return item;
            }
    }

    public static ValueTask<List<TModel>> ToListAsync<TModel>(this IQueryable<TModel> query,
        CancellationToken cancellationToken = default)
    {
        return query
            .ToFeedIterator<TModel>()
            .ToAsyncEnumerable<TModel>(cancellationToken)
            .ToListAsync(cancellationToken);
    }
    
    public static ValueTask<TModel?> FirstOrDefaultAsync<TModel>(this IQueryable<TModel> query,
        CancellationToken cancellationToken = default)
    {
        return query.ToFeedIterator<TModel>().ToAsyncEnumerable(cancellationToken)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
