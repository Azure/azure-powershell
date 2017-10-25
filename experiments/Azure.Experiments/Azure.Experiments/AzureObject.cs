using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Azure.Experiments
{
    public abstract class AzureObject
    {
        public static IEnumerable<AzureObject> NoDependencies { get; } 
            = Enumerable.Empty<AzureObject>();

        public string Name { get; }

        public IEnumerable<AzureObject> Dependencies { get; }

        public abstract Task CheckOrCreateAsync(string location);

        public int Priority { get; }

        /// <summary>
        /// The function should be called only after GetInfo is called for the 
        /// object and its dependencies.
        /// </summary>
        /// <returns></returns>
        public abstract string GetInfoLocation();

        /// <summary>
        /// The function should be called only after GetInfo is called for the 
        /// object and its dependencies.
        /// </summary>
        /// <returns></returns>
        public DependencyLocation GetDependencyLocation()
        {
            var location = GetInfoLocation();
            return location != null
                ? new DependencyLocation(location, Priority)
                : Dependencies
                    .Select(d => GetDependencyLocation())
                    .Aggregate(
                        DependencyLocation.None,
                        (a, b) => a.Priority > b.Priority ? a : b);
        }

        protected AzureObject(string name, IEnumerable<AzureObject> dependencies)
        {
            Name = name;
            Dependencies = dependencies;
            Priority = dependencies.Any() 
                ? dependencies.Max(d => d.Priority) + 1 
                : 1;
        }
    }

    public abstract class AzureObject<T, P> : AzureObject
        where T: class
        where P: struct, IInfoPolicy<T>
    {
        public T Info { get; private set; }

        public override string GetInfoLocation()
            => Info == null ? null : new P().GetLocation(Info);

        public async Task<T> GetOrNullAsync()
        {
            if (!IsGetCalled)
            {
                IsGetCalled = true;
                try
                {
                    Info = await GetOrThrowAsync();
                }
                catch (CloudException e) 
                    when (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                }
            }
            return Info;
        }

        public async Task<T> GetOrCreateAsync(string location)
        {
            Info = await GetOrNullAsync();
            if (Info == null)
            {
                // this can be optimized by using WaitForAll and a state 
                // machine for `Task<T> Info`. The state machine is required to
                // avoid multiple creations of the same resource group.
                foreach (var d in Dependencies)
                {
                    await d.CheckOrCreateAsync(location);
                }
                Info = await CreateAsync(location);
            }
            return Info;
        }

        public async Task<T> GetOrCreateAsync()
        {
            await GetOrNullAsync();
            var dl = GetDependencyLocation();
            var location = dl.Location ?? "eastus";
            return await GetOrCreateAsync(location);
        }

        protected AzureObject(string name, IEnumerable<AzureObject> dependencies) 
            : base(name, dependencies)
        {
        }

        public override Task CheckOrCreateAsync(string location)
            => GetOrCreateAsync(location);

        protected abstract Task<T> GetOrThrowAsync();

        protected abstract Task<T> CreateAsync(string location);

        private bool IsGetCalled;       
    }
}
