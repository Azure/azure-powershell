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

        Task<object> CreateAsync(Context context, string location);
    }

    public static class ResourceConfig
    {
        public static ResourceConfig<I> Create<I>(
            string name,
            IEnumerable<IResourceConfig> dependencies,
            Func<Context, Task<I>> getAsync,
            Func<I, Location> getLocation,
            Func<IStateMap, ResourceConfig<I>, I> getState,
            Func<Context, string, Task<I>> createAsync)
            => new ResourceConfig<I>(
                name, dependencies, getAsync, getLocation, getState, createAsync);
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
            Func<IStateMap, ResourceConfig<I>, I> getStateFunc,
            Func<Context, string, Task<I>> createAsyncFunc)
        {
            Name = name;
            Dependencies = dependencies;
            GetAsyncFunc = getAsyncFunc;
            GetLocationFunc = getLocationFunc;
            GetStateFunc = getStateFunc;
            CreateAsyncFunc = createAsyncFunc;
        }

        public async Task<object> GetAsync(Context context) => await GetAsyncFunc(context);

        public Location GetLocation(object i) => GetLocationFunc((I)i);

        public object GetState(IStateMap stateMap) => GetStateFunc(stateMap, this);

        public async Task<object> CreateAsync(Context context, string location)
            => await CreateAsyncFunc(context, location);

        private Func<Context, Task<I>> GetAsyncFunc { get; }

        private Func<I, Location> GetLocationFunc { get; }
   
        public Func<IStateMap, ResourceConfig<I>, I> GetStateFunc { get; }

        private Func<Context, string, Task<I>> CreateAsyncFunc { get; }
    }
}
