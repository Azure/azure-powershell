using Microsoft.Rest.Azure;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public sealed class States
    {
        public static async Task<States> CreateAsync(
            Context context, IResourceConfig config)
        {
            var mapContext = new MapContext(context);
            await mapContext.UpdateStateAsync(config);
            return new States(new StateMap(mapContext.ResultMap));
        }

        public T Get<T>(ResourceConfig<T> config)
            where T : class
            => config.GetStateFunc(Map, config);

        public Location GetLocation()
            => Map
                .Map
                .Select(v => v.Key.GetLocation(v.Value))
                .Aggregate((Location)null, LocationExtensions.Merge);

        private States(StateMap map)
        {
            Map = map;
        }

        private sealed class StateMap : IStateMap
        {
            public I Get<I>(ResourceConfig<I> config) 
                where I : class
                => Map.TryGetValue(config, out var result) ? result as I : null;

            public StateMap(ConcurrentDictionary<IResourceConfig, object> map)
            {
                Map = map;
            }

            public ConcurrentDictionary<IResourceConfig, object> Map { get; }
        }

        private StateMap Map { get; }

        private sealed class MapContext
        {
            public ConcurrentDictionary<IResourceConfig, object> ResultMap { get; }
                = new ConcurrentDictionary<IResourceConfig, object>();

            public MapContext(Context context)
            {
                Context = context;            
            }

            public async Task UpdateStateAsync(IResourceConfig config)
            {
                var result = await TaskMap.GetOrAdd(
                    config,
                    async c =>
                    {
                        try
                        {
                            return await c.GetAsync(Context);
                        }
                        catch (CloudException e) when (e.Response.StatusCode == HttpStatusCode.NotFound)
                        {
                            return null;
                        }
                    });
                if (result != null)
                {
                    ResultMap.GetOrAdd(config, result);
                }
                else
                {
                    var taskSet = config.Dependencies.Select(UpdateStateAsync);
                    await Task.WhenAll(taskSet);
                }
            }

            private ConcurrentDictionary<IResourceConfig, Task<object>> TaskMap { get; }
                = new ConcurrentDictionary<IResourceConfig, Task<object>>();

            private Context Context { get; }
        }
    }
}
