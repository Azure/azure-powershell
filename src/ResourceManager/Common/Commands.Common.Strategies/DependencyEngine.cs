using System.Collections.Concurrent;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class DependencyEngine : IEngine
    {
        public ConcurrentDictionary<string, IEntityConfig> Dependencies { get; }
            = new ConcurrentDictionary<string, IEntityConfig>();

        public string GetId(IEntityConfig config)
        {
            var id = config.DefaultIdStr();
            Dependencies.GetOrAdd(id, config);
            return id;
        }
    }
}
