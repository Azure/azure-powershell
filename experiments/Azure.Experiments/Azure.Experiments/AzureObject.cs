using Microsoft.Rest.Azure;using System.Collections.Generic;
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

        public abstract Task CheckOrCreateAsync();

        public int Priority { get; }

        protected AzureObject(string name, IEnumerable<AzureObject> dependencies)
        {
            Name = name;
            Dependencies = dependencies;
            Priority = dependencies.Any() ? dependencies.Max(d => d.Priority) + 1 : 0;
        }
    }

    public abstract class AzureObject<T> : AzureObject
        where T: class
    {
        public T Info { get; private set; }

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

        public async Task<T> GetOrCreateAsync()
        {
            Info = await GetOrNullAsync();
            if (Info == null)
            {
                // this can be optimized by using WaitForAll and a state 
                // machine for `Task<T> Info`. The state machine is required to
                // avoid multiple creations of the same resource group.
                foreach (var d in Dependencies)
                {
                    await d.CheckOrCreateAsync();
                }
                Info = await CreateAsync();
            }
            return Info;
        }

        protected AzureObject(string name, IEnumerable<AzureObject> dependencies) 
            : base(name, dependencies)
        {
        }

        public override Task CheckOrCreateAsync()
            => GetOrCreateAsync();

        protected abstract Task<T> GetOrThrowAsync();

        protected abstract Task<T> CreateAsync();

        private bool IsGetCalled;       
    }
}
