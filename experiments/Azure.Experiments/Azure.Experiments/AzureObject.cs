using Microsoft.Rest.Azure;
using System;
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

        public abstract Task CheckOrCreateAsync(Context c);

        protected AzureObject(string name, IEnumerable<AzureObject> dependencies)
        {
            Name = name;
            Dependencies = dependencies;
        }
    }

    public abstract class AzureObject<T, C> : AzureObject
        where T: class
    {
        public async Task<T> GetOrNullAsync(C c)
        {
            if (!IsGetCalled)
            {
                IsGetCalled = true;
                try
                {
                    Info = await GetOrThrowAsync(c);
                }
                catch (CloudException e) 
                    when (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                }
            }
            return Info;
        }

        public Task<T> GetOrNullAsync(Context c)
            => GetOrNullAsync(CreateClient(c));

        public async Task<T> GetOrCreateAsync(Context c)
        {
            Info = await GetOrNullAsync(c);
            if (Info == null)
            {
                // this can be optimized by using WaitForAll and a state 
                // machine for `Task<T> Info`. The state machine is required to
                // avoid multiple creations of the same resource group.
                foreach (var d in Dependencies)
                {
                    await d.CheckOrCreateAsync(c);
                }
                Info = await CreateAsync(CreateClient(c));
            }
            return Info;
        }

        public Task DeleteAsync(Context c)
            => DeleteAsync(CreateClient(c));

        public override Task CheckOrCreateAsync(Context c)
            => GetOrCreateAsync(c);

        protected AzureObject(string name, IEnumerable<AzureObject> dependencies) 
            : base(name, dependencies)
        {
        }

        protected abstract C CreateClient(Context c);

        protected abstract Task<T> GetOrThrowAsync(C c);

        protected abstract Task<T> CreateAsync(C c);

        protected abstract Task DeleteAsync(C c);

        private bool IsGetCalled;

        private T Info;
    }
}
