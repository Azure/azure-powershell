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

        public abstract string Name { get; }

        public abstract IEnumerable<Parameters> Dependencies { get; }

        public abstract bool HasCommonLocation { get; }

        public abstract Task<DependencyLocation> GetDependencyLocation(
            Context context, IGetParameters getParameters);
    }

    public abstract class Parameters<T> : Parameters
        where T : class
    {
        public Task<T> GetOrNullAsync(
            Context context, IGetParameters getParameters)
            => getParameters.GetOrAdd(
                this,
                async () => 
                {
                    try
                    {
                        return await GetAsync(context, getParameters);
                    }
                    catch (CloudException e)
                        when (e.Response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                });

        protected abstract Task<T> GetAsync(
            Context context, IGetParameters getParameters);

        public abstract string GetLocation(T value);

        public sealed override async Task<DependencyLocation> GetDependencyLocation(
            Context context, IGetParameters getParameters)
        {
            var info = await GetOrNullAsync(context, getParameters);
            var location = info == null ? null : GetLocation(info);
            if (location == null)
            {
                var tasks = Dependencies.Select(
                    d => d.GetDependencyLocation(context, getParameters));
                var dependencyLocations = await Task.WhenAll(tasks);
                return dependencyLocations.Aggregate(
                    (DependencyLocation)null, DependencyLocationExtensions.Best);
            }
            return new DependencyLocation(location, HasCommonLocation);
        }

        //protected abstract Task<T> CreateAsync(
        //    Context context, ICreateParameters createParameters);
    }
}
