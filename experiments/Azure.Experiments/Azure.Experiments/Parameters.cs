using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public abstract class Parameters
    {
        public static IEnumerable<Parameters> NoDependencies
            => Enumerable.Empty<Parameters>();

        public string Name { get; }

        public IEnumerable<Parameters> Dependencies { get; }

        protected Parameters(string name, IEnumerable<Parameters> dependencies)
        {
            Name = name;
            Dependencies = dependencies;
        }
    }

    public abstract class Parameters<T> : Parameters
        where T : class
    {
        protected Parameters(string name, IEnumerable<Parameters> parameters)
            : base(name, parameters)
        {
        }

        public async Task<T> GetOrNullAsync(GetContext context)
            => await context.GetOrAdd(
                this, 
                async () => 
                {
                    try
                    {
                        return await GetAsync(context);
                    }
                    catch (CloudException e)
                        when (e.Response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                });

        protected abstract Task<T> GetAsync(GetContext context);
    }
}
