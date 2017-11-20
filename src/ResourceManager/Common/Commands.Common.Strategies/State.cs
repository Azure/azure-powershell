using System;
using System.Collections.Concurrent;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    sealed class State : IState
    {
        public Model Get<Model>(ResourceConfig<Model> config)
            where Model : class
            => Map.GetOrNull(config.DefaultIdStr()) as Model;

        public Model GetOrAdd<Model>(ResourceConfig<Model> config, Func<Model> f)
            where Model : class
            => Map.GetOrNull(config.DefaultIdStr()) as Model;

        ConcurrentDictionary<string, object> Map { get; }
            = new ConcurrentDictionary<string, object>();
    }
}
