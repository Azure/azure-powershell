using Microsoft.Rest.Azure;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public static class State
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
            public async Task<Config> GetOrAdd<Config>(IResourceConfig<Config> config)
                where Config : class
            {
                var result = await Map.GetOrAdd(
                    config,
                    async _ =>
                    {
                        var info = await config.Apply(this);
                        if (info != null)
                        {
                            Result.Map.GetOrAdd(config, info);
                        }
                        return info;
                    });
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
                    var tasks = config.Dependencies.Select(d => d.Apply(this));
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

            public Result Result { get; } = new Result();

            IClient Client { get; }

            ConcurrentDictionary<IResourceConfig, Task<object>> Map { get; }
                = new ConcurrentDictionary<IResourceConfig, Task<object>>();
        }

        sealed class Result : IState
        {
            public Config Get<Config>(IResourceConfig<Config> config)
                where Config : class
                => Map.TryGetValue(config, out var result) ? result as Config : null;

            public ConcurrentDictionary<IResourceConfig, object> Map { get; }
                = new ConcurrentDictionary<IResourceConfig, object>();
        }
    }
}
