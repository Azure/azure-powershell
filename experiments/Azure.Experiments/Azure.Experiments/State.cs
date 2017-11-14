using System;
using System.Collections.Concurrent;

namespace Microsoft.Azure.Experiments
{
    sealed class State : IState
    {
        public Config GetOrNull<Config>(IResourceConfig<Config> config)
            where Config : class
            => Map.TryGetValue(config, out var result) ? result as Config : null;

        public Config GetOrAdd<Config>(IResourceConfig<Config> config, Func<Config> f)
            where Config : class
            => GetOrAddUntyped(config, f) as Config;

        public object GetOrAddUntyped(IResourceConfig config, Func<object> f)
            => Map.GetOrAdd(config, _ => f());

        ConcurrentDictionary<IResourceConfig, object> Map { get; }
            = new ConcurrentDictionary<IResourceConfig, object>();
    }
}
