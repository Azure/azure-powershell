using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    /// <summary>
    /// Common resource parameters.
    /// </summary>
    public abstract class ResourceParameters
    {
        public static IEnumerable<ResourceParameters> NoDependencies => Enumerable.Empty<ResourceParameters>();

        /// <summary>
        /// A resource name.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Resource dependencies.
        /// </summary>
        public abstract IEnumerable<ResourceParameters> Dependencies { get; }

        public abstract bool HasCommonLocation { get; }

        public abstract Task<DependencyLocation> GetDependencyLocation(IGetInfoContext getContext);
    }

    public abstract class ResourceParameters<Info> : ResourceParameters
        where Info : class
    {
        public Task<Info> GetOrNullAsync(IGetInfoContext getContext)
            => getContext.GetOrAdd(
                this,
                async () => 
                {
                    try
                    {
                        return await GetAsync(getContext);
                    }
                    catch (CloudException e) when (e.Response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                });

        protected abstract Task<Info> GetAsync(IGetInfoContext getContext);

        public abstract string GetLocation(Info info);

        public sealed override async Task<DependencyLocation> GetDependencyLocation(
            IGetInfoContext getContext)
        {
            var info = await GetOrNullAsync(getContext);
            var location = info == null ? null : GetLocation(info);
            if (location == null)
            {
                var tasks = Dependencies.Select(d => d.GetDependencyLocation(getContext));
                var dependencyLocations = await Task.WhenAll(tasks);
                return dependencyLocations.Aggregate(
                    (DependencyLocation)null, DependencyLocationExtensions.Merge);
            }
            return new DependencyLocation(location, HasCommonLocation);
        }

        //protected abstract Task<T> CreateAsync(
        //    Context context, ICreateParameters createParameters);
    }
}
