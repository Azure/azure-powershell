using Microsoft.Rest.Azure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public static class CurrentState
    {
        public static async Task<IState> GetState<Config>(
            this IResourceConfig<Config> resourceConfig,
            IClient client,
            CancellationToken cancellationToken)
            where Config : class
        {
            var visitor = new Visitor(client, cancellationToken);
            await visitor.GetOrAdd(resourceConfig);
            return visitor.Result;
        }

        sealed class Visitor : AsyncOperation
        {
            public override async Task<object> Visit<Config>(ResourceConfig<Config> config)
            {
                Config info;
                try
                {
                    info = await config.Policy.GetAsync(GetAsyncParams.Create(
                        Client, config.ResourceGroupName, config.Name, CancellationToken));
                }
                catch (CloudException e) when (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    info = null;
                }
                if (info == null)
                {
                    var tasks = config.Dependencies.Select(GetOrAddUntyped);
                    await Task.WhenAll(tasks);
                    return null;
                }
                return info;
            }

            public override async Task<object> Visit<Config, ParentConfig>(
                NestedResourceConfig<Config, ParentConfig> config)
            {
                var parent = await GetOrAdd(config.Parent);
                return parent == null ? null : config.Policy.Get(parent);
            }

            public Visitor(IClient client, CancellationToken cancellationToken)
                : base(client, cancellationToken)
            {
            }
        }
    }
}
