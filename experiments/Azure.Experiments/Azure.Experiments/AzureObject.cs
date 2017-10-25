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

        public abstract string Name { get; }

        public IEnumerable<AzureObject> Dependencies { get; }

        public abstract Task CheckOrCreateAsync(string location);

        public int Priority { get; }

        /// <summary>
        /// The function should be called only after GetInfo is called for the 
        /// object and its dependencies.
        /// </summary>
        /// <returns></returns>
        public abstract Task<string> GetInfoLocationAsync();

        /// <summary>
        /// The function should be called only after GetInfo is called for the 
        /// object and its dependencies.
        /// </summary>
        /// <returns></returns>
        public async Task<DependencyLocation> GetDependencyLocationAsync()
        {
            if (DependencyLocation == null)
            {
                var location = await GetInfoLocationAsync();
                if (location != null)
                {
                    return new DependencyLocation(location, Priority);
                }
                var taskList = Dependencies.Select(d => GetDependencyLocationAsync());
                var dlList = await Task.WhenAll(taskList);
                DependencyLocation = dlList.Aggregate(
                    DependencyLocation.None,
                    (a, b) => a.Priority > b.Priority ? a : b);
            }
            return DependencyLocation;
        }

        protected AzureObject(IEnumerable<AzureObject> dependencies)
        {
            // Name = name;
            Dependencies = dependencies;
            Priority = dependencies.Any() 
                ? dependencies.Max(d => d.Priority) + 1 
                : 1;
        }

        private DependencyLocation DependencyLocation { get; set; }
    }

    public abstract class AzureObject<T, P> : AzureObject
        where T: class
        where P: struct, IInfoPolicy<T>
    {
        private T Info { get; set; }

        public override async Task<string> GetInfoLocationAsync()
            => await GetOrNullAsync() == null ? null : new P().GetLocation(Info);

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
            var dl = await GetDependencyLocationAsync();
            var location = dl.Location ?? "eastus";
            return await GetOrCreateAsync(location);
        }

        protected AzureObject(IEnumerable<AzureObject> dependencies) 
            : base(dependencies)
        {
        }

        public override Task CheckOrCreateAsync(string location)
            => GetOrCreateAsync(location);

        protected abstract Task<T> GetOrThrowAsync();

        protected abstract Task<T> CreateAsync(string location);

        private bool IsGetCalled;       
    }
}
