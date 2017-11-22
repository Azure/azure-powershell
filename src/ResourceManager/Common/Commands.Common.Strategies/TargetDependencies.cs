using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class TargetDependencies
    {
        public static IEnumerable<IResourceConfig> GetTargetDependencies(
            this IResourceConfig config, IState target)
            => config
                .Dependencies
                .Select(d => d.Resource)
                .Where(target.Contains);
    }
}
