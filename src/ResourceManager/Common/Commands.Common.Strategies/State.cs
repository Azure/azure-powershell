using System;
using System.Collections.Concurrent;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    sealed class State : IState
    {
        public Model GetOrNull<Model>(IResourceConfig<Model> config)
            where Model : class
            => Map.GetOrNull(config.DefaultIdStr()) as Model;

        public Model GetOrAdd<Model>(IResourceConfig<Model> config, Func<Model> f)
            where Model : class
            => GetOrAddUntyped(config, f) as Model;

        public object GetOrAddUntyped(IResourceConfig config, Func<object> f)
            => Map.GetOrAdd(config.DefaultIdStr(), _ => f());

        ConcurrentDictionary<string, object> Map { get; }
            = new ConcurrentDictionary<string, object>();
    }
}
