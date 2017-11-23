using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class ResourceConfigExtensions
    {
        public static ResourceConfig<TModel> CreateConfig<TModel>(
            this ResourceStrategy<TModel> strategy,
            string resourceGroupName,
            string name,
            Func<string, TModel> createModel = null,
            IEnumerable<IEntityConfig> dependencies = null)
            where TModel : class, new()
            => new ResourceConfig<TModel>(
                strategy,
                resourceGroupName,
                name,
                createModel ?? (_ => new TModel()),
                dependencies.EmptyIfNull());

        public static ResourceConfig<TModel> CreateConfig<TModel>(
            this ResourceStrategy<TModel> strategy,
            ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            Func<string, TModel> createModel = null,
            IEnumerable<IEntityConfig> dependencies = null)
            where TModel : class, new()
            => strategy.CreateConfig(
                resourceGroup.Name,
                name,
                createModel,
                dependencies.EmptyIfNull().Concat(new[] { resourceGroup }));

        public static async Task<TModel> GetAsync<TModel>(
            this ResourceConfig<TModel> config,
            IClient client,
            CancellationToken cancellationToken)
            where TModel : class
        {
            try
            {
                return await config.Strategy.GetAsync(
                    client,
                    new GetAsyncParams(config.ResourceGroupName, config.Name, cancellationToken));
            }
            catch (CloudException e)
                when (e.Response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public static Task<TModel> CreateOrUpdateAsync<TModel>(
            this ResourceConfig<TModel> config,
            IClient client,
            TModel model,
            CancellationToken cancellationToken)
            where TModel : class
            => config.Strategy.CreateOrUpdateAsync(
                client,
                CreateOrUpdateAsyncParams.Create(
                    config.ResourceGroupName,
                    config.Name,
                    model,
                    cancellationToken));

        public static IEnumerable<IResourceConfig> GetResourceDependencies(
            this IResourceConfig config)
            => config.Dependencies.Select(d => d.Resource);
    }
}
