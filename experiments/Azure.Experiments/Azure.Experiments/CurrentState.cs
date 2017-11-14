using Microsoft.Rest.Azure;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public static class CurrentState
    {
        public static async Task<IState> GetState<Config>(
            IClient client, IResourceConfig<Config> resourceConfig)
            where Config : class
        {
            var visitor = new Visitor(client);
            await visitor.GetOrAdd(resourceConfig);
            return visitor.Result;
        }

        sealed class Visitor : IResourceConfigVisitor<Task<object>>
        {
            public async Task<object> GetOrAddUntyped(IResourceConfig config)
                => await Map.GetOrAdd(
                    config,
                    async _ =>
                    {
                        var info = await config.Apply(this);
                        if (info != null)
                        {
                            Result.GetOrAddUntyped(config, () => info);
                        }
                        return info;
                    });

            public async Task<Config> GetOrAdd<Config>(IResourceConfig<Config> config)
                where Config : class
            {
                var result = await GetOrAddUntyped(config);
                return result as Config;
            }

            public async Task<object> Visit<Config>(ResourceConfig<Config> config)
                where Config : class
            {
                Config info;
                try
                {
                    info = await config.Policy.GetAsync(GetAsyncParams.Create(
                        Client, config.ResourceGroupName, config.Name, new CancellationToken()));
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

            public async Task<object> Visit<Config, ParentConfig>(
                NestedResourceConfig<Config, ParentConfig> config)
                where Config : class
                where ParentConfig : class
            {
                var parent = await GetOrAdd(config.Parent);
                return parent == null ? null : config.Policy.Get(parent);
            }

            public Visitor(IClient client)
            {
                Client = client;
            }

            public State Result { get; } = new State();

            IClient Client { get; }

            ConcurrentDictionary<IResourceConfig, Task<object>> Map { get; }
                = new ConcurrentDictionary<IResourceConfig, Task<object>>();
        }
    }
}
