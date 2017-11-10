using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public static class State
    {
        public static async Task<IState> GetStateAsync<T>(this IClient client, ResourceConfig<T> config)
            where T : class
        {
            var visitor = new GetAsyncVisitor(client);
            await visitor.Visit(config);
            return visitor.State;
        }

        sealed class Result : IState
        {
            public T Get<T>(ResourceConfig<T> resourceConfig)
                where T : class
                => Resources.TryGetValue(resourceConfig, out var result) ? (T)result : null;

            public T Get<T, P>(ChildResourceConfig<T, P> config)
                where T : class
                where P : class
            {
                var parent = Get(config.Parent);
                return parent == null ? null : config.Policy.Get(parent, config.Name);
            }

            public ResourceGroup GetResourceGroup(string name)
                => ResourceGroups.TryGetValue(name, out var result) ? result : null;

            public ConcurrentDictionary<string, ResourceGroup> ResourceGroups { get; }
                = new ConcurrentDictionary<string, ResourceGroup>();

            public ConcurrentDictionary<IResourceConfig, object> Resources { get; }
                = new ConcurrentDictionary<IResourceConfig, object>();
        }

        static async Task<T> HandleNotFoundException<T>(Func<Task<T>> f)
            where T : class
        {
            try
            {
                return await f();
            }
            catch (CloudException e)
                when (e.Response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        sealed class GetAsyncVisitor :
            IResourceConfigVisitor<Task>,
            IChildResourceConfigVisitor<Task>
        {
            public Result State { get; } = new Result();

            public GetAsyncVisitor(IClient client)
            {
                Client = client;
            }

            public async Task GetResourceGroupAsync(string name)
                => await ResourceGroupTasks.GetOrAdd(
                    name,
                    async _ =>
                    {
                        var result = await HandleNotFoundException(
                            () => Client
                                .GetClient<IResourceManagementClient>()
                                .ResourceGroups
                                .GetAsync(name));
                        if (result != null)
                        {
                            State.ResourceGroups.GetOrAdd(name, result);
                        }
                        return result;
                    });

            public async Task Visit<Info>(ResourceConfig<Info> config)
                where Info : class
                => await ResourcesTasks.GetOrAdd(
                    config,
                    async _ =>
                    {
                        var i = await HandleNotFoundException(
                            () => config.Policy.Operations.GetAsync(Client, config.Name));
                        if (i != null)
                        {
                            State.Resources.GetOrAdd(config, i);
                        }
                        else
                        {
                            var resourceGroupTask = GetResourceGroupAsync(config.Name.ResourceGroupName);
                            var resourceTasks = config.Resources.Select(c => c.Apply(this));
                            var childResourceTasks = config.ChildResources.Select(c => c.Apply(this));
                            var tasks = resourceTasks
                                .Concat(childResourceTasks)
                                .Concat(new[] { resourceGroupTask });
                            // wait for all dependencies 
                            // (resource group, resources, and child resources).
                            await Task.WhenAll(tasks);
                        }
                        return i;
                    });

            public Task Visit<Info, ParentInfo>(ChildResourceConfig<Info, ParentInfo> config)
                where Info : class
                where ParentInfo : class
                => Visit(config.Parent);

            IClient Client { get; }

            ConcurrentDictionary<string, Task<ResourceGroup>> ResourceGroupTasks { get; }
                = new ConcurrentDictionary<string, Task<ResourceGroup>>();

            ConcurrentDictionary<IResourceConfig, Task<object>> ResourcesTasks { get; }
                = new ConcurrentDictionary<IResourceConfig, Task<object>>();
        }
    }
}
