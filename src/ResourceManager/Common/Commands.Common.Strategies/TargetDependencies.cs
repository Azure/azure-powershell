using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class TargetDependencies
    {
        public static IEnumerable<IResourceConfig> GetTargetDependencies(
            this IResourceConfig config, IState target)
            => config.GetResourceDependencies().Where(target.Contains);
    }
}
