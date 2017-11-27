using System;
using System.Collections.Concurrent;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    sealed class State : IState
    {
        readonly ConcurrentDictionary<string, object> _Map
            = new ConcurrentDictionary<string, object>();

        public TModel Get<TModel>(ResourceConfig<TModel> config)
            where TModel : class
            => _Map.GetOrNull(config.DefaultIdStr()) as TModel;

        public TModel GetOrAdd<TModel>(ResourceConfig<TModel> config, Func<TModel> f)
            where TModel : class
            => _Map.GetOrAddWithCast(config.DefaultIdStr(), f);

        public bool Contains(IResourceConfig config)
            => _Map.ContainsKey(config.DefaultIdStr());
    }
}
