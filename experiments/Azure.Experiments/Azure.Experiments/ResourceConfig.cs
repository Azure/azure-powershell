using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public interface IResourceConfig
    {
        string Name { get; }

        IEnumerable<IResourceConfig> Dependencies { get; }

        Task<object> GetAsync(Context context);

        Location GetLocation(object i);

        object GetState(IStateMap getState);
    }

    public static class ResourceConfig
    {
        public static ResourceConfig<I> Create<I>(
            string name,
            IEnumerable<IResourceConfig> dependencies,
            Func<Context, Task<I>> getAsync,
            Func<I, Location> getLocation,
            Func<IStateMap, ResourceConfig<I>, I> getState)
            => new ResourceConfig<I>(name, dependencies, getAsync, getLocation, getState);
    }

    public sealed class ResourceConfig<I> : IResourceConfig
    {
        public string Name { get; }

        public IEnumerable<IResourceConfig> Dependencies { get; }

        public ResourceConfig(
            string name,
            IEnumerable<IResourceConfig> dependencies,
            Func<Context, Task<I>> getAsyncFunc,
            Func<I, Location> getLocationFunc,
            Func<IStateMap, ResourceConfig<I>, I> getStateFunc)
        {
            Name = name;
            Dependencies = dependencies;
            GetAsyncFunc = getAsyncFunc;
            GetLocationFunc = getLocationFunc;
            GetStateFunc = getStateFunc;
        }

        public async Task<object> GetAsync(Context context) => await GetAsyncFunc(context);

        public Location GetLocation(object i) => GetLocationFunc((I)i);

        public object GetState(IStateMap stateMap) => GetStateFunc(stateMap, this);

        private Func<Context, Task<I>> GetAsyncFunc { get; }

        private Func<I, Location> GetLocationFunc { get; }
   
        public Func<IStateMap, ResourceConfig<I>, I> GetStateFunc { get; }
    }
}
