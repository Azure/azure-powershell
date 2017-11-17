using System;
using System.Collections.Concurrent;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    sealed class State : IState
    {
        public object GetOrNullUntyped(IResourceBaseConfig config)
            => Map.GetOrNull(config.DefaultIdStr());

        public Model GetOrNull<Model>(IResourceBaseConfig<Model> config)
            where Model : class
            => GetOrNullUntyped(config) as Model;

        public Model GetOrAdd<Model>(IResourceBaseConfig<Model> config, Func<Model> f)
            where Model : class
            => GetOrAddUntyped(config, f) as Model;

        public object GetOrAddUntyped(IResourceBaseConfig config, Func<object> f)
            => Map.GetOrAdd(config.DefaultIdStr(), _ => f());

        ConcurrentDictionary<string, object> Map { get; }
            = new ConcurrentDictionary<string, object>();
    }
}
