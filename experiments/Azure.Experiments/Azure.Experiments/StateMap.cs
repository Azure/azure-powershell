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
    public sealed class StateMap : IState
    {
        public T Get<T>(ResourceConfig<T> resourceConfig)
            where T : class
            => Resources.TryGetValue(resourceConfig, out var result) ? (T)result : null;

        public T Get<T>(IChildResourceConfig<T> childResourceConfig)
            where T : class
            => ChildResources.TryGetValue(childResourceConfig, out var result) ? (T)result : null;

        public ResourceGroup GetResourceGroup(string name)
            => ResourceGroups.TryGetValue(name, out var result) ? result : null;

        public Task GetAsync<T>(IClient client, ResourceConfig<T> config)
            where T : class
            => new GetAsyncVisitor(this, client).Visit(config);

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
            public GetAsyncVisitor(StateMap map, IClient client)
            {
                State = map;
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

            public async Task<Info> GetResourceAsync<Info>(ResourceConfig<Info> config)
                where Info : class
            {
                var result = await ResourcesTasks.GetOrAdd(
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
                return result as Info;
            }

            public async Task Visit<Info>(ResourceConfig<Info> config)
                where Info : class
                => await GetResourceAsync(config);

            /// <summary>
            /// Get infromation about a child resource.
            /// </summary>
            /// <typeparam name="Info"></typeparam>
            /// <typeparam name="ParentInfo"></typeparam>
            /// <param name="config"></param>
            /// <returns></returns>
            public async Task Visit<Info, ParentInfo>(ChildResourceConfig<Info, ParentInfo> config)
                where Info : class
                where ParentInfo : class
                => await ChildResourcesTasks.GetOrAdd(
                    config,
                    async _ => 
                    {
                        var parent = await GetResourceAsync(config.Parent);
                        if (parent != null)
                        {
                            var result = config.Policy.Get(parent, config.Name);
                            if (result != null)
                            {
                                State.ChildResources.GetOrAdd(config, result);                                
                            }
                            return result;
                        }
                        else
                        {
                            return null;
                        }
                    });

            StateMap State { get; }

            IClient Client { get; }

            ConcurrentDictionary<string, Task<ResourceGroup>> ResourceGroupTasks { get; }
                = new ConcurrentDictionary<string, Task<ResourceGroup>>();

            ConcurrentDictionary<IResourceConfig, Task<object>> ResourcesTasks { get; }
                = new ConcurrentDictionary<IResourceConfig, Task<object>>();

            ConcurrentDictionary<IChildResourceConfig, Task<object>> ChildResourcesTasks { get; }
                = new ConcurrentDictionary<IChildResourceConfig, Task<object>>();
        }

        ConcurrentDictionary<string, ResourceGroup> ResourceGroups { get; }
            = new ConcurrentDictionary<string, ResourceGroup>();

        ConcurrentDictionary<IResourceConfig, object> Resources { get; }
            = new ConcurrentDictionary<IResourceConfig, object>();

        ConcurrentDictionary<IChildResourceConfig, object> ChildResources { get; }
            = new ConcurrentDictionary<IChildResourceConfig, object>();
    }
}
